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
    public partial class frmIngresarAnioMesAlmacen : Form
    {
        public frmIngresarAnioMesAlmacen()
        {
            InitializeComponent();
        }
        public void VentanaSeleccionar()
        {
            this.Show();
            this.FechaActual();
        }
        public void FechaActual()
        {
            this.txtAnio.Text = DateTime.Now.Year.ToString();
        }
        public void SeleccionarFecha()
        {

            if (this.txtAnio.Text.Length != 4)
            {
                Mensaje.OperacionDenegada("Ingresar año correcto", this.Text);
                return;
            }

            frmReportResumenAnualAlmacen win = new frmReportResumenAnualAlmacen();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmResumenAlmacen, null);
        }
        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.SeleccionarFecha();
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
