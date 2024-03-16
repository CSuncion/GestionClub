using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
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
using WinControles.ControlesWindows;

namespace GestionClubView.MdiPrincipal
{
    public partial class frmSeleccionarCaja : Form
    {
        public frmPrincipal wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmSeleccionarCaja()
        {
            InitializeComponent();
        }

        public void VentanaSeleccionar()
        {
            this.InicializaVentana();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
        }
        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarCaja();
            // Deshabilitar al propietario
            //this.wFrm.Enabled = false;
            this.wFrm.menuStrip1.Enabled = false;
            this.wFrm.tsbComanda.Enabled = false;
            this.wFrm.tsbComprobante.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboCaja, true, "Caja", "vvff", 150);
            xLis.Add(xCtrl);


            return xLis;
        }
        public void CargarCaja()
        {
            Cmb.Cargar(this.cboCaja, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Caja.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void SeleccionarCaja()
        {
            Universal.caja = Cmb.ObtenerValor(this.cboCaja, string.Empty);

            if (!this.ValidaAperturaCaja())
            {
                this.wFrm.InstanciarAperturaCaja();
            }

            if (!this.ValidaTipoCambio())
            {
                this.wFrm.InstanciarTipoCambio();
            }
            //this.wFrm.ConfiguracionCajas();

            this.wFrm.tssStatusBar.Text = Universal.EstadoBarra();
            this.Close();
        }
        public bool ValidaAperturaCaja()
        {
            bool result = true;
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            gestionClubAperturaCajaDto.caja = Cmb.ObtenerValor(this.cboCaja, string.Empty);
            gestionClubAperturaCajaDto = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0) { Mensaje.OperacionDenegada("Debe aperturar la caja.", this.wFrm.eTitulo); result = false; }

            return result;
        }

        public bool ValidaTipoCambio()
        {
            bool result = true;
            GestionClubTipoCambioDto gestionClubTipoCambioDto = new GestionClubTipoCambioDto();
            gestionClubTipoCambioDto.FechaTipoCambio = DateTime.Now.ToString();
            gestionClubTipoCambioDto = GestionClubTipoCambioController.ListarTipoCambioPorFecha(gestionClubTipoCambioDto);

            if (gestionClubTipoCambioDto.idTipoCambio == 0) { Mensaje.OperacionDenegada("Debe ingresar tipo de cambio.", this.wFrm.eTitulo); result = false; }

            return result;
        }

        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmAperturaCaja, null);
        }
        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionarCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
            this.wFrm.menuStrip1.Enabled = true;
            this.wFrm.tsbComanda.Enabled = true;
            this.wFrm.tsbComprobante.Enabled = true;
            this.Cerrar();
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.SeleccionarCaja();
        }
    }
}
