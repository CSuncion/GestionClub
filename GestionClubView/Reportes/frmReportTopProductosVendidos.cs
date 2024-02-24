using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.Consultas;
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
    public partial class frmReportTopProductosVendidos : Form
    {
        public frmIngresarAnioTopVentaProductos wFrm;
        //CreditsReportController objReportController = new CreditsReportController();
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoTopProductosVentasAnual.rdlc";
        public string formaReporte = "Normal";
        public frmReportTopProductosVendidos()
        {
            InitializeComponent();
        }

        private void frmReportListadoDeComprobantesDelDia_Load(object sender, EventArgs e)
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
                rds.Name = "dsTopVentasProductosAnual";
                rds.Value = GestionClubComprobanteController.TopVentaProductos(this.wFrm.txtAnio.Text);

                ReportParameter[] rp = new ReportParameter[2];

                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text.ToString());


                this.rpvResumenAnualProducto.Reset();
                this.rpvResumenAnualProducto.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rpvResumenAnualProducto.LocalReport.SetParameters(rp);
                this.rpvResumenAnualProducto.LocalReport.EnableExternalImages = true;
                this.rpvResumenAnualProducto.LocalReport.DataSources.Clear();
                this.rpvResumenAnualProducto.LocalReport.DataSources.Add(rds);
                this.rpvResumenAnualProducto.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvResumenAnualProducto.ZoomMode = ZoomMode.Percent;
                this.rpvResumenAnualProducto.ZoomPercent = 100;

                PageSettings newPageSettings = new PageSettings();
                newPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (formaReporte == "Horizontal")
                {
                    newPageSettings.Landscape = true;
                }
                this.rpvResumenAnualProducto.SetPageSettings(newPageSettings);

                this.rpvResumenAnualProducto.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportListadoDeComprobantesDelDia_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
