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

namespace GestionClubView.Reportes
{
    public partial class frmReportEstadisticaVentaAnualMensual : Form
    {
        public frmIngresarAnioVentaAnual wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptEstadisticaVentaAnualMensual.rdlc";
        public string formaReporte = "Horizontal";
        public frmReportEstadisticaVentaAnualMensual()
        {
            InitializeComponent();
        }

        private void frmReportEstadisticaVentaAnualMensual_Load(object sender, EventArgs e)
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
                rds.Name = "dsVentaAnualesMensual";
                rds.Value = GestionClubComprobanteController.VentaAnualMensual(this.wFrm.txtAnio.Text);

                ReportParameter[] rp = new ReportParameter[2];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text.ToString());


                this.rvVentaAnualMensual.Reset();
                this.rvVentaAnualMensual.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvVentaAnualMensual.LocalReport.SetParameters(rp);
                this.rvVentaAnualMensual.LocalReport.EnableExternalImages = true;
                this.rvVentaAnualMensual.LocalReport.DataSources.Clear();
                this.rvVentaAnualMensual.LocalReport.DataSources.Add(rds);
                this.rvVentaAnualMensual.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvVentaAnualMensual.ZoomMode = ZoomMode.Percent;
                this.rvVentaAnualMensual.ZoomPercent = 100;

                PageSettings newPageSettings = new PageSettings();
                newPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (formaReporte == "Horizontal")
                {
                    newPageSettings.Landscape = true;
                }
                this.rvVentaAnualMensual.SetPageSettings(newPageSettings);

                this.rvVentaAnualMensual.RefreshReport();
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

        private void frmReportEstadisticaVentaAnualMensual_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Cerrar();
        }
    }
}
