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
    public partial class frmEditarAperturaCaja : Form
    {
        public frmAperturaCaja wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmEditarAperturaCaja()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarAperturaCaja(GestionClubAperturaCajaController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecAperturaCaja.Focus();
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
            xCtrl.TxtTodo(this.dtpFecAperturaCaja, true, "Fecha Apertura", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtMonto, true, "Monto", "vvff", 2);
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
            if (this.EsCodigoAperturaCajaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAperturaCaja();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El AperturaCaja se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvAperturaCaja = this.ObtenerIdAperturaCaja();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarAperturaCaja(GestionClubAperturaCajaController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecAperturaCaja.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
            
            if (this.ValidarMontoMayorCero()) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarAperturaCaja().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAperturaCaja();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El AperturaCaja se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvAperturaCaja = this.ObtenerIdAperturaCaja();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarAperturaCaja().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAperturaCaja();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El AperturaCaja se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarAperturaCaja()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            GestionClubAperturaCajaController.EliminarAperturaCaja(iPerEN);
        }
        public string ObtenerIdAperturaCaja()
        {
            //asignar parametros
            GestionClubAperturaCajaDto iAmbEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iAmbEN);

            //devolver
            return iAmbEN.idAperturaCaja.ToString();
        }
        public void AdicionarAperturaCaja()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            GestionClubAperturaCajaController.AdicionarAperturaCaja(iPerEN);
        }
        public bool EsCodigoAperturaCajaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubAperturaCajaDto iAperturaCaja = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iAperturaCaja);
            iAperturaCaja = GestionClubAperturaCajaController.EsFechaAperturaCajaDisponible(iAperturaCaja);
            if (iAperturaCaja.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAperturaCaja.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.dtpFecAperturaCaja.Focus();
            }
            return iAperturaCaja.Adicionales.EsVerdad;
        }

        public void MostrarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            this.dtpFecAperturaCaja.Text = pObj.fecAperturaCaja.ToString();
            this.txtMonto.Text = pObj.montoAperturaCaja.ToString();
            this.txtId.Text = pObj.idAperturaCaja.ToString();
        }

        public void AsignarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.caja = Universal.caja;
            pObj.fecAperturaCaja = Convert.ToDateTime(this.dtpFecAperturaCaja.Text);
            pObj.montoAperturaCaja = Convert.ToDecimal(this.txtMonto.Text);
            pObj.estadoAperturaCaja = "01";
            pObj.idAperturaCaja = Convert.ToInt32(this.txtId.Text);
            //Universal.caja = Cmb.ObtenerValor(this.cboCaja, string.Empty);  
        }
        public void VentanaModificar(GestionClubAperturaCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAperturaCaja(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecAperturaCaja.Focus();
        }


        public void ModificarAperturaCaja()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            iPerEN = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(iPerEN);
            this.AsignarAperturaCaja(iPerEN);
            GestionClubAperturaCajaController.ModificarAperturaCaja(iPerEN);
        }
        public void VentanaEliminar(GestionClubAperturaCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAperturaCaja(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubAperturaCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAperturaCaja(pObj);
            eMas.AccionHabilitarControles(3);
            this.tsBtnGrabar.Enabled = false;
        }
        public bool ValidarMontoMayorCero()
        {
            bool result = false;
            if (Convert.ToDecimal(this.txtMonto.Text) <= 0)
            {
                Mensaje.OperacionDenegada("Ingrese un monto correcto.", this.wFrm.eTitulo);
                result = true;
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

        private void frmEditarAperturaCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
