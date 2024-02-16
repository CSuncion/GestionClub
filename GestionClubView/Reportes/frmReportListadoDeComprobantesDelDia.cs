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
        public string formaReporte = "Normal";
        public frmReportListadoDeComprobantesDelDia()
        {
            InitializeComponent();
        }

        private void frmReportListadoDeComprobantesDelDia_Load(object sender, EventArgs e)
        {
        }
        public void GenerarInforme()
        {
            this.Dock = DockStyle.Fill;
            try
            {
                GestionClubComprobanteDto gestionClubComprobanteDto = new GestionClubComprobanteDto();
                gestionClubComprobanteDto.fecComprobante = this.wFrm.fecCierreCaja;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsListaComprobanteDelDia";
                rds.Value = GestionClubComprobanteController.ListarComprobantesFacturaYBoletaPorFecha(gestionClubComprobanteDto);

                ReportParameter[] rp = new ReportParameter[1];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                //rp[1] = new ReportParameter("fecComprobante", this.wFrm.fecCierreCaja.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);


                this.rpvListadoComprobanteDelDia.Reset();
                this.rpvListadoComprobanteDelDia.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rpvListadoComprobanteDelDia.LocalReport.SetParameters(rp);
                this.rpvListadoComprobanteDelDia.LocalReport.EnableExternalImages = true;
                this.rpvListadoComprobanteDelDia.LocalReport.DataSources.Clear();
                this.rpvListadoComprobanteDelDia.LocalReport.DataSources.Add(rds);
                this.rpvListadoComprobanteDelDia.SetDisplayMode(DisplayMode.PrintLayout);
                this.rpvListadoComprobanteDelDia.ZoomMode = ZoomMode.Percent;
                this.rpvListadoComprobanteDelDia.ZoomPercent = 100;

                PageSettings newPageSettings = new PageSettings();
                newPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (formaReporte == "Horizontal")
                {
                    newPageSettings.Landscape = true;
                }
                this.rpvListadoComprobanteDelDia.SetPageSettings(newPageSettings);

                this.rpvListadoComprobanteDelDia.RefreshReport();
                this.Show();
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
