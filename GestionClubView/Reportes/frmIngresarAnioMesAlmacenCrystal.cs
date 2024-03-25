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
    public partial class frmIngresarAnioMesAlmacenCrystal : Form
    {
        public frmIngresarAnioMesAlmacenCrystal()
        {
            InitializeComponent();
        }
        public void VentanaSeleccionar()
        {
            this.Show();
            this.CargarMes();
            this.FechaActual();
        }
        public void CargarMes()
        {
            Cmb.Cargar(this.cboMes, GestionClubGeneralController.ListarSistemaDetallePorTablaPorObs(GestionClubEnum.Sistema.Mes.ToString(), string.Empty).OrderBy(x => x.idTabSistemaDetalle).ToList(), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
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

            frmReportMiscelaneo win = new frmReportMiscelaneo();
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
