using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.Consultas;
using GestionClubView.Listas;
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
    public partial class frmEditarCierreCaja : Form
    {
        public frmCierreCaja wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmEditarCierreCaja()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarCierreCaja(GestionClubCierreCajaController.EnBlanco());
            this.MuestraMonto();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecCierreCaja.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //this.ActualizarVentana();
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
            xCtrl.TxtTodo(this.dtpFecCierreCaja, true, "Fecha Cierre", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtMonto, true, "Monto", "ffff", 2);
            xLis.Add(xCtrl);


            return xLis;
        }
        public void MuestraMonto()
        {
            this.txtMonto.Text = this.SumarMontoListadoComprobantePorCaja().ToString();
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


            //if (this.ValidarMontoMayorCero()) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoCierreCajaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarCierreCaja();
            this.ListarComprobante();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cierre Caja se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvCierreCaja = this.ObtenerIdCierreCaja();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarCierreCaja(GestionClubCierreCajaController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecCierreCaja.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            if (this.ValidarMontoMayorCero()) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarCierreCaja().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCierreCaja();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cierre Caja se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvCierreCaja = this.ObtenerIdCierreCaja();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarCierreCaja().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCierreCaja();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cierre Caja se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarCierreCaja()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            GestionClubCierreCajaController.EliminarCierreCaja(iPerEN);
        }
        public string ObtenerIdCierreCaja()
        {
            //asignar parametros
            GestionClubCierreCajaDto iAmbEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iAmbEN);

            //devolver
            return iAmbEN.idCierreCaja.ToString();
        }
        public void AdicionarCierreCaja()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            GestionClubCierreCajaController.AdicionarCierreCaja(iPerEN);
        }
        public bool EsCodigoCierreCajaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubCierreCajaDto iCierreCaja = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iCierreCaja);
            iCierreCaja = GestionClubCierreCajaController.EsFechaCierreCajaDisponible(iCierreCaja);
            if (iCierreCaja.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCierreCaja.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.dtpFecCierreCaja.Focus();
            }
            return iCierreCaja.Adicionales.EsVerdad;
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
        public decimal SumarMontoListadoComprobantePorCaja()
        {
            decimal result = 0;
            List<GestionClubComprobanteDto> listComprobantes = new List<GestionClubComprobanteDto>();
            listComprobantes = GestionClubComprobanteController.ListarComprobantes()
                .Where(x => Fecha.ObtenerDiaMesAno(x.fecComprobante) == Fecha.ObtenerDiaMesAno(this.dtpFecCierreCaja.Value)
                       && x.caja == Universal.caja
                       && (x.tipComprobante == "01" || x.tipComprobante == "02" || x.tipComprobante == "04"))
                .ToList();
            if (listComprobantes.Count > 0)
            {
                result = listComprobantes.Sum(x => x.impNetComprobante);
            }
            else result = 0;

            return result;
        }
        public void MostrarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            this.dtpFecCierreCaja.Text = pObj.fecCierreCaja.ToString();
            this.txtMonto.Text = pObj.montoCierreCaja.ToString();
            this.txtId.Text = pObj.idCierreCaja.ToString();
        }

        public void AsignarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.caja = Universal.caja;
            pObj.fecCierreCaja = Convert.ToDateTime(this.dtpFecCierreCaja.Text);
            pObj.montoCierreCaja = this.SumarMontoListadoComprobantePorCaja();
            pObj.estadoCierreCaja = "05";
            pObj.idCierreCaja = Convert.ToInt32(this.txtId.Text);
            //Universal.caja = Cmb.ObtenerValor(this.cboCaja, string.Empty);  
        }
        public void VentanaModificar(GestionClubCierreCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCierreCaja(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecCierreCaja.Focus();
        }


        public void ModificarCierreCaja()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            iPerEN = GestionClubCierreCajaController.ListarCierreCajasPorFechaPorCaja(iPerEN);
            this.AsignarCierreCaja(iPerEN);
            GestionClubCierreCajaController.ModificarCierreCaja(iPerEN);
        }
        public void VentanaEliminar(GestionClubCierreCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCierreCaja(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubCierreCajaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCierreCaja(pObj);
            eMas.AccionHabilitarControles(3);
            this.tsBtnGrabar.Enabled = false;
        }

        public void ListarComprobante()
        {
            //si es de lectura , entonces no lista
            //if (this.txtDocId.ReadOnly == true) { return; }

            //instanciar
            frmListadoDeComprobante win = new frmListadoDeComprobante();
            win.eVentana = this;
            win.eTituloVentana = "Listado Comprobante";
            win.fecCierreCaja = this.dtpFecCierreCaja.Value;
            win.eCondicionLista = frmListadoDeComprobante.Condicion.Comprobantes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnGrabar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void frmEditarCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
