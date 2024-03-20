using Comun;
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

namespace GestionClubView.Reportes
{
    public partial class frmReportListadoDeComprobantesDelDia : Form
    {
        public frmListadoDeComprobante wFrm;
        //CreditsReportController objReportController = new CreditsReportController();
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoDeComprobantesDelDia.rdlc";
        public string nombreReporteResumen = "GestionClubView.Reportes.rptResumenCierreCaja.rdlc";
        public string formaReporte = "Normal";
        public frmReportListadoDeComprobantesDelDia()
        {
            InitializeComponent();
        }

        private void frmReportListadoDeComprobantesDelDia_Load(object sender, EventArgs e)
        {
        }
        public void GenerarInforme(int reporte)
        {
            this.Show();
            this.Dock = DockStyle.Fill;
            try
            {
                GestionClubComprobanteDto gestionClubComprobanteDto = new GestionClubComprobanteDto();
                gestionClubComprobanteDto.fecComprobante = this.wFrm.fecCierreCaja;
                ReportDataSource rds = new ReportDataSource();

                if (reporte == 1)
                    rds.Name = "dsListaComprobanteDelDia";
                else
                    rds.Name = "dsResumenCierreCaja";


                rds.Value = GestionClubComprobanteController.ListarComprobantesFacturaYBoletaPorFecha(gestionClubComprobanteDto).Where(x => x.caja == Universal.caja);

                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("nroCaja", Universal.caja.ToString());
                rp[2] = new ReportParameter("fecCierre", Fecha.ObtenerDiaMesAno(this.wFrm.fecCierreCaja.ToString()));

                this.rpvListadoComprobanteDelDia.Reset();
                if (reporte == 1)
                    this.rpvListadoComprobanteDelDia.LocalReport.ReportEmbeddedResource = nombreReporte;
                else
                    this.rpvListadoComprobanteDelDia.LocalReport.ReportEmbeddedResource = nombreReporteResumen;

                this.rpvListadoComprobanteDelDia.LocalReport.SetParameters(rp);
                this.rpvListadoComprobanteDelDia.LocalReport.EnableExternalImages = true;
                this.rpvListadoComprobanteDelDia.LocalReport.DataSources.Clear();
                this.rpvListadoComprobanteDelDia.LocalReport.DataSources.Add(rds);
                this.rpvListadoComprobanteDelDia.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvListadoComprobanteDelDia.ZoomMode = ZoomMode.Percent;
                this.rpvListadoComprobanteDelDia.ZoomPercent = 100;

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
                this.rpvListadoComprobanteDelDia.SetPageSettings(pg);

                this.rpvListadoComprobanteDelDia.RefreshReport();
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
