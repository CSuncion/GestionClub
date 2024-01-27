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
    public partial class frmEditarAmbientes : Form
    {
        public frmAmbientes wAmb;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubAmbienteController oOpe = new GestionClubAmbienteController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public frmEditarAmbientes()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarAmbiente(GestionClubAmbienteController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wAmb.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarEstados();

            // Deshabilitar al propietario
            this.wAmb.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtAmbiente, true, "Nombre Ambiente", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboEstado, true, "Estado Ambiente", "vvff", 150);
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

            //el codigo de usuario ya existe?
            if (this.EsCodigoAmbienteDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAmb.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAmbiente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Ambiente se adiciono correctamente", this.wAmb.eTitulo);

            //actualizar al propietario
            this.wAmb.eClaveDgvAmbiente = this.ObtenerIdAmbiente();
            this.wAmb.ActualizarVentana();

            //limpiar controles
            this.MostrarAmbiente(GestionClubAmbienteController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAmb.EsActoModificarAmbiente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAmb.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAmbiente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Ambiente se modifico correctamente", this.wAmb.eTitulo);

            //actualizar al wUsu
            this.wAmb.eClaveDgvAmbiente = this.ObtenerIdAmbiente();
            this.wAmb.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAmb.EsActoEliminarAmbiente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAmb.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAmbiente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Ambiente se elimino correctamente", this.wAmb.eTitulo);

            //actualizar al propietario           
            this.wAmb.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarAmbiente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            GestionClubAmbienteController.EliminarAmbiente(iPerEN);
        }
        public string ObtenerIdAmbiente()
        {
            //asignar parametros
            GestionClubAmbientesDto iAmbEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iAmbEN);

            //devolver
            return iAmbEN.idAmbiente.ToString();
        }
        public void AdicionarAmbiente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            GestionClubAmbienteController.AdicionarAmbiente(iPerEN);
        }
        public bool EsCodigoAmbienteDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubAmbientesDto iAmbiente = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iAmbiente);
            iAmbiente = GestionClubAmbienteController.EsCodigoAmbienteDisponible(iAmbiente);
            if (iAmbiente.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAmbiente.Adicionales.Mensaje, this.wAmb.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iAmbiente.Adicionales.EsVerdad;
        }

        public void MostrarAmbiente(GestionClubAmbientesDto pObj)
        {
            this.txtCodigo.Text = pObj.codAmbiente;
            this.txtAmbiente.Text = pObj.desAmbiente;
            this.cboEstado.SelectedValue = pObj.estadoAmbiente;
            this.txtIdAmbiente.Text = pObj.idAmbiente.ToString();
        }

        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AsignarAmbiente(GestionClubAmbientesDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.codAmbiente = this.txtCodigo.Text.Trim();
            pObj.desAmbiente = this.txtAmbiente.Text.Trim();
            pObj.estadoAmbiente = Cmb.ObtenerValor(this.cboEstado, string.Empty);
            pObj.idAmbiente = Convert.ToInt32(this.txtIdAmbiente.Text);
        }
        public void VentanaModificar(GestionClubAmbientesDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAmbiente(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }


        public void ModificarAmbiente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            iPerEN = GestionClubAmbienteController.BuscarAmbienteXId(iPerEN);
            this.AsignarAmbiente(iPerEN);
            GestionClubAmbienteController.ModificarAmbiente(iPerEN);
        }
        public void VentanaEliminar(GestionClubAmbientesDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAmbiente(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubAmbientesDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAmbiente(pObj);
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

        private void frmEditarAmbientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAmb.Enabled = true;
        }
    }
}
