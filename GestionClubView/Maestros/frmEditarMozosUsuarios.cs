using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubUtil.Util;
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
using System.Xml.Linq;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Maestros
{
    public partial class frmEditarMozosUsuarios : Form
    {
        public frmMozosUsuarios wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public GestionClubProductoController oOpe = new GestionClubProductoController();
        public GestionClubCategoriaController oOpeCate = new GestionClubCategoriaController();
        public frmEditarMozosUsuarios()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarAccess(GestionClubAccessController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.cboAmbiente.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarEstados();
            this.CargarPrimerNivel();
            this.CargarSegundoNivel();

            //this.ActualizarVentana();
            // Deshabilitar al propietario
            this.wFrm.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarPrimerNivel()
        {
            Cmb.Cargar(this.cboNivel, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.PrimerNivel.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarSegundoNivel()
        {
            Cmb.Cargar(this.cboNivelSeg, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.SegundoNivel.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDocId, true, "Documento de Identificación", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtApePaterno, true, "Apellido Paterno", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtApeMaterno, true, "Apellido Materno", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNombres, true, "Nombres", "vvff", 150);
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
            if (this.EsCodigoAccessDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAccess();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El personal se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvUsuariosMozos = this.ObtenerIdAccess();
            this.wFrm.ActualizarVentana();


            //limpiar controles
            this.MostrarAccess(GestionClubAccessController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarAccess().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAccess();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El personal se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvUsuariosMozos = this.ObtenerIdAccess();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarAccess().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAccess();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El personal se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarAccess()
        {
            GestionClubAccessDto iPerEN = new GestionClubAccessDto();
            this.AsignarAccess(iPerEN);
            GestionClubAccessController.EliminarAcceso(iPerEN);
        }
        public string ObtenerIdAccess()
        {
            //asignar parametros
            GestionClubAccessDto iAmbEN = new GestionClubAccessDto();
            this.AsignarAccess(iAmbEN);

            //devolver
            return iAmbEN.idAcceso.ToString();
        }
        public void AdicionarAccess()
        {
            GestionClubAccessDto iPerEN = new GestionClubAccessDto();
            this.AsignarAccess(iPerEN);
            GestionClubAccessController.AdicionarAcceso(iPerEN);
        }
        public bool EsCodigoAccessDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubAccessDto iAccess = new GestionClubAccessDto();
            this.AsignarAccess(iAccess);
            iAccess = GestionClubAccessController.EsCodigoAccesoDisponible(iAccess);
            if (iAccess.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAccess.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iAccess.Adicionales.EsVerdad;
        }

        public void MostrarAccess(GestionClubAccessDto pObj)
        {
            this.txtId.Text = pObj.idAcceso.ToString();
            this.txtCodigo.Text = pObj.codAcceso.ToString();
            this.txtDocId.Text = pObj.dniAcceso.ToString();
            this.txtApePaterno.Text = pObj.paternoAcceso.ToString();
            this.txtApeMaterno.Text = pObj.maternoAcceso.ToString();
            this.txtNombres.Text = pObj.nombresAcceso.ToString();
            this.txtEmail.Text = pObj.mailAcceso.ToString();
            this.txtDireccion.Text = pObj.domicilioAcceso.ToString();
            this.txtTlf.Text = pObj.fijoAcceso.ToString();
            this.txtCargoAcceso.Text = pObj.cargoAcceso.ToString();
            this.txtCelular.Text = pObj.movilAcceso.ToString();
            this.cboNivel.SelectedValue = pObj.levelAcceso.ToString();
            this.cboNivelSeg.SelectedValue = pObj.gradoAcceso.ToString();
            this.cboEstado.SelectedValue = pObj.sitAcceso.ToString();
        }
        public void AsignarAccess(GestionClubAccessDto pObj)
        {
            pObj.idAcceso = Convert.ToInt32(this.txtId.Text);
            pObj.codAcceso = this.txtCodigo.Text;
            pObj.nombreAcceso = this.txtNombres.Text;
            pObj.dniAcceso = this.txtDocId.Text;
            pObj.passAcceso = UtilGestionClub.Encripta(this.txtDocId.Text.Trim());
            pObj.paternoAcceso = this.txtApePaterno.Text;
            pObj.maternoAcceso = this.txtApeMaterno.Text;
            pObj.nombresAcceso = this.txtNombres.Text;
            pObj.mailAcceso = this.txtEmail.Text;
            pObj.domicilioAcceso = this.txtDireccion.Text;
            pObj.dptoAcceso = 15;
            pObj.provAcceso = 1;
            pObj.distAcceso = 43;
            pObj.fijoAcceso = this.txtTlf.Text;
            pObj.movilAcceso = this.txtCelular.Text;
            pObj.levelAcceso = Convert.ToInt32(Cmb.ObtenerValor(this.cboNivel, string.Empty));
            pObj.sitAcceso = Cmb.ObtenerValor(this.cboEstado, String.Empty);
            pObj.fechaAcceso = DateTime.Now;
            pObj.ofc1 = 2;
            pObj.ofc2 = 6;
            pObj.ofc3 = 3;
            pObj.ofc4 = 0;
            pObj.cipAcceso = string.Empty;
            pObj.codofinAcceso = string.Empty;
            pObj.gradoAcceso = Convert.ToInt32(Cmb.ObtenerValor(this.cboNivel, string.Empty));
            pObj.pnp = 1;
            pObj.cargoAcceso = this.txtCargoAcceso.Text;
        }
        public void VentanaModificar(GestionClubAccessDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAccess(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }


        public void ModificarAccess()
        {
            GestionClubAccessDto iPerEN = new GestionClubAccessDto();
            this.AsignarAccess(iPerEN);
            iPerEN = GestionClubAccessController.BuscarAccessXId(iPerEN);
            this.AsignarAccess(iPerEN);
            GestionClubAccessController.ModificarAcceso(iPerEN);
        }
        public void VentanaEliminar(GestionClubAccessDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAccess(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubAccessDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAccess(pObj);
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

        private void frmEditarMozosUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
