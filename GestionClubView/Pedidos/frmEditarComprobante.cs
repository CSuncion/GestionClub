using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Listas;
using GestionClubView.Maestros;
using GestionClubView.MdiPrincipal;
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

namespace GestionClubView.Pedidos
{
    public partial class frmEditarComprobante : Form
    {
        public frmComprobantes wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public string eTitulo = "Registro Comprobante";
        public List<GestionClubDetalleComprobanteDto> lObjDetalle = new List<GestionClubDetalleComprobanteDto>();
        Dgv.Franja eFranjaDgvComDet = Dgv.Franja.PorIndice;
        public string eClaveDgvComDet = string.Empty;
        public frmEditarComprobante()
        {
            InitializeComponent();
        }
        //public void NewWindow()
        //{
        //    this.InicializaVentana();
        //    this.Show();
        //}
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            //this.MostrarAmbiente(GestionClubAmbienteController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtNroDoc.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = "Registrar" + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarTipoDocumentos();
            this.CargarMoneda();
            this.SetearConCeroModoPago();
            // Deshabilitar al propietario
            //this.wCom.Enabled = false;

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
            xCtrl.txtNoFoco(this.txtApeNom, this.txtSerDoc, "ffff");
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtEfectivo, false, "Efectivo", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtYape, false, "Yape", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTarjeta, false, "Tarjeta", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTransferencia, false, "Transferencia", "vvff", 2);
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtCodProd, this.nudCantidadProducto, "ffff");
            //xLis.Add(xCtrl);


            return xLis;
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
                Mensaje.OperacionDenegada(iCliEN.Adicionales.Mensaje, this.eTitulo);
                this.txtDocId.Focus();
            }

            //mostrar datos
            this.txtIdCliente.Text = iCliEN.idCliente.ToString();
            this.txtDocId.Text = iCliEN.nroIdentificacionCliente;
            this.txtApeNom.Text = iCliEN.nombreRazSocialCliente;

            //devolver
            return iCliEN.Adicionales.EsVerdad;
        }
        public void ListarProducto()
        {
            //si es de lectura , entonces no lista
            if (this.txtDocId.ReadOnly == true) { return; }

            //instanciar
            frmListarProducto win = new frmListarProducto();
            win.eVentana = this;
            win.eTituloVentana = "Productos";
            win.eCtrlValor = this.txtCodProd;
            win.eCtrlFoco = this.txtDesProd;
            win.eCondicionLista = frmListarProducto.Condicion.Productos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsProductoValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodProd.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            GestionClubProductoDto iProEN = new GestionClubProductoDto();
            iProEN.codProducto = this.txtCodProd.Text.Trim();
            iProEN = GestionClubProductoController.EsProductoActivoValido(iProEN);
            if (iProEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iProEN.Adicionales.Mensaje, this.eTitulo);
                this.txtDocId.Focus();
            }

            //mostrar datos
            this.txtCodProd.Text = iProEN.codProducto.ToString();
            this.txtDesProd.Text = iProEN.desProducto;
            this.txtPrecio.Text = iProEN.preCosProducto.ToString();
            this.txtIdProd.Text = iProEN.idProducto.ToString();

            //devolver
            return iProEN.Adicionales.EsVerdad;
        }
        public void CargarTipoDocumentos()
        {
            Cmb.Cargar(this.cboTipDoc, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.DocFac.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarMoneda()
        {
            Cmb.Cargar(this.cboMoneda, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Moneda.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AgregarDetalleComprobante()
        {
            if (!this.ValidaProductoAgrega()) return;
            if (!this.ValidaCantidadMayorCero()) return;

            GestionClubDetalleComprobanteDto obj = new GestionClubDetalleComprobanteDto();
            obj.idComprobante = 0;
            obj.estadoDetalleComprobante = "01";
            obj.obsDetalleComprobante = string.Empty;
            obj.idProducto = Convert.ToInt32(this.txtIdProd.Text);
            obj.codProducto = this.txtCodProd.Text;
            obj.desProducto = this.txtDesProd.Text;
            obj.preVenta = Convert.ToDecimal(this.txtPrecio.Text);
            obj.cantidad = Convert.ToInt32(this.nudCantidadProducto.Value);
            obj.preTotal = Convert.ToDecimal(this.txtPrecio.Text) * Convert.ToInt32(this.nudCantidadProducto.Value);

            if (this.lObjDetalle.Count > 0)
            {
                for (int i = 0; i < this.lObjDetalle.Count; i++)
                {
                    if (this.lObjDetalle[i].idProducto.ToString() == this.txtIdProd.Text)
                    {
                        var itemToRemove = lObjDetalle.Single(r => r.idProducto.ToString() == this.txtIdProd.Text);
                        this.lObjDetalle.Remove(itemToRemove);
                    }
                }
            }

            this.lObjDetalle.Add(obj);
            this.MostrarComprobanteDeta();
            this.LimpiarCamposDetalleComprobante();
            this.CalcularTotalYCantidad();
            this.CalcularPendientePagar();

        }
        public void CalcularTotalYCantidad()
        {
            this.lblCantidad.Text = Convert.ToInt32(this.lObjDetalle.Sum(x => x.cantidad)).ToString();
            this.lblTotal.Text = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)).ToString();
        }
        public void QuitarDetalleComprobante()
        {
            if (this.lObjDetalle.Count > 0)
            {
                for (int i = 0; i < this.lObjDetalle.Count; i++)
                {
                    if (this.lObjDetalle[i].idProducto.ToString() == Dgv.ObtenerValorCelda(this.DgvComprobanteDeta, GestionClubDetalleComprobanteDto._idProducto))
                    {
                        var itemToRemove = lObjDetalle.Single(r => r.idProducto.ToString() == Dgv.ObtenerValorCelda(this.DgvComprobanteDeta, GestionClubDetalleComprobanteDto._idProducto));
                        this.lObjDetalle.Remove(itemToRemove);
                    }
                }
            }
            this.MostrarComprobanteDeta();
            this.CalcularTotalYCantidad();
            this.CalcularPendientePagar();
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
            pObj.idNroComanda = 0;
            pObj.idAmbiente = 0;
            pObj.idMesa = 0;
            pObj.idMozo = 0;
            pObj.turnoCaja = "01";
            pObj.modPagoComprobante = this.modoPago();
            pObj.tipMovComprobante = "01";
            pObj.impEfeComprobante = Convert.ToDecimal(this.txtEfectivo.Text);
            pObj.impDepComprobante = Convert.ToDecimal(this.txtTransferencia.Text);
            pObj.impTarComprobante = Convert.ToDecimal(this.txtYape.Text) + Convert.ToDecimal(this.txtTarjeta.Text);
            pObj.impBruComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) - Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * Convert.ToDecimal(0.18);
            pObj.impIgvComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * Convert.ToDecimal(0.18);
            pObj.impNetComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal));
            pObj.impDtrComprobante = 0;
            pObj.idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            pObj.obsComprobante = string.Empty;
            pObj.estadoComprobante = "04";
        }

        public void AsignarDetalleComprobante(GestionClubDetalleComprobanteDto pObj, int identity)
        {
            pObj.idComprobante = identity;
            pObj.estadoDetalleComprobante = "04";
            pObj.obsDetalleComprobante = string.Empty;
            foreach (GestionClubDetalleComprobanteDto obj in this.lObjDetalle)
            {
                pObj.idProducto = obj.idProducto;
                pObj.preVenta = obj.preVenta;
                pObj.cantidad = obj.cantidad;
                pObj.preTotal = obj.preTotal;
                GestionClubComprobanteController.AgregarDetalleComprobante(pObj);
            }
        }
        public void MostrarComprobanteDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvComprobanteDeta;
            List<GestionClubDetalleComprobanteDto> iFuenteDatos = GestionClubComprobanteController.RefrescarListaComprobanteDeta(this.lObjDetalle);
            Dgv.Franja iCondicionFranja = eFranjaDgvComDet;
            string iClaveBusqueda = eClaveDgvComDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._codProducto, "Código", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._desProducto, "Producto", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._preVenta, "Precio", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._cantidad, "Cantidad", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._preTotal, "Total", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._idProducto, "idProducto", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._claveObjeto, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        public void LimpiarCamposDetalleComprobante()
        {
            this.txtCodProd.Text = string.Empty;
            this.txtDesProd.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.nudCantidadProducto.Value = 0;
            this.txtIdProd.Text = "0";
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
        public void CalcularPendientePagar()
        {
            this.lblPendiente.Text = (Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtTarjeta.Text) + Convert.ToDecimal(this.txtYape.Text) + Convert.ToDecimal(this.txtEfectivo.Text))).ToString();
        }
        public bool ValidaCantidadMayorCero()
        {
            bool result = true;
            if (this.nudCantidadProducto.Value <= 0)
            {
                Mensaje.OperacionDenegada("La cantidad debe ser mayor a 0.", this.eTitulo);
                result = false;
            }
            return result;
        }
        public bool ValidaProductoAgrega()
        {
            bool result = true;
            if (this.txtCodProd.Text == string.Empty && this.txtDesProd.Text == string.Empty)
            {
                Mensaje.OperacionDenegada("Debe seleccionar un producto para agregar.", this.eTitulo);
                result = false;
            }
            return result;
        }
        public void SetearConCeroModoPago()
        {
            this.txtEfectivo.Text = "0";
            this.txtYape.Text = "0";
            this.txtTransferencia.Text = "0";
            this.txtTarjeta.Text = "0";
        }
        public void Grabar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            this.CalcularPendientePagar();

            if (this.ValidaPagoPendiente() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.AdicionarComprobante();
            this.ImprimirComprobante();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El comprobante se adiciono correctamente", this.eTitulo);


            //this.wFrm.eClaveDgvComprobante = this.ObtenerIdAmbiente();
            this.wFrm.ActualizarVentana();

            eMas.AccionPasarTextoPrincipal();
            this.Close();
        }
        public void ImprimirComprobante()
        {
      
            PrinterAPI.clsPrinter oTicket = new PrinterAPI.clsPrinter();
            oTicket.PrintNewPage();
            oTicket.PrinterOnLine();
            oTicket.PrintDataLn(("CIRCULO DE OFICIALES DE LA FF.PP.").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("R.U.C.N° 20136926455").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("Calle Lopez DE AYALA NRO. 1684").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("Lima - Lima - San Borja").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("Tel.(01)475-8384").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("E-mail: cosfup@gmail.com").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("-", 40).ToString());
            oTicket.PrintDataLn(("BOLETA ELECTRONICA").PadLeft(40).PadRight(40));
            oTicket.PrintDataLn(("B001-0004420").PadLeft(40).PadRight(40));
            oTicket.PrintEndDoc();
        }
        public bool ValidaPagoPendiente()
        {
            bool result = true;
            if (Convert.ToDecimal(this.lblPendiente.Text) != 0)
            {
                Mensaje.OperacionDenegada("Corroborar que se haya pagado correctamente.", this.eTitulo);
                result = false;
            }
            return result;
        }

        private void txtDocId_Validating(object sender, CancelEventArgs e)
        {
            this.EsClienteValido();
        }

        private void txtDocId_DoubleClick(object sender, EventArgs e)
        {
            this.ListarClientes();
        }

        private void txtDocId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarClientes(); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AgregarDetalleComprobante();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.QuitarDetalleComprobante();
        }

        private void txtCodProd_Validating(object sender, CancelEventArgs e)
        {
            this.EsProductoValido();
        }

        private void txtCodProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProducto(); }
        }

        private void txtCodProd_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProducto();
        }

        private void chEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtEfectivo.Enabled = !this.txtEfectivo.Enabled;
        }

        private void chYape_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYape.Enabled = !this.txtYape.Enabled;
        }

        private void chTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTarjeta.Enabled = !this.txtTarjeta.Enabled;
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
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

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            this.Grabar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprobante_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }
    }
}
