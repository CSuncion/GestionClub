using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Pedidos
{
    public partial class frmCobrar : Form
    {
        public frmComanda wCom;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public List<GestionClubDetalleComandaDto> lObjDetalle = new List<GestionClubDetalleComandaDto>();
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty;
        public List<GestionClubMesaDto> lObjMesas = new List<GestionClubMesaDto>();
        public string eTitulo = "Cobrar Comanda";
        public frmCobrar()
        {
            InitializeComponent();
        }
        public void VentanaCobrar(GestionClubComandaDto objCom)
        {
            this.InicializaVentana();
            this.CargarProductosSeleccionados();
            this.CargarRutas();
            this.MostrarProductosPedidosEnComandaBD(objCom);
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtDocId.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCom.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarTipoDocumentos();
            this.CargarMoneda();

            // Deshabilitar al propietario
            this.wCom.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDocId, true, "Doc, Identificación", "vvff", 150);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtApeNom, this.txtNroDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cboTipDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, true, "Ser. Doc.", "vvff", 11);
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroDoc, true, "N°. Doc.", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cboMoneda, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtEfectivo, true, "Efectivo", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtYape, true, "Yape", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTarjeta, true, "Tarjeta", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTransferencia, true, "Transferencia", "vvff", 2);
            xLis.Add(xCtrl);

            return xLis;
        }
        public void CargarProductosSeleccionados()
        {
            lvProductosSeleccionados.View = View.LargeIcon;

            lvProductosSeleccionados.Columns.Add("PRODUCTOS", 220);
            lvProductosSeleccionados.Columns.Add("CANTIDAD", 80);
            lvProductosSeleccionados.Columns.Add("IMPORTE", 100);
        }
        public void CargarRutas()
        {
            rutaMesa = ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = ConfigurationManager.AppSettings["RutaProducto"].ToString();
        }
        public void CargarTipoDocumentos()
        {
            Cmb.Cargar(this.cboTipDoc, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.DocFac.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarMoneda()
        {
            Cmb.Cargar(this.cboMoneda, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Moneda.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void MostrarProductosPedidosEnComandaBD(GestionClubComandaDto objCom)
        {
            lvProductosSeleccionados.View = View.Details;

            GestionClubDetalleComandaDto objEn = new GestionClubDetalleComandaDto();
            objEn.idMesa = objCom.idMesa;
            this.lvProductosSeleccionados.Items.Clear();

            this.lObjDetalle = GestionClubComandaController.ListarDetalleComandaPorMesaYPendienteCobrar(objEn);

            this.lblFecha.Text = this.lObjDetalle.FirstOrDefault().fecDetalleComanda.ToString();
            this.lblAmbiente.Text = this.lObjDetalle.FirstOrDefault().desAmbiente;
            this.lblIdAmbiente.Text = this.lObjDetalle.FirstOrDefault().idAmbiente.ToString();
            this.lblIdMesa.Text = this.lObjDetalle.FirstOrDefault().idMesa.ToString();
            this.lblNroMesa.Text = this.lObjDetalle.FirstOrDefault().desMesas;
            this.lblIdMozo.Text = this.lObjDetalle.FirstOrDefault().idMozo.ToString();
            this.lblIdNroComanda.Text = this.lObjDetalle.FirstOrDefault().idComanda.ToString();


            this.txtEfectivo.Text = "0";
            this.txtYape.Text = "0";
            this.txtTransferencia.Text = "0";
            this.txtTarjeta.Text = "0";

            this.lblCantidad.Text = "0";
            this.lblTotal.Text = "0";

            foreach (GestionClubDetalleComandaDto detalle in this.lObjDetalle)
            {
                this.imgProductosSel.ImageSize = new Size(50, 50);
                this.imgProductosSel.Images.Add(detalle.idProducto.ToString(), Image.FromFile(this.rutaProducto + detalle.archivoProducto));
                this.lvProductosSeleccionados.SmallImageList = this.imgProductosSel;

                this.lvProductosSeleccionados.SmallImageList = imgProductosSel;
                this.lvProductosSeleccionados.Items.Add(new ListViewItem(new[] { detalle.desProducto.ToString(), detalle.cantidad.ToString(), detalle.preVenta.ToString() }, detalle.idProducto.ToString()));
                this.lblCantidad.Text = (Convert.ToInt32(this.lblCantidad.Text) + Convert.ToInt32(detalle.cantidad.ToString())).ToString();
                this.lblTotal.Text = (Convert.ToDecimal(this.lblTotal.Text) + Convert.ToInt32(detalle.cantidad.ToString()) * Convert.ToDecimal(detalle.preVenta)).ToString();
            }
            this.CalcularPendientePagar();
        }
        public void CalcularPendientePagar()
        {
            this.lblPendiente.Text = (Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtTarjeta.Text) + Convert.ToDecimal(this.txtYape.Text) + Convert.ToDecimal(this.txtEfectivo.Text))).ToString();
        }
        public bool EsClienteValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtDocId.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            GestionClubClienteDto iCliEN = new GestionClubClienteDto();
            iCliEN.nroIdentificacionCliente = this.txtDocId.Text.Trim();
            iCliEN = GestionClubClienteController.EsClienteActivoValido(iCliEN);
            if (iCliEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCliEN.Adicionales.Mensaje, this.wCom.eTitulo);
                this.txtDocId.Focus();
            }

            //mostrar datos
            this.txtIdCliente.Text = iCliEN.idCliente.ToString();
            this.txtDocId.Text = iCliEN.nroIdentificacionCliente;
            this.txtApeNom.Text = iCliEN.nombreRazSocialCliente;

            //devolver
            return iCliEN.Adicionales.EsVerdad;
        }
        public void ListarClientes()
        {
            //si es de lectura , entonces no lista
            if (this.txtDocId.ReadOnly == true) { return; }

            //instanciar
            frmListarClientes win = new frmListarClientes();
            win.eVentana = this;
            win.eTituloVentana = "Clientes";
            win.eCtrlValor = this.txtDocId;
            win.eCtrlFoco = this.txtApeNom;
            win.eCondicionLista = frmListarClientes.Condicion.Clientes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void Cobrar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            //if (this.EsCodigoAmbienteDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCom.eTitulo) == false) { return; }

            this.AdicionarComprobante();
            this.ModificarSituacionMesa();
            this.ModificarSituacionComanda();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El comprobante se adiciono correctamente", this.eTitulo);

            this.wCom.cargarMesas();
            this.wCom.LimpiarLvSeleccionados();
            //salir de la ventana
            this.Close();
        }
        public void AdicionarComprobante()
        {
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);
            int identity = GestionClubComprobanteController.AgregarComprobante(iComEN);


            GestionClubDetalleComprobanteDto iDetObjEN = new GestionClubDetalleComprobanteDto();
            this.AsignarDetalleComprobante(iDetObjEN, identity);

        }
        public void AsignarComprobante(GestionClubComprobanteDto pObj)
        {
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.tipComprobante = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            pObj.serComprobante = this.txtSerDoc.Text.Trim();
            pObj.nroComprobante = this.txtNroDoc.Text.Trim();
            pObj.fecComprobante = Convert.ToDateTime(this.dtpFecDoc.Value.ToString());
            pObj.codMoneda = Cmb.ObtenerValor(this.cboMoneda, string.Empty);
            pObj.impCambio = 0;
            pObj.serGuiaComprobante = string.Empty;
            pObj.nroGuiaComprobante = string.Empty;
            pObj.fecGuiaComprobante = DateTime.Now;
            pObj.idNroComanda = Convert.ToInt32(this.lblIdNroComanda.Text);
            pObj.idAmbiente = Convert.ToInt32(this.lblIdAmbiente.Text);
            pObj.idMesa = Convert.ToInt32(this.lblIdMesa.Text);
            pObj.idMozo = Convert.ToInt32(this.lblIdMozo.Text);
            pObj.turnoCaja = "01";
            pObj.modPagoComprobante = this.modoPago();
            pObj.tipMovComprobante = "01";
            pObj.impEfeComprobante = Convert.ToDecimal(this.txtEfectivo.Text);
            pObj.impDepComprobante = Convert.ToDecimal(this.txtTransferencia.Text);
            pObj.impTarComprobante = Convert.ToDecimal(this.txtYape.Text) + Convert.ToDecimal(this.txtTarjeta.Text);
            pObj.impBruComprobante = Convert.ToDecimal(this.lblTotal.Text) - Convert.ToDecimal(this.lblTotal.Text) * Convert.ToDecimal(0.18);
            pObj.impIgvComprobante = Convert.ToDecimal(this.lblTotal.Text) * Convert.ToDecimal(0.18);
            pObj.impNetComprobante = Convert.ToDecimal(this.lblTotal.Text);
            pObj.impDtrComprobante = 0;
            pObj.idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            pObj.obsComprobante = string.Empty;
            pObj.estadoComprobante = "01";
        }

        public void AsignarDetalleComprobante(GestionClubDetalleComprobanteDto pObj, int identity)
        {
            pObj.idComprobante = identity;
            pObj.estadoDetalleComprobante = "01";
            pObj.obsDetalleComprobante = string.Empty;
            foreach (ListViewItem item in this.lvProductosSeleccionados.Items)
            {
                pObj.idProducto = Convert.ToInt32(item.ImageKey);
                pObj.preVenta = Convert.ToDecimal(item.SubItems[2].Text);
                pObj.cantidad = Convert.ToInt32(item.SubItems[1].Text);
                pObj.preTotal = (pObj.preVenta * pObj.cantidad);
                GestionClubComprobanteController.AgregarDetalleComprobante(pObj);
            }

        }

        public string modoPago()
        {
            string modoPago = string.Empty;
            int cantidadCheck = 0;

            if (this.chEfectivo.Checked) { cantidadCheck++; modoPago = "01"; }
            if (this.chYape.Checked) { cantidadCheck++; modoPago = "02"; }
            if (this.chTarjeta.Checked) { cantidadCheck++; modoPago = "03"; }
            if (this.chTransferencia.Checked) { cantidadCheck++; modoPago = "04"; }
            if (cantidadCheck > 1) modoPago = "05";

            return modoPago;
        }

        public void ModificarSituacionMesa()
        {
            GestionClubMesaDto obj = new GestionClubMesaDto();
            obj.idMesa = Convert.ToInt32(this.lblIdMesa.Text);
            obj = GestionClubMesaController.BuscarMesaXId(obj);
            obj.sitMesa = "01";
            GestionClubMesaController.ModificarMesa(obj);
        }
        public void ModificarSituacionComanda()
        {
            GestionClubComandaDto objCab = new GestionClubComandaDto();
            objCab.idComanda = Convert.ToInt32(this.lblIdNroComanda.Text);
            objCab.estadoComanda = "04";
            GestionClubComandaController.ModificarSituacionComanda(objCab);
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCom.Enabled = !this.wCom.Enabled;
            this.wCom.btnCobrar.Enabled = !this.wCom.btnCobrar.Enabled;
        }

        private void chEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtEfectivo.Enabled = !this.txtEfectivo.Enabled;
        }

        private void chYape_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYape.Enabled = !this.txtYape.Enabled;
        }

        private void tsBtnCobrar_Click(object sender, EventArgs e)
        {
            this.Cobrar();
        }

        private void tsBtnTicket_Click(object sender, EventArgs e)
        {

        }

        private void txtEfectivo_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void txtYape_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void txtTarjeta_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void txtTransferencia_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void txtDocId_DoubleClick(object sender, EventArgs e)
        {
            this.ListarClientes();
        }

        private void txtDocId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarClientes(); }
        }

        private void txtDocId_Validating(object sender, CancelEventArgs e)
        {
            this.EsClienteValido();
        }
        private void chTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTarjeta.Enabled = !this.txtTarjeta.Enabled;
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
        }
    }
}
