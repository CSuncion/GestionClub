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
    public partial class frmEditarTablaSistema : Form
    {
        public frmTablaSistema wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public frmEditarTablaSistema()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarTablaDetalle(GestionClubGeneralController.EnBlanco());
            this.ValoresXDefecto();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();


            this.CargarEstados();

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
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNombre, true, "Nombre Mesa", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtAbrevia, true, "Abreviatura", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboEstado, true, "Estado", "vvff", 150);
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
        public void VentanaModificar(GestionClubSistemaDetalleDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTablaDetalle(pObj);
            this.ValoresXDefecto();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void MostrarTablaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            this.txtCodigo.Text = pObj.codigo;
            this.txtNombre.Text = pObj.descri;
            this.txtAbrevia.Text = pObj.desbrv;
            this.cboEstado.SelectedValue = pObj.estado;
            this.txtIdTablaDetalle.Text = pObj.idTabSistemaDetalle.ToString();

            //if (pObj.)
            //{
            //    this.txtTabla.Text = pObj.titSistema;
            //    this.txtIdTabla.Text = pObj.idTabSistema.ToString();
            //    this.txtNroSistema.Text = pObj.nroSistema;
            //}
        }
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoTablaDetalleDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarSistemaDetalle();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El detalle sistema se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvIte = this.ObtenerIdMesa();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarTablaDetalle(GestionClubGeneralController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarDetalleSistema().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarSistemaDetalle();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El detalle sistema se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvIte = this.ObtenerIdMesa();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void ModificarSistemaDetalle()
        {
            GestionClubSistemaDetalleDto iObjEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iObjEN);
            iObjEN = GestionClubGeneralController.BuscarSistemaDetalleXId(iObjEN);
            this.AsignarDetalleSistema(iObjEN);
            GestionClubGeneralController.ModificarSistemaDetalle(iObjEN);
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarSistemaDetalle().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El detalle sistema se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarMesa()
        {
            GestionClubSistemaDetalleDto iObjEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iObjEN);
            GestionClubGeneralController.EliminarSistemaDetalle(iObjEN);
        }
        public bool EsCodigoTablaDetalleDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubSistemaDetalleDto iDto = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iDto);
            iDto = GestionClubGeneralController.EsCodigoSistemaDetalleDisponible(iDto);
            if (iDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iDto.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iDto.Adicionales.EsVerdad;
        }
        public void AsignarDetalleSistema(GestionClubSistemaDetalleDto pObj)
        {
            pObj.nroSistema = this.txtNroSistema.Text;
            pObj.codigo = this.txtCodigo.Text;
            pObj.descri = this.txtNombre.Text;
            pObj.desbrv = this.txtAbrevia.Text;
            pObj.idTabSistema = Convert.ToInt32(this.txtIdTabla.Text);
            pObj.idTabSistemaDetalle = Convert.ToInt32(this.txtIdTablaDetalle.Text);
            pObj.estado = Cmb.ObtenerValor(this.cboEstado, string.Empty);
        }
        public void ValoresXDefecto()
        {
            this.txtTabla.Text = Dgv.ObtenerValorCelda(this.wFrm.DgvSistema, GestionClubSistemaDto._titSistema);
            this.txtIdTabla.Text = Dgv.ObtenerValorCelda(this.wFrm.DgvSistema, GestionClubSistemaDto._idTabSistema);
            this.txtNroSistema.Text = Dgv.ObtenerValorCelda(this.wFrm.DgvSistema, GestionClubSistemaDto._nroSistema);
        }
        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void AdicionarSistemaDetalle()
        {
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iPerEN);
            GestionClubGeneralController.AdicionarSistemaDetalle(iPerEN);
        }

        public string ObtenerIdMesa()
        {
            //asignar parametros
            GestionClubSistemaDetalleDto iObjEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iObjEN);

            //devolver
            return iObjEN.idTabSistemaDetalle.ToString();
        }
        public void VentanaEliminar(GestionClubSistemaDetalleDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTablaDetalle(pObj);
            this.ValoresXDefecto();
            eMas.AccionHabilitarControles(2);
        }
        public void VentanaVisualizar(GestionClubSistemaDetalleDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTablaDetalle(pObj);
            this.ValoresXDefecto();
            eMas.AccionHabilitarControles(3);
            this.tsBtnGrabar.Enabled = false;
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnGrabar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void frmEditarMesas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
