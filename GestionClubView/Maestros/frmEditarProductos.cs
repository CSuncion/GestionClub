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
    public partial class frmEditarProductos : Form
    {
        public frmProductos wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public GestionClubProductoController oOpe = new GestionClubProductoController();
        public GestionClubCategoriaController oOpeCate = new GestionClubCategoriaController();
        public frmEditarProductos()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarProducto(GestionClubProductoController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.cboUniMed.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarEstados();
            this.CargarCategorias();
            this.CargarMoneda();
            this.CargarUndMedida();

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
            xCtrl.TxtTodo(this.txtDescripcion, true, "Descripción", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboMoneda, true, "Moneda", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.cboUniMed, true, "U. Medida", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPrecio, true, "Precio", "vvff", 2, 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPrecioSocio, false, "Precio Socio", "vvff", 2, 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPrecioNoSocio, false, "Precio No Socio", "vvff", 2, 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPorDtra, false, "Porcentaje Detracción", "vvff", 2, 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtImpDol, false, "Importe Dolares", "vvff", 2, 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtOtrImp, false, "Otro Importe", "vvff", 2, 15);
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
            if (this.EsCodigoProductoDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Producto se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            this.wFrm.eClaveDgvProducto = this.ObtenerIdProducto();
            this.wFrm.ActualizarVentana();

            //limpiar controles
            this.MostrarProducto(GestionClubProductoController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarProducto().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Producto se modifico correctamente", this.wFrm.eTitulo);

            //actualizar al wUsu
            this.wFrm.eClaveDgvProducto = this.ObtenerIdProducto();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarProducto().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Producto se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarProducto()
        {
            GestionClubProductoDto iPerEN = new GestionClubProductoDto();
            this.AsignarProducto(iPerEN);
            GestionClubProductoController.EliminarProducto(iPerEN);
        }
        public string ObtenerIdProducto()
        {
            //asignar parametros
            GestionClubProductoDto iAmbEN = new GestionClubProductoDto();
            this.AsignarProducto(iAmbEN);

            //devolver
            return iAmbEN.idProducto.ToString();
        }
        public void AdicionarProducto()
        {
            GestionClubProductoDto iPerEN = new GestionClubProductoDto();
            this.AsignarProducto(iPerEN);
            GestionClubProductoController.AdicionarProducto(iPerEN);
        }
        public bool EsCodigoProductoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            GestionClubProductoDto iProducto = new GestionClubProductoDto();
            this.AsignarProducto(iProducto);
            iProducto = GestionClubProductoController.EsCodigoProductoDisponible(iProducto);
            if (iProducto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iProducto.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodigo.Clear();
                this.txtCodigo.Focus();
            }
            return iProducto.Adicionales.EsVerdad;
        }

        public void MostrarProducto(GestionClubProductoDto pObj)
        {
            this.txtId.Text = pObj.idProducto.ToString();
            this.cboMoneda.SelectedValue = pObj.codMoneda;
            this.txtCodigo.Text = pObj.codProducto;
            this.txtDescripcion.Text = pObj.desProducto;
            this.cboUniMed.SelectedValue = pObj.uniMedProducto.ToString();
            this.txtPrecio.Text = pObj.preCosProducto.ToString();
            this.txtPrecioSocio.Text = pObj.preVtsProducto.ToString();
            this.txtPrecioNoSocio.Text = pObj.preVnsProducto.ToString();

            if (pObj.afeIgvProducto.ToString() == "1")
                this.chkAfeIgvSi.Checked = true;
            else
                this.chkAfeIgvNo.Checked = true;

            if (pObj.afeDtraProducto.ToString() == "1")
                this.chkAfeDtraSi.Checked = true;
            else
                this.chkAfeDtraNo.Checked = true;

            this.txtPorDtra.Text = pObj.porDtraProducto.ToString();
            this.txtImpDol.Text = pObj.impDolProducto.ToString();
            this.txtOtrImp.Text = pObj.impOtrProducto.ToString();
            this.txtStock.Text = pObj.stockProducto.ToString();
            this.txtArchivo.Text = pObj.archivoProducto;
            this.cboEstado.SelectedValue = pObj.estadoProducto;
            this.txtId.Text = pObj.idProducto.ToString();
        }
        public void CargarEstados()
        {
            Cmb.Cargar(this.cboEstado, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Estado.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarCategorias()
        {
            Cmb.Cargar(this.cboCategoria, GestionClubCategoriaController.ListarCategoriasActivos(), GestionClubCategoriaDto._idCategoria, GestionClubCategoriaDto._desCategoria);
        }
        public void CargarMoneda()
        {
            Cmb.Cargar(this.cboMoneda, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Moneda.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarUndMedida()
        {
            Cmb.Cargar(this.cboUniMed, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.UndMedida.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AsignarProducto(GestionClubProductoDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.codProducto = this.txtCodigo.Text.Trim();
            pObj.idCategoria = Convert.ToString(Cmb.ObtenerValor(this.cboCategoria, string.Empty));
            pObj.codMoneda = Cmb.ObtenerValor(this.cboMoneda, string.Empty);
            pObj.desProducto = this.txtDescripcion.Text.Trim();
            pObj.uniMedProducto = Cmb.ObtenerValor(this.cboUniMed, string.Empty);
            pObj.preCosProducto = Convert.ToDecimal(this.txtPrecio.Text);
            pObj.preVtsProducto = Convert.ToDecimal(this.txtPrecioSocio.Text);
            pObj.preVnsProducto = Convert.ToDecimal(this.txtPrecioNoSocio.Text);
            pObj.afeIgvProducto = this.chkAfeIgvSi.Checked ? 1 : 2;
            pObj.afeDtraProducto = this.chkAfeDtraSi.Checked ? 1 : 2;
            pObj.porDtraProducto = Convert.ToDecimal(this.txtPorDtra.Text);
            pObj.impDolProducto = Convert.ToDecimal(this.txtImpDol.Text);
            pObj.impOtrProducto = Convert.ToDecimal(this.txtOtrImp.Text);
            pObj.estadoProducto = Cmb.ObtenerValor(this.cboEstado, string.Empty);
            pObj.stockProducto = Convert.ToInt32(this.txtStock.Text);
            pObj.archivoProducto = this.txtArchivo.Text;
            pObj.idProducto = Convert.ToInt32(this.txtId.Text);
        }
        public void VentanaModificar(GestionClubProductoDto pObj)
        {
            this.InicializaVentana();
            this.MostrarProducto(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodigo.Focus();
        }


        public void ModificarProducto()
        {
            GestionClubProductoDto iPerEN = new GestionClubProductoDto();
            this.AsignarProducto(iPerEN);
            iPerEN = GestionClubProductoController.BuscarProductoXId(iPerEN);
            this.AsignarProducto(iPerEN);
            GestionClubProductoController.ModificarProducto(iPerEN);
        }
        public void VentanaEliminar(GestionClubProductoDto pObj)
        {
            this.InicializaVentana();
            this.MostrarProducto(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubProductoDto pObj)
        {
            this.InicializaVentana();
            this.MostrarProducto(pObj);
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

        private void frmEditarProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }

        private void chkAfeDtraSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfeDtraSi.Checked)
                chkAfeDtraNo.Checked = false;
            else
                chkAfeDtraNo.Checked = true;
        }

        private void chkAfeDtraNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfeDtraNo.Checked)
                chkAfeDtraSi.Checked = false;
            else
                chkAfeDtraSi.Checked = true;
        }

        private void chkAfeIgvSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfeIgvSi.Checked)
                chkAfeIgvNo.Checked = false;
            else
                chkAfeIgvNo.Checked = true;
        }

        private void chkAfeIgvNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfeIgvNo.Checked)
                chkAfeIgvSi.Checked = false;
            else
                chkAfeIgvSi.Checked = true;
        }
    }
}
