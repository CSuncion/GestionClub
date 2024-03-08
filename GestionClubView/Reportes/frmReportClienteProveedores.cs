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
    public partial class frmReportClienteProveedores : Form
    {
        public frmEscogerTipoNombreDniListadoClientes wFrm;
        UtilConvertDataTable utilConvertDataTable = new UtilConvertDataTable();
        public string nombreReporte = "GestionClubView.Reportes.rptListaClienteProveedores.rdlc";
        public string formaReporte = "Normal";
        public frmReportClienteProveedores()
        {
            InitializeComponent();
        }

        private void frmReportClienteProveedores_Load(object sender, EventArgs e)
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
                GestionClubClienteDto gestionClubClienteDto = new GestionClubClienteDto();
                gestionClubClienteDto.tipCliente = Cmb.ObtenerValor(this.wFrm.cboTipCliente,string.Empty);
                gestionClubClienteDto.nroIdentificacionCliente = this.wFrm.txtNroIdentificacion.Text;
                gestionClubClienteDto.nombreRazSocialCliente = this.wFrm.txtNomRazSoc.Text;

                GestionClubClienteController gestionClubClienteController = new GestionClubClienteController();
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsListaClienteProveedores";
                rds.Value = gestionClubClienteController.ListarClientePorTipoPorNroIdePorNomRaz(gestionClubClienteDto);

                ReportParameter[] rp = new ReportParameter[1];
                //rp[0] = new ReportParameter("idEmpresa", Universal.gIdEmpresa.ToString());
                //rp[1] = new ReportParameter("fecComprobante", this.wFrm.fecCierreCaja.ToString());
                rp[0] = new ReportParameter("userConsulta", Universal.gNombreUsuario);


                this.rvListadoClienteProveedores.Reset();
                this.rvListadoClienteProveedores.LocalReport.ReportEmbeddedResource = nombreReporte;
                this.rvListadoClienteProveedores.LocalReport.SetParameters(rp);
                this.rvListadoClienteProveedores.LocalReport.EnableExternalImages = true;
                this.rvListadoClienteProveedores.LocalReport.DataSources.Clear();
                this.rvListadoClienteProveedores.LocalReport.DataSources.Add(rds);
                this.rvListadoClienteProveedores.SetDisplayMode(DisplayMode.PrintLayout);
                this.rvListadoClienteProveedores.ZoomMode = ZoomMode.Percent;
                this.rvListadoClienteProveedores.ZoomPercent = 100;

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
                this.rvListadoClienteProveedores.SetPageSettings(pg);

                this.rvListadoClienteProveedores.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmListaClienteProveedores, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportClienteProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Cerrar();
        }
    }
}
