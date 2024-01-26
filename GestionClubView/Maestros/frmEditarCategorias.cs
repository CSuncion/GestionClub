using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Comanda;
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
    public partial class frmEditarCategorias : Form
    {
        public frmCategorias wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubCategoriaController oOpe = new GestionClubCategoriaController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public frmEditarCategorias()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarCategoria(GestionClubCategoriaController.EnBlanco());
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
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCategoria, true, "Nombre Categoria", "vvff", 150);
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
            if (this.EsCodigoCategoriaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarCategoria();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Categoria se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvCategoria = this.ObtenerIdCategoria();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarCategoria(GestionClubCategoriaController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarCategoria().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCategoria();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Categoria se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvCategoria = this.ObtenerIdCategoria();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarCategoria().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCategoria();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Categoria se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarCategoria()
        {
            GestionClubCategoriaDto iPerEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iPerEN);
            GestionClubCategoriaController.EliminarCategoria(iPerEN);
        }
        public string ObtenerIdCategoria()
        {
            //asignar parametros
            GestionClubCategoriaDto iAmbEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iAmbEN);

            //devolver
            return iAmbEN.idCategoria.ToString();
        }
        public void AdicionarCategoria()
        {
            GestionClubCategoriaDto iPerEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iPerEN);
            GestionClubCategoriaController.AdicionarCategoria(iPerEN);
        }
        public bool EsCodigoCategoriaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubCategoriaDto iCategoria = new GestionClubCategoriaDto();
            this.AsignarCategoria(iCategoria);
            iCategoria = GestionClubCategoriaController.EsCodigoCategoriaDisponible(iCategoria);
            if (iCategoria.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCategoria.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iCategoria.Adicionales.EsVerdad;
        }

        public void MostrarCategoria(GestionClubCategoriaDto pObj)
        {
            this.txtCodigo.Text = pObj.codCategoria;
            this.txtCategoria.Text = pObj.desCategoria;
            this.cboEstado.SelectedValue = pObj.estadoCategoria;
            this.txtId.Text = pObj.idCategoria.ToString();
        }

        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, oOpeGral.ListarSistemaDetallePorTabla(((int)GestionClubEnum.Sistema.Estado).ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AsignarCategoria(GestionClubCategoriaDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.codCategoria = this.txtCodigo.Text.Trim();
            pObj.desCategoria = this.txtCategoria.Text.Trim();
            pObj.estadoCategoria = Cmb.ObtenerValor(this.cboEstado, string.Empty);
            pObj.idCategoria = Convert.ToInt32(this.txtId.Text);
        }
        public void VentanaModificar(GestionClubCategoriaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCategoria(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }


        public void ModificarCategoria()
        {
            GestionClubCategoriaDto iPerEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iPerEN);
            iPerEN = GestionClubCategoriaController.BuscarCategoriaXId(iPerEN);
            this.AsignarCategoria(iPerEN);
            GestionClubCategoriaController.ModificarCategoria(iPerEN);
        }
        public void VentanaEliminar(GestionClubCategoriaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCategoria(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubCategoriaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarCategoria(pObj);
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

        private void frmEditarCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
