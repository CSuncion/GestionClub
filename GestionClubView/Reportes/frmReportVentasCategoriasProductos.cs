using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
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
    public partial class frmReportVentasCategoriasProductos : Form
    {
        public frmEscogerAnioCategoriaProductoVentas wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptEstadisticaVentasPorCategoriasProductos.rdlc";
        public string formaReporte = "Normal";
        public frmReportVentasCategoriasProductos()
        {
            InitializeComponent();
        }

        private void frmReportVentasCategoriasProductos_Load(object sender, EventArgs e)
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
                rds.Name = "dsVentasCategoriasProductos";
                rds.Value = GestionClubComprobanteController.ListarVentasPorCategoriaProductos(this.wFrm.txtAnio.Text, string.Empty, string.Empty);

                ReportParameter[] rp = new ReportParameter[2];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);
                rp[1] = new ReportParameter("anio", this.wFrm.txtAnio.Text.ToString());



                this.rvVentasCategoriaProductos.Reset();
                this.rvVentasCategoriaProductos.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvVentasCategoriaProductos.LocalReport.SetParameters(rp);
                this.rvVentasCategoriaProductos.LocalReport.EnableExternalImages = true;
                this.rvVentasCategoriaProductos.LocalReport.DataSources.Clear();
                this.rvVentasCategoriaProductos.LocalReport.DataSources.Add(rds);
                this.rvVentasCategoriaProductos.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvVentasCategoriaProductos.ZoomMode = ZoomMode.Percent;
                this.rvVentasCategoriaProductos.ZoomPercent = 100;

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
                this.rvVentasCategoriaProductos.SetPageSettings(pg);

                this.rvVentasCategoriaProductos.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
