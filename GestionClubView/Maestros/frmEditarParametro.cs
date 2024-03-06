using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Pedidos;
using GestionClubView.Venta;
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
    public partial class frmEditarParametro : Form
    {
        public frmParametro wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public string Formulario = string.Empty;
        public frmEditarParametro()
        {
            InitializeComponent();
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
            xCtrl.TxtTodo(this.txtRutaLogo, true, "Ruta Logo", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtIgv, true, "IGV", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDetraccion, false, "Detracción", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNSoles, false, "Soles", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNDolares, false, "Dolares", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRutaCategoria, false, "Ruta Categoria", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRutaProducto, false, "Ruta Producto", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRutaMesa, false, "Ruta Mesa", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRutaQR, false, "Ruta QR", "vvff", 150);
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
            //if (this.EsCodigoClienteDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo)) { return; }

            //adicionando el registro
            this.AdicionarCliente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Parametro se adiciono correctamente", this.wFrm.eTitulo);

            //actualizar al propietario
            if (this.Formulario == "Cliente")
            {
                //this.wFrm.eClaveDgvCliente = this.ObtenerIdCliente();
                this.wFrm.ActualizarVentana();
            }
            else { this.Close(); }

            //limpiar controles
            this.MostrarParametro(GestionClubParametroController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtRutaLogo.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarParametro().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.Formulario == "Cliente" ? this.wFrm.eTitulo : "Comprobantes") == false) { return; }

            //modificar el registro    
            this.ModificarCliente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Parametro se modifico correctamente", this.Formulario == "Cliente" ? this.wFrm.eTitulo : "Comprobantes");

            //actualizar al wUsu
            //this.wFrm.eClaveDgvParametro = this.ObtenerIdCliente();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wFrm.EsActoEliminarCliente().Adicionales.EsVerdad == false) { return; }

            //if (this.ValidarExisteClienteTieneComprobante()) { Mensaje.OperacionDenegada("El cliente tiene movimentos. No puede eliminar", this.Formulario == "Cliente" ? this.wFrm.eTitulo : this.wFrm1.eTitulo); return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.Formulario == "Cliente" ? this.wFrm.eTitulo : this.wFrm1.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCliente();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("El Cliente se elimino correctamente", this.Formulario == "Cliente" ? this.wFrm.eTitulo : this.wFrm1.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        //public bool ValidarExisteClienteTieneComprobante()
        //{
        //    GestionClubParametroDto iPerEN = new GestionClubParametroDto();
        //    this.AsignaParametro(iPerEN);
        //    return GestionClubComprobanteController.ValidaExisteClienteComprobante(iPerEN);
        //}
        public void EliminarCliente()
        {
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();
            this.AsignaParametro(iPerEN);
            //GestionClubClienteController.EliminarCliente(iPerEN);
        }
        //public string ObtenerIdCliente()
        //{
        //    //asignar parametros
        //    GestionClubParametroDto iAmbEN = new GestionClubParametroDto();
        //    this.AsignaParametro(iAmbEN);

        //    //devolver
        //    return iAmbEN.idCliente.ToString();
        //}
        public void AdicionarCliente()
        {
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();
            this.AsignaParametro(iPerEN);
            //GestionClubClienteController.AdicionarCliente(iPerEN);
        }
        //public bool EsCodigoClienteDisponible()
        //{
        //    //cuando la operacion es diferente del adicionar entonces retorna verdadero
        //    if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

        //    GestionClubParametroDto iCliente = new GestionClubParametroDto();
        //    this.AsignaParametro(iCliente);
        //    iCliente = GestionClubClienteController.EsCodigoClienteDisponible(iCliente);
        //    if (iCliente.Adicionales.EsVerdad == false)
        //    {
        //        Mensaje.OperacionDenegada(iCliente.Adicionales.Mensaje, this.Formulario == "Cliente" ? this.wFrm.eTitulo : this.wFrm1.eTitulo);
        //        this.txtRutaLogo.Clear();
        //        this.txtRutaLogo.Focus();
        //    }
        //    return iCliente.Adicionales.EsVerdad;
        //}

        public void MostrarParametro(GestionClubParametroDto pObj)
        {

            this.txtRutaLogo.Text = pObj.RutaLogoEmpresa;
            this.txtIgv.Text = pObj.PorcentajeIgv.ToString();
            this.txtDetraccion.Text = pObj.PorcentajeDetra.ToString();
            this.txtNSoles.Text = pObj.NombreSoles;
            this.txtNDolares.Text = pObj.NombreDolares;
            this.txtRutaCategoria.Text = pObj.RutaImagenCategoria;
            this.txtRutaProducto.Text = pObj.RutaImagenProducto;
            this.txtRutaMesa.Text = pObj.RutaImagenMesa;
            this.txtRutaQR.Text = pObj.RutaImagenQR;
        }

        public void AsignaParametro(GestionClubParametroDto pObj)
        {
            pObj.RutaLogoEmpresa = this.txtRutaLogo.Text;
            pObj.PorcentajeIgv = Convert.ToDecimal(this.txtIgv.Text);
            pObj.PorcentajeDetra = Convert.ToDecimal(this.txtDetraccion.Text);
            pObj.NombreSoles = this.txtNSoles.Text;
            pObj.NombreDolares = this.txtNDolares.Text;
            pObj.RutaImagenCategoria = this.txtRutaCategoria.Text;
            pObj.RutaImagenProducto = this.txtRutaProducto.Text;
            pObj.RutaImagenMesa = this.txtRutaMesa.Text;
            pObj.RutaImagenQR = this.txtRutaQR.Text;
        }
        public void VentanaModificar(GestionClubParametroDto pObj)
        {
            this.InicializaVentana();
            this.MostrarParametro(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtRutaLogo.Focus();
        }


        public void ModificarCliente()
        {
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();
            this.AsignaParametro(iPerEN);
            iPerEN = GestionClubParametroController.BuscarParametroXId(iPerEN);
            this.AsignaParametro(iPerEN);
            GestionClubParametroController.ModificarParametro(iPerEN);
        }
        public void VentanaEliminar(GestionClubParametroDto pObj)
        {
            this.InicializaVentana();
            this.MostrarParametro(pObj);
            eMas.AccionHabilitarControles(2);
        }

        public void VentanaVisualizar(GestionClubParametroDto pObj)
        {
            this.InicializaVentana();
            this.MostrarParametro(pObj);
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
