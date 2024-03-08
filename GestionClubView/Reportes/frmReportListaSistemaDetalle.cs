using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.Consultas;
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
    public partial class frmReportListaSistemaDetalle : Form
    {
        public frmEscogerCategoriaListaPrecios wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoSistemaDetalle.rdlc";
        public string formaReporte = "Normal";
        public frmReportListaSistemaDetalle()
        {
            InitializeComponent();
        }

        private void frmReportListaPrecios_Load(object sender, EventArgs e)
        {

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
                rds.Name = "dsListadoSistemaDetalle";

                rds.Value = GestionClubGeneralController.ListarSistemaDetalle();

                ReportParameter[] rp = new ReportParameter[1];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                //rp[1] = new ReportParameter("fecComprobante", this.wFrm.fecCierreCaja.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);


                this.rvListaPrecios.Reset();
                this.rvListaPrecios.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvListaPrecios.LocalReport.SetParameters(rp);
                this.rvListaPrecios.LocalReport.EnableExternalImages = true;
                this.rvListaPrecios.LocalReport.DataSources.Clear();
                this.rvListaPrecios.LocalReport.DataSources.Add(rds);
                this.rvListaPrecios.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvListaPrecios.ZoomMode = ZoomMode.Percent;
                this.rvListaPrecios.ZoomPercent = 100;

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
                this.rvListaPrecios.SetPageSettings(pg);

                this.rvListaPrecios.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmReporteTablaSistema, null);
        }
        private void frmReportListaPrecios_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
