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
    public partial class frmEscogerTipoNombreDniListadoClientes : Form
    {
        public frmEscogerTipoNombreDniListadoClientes()
        {
            InitializeComponent();
        }
        public void VentanaSeleccionar()
        {
            this.Show();
            this.CargarTipoCliente();
        }
        public void CargarTipoCliente()
        {
            Cmb.Cargar(this.cboTipCliente, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.TipoCliente.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void SeleccionarFecha()
        {
            frmReportClienteProveedores win = new frmReportClienteProveedores();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmListaPrecios, null);
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

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.BloquearCategoria();
        }
    }
}
