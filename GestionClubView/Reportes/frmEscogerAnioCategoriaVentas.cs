using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;
using WinControles;
using Comun;
using GestionClubView.MdiPrincipal;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;

namespace GestionClubView.Reportes
{
    public partial class frmEscogerAnioCategoriaVentas : Form
    {
        public frmEscogerAnioCategoriaVentas()
        {
            InitializeComponent();
        }
        public void VentanaSeleccionar()
        {
            this.Show();
            this.FechaActual();
            this.CargarCategorias();
        }
        public void CargarCategorias()
        {
            Cmb.Cargar(this.cboCategoria, GestionClubCategoriaController.ListarCategoriasActivos(), GestionClubCategoriaDto._codCategoria, GestionClubCategoriaDto._desCategoria);
        }
        public void MostrarReporte()
        {
            frmReportResumenVentasAnual win = new frmReportResumenVentasAnual();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar();
        }
        public void FechaActual()
        {
            this.txtAnio.Text = DateTime.Now.Year.ToString();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmResumenDeVentasAnual, null);
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.MostrarReporte();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEscogerListaVentasPorFechas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

    }
}
