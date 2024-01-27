using Comun;
using GestionClubModel.ModelDto;
using GestionClubView.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;

namespace GestionClubView.Maestros
{
    public partial class frmEditarClientes : Form
    {
        public frmMesas wMes;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmEditarClientes()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.cboAmbiente.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wMes.eTitulo;

            //eventos de controles
            //eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            //this.ActualizarVentana();
            // Deshabilitar al propietario
            this.wMes.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
