using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.MdiPrincipal;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Reportes
{
    public partial class frmReportEstadisticaVentaAnualMensualPorTipo : Form
    {
        public frmIngresarAnioTipoVentaAnual wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptEstadisticaVentaAnualMensualPorTipo.rdlc";
        public string formaReporte = "Horizontal";
        public frmReportEstadisticaVentaAnualMensualPorTipo()
        {
            InitializeComponent();
        }
        public void VentanaVisualizar()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.GenerarInforme();
        }
        public void GenerarInforme()
        {
            this.Dock = DockStyle.Fill;
            try
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsVentaAnualesMensualPorTipo";
                rds.Value = GestionClubComprobanteController.VentaAnualMensualPorTipo(this.wFrm.txtAnio.Text, Cmb.ObtenerValor(this.wFrm.cboTipDoc, string.Empty));

                ReportParameter[] rp = new ReportParameter[3];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text.ToString());
                rp[2] = new ReportParameter("tipo", Cmb.ObtenerTexto(this.wFrm.cboTipDoc));


                this.rvVentaAnualMensualPorTipo.Reset();
                this.rvVentaAnualMensualPorTipo.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvVentaAnualMensualPorTipo.LocalReport.SetParameters(rp);
                this.rvVentaAnualMensualPorTipo.LocalReport.EnableExternalImages = true;
                this.rvVentaAnualMensualPorTipo.LocalReport.DataSources.Clear();
                this.rvVentaAnualMensualPorTipo.LocalReport.DataSources.Add(rds);
                this.rvVentaAnualMensualPorTipo.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvVentaAnualMensualPorTipo.ZoomMode = ZoomMode.Percent;
                this.rvVentaAnualMensualPorTipo.ZoomPercent = 100;

                PageSettings pg = new PageSettings
                {
                    Landscape = false
                };
                pg.Margins = new Margins(0, 0, 0, 0);
                PaperSize size = new PaperSize("A4", 827, 1169);
                pg.PaperSize = size;

                if (formaReporte == "Horizontal")
                {
                    pg.Landscape = true;
                }
                this.rvVentaAnualMensualPorTipo.SetPageSettings(pg);

                this.rvVentaAnualMensualPorTipo.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmVentaAnualesMes, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportEstadisticaVentaAnualMensualPorTipo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmReportEstadisticaVentaAnualMensualPorTipo_Load(object sender, EventArgs e)
        {

        }
    }
}
