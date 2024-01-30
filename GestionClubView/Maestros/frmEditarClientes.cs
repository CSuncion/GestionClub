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
    public partial class frmEditarClientes : Form
    {
        public frmClientes wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public frmEditarClientes()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarCliente(GestionClubClienteController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.cboTipSocio.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarEstados();
            this.CargarTipoCliente();
            this.CargarTipoSocio();

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
            xCtrl.TxtTodo(this.cboTipSocio, true, "Tipo Socio", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboTipCliente, true, "Tipo Cliente", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroIdentificacion, true, "Cod. Identificación", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomRazSoc, true, "Nombre/Raz. Social", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRazCom, true, "Raz. Comercial", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtEmail, true, "Email", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroCelular, true, "N° Celular", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRepresentante, true, "Representante", "vvff", 150);
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
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoClienteDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarCliente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cliente se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvCliente = this.ObtenerIdCliente();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarCliente(GestionClubClienteController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtNroIdentificacion.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarCliente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCliente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cliente se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvCliente = this.ObtenerIdCliente();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarCliente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCliente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cliente se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarCliente()
        {
            GestionClubClienteDto iPerEN = new GestionClubClienteDto();
            this.AsignarCliente(iPerEN);
            GestionClubClienteController.EliminarCliente(iPerEN);
        }
        public string ObtenerIdCliente()
        {
            //asignar parametros
            GestionClubClienteDto iAmbEN = new GestionClubClienteDto();
            this.AsignarCliente(iAmbEN);

            //devolver
            return iAmbEN.idCliente.ToString();
        }
        public void AdicionarCliente()
        {
            GestionClubClienteDto iPerEN = new GestionClubClienteDto();
            this.AsignarCliente(iPerEN);
            GestionClubClienteController.AdicionarCliente(iPerEN);
        }
        public bool EsCodigoClienteDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubClienteDto iCliente = new GestionClubClienteDto();
            this.AsignarCliente(iCliente);
            iCliente = GestionClubClienteController.EsCodigoClienteDisponible(iCliente);
            if (iCliente.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCliente.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtNroIdentificacion.Clear();
                this.txtNroIdentificacion.Focus();
            }
            return iCliente.Adicionales.EsVerdad;
        }

        public void MostrarCliente(GestionClubClienteDto pObj)
        {
            this.txtId.Text = pObj.idCliente.ToString();
            this.cboTipSocio.SelectedValue = pObj.tipSocioCliente;
            this.cboTipCliente.SelectedValue = pObj.tipCliente;
            this.txtCodigo.Text = pObj.codCliente;
            this.txtNroIdentificacion.Text = pObj.nroIdentificacionCliente;
            this.txtNomRazSoc.Text = pObj.nombreRazSocialCliente;
            this.txtRazCom.Text = pObj.razComercialCliente;
            this.txtEmail.Text = pObj.emailCliente;
            this.txtNroCelular.Text = pObj.nroCelularCliente;
            this.txtRepresentante.Text = pObj.representanteCliente;
            this.cboEstado.SelectedValue = pObj.estadoCliente;
            this.txtId.Text = pObj.idCliente.ToString();
        }
        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarTipoSocio()
        {
            Cmb.Cargar(this.cboTipSocio, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.TipoSocio.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarTipoCliente()
        {
            Cmb.Cargar(this.cboTipCliente, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.TipoCliente.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AsignarCliente(GestionClubClienteDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.tipSocioCliente = Cmb.ObtenerValor(this.cboTipSocio, string.Empty);
            pObj.tipCliente = Cmb.ObtenerValor(this.cboTipCliente, string.Empty);
            pObj.codCliente = this.txtCodigo.Text;
            pObj.nroIdentificacionCliente = this.txtNroIdentificacion.Text;
            pObj.nombreRazSocialCliente = this.txtNomRazSoc.Text;
            pObj.razComercialCliente = this.txtRazCom.Text;
            pObj.emailCliente = this.txtEmail.Text;
            pObj.nroCelularCliente = this.txtNroCelular.Text;
            pObj.representanteCliente = this.txtRepresentante.Text;
            pObj.estadoCliente = Cmb.ObtenerValor(this.cboEstado, string.Empty);
            pObj.idCliente = Convert.ToInt32(this.txtId.Text);
        }
        public void VentanaModificar(GestionClubClienteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCliente(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }


        public void ModificarCliente()
        {
            GestionClubClienteDto iPerEN = new GestionClubClienteDto();
            this.AsignarCliente(iPerEN);
            iPerEN = GestionClubClienteController.BuscarClienteXId(iPerEN);
            this.AsignarCliente(iPerEN);
            GestionClubClienteController.ModificarCliente(iPerEN);
        }
        public void VentanaEliminar(GestionClubClienteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCliente(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubClienteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCliente(pObj);
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

        private void frmEditarClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
