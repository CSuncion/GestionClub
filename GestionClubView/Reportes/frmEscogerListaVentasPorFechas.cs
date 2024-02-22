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

namespace GestionClubView.Reportes
{
    public partial class frmEscogerListaVentasPorFechas : Form
    {
        public frmEscogerListaVentasPorFechas()
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
            this.dtpFecDesde.Value = DateTime.Now;
            this.dtpFecHasta.Value = DateTime.Now;
        }
        public void SeleccionarFecha()
        {

            if (Conversion.ADateTime(this.dtpFecDesde.Text) > Conversion.ADateTime(this.dtpFecHasta.Text))
            {
                Mensaje.OperacionDenegada("La fecha desde no puede ser mayor a la fecha hasta", this.Text);
                return;
            }

            frmReportListaVentasPorFecha win = new frmReportListaVentasPorFecha();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmListaVentaFechas, null);
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
