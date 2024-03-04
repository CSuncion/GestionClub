using Comun;
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
    public partial class frmReportListaVentasPorFecha : Form
    {
        public frmEscogerListaVentasPorFechas wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoComprobantesPorFecha.rdlc";
        public string formaReporte = "Normal";
        public frmReportListaVentasPorFecha()
        {
            InitializeComponent();
        }

        private void frmReportListaVentasPorFecha_Load(object sender, EventArgs e)
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
            try
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsRegistroVentasPorFecha";
                rds.Value = GestionClubComprobanteController.ListarComprobantesFacturaYBoletaPorFechaDesdeHasta(this.wFrm.dtpFecDesde.Value, this.wFrm.dtpFecHasta.Value);

                ReportParameter[] rp = new ReportParameter[3];
                rp[0] = new ReportParameter("fecDesde", Fecha.ObtenerDiaMesAno(this.wFrm.dtpFecDesde.Value));
                rp[1] = new ReportParameter("fecHasta", Fecha.ObtenerDiaMesAno(this.wFrm.dtpFecHasta.Value));
                rp[2] = new ReportParameter("userConsulta", Universal.gNombreUsuario);


                this.rvListaVentasPorFecha.Reset();
                this.rvListaVentasPorFecha.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvListaVentasPorFecha.LocalReport.SetParameters(rp);
                this.rvListaVentasPorFecha.LocalReport.EnableExternalImages = true;
                this.rvListaVentasPorFecha.LocalReport.DataSources.Clear();
                this.rvListaVentasPorFecha.LocalReport.DataSources.Add(rds);
                this.rvListaVentasPorFecha.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvListaVentasPorFecha.ZoomMode = ZoomMode.Percent;
                this.rvListaVentasPorFecha.ZoomPercent = 100;

                PageSettings newPageSettings = new PageSettings();
                newPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (formaReporte == "Horizontal")
                {
                    newPageSettings.Landscape = true;
                }
                this.rvListaVentasPorFecha.SetPageSettings(newPageSettings);

                this.rvListaVentasPorFecha.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void frmReportListaVentasPorFecha_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
