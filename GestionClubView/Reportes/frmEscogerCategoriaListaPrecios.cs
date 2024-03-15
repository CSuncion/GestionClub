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

namespace GestionClubView.Reportes
{
    public partial class frmEscogerCategoriaListaPrecios : Form
    {
        public frmEscogerCategoriaListaPrecios()
        {
            InitializeComponent();
        }
        public void VentanaSeleccionar()
        {
            this.Show();
            this.CargarCategorias();
        }
        public void CargarCategorias()
        {
            Cmb.Cargar(this.cboCategoria, GestionClubCategoriaController.ListarCategoriasActivos(), GestionClubCategoriaDto._codCategoria, GestionClubCategoriaDto._desCategoria);
        }
        public void SeleccionarOpciones()
        {
            frmReportListaPrecios win = new frmReportListaPrecios();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmListaPrecios, null);
        }
        public void BloquearCategoria()
        {
            if (this.chkTodos.Checked)
                this.cboCategoria.Enabled = false;
            else
                this.cboCategoria.Enabled = true;
        }
        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.SeleccionarOpciones();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEscogerListaVentasPorFechas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.BloquearCategoria();
        }
    }
}
