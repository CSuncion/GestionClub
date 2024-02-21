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
    public partial class frmReportRegistroVentas : Form
    {
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListadoComprobantes.rdlc";
        public string formaReporte = "Normal";
        public frmReportRegistroVentas()
        {
            InitializeComponent();
        }

        private void frmReportRegistroVentas_Load(object sender, EventArgs e)
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
                rds.Name = "dsRegistroVentas";
                rds.Value = GestionClubComprobanteController.ListarComprobantes();

                ReportParameter[] rp = new ReportParameter[1];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                //rp[1] = new ReportParameter("fecComprobante", this.wFrm.fecCierreCaja.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);


                this.rvRegistroVentas.Reset();
                this.rvRegistroVentas.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvRegistroVentas.LocalReport.SetParameters(rp);
                this.rvRegistroVentas.LocalReport.EnableExternalImages = true;
                this.rvRegistroVentas.LocalReport.DataSources.Clear();
                this.rvRegistroVentas.LocalReport.DataSources.Add(rds);
                this.rvRegistroVentas.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvRegistroVentas.ZoomMode = ZoomMode.Percent;
                this.rvRegistroVentas.ZoomPercent = 100;

                PageSettings newPageSettings = new PageSettings();
                newPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (formaReporte == "Horizontal")
                {
                    newPageSettings.Landscape = true;
                }
                this.rvRegistroVentas.SetPageSettings(newPageSettings);

                this.rvRegistroVentas.RefreshReport();
                this.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmRegistroVentas, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportRegistroVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
