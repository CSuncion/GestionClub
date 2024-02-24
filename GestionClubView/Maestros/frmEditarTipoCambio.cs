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

namespace GestionClubView.Maestros
{
    public partial class frmEditarTipoCambio : Form
    {
        public frmTipoCambio wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmEditarTipoCambio()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(GestionClubTipoCambioController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipoCambio.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            // Deshabilitar al propietario
            this.wFrm.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.dtpFecTipoCambio, true, "Fecha Apertura", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCompra, true, "Monto Compra", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtVenta, true, "Monto Venta", "vvff", 2);
            xLis.Add(xCtrl);


            return xLis;
        }
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            if (this.ValidarMontoMayorCero()) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoTipoCambioDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Cambio se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvTipoCambio = this.ObtenerIdTipoCambio();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoCambio(GestionClubTipoCambioController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipoCambio.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            if (this.ValidarMontoMayorCero()) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarTipoCambio().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Cambio se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvTipoCambio = this.ObtenerIdTipoCambio();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarTipoCambio().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Cambio se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarTipoCambio()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            GestionClubTipoCambioController.EliminarTipoCambio(iPerEN);
        }
        public string ObtenerIdTipoCambio()
        {
            //asignar parametros
            GestionClubTipoCambioDto iAmbEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iAmbEN);

            //devolver
            return iAmbEN.idTipoCambio.ToString();
        }
        public void AdicionarTipoCambio()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            GestionClubTipoCambioController.AdicionarTipoCambio(iPerEN);
        }
        public bool EsCodigoTipoCambioDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubTipoCambioDto iTipoCambio = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iTipoCambio);
            iTipoCambio = GestionClubTipoCambioController.EsFechaTipoCambioDisponible(iTipoCambio);
            if (iTipoCambio.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipoCambio.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.dtpFecTipoCambio.Focus();
            }
            return iTipoCambio.Adicionales.EsVerdad;
        }

        public void MostrarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            this.dtpFecTipoCambio.Text = pObj.FechaTipoCambio.ToString();
            this.txtCompra.Text = pObj.CompraTipoCambio.ToString();
            this.txtVenta.Text = pObj.VentaTipoCambio.ToString();
            this.txtId.Text = pObj.idTipoCambio.ToString();
        }

        public void AsignarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            pObj.FechaTipoCambio = this.dtpFecTipoCambio.Text;
            pObj.CompraTipoCambio = Convert.ToDecimal(this.txtCompra.Text);
            pObj.VentaTipoCambio = Convert.ToDecimal(this.txtVenta.Text);
            pObj.CEstadoTipoCambio = "01";
            pObj.idTipoCambio = Convert.ToInt32(this.txtId.Text);
            //Universal.caja = Cmb.ObtenerValor(this.cboCaja, string.Empty);  
        }
        public void VentanaModificar(GestionClubTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipoCambio.Focus();
        }


        public void ModificarTipoCambio()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = GestionClubTipoCambioController.ListarTipoCambioPorFecha(iPerEN);
            this.AsignarTipoCambio(iPerEN);
            GestionClubTipoCambioController.ModificarTipoCambio(iPerEN);
        }
        public void VentanaEliminar(GestionClubTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(3);
            this.tsBtnGrabar.Enabled = false;
        }
        public bool ValidarMontoMayorCero()
        {
            bool result = false;
            if (Convert.ToDecimal(this.txtCompra.Text) <= 0)
            {
                Mensaje.OperacionDenegada("Ingrese un monto compra correcto.", this.wFrm.eTitulo);
                return true;
            }
            if (Convert.ToDecimal(this.txtVenta.Text) <= 0)
            {
                Mensaje.OperacionDenegada("Ingrese un monto venta correcto.", this.wFrm.eTitulo);
                return true;
            }
            return result;
        }
        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnGrabar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void frmEditarTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
