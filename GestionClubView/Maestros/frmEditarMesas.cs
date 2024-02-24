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
    public partial class frmEditarMesas : Form
    {
        public frmMesas wMes;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubMesaController oOpe = new GestionClubMesaController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public GestionClubAmbienteController oOpeAmbiente = new GestionClubAmbienteController();
        public frmEditarMesas()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarMesa(GestionClubMesaController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.cboAmbiente.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wMes.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarEstados();
            this.CargarAmbientes();

            // Deshabilitar al propietario
            this.wMes.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboAmbiente, true, "Ambiente", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodigo, true, "Código", "vfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtMesa, true, "Nombre Mesa", "vvff", 150);
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
        public void VentanaModificar(GestionClubMesaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarMesa(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void MostrarMesa(GestionClubMesaDto pObj)
        {
            this.cboAmbiente.SelectedValue = pObj.idAmbiente;
            this.txtCodigo.Text = pObj.codMesas;
            this.txtMesa.Text = pObj.desMesas;
            this.cboEstado.SelectedValue = pObj.estadoMesa;
            this.txtIdMesa.Text = pObj.idMesa.ToString();
        }
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoMesaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wMes.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Mesa se adiciono correctamente", this.wMes.eTitulo);

            //actualizar al propietario
            this.wMes.eClaveDgvMesas = this.ObtenerIdMesa();
            this.wMes.ActualizarVentana();

            //limpiar controles
            this.MostrarMesa(GestionClubMesaController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wMes.EsActoModificarMesa().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wMes.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Mesa se modifico correctamente", this.wMes.eTitulo);

            //actualizar al wUsu
            this.wMes.eClaveDgvMesas = this.ObtenerIdMesa();
            this.wMes.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void ModificarMesa()
        {
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();
            this.AsignarMesa(iObjEN);
            iObjEN = GestionClubMesaController.BuscarMesaXId(iObjEN);
            this.AsignarMesa(iObjEN);
            GestionClubMesaController.ModificarMesa(iObjEN);
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wMes.EsActoEliminarMesa().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wMes.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Mesa se elimino correctamente", this.wMes.eTitulo);

            //actualizar al propietario           
            this.wMes.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarMesa()
        {
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();
            this.AsignarMesa(iObjEN);
            GestionClubMesaController.EliminarMesa(iObjEN);
        }
        public bool EsCodigoMesaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubMesaDto iDto = new GestionClubMesaDto();
            this.AsignarMesa(iDto);
            iDto = GestionClubMesaController.EsCodigoMesaDisponible(iDto);
            if (iDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iDto.Adicionales.Mensaje, this.wMes.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iDto.Adicionales.EsVerdad;
        }
        public void AsignarMesa(GestionClubMesaDto pObj)
        {
            pObj.idAmbiente = Convert.ToInt32(Cmb.ObtenerValor(this.cboAmbiente, string.Empty));
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.codMesas = this.txtCodigo.Text.Trim();
            pObj.desMesas = this.txtMesa.Text.Trim();
            pObj.estadoMesa = Cmb.ObtenerValor(this.cboEstado, string.Empty);
            pObj.idMesa = Convert.ToInt32(this.txtIdMesa.Text);
        }
        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarAmbientes()
        {
            Cmb.Cargar(this.cboAmbiente, oOpeAmbiente.ListarAmbientesActivos(), GestionClubAmbientesDto._idAmbiente, GestionClubAmbientesDto._desAmbiente);
        }
        public void AdicionarMesa()
        {
            GestionClubMesaDto iPerEN = new GestionClubMesaDto();
            this.AsignarMesa(iPerEN);
            GestionClubMesaController.AdicionarMesa(iPerEN);
        }

        public string ObtenerIdMesa()
        {
            //asignar parametros
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();
            this.AsignarMesa(iObjEN);

            //devolver
            return iObjEN.idAmbiente.ToString();
        }
        public void VentanaEliminar(GestionClubMesaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarMesa(pObj);
            eMas.AccionHabilitarControles(2);
        }
        public void VentanaVisualizar(GestionClubMesaDto pObj)
        {
            this.InicializaVentana();
            this.MostrarMesa(pObj);
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
            this.wMes.Enabled = true;
        }
    }
}
