using Comun;
using GestionClubModel.ModelDto;
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

namespace GestionClubView.Comanda
{
    public partial class frmCobrar : Form
    {
        public frmComanda wCom;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmCobrar()
        {
            InitializeComponent();
        }
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtDocId.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCom.eTitulo;

            //eventos de controles
            //eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            //this.ActualizarVentana();
            // Deshabilitar al propietario
            this.wCom.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCom.Enabled = !this.wCom.Enabled;
            this.wCom.btnCobrar.Enabled = !this.wCom.btnCobrar.Enabled;
        }

        private void chEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtEfectivo.Enabled = !this.txtEfectivo.Enabled;
        }

        private void chYape_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYape.Enabled = !this.txtYape.Enabled;
        }

        private void chTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTarjeta.Enabled = !this.txtTarjeta.Enabled;
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
        }
    }
}
