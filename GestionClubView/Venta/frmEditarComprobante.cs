using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Listas;
using GestionClubView.Maestros;
using GestionClubView.MdiPrincipal;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Venta
{
    public partial class frmEditarComprobante : Form
    {
        public frmComprobantes wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public string eTitulo = "Comprobante";
        public List<GestionClubDetalleComprobanteDto> lObjDetalle = new List<GestionClubDetalleComprobanteDto>();
        Dgv.Franja eFranjaDgvComDet = Dgv.Franja.PorIndice;
        public string eClaveDgvComDet = string.Empty;
        public string NombreEmpresa = string.Empty, NroRuc = string.Empty, DireccionEmpresa = string.Empty, Ubigeo = string.Empty, Tlf = string.Empty, Email = string.Empty;
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty, RutaQR = string.Empty;
        Dgv.Franja eFranjaDgvCliente = Dgv.Franja.PorIndice;
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
            this.MostrarComprobante(GestionClubComprobanteController.EnBlanco());
            this.GenerarCorrelativo();
            this.MostrarTipoCambio();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtNroDoc.Focus();
        }
        public void VentanaVisualizar(GestionClubComprobanteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarComprobante(pObj);
            this.LLenarComprobanteDetaDeBaseDatos(pObj);
            this.MostrarComprobanteDeta();
            this.MostrarTipoCambio();
            eMas.AccionHabilitarControles(3);
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.CargarDatosEmpresa();
            this.CargarRutas();
            this.CargarTipoDocumentos();
            this.CargarMoneda();
            this.SetearConCeroModoPago();
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
            xCtrl.TxtTodo(this.txtDocId, true, "Doc, Identificación", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtApeNom, this.txtSerDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cboTipDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, true, "Ser. Doc.", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroDoc, true, "N°. Doc.", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cboMoneda, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGlosa, false, "Observación", "vvff", 200);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipoCambio, true, "Tipo de Cambio", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtEfectivo, true, "Efectivo", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtDeposito, true, "Tarjeta", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTransferencia, true, "Transferencia", "vvff", 2);
            xLis.Add(xCtrl);


            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtCodProd, this.nudCantidadProducto, "ffff");
            //xLis.Add(xCtrl);


            return xLis;
        }
        public void LimpiarCliente()
        {
            if (Cmb.ObtenerValor(this.cboTipDoc, string.Empty) == "01")
            {
                this.txtDocId.Text = string.Empty;
                this.txtApeNom.Text = string.Empty;
                this.txtIdCliente.Text = string.Empty;
                this.txtTipoDoc.Text = string.Empty;
            }
        }
        public void GenerarCorrelativo()
        {
            this.txtSerDoc.Text = string.Empty;
            this.txtNroDoc.Text = string.Empty;
            GestionClubCorrelativoComprobanteDto gestionClubCorrelativoComprobanteDto = new GestionClubCorrelativoComprobanteDto();
            gestionClubCorrelativoComprobanteDto.tipoDocumento = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            gestionClubCorrelativoComprobanteDto = GestionClubCorrelativoComprobanteController.GenerarCorrelativo(gestionClubCorrelativoComprobanteDto);
            this.txtSerDoc.Text = Cmb.ObtenerTexto(this.cboTipDoc).Substring(0, 1) + gestionClubCorrelativoComprobanteDto.serCorrelativo;
            this.txtNroDoc.Text = gestionClubCorrelativoComprobanteDto.nroCorrelativo;
        }
        public void MostrarTipoCambio()
        {
            if (!this.ValidaTipoCambio()) return;
            GestionClubTipoCambioDto gestionClubTipoCambioDto = new GestionClubTipoCambioDto();
            gestionClubTipoCambioDto.FechaTipoCambio = this.dtpFecDoc.Value.ToString();
            gestionClubTipoCambioDto = GestionClubTipoCambioController.ListarTipoCambioPorFecha(gestionClubTipoCambioDto);

            if (Cmb.ObtenerValor(this.cboMoneda, string.Empty) == "01")
                this.txtTipoCambio.Text = gestionClubTipoCambioDto.CompraTipoCambio.ToString();
            else
                this.txtTipoCambio.Text = gestionClubTipoCambioDto.VentaTipoCambio.ToString();
        }
        public bool ValidaTipoCambio()
        {
            bool result = true;
            GestionClubTipoCambioDto gestionClubTipoCambioDto = new GestionClubTipoCambioDto();
            gestionClubTipoCambioDto.FechaTipoCambio = DateTime.Now.ToString();
            gestionClubTipoCambioDto = GestionClubTipoCambioController.ListarTipoCambioPorFecha(gestionClubTipoCambioDto);

            if (gestionClubTipoCambioDto.idTipoCambio == 0) { Mensaje.OperacionDenegada("Debe ingresar tipo de cambio.", this.eTitulo); result = false; }

            return result;
        }
        public void CargarRutas()
        {
            //variables
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();

            rutaMesa = iParEN.FirstOrDefault().RutaImagenMesa; // ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = iParEN.FirstOrDefault().RutaImagenCategoria;//ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = iParEN.FirstOrDefault().RutaImagenProducto;// ConfigurationManager.AppSettings["RutaProducto"].ToString();
            RutaQR = iParEN.FirstOrDefault().RutaImagenQR;//ConfigurationManager.AppSettings["RutaQR"].ToString();
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
            win.tipCliente = Cmb.ObtenerTexto(this.cboTipDoc).ToLower() == "factura" ? "02" : "01";
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
            this.txtTipoDoc.Text = iCliEN.tipCliente;

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
            win.eCondicionLista = frmListarProducto.Condicion.ProductosComprobante;
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
            Cmb.Cargar(this.cboTipDoc, GestionClubGeneralController.ListarSistemaDetallePorTablaPorObs(GestionClubEnum.Sistema.DocFac.ToString(), "pedidos").OrderByDescending(x => x.idTabSistemaDetalle).ToList(), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarMoneda()
        {
            Cmb.Cargar(this.cboMoneda, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.Moneda.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }

        public void AgregarDetalleComprobante()
        {
            if (!this.ValidaProductoAgrega()) return;

            if (!this.ValidaCantidadMayorCero()) return;

            if (!this.ValidaPrecioMayorCero()) return;

            GestionClubDetalleComprobanteDto obj = new GestionClubDetalleComprobanteDto();
            obj.idComprobante = 0;
            obj.idDetalleComprobante = 0;
            obj.estadoDetalleComprobante = "05";
            obj.obsDetalleComprobante = this.txtGlosa.Text;
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
            this.lblTotal.Text = Formato.NumeroDecimal(Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)), 2);
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
            this.ActualizarCorrelativoComprobante();
            int identity = GestionClubComprobanteController.AgregarComprobante(iComEN);


            GestionClubDetalleComprobanteDto iDetObjEN = new GestionClubDetalleComprobanteDto();
            this.AsignarDetalleComprobante(iDetObjEN, identity);

        }
        public void AsignarComprobante(GestionClubComprobanteDto pObj)
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            pObj.idEmpresa = Convert.ToInt32(Universal.gIdEmpresa);
            pObj.tipComprobante = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            pObj.serComprobante = this.txtSerDoc.Text.Trim();
            pObj.nroComprobante = this.txtNroDoc.Text.Trim();
            pObj.fecComprobante = Convert.ToDateTime(this.dtpFecDoc.Value.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            pObj.codMoneda = Cmb.ObtenerValor(this.cboMoneda, string.Empty);
            pObj.impCambio = Convert.ToDecimal(this.txtTipoCambio.Text);
            pObj.serGuiaComprobante = string.Empty;
            pObj.nroGuiaComprobante = string.Empty;
            pObj.fecGuiaComprobante = DateTime.Now;
            pObj.idNroComanda = 0;
            pObj.idAmbiente = 0;
            pObj.idMesa = 0;
            pObj.idMozo = 0;
            pObj.turnoCaja = "01";
            pObj.modPagoComprobante = this.modoPago();
            pObj.tipMovComprobante = "20";
            pObj.impEfeComprobante = Convert.ToDecimal(this.txtEfectivo.Text);
            pObj.impDepComprobante = Convert.ToDecimal(this.txtDeposito.Text);
            pObj.impTarComprobante = Convert.ToDecimal(this.txtTransferencia.Text);
            pObj.impBruComprobante = !this.ValidarItemParaTicket() ? Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) :
                Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) - Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * (iParEN.FirstOrDefault().PorcentajeIgv / 100);
            pObj.impIgvComprobante = !this.ValidarItemParaTicket() ? 0 :
                Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * (iParEN.FirstOrDefault().PorcentajeIgv / 100);
            pObj.impDtrComprobante = !this.ValidarItemParaFacturar() ? Convert.ToDecimal(Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * (iParEN.FirstOrDefault().PorcentajeDetra / 100))
                : 0;
            pObj.impNetComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal));
            pObj.tipCliente = this.txtTipoDoc.Text;
            pObj.idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            pObj.nombreRazSocialCliente = this.txtApeNom.Text;
            pObj.nroIdentificacionCliente = this.txtDocId.Text;
            pObj.obsComprobante = this.txtGlosa.Text;
            pObj.estadoComprobante = "05";
            pObj.idComprobante = Convert.ToInt32(this.txtIdComprobante.Text);
        }
        public bool ValidarItemParaFacturar()
        {
            bool result = false;
            if (this.lObjDetalle.Count > 0)
                if (this.lObjDetalle.Exists(x => x.codProducto.Substring(0, 2).Contains("06")))
                {
                    result = true;
                }

            if (result)
                if (this.lObjDetalle.Count > 1)
                {
                    Mensaje.OperacionDenegada("Solo debe existir servicio de Evento, debido que contiene detracción.", this.wFrm.eTitulo);
                    result = true;
                }
                else
                    result = false;

            return result;
        }
        public bool ValidarComprobanteFactura()
        {
            bool result = false;
            if (this.lObjDetalle.Count > 0)
                if (this.lObjDetalle.Exists(x => x.codProducto.Substring(0, 2).Contains("06")))
                {
                    result = true;
                }

            if (result)
                if (Cmb.ObtenerValor(this.cboTipDoc, string.Empty) == "02" || Cmb.ObtenerValor(this.cboTipDoc, string.Empty) == "03")
                {
                    Mensaje.OperacionDenegada("Debe ser factura, si contiene un item para Eventos.", this.wFrm.eTitulo);
                    result = true;
                }
                else
                    result = false;

            return result;
        }
        public void AsignarDetalleComprobante(GestionClubDetalleComprobanteDto pObj, int identity)
        {
            pObj.idComprobante = identity;
            pObj.estadoDetalleComprobante = "05";
            pObj.obsDetalleComprobante = this.txtGlosa.Text;
            foreach (GestionClubDetalleComprobanteDto obj in this.lObjDetalle)
            {
                pObj.idDetalleComprobante = obj.idDetalleComprobante;
                pObj.idProducto = obj.idProducto;
                pObj.preVenta = obj.preVenta;
                pObj.cantidad = obj.cantidad;
                pObj.preTotal = obj.preTotal;

                if (pObj.idDetalleComprobante == 0)
                    GestionClubComprobanteController.AgregarDetalleComprobante(pObj);
                else
                    GestionClubComprobanteController.ModificarDetalleComprobante(pObj);

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
        public void LLenarComprobanteDetaDeBaseDatos(GestionClubComprobanteDto pObj)
        {
            GestionClubDetalleComprobanteDto iComDetEN = new GestionClubDetalleComprobanteDto();
            iComDetEN.idComprobante = pObj.idComprobante;
            iComDetEN.Adicionales.CampoOrden = GestionClubDetalleComprobanteDto._idDetalleComprobante;
            this.lObjDetalle = GestionClubComprobanteController.ListarDetallesComprobantesPorComprobante(iComDetEN);
        }
        public void MostrarComprobante(GestionClubComprobanteDto pObj)
        {
            this.txtIdComprobante.Text = pObj.idComprobante.ToString();
            this.cboMoneda.SelectedValue = pObj.codMoneda;
            this.txtDocId.Text = pObj.nroIdentificacionCliente;
            this.txtApeNom.Text = pObj.nombreRazSocialCliente;
            this.txtIdCliente.Text = pObj.idCliente.ToString();
            this.txtTipoDoc.Text = pObj.tipCliente.ToString();
            this.cboTipDoc.SelectedValue = pObj.tipComprobante;
            this.dtpFecDoc.Text = pObj.fecComprobante.ToShortDateString();
            this.txtSerDoc.Text = pObj.serComprobante;
            this.txtNroDoc.Text = pObj.nroComprobante;

            this.txtEfectivo.Text = pObj.impEfeComprobante.ToString();
            if (pObj.impEfeComprobante > 0)
                this.chEfectivo.Checked = true;

            this.txtDeposito.Text = pObj.impDepComprobante.ToString();
            if (pObj.impDepComprobante > 0)
                this.chDeposito.Checked = true;

            this.txtTransferencia.Text = pObj.impTarComprobante.ToString();
            if (pObj.impTarComprobante > 0)
                this.chTransferencia.Checked = true;


        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._codProducto, "Código", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._desProducto, "Producto", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(GestionClubDetalleComprobanteDto._preVenta, "Precio", 80, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._cantidad, "Cantidad", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(GestionClubDetalleComprobanteDto._preTotal, "Total", 80, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._idProducto, "idProducto", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(GestionClubDetalleComprobanteDto._idDetalleComprobante, "idDetalleComprobante", 50, false));
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
            if (this.chDeposito.Checked) { cantidadCheck++; modoPago = "02"; }
            if (this.chTransferencia.Checked) { cantidadCheck++; modoPago = "03"; }
            if (cantidadCheck > 1) modoPago = "04";

            return modoPago;
        }
        public void CalcularPendientePagar()
        {
            this.txtEfectivo.Text = Formato.NumeroDecimal(this.txtEfectivo.Text, 2);
            this.txtDeposito.Text = Formato.NumeroDecimal(this.txtDeposito.Text, 2);
            this.txtTransferencia.Text = Formato.NumeroDecimal(this.txtTransferencia.Text, 2);
            this.lblPendiente.Text = Formato.NumeroDecimal(Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtDeposito.Text) + Convert.ToDecimal(this.txtEfectivo.Text)), 2);
        }
        public bool ValidaPrecioMayorCero()
        {
            bool result = true;
            if (Convert.ToDecimal(this.txtPrecio.Text) <= 0)
            {
                Mensaje.OperacionDenegada("El precio debe ser mayor a 0.", this.eTitulo);
                result = false;
            }
            return result;
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
            this.txtDeposito.Text = "0";
            this.txtTransferencia.Text = "0";
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

            if (this.ValidaPagoPendiente() == false) { return; };

            if (this.ValidarItemParaFacturar()) { return; }

            if (this.ValidarComprobanteFactura()) { return; }

            if (this.ValidarItemParaTicket()) { return; }

            if (this.ValidarComprobanteTicket()) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.AdicionarComprobante();
            this.ActualizarStockProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El comprobante se adiciono correctamente", this.eTitulo);

            this.ImprimirComprobante();

            this.wFrm.eClaveDgvComprobante = this.ObtenerIdComprobante();
            this.wFrm.ActualizarVentana();

            eMas.AccionPasarTextoPrincipal();
            this.Close();
        }

        public bool ValidarItemParaTicket()
        {
            bool result = false;
            int cantidadItems = this.lObjDetalle.Count;
            int cantidad = 0;
            if (cantidadItems == 1)
            {
                return false;
            }

            if (cantidadItems > 1)
            {
                for (int i = 0; i < cantidadItems; i++)
                {
                    if (this.lObjDetalle.Exists(x => x.codProducto.StartsWith("02")))
                    {
                        if (!this.lObjDetalle[i].codProducto.StartsWith("02"))
                        {
                            cantidad += 1;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (cantidad > 0)
            {
                Mensaje.OperacionDenegada("Hay aportes en los items, validar bien lo agregado.", this.wFrm.eTitulo);
                result = true;
            }
            return result;
        }
        public bool ValidarComprobanteTicket()
        {
            bool result = false;
            if (this.lObjDetalle.Count > 0)
                foreach (GestionClubDetalleComprobanteDto item in this.lObjDetalle)
                {
                    if (item.codProducto.Substring(0, 2) == "02")
                    {
                        result = true;
                    }
                }

            if (result)
                if (Cmb.ObtenerValor(this.cboTipDoc, string.Empty) == "02" || Cmb.ObtenerValor(this.cboTipDoc, string.Empty) == "01")
                {
                    Mensaje.OperacionDenegada("Debe ser ticket, si contiene un item para aportes.", this.wFrm.eTitulo);
                    result = true;
                }
                else
                    result = false;

            return result;
        }


        public void ActualizarStockProducto()
        {
            GestionClubProductoDto xProducto;
            foreach (GestionClubDetalleComprobanteDto producto in this.lObjDetalle)
            {
                xProducto = new GestionClubProductoDto();
                xProducto.idProducto = producto.idProducto;
                xProducto.stockProducto -= producto.cantidad;
                GestionClubProductoController.ActualizarStockProducto(xProducto);
            }
        }
        public bool ValidaMontoSeanMayoresACero()
        {
            this.CalcularPendientePagar();
            bool result = false;
            if (this.lblPendiente.Text != "0.00") result = true;

            if (result) Mensaje.OperacionDenegada("No a ingresado monto en los pagos", this.eTitulo);

            return result;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoModificarComprobante().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarComprobante();
            //this.ActualizarStockProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Comprobante se modifico correctamente", this.wFrm.eTitulo);

            this.ImprimirComprobante();

            //actualizar al wUsu
            this.wFrm.eClaveDgvComprobante = this.ObtenerIdComprobante();
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public string ObtenerIdComprobante()
        {
            //asignar parametros
            GestionClubComprobanteDto iAmbEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iAmbEN);

            //devolver
            return iAmbEN.idAmbiente.ToString();
        }
        public void ModificarComprobante()
        {
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);
            iComEN = GestionClubComprobanteController.BuscarComprobanteXId(iComEN);
            this.AsignarComprobante(iComEN);
            GestionClubComprobanteController.ModificarComprobante(iComEN);

            GestionClubDetalleComprobanteDto iDetObjEN = new GestionClubDetalleComprobanteDto();
            this.AsignarDetalleComprobante(iDetObjEN, Convert.ToInt32(this.txtIdComprobante.Text));
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsActoEliminarComprobante().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //eliminar el registro
            //this.EliminarAmbiente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Comprobante se elimino correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void CargarDatosEmpresa()
        {
            NombreEmpresa = ConfigurationManager.AppSettings["NombreEmpresa"].ToString();
            NroRuc = ConfigurationManager.AppSettings["NroRuc"].ToString();
            DireccionEmpresa = ConfigurationManager.AppSettings["DireccionEmpresa"].ToString();
            Ubigeo = ConfigurationManager.AppSettings["Ubigeo"].ToString();
            Tlf = ConfigurationManager.AppSettings["Tlf"].ToString();
            Email = ConfigurationManager.AppSettings["Email"].ToString();
        }
        public string modoDescriPago()
        {
            string modoPago = string.Empty;
            int cantidadCheck = 0;

            if (this.chEfectivo.Checked) { cantidadCheck++; modoPago = "EFECTIVO"; }
            if (this.chDeposito.Checked) { cantidadCheck++; modoPago = "DEPOSITO"; }
            if (this.chTransferencia.Checked) { cantidadCheck++; modoPago = "TRANSFERENCIA"; }
            if (cantidadCheck > 1) modoPago = "MIXTO";

            return modoPago;
        }

        public void ImprimirComprobante()
        {
            PrintDocument printDocument = new PrintDocument();
            PaperSize ps = new PaperSize("", 420, 840);
            if (Mensaje.DeseasRealizarOperacion("¿Desea comprobante detallado?", this.eTitulo))
                printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPageDetallado);
            else
                printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPageConsumo);



            printDocument.PrintController = new StandardPrintController();
            printDocument.DefaultPageSettings.Margins.Left = 0;
            printDocument.DefaultPageSettings.Margins.Right = 0;
            printDocument.DefaultPageSettings.Margins.Top = 0;
            printDocument.DefaultPageSettings.Margins.Bottom = 0;
            printDocument.DefaultPageSettings.PaperSize = ps;
            printDocument.Print();
        }
        void pd_PrintPageConsumo(object sender, PrintPageEventArgs e)
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);

            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
            string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "cosfupico.ico";
            g.DrawImage(Image.FromFile(title), 100, 7);

            Font fBody = new Font("Calibri", 8, FontStyle.Bold);
            Font fHead = new Font("Calibri", 9, FontStyle.Bold);
            Font fBodyNoBoldFood = new Font("Calibri", 7, FontStyle.Regular);
            Font fBodyNoBold = new Font("Calibri", 8, FontStyle.Regular);
            Font fBodySerNro = new Font("Calibri", 9, FontStyle.Regular);
            Font fBodyTitle = new Font("Calibri", 10, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);

            g.DrawString(this.NombreEmpresa, fBodyTitle, sb, 30, 100);
            g.DrawString("R.U.C. N° " + this.NroRuc, fHead, sb, 65, 120);
            g.DrawString(this.DireccionEmpresa, fHead, sb, 45, 140);
            g.DrawString(this.Ubigeo, fHead, sb, 70, 155);
            g.DrawString("Tel." + this.Tlf, fHead, sb, 85, 170);
            g.DrawString("E-mail: " + this.Email, fHead, sb, 70, 185);
            g.DrawString("______________________________________________", fBody, sb, 10, 190);

            int SPACE = 240;

            if (Cmb.ObtenerValor(this.cboTipDoc).ToUpper() == "03")
                g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper(), fHead, sb, 100, 205);
            else
                g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);


            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);

            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);

            if (Cmb.ObtenerValor(this.cboTipDoc).ToUpper() == "01")
                g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
            else
                g.DrawString(iComEN.nroIdentificacionCliente.Substring(iComEN.nroIdentificacionCliente.Length - 8, 8), fBodyNoBold, sb, 90, SPACE + 30);

            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);


            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString(this.modoDescriPago(), fBodyNoBold, sb, 90, SPACE + 95); ;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 100);
            g.DrawString("Cant.", fBody, sb, 10, SPACE + 115);
            g.DrawString("Descripción", fBody, sb, 80, SPACE + 115);
            g.DrawString("P. Unit.", fBody, sb, 180, SPACE + 115);
            g.DrawString("Total", fBody, sb, 230, SPACE + 115);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 120);

            int saltoLinea = 120;
            decimal total = 0, precio = 0, precioPorCantidad = 0;
            string subtotal = string.Empty, igv = string.Empty;
            int cantidad = 0;
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            formato.LineAlignment = StringAlignment.Far;
            //format.LineAlignment = StringAlignment.;

            foreach (GestionClubDetalleComprobanteDto item in this.lObjDetalle)
            {
                cantidad += item.cantidad;

                precio += item.preVenta;

                precioPorCantidad += (Convert.ToDecimal(item.preVenta) * Convert.ToInt32(item.cantidad));

                total += Convert.ToDecimal(item.preVenta) * Convert.ToInt32(item.cantidad);
            }


            saltoLinea = saltoLinea + 15;

            g.DrawString(cantidad.ToString(), fBodyNoBold, sb, 10, SPACE + (saltoLinea)); //precio            
            g.DrawString("Por consumo", fBodyNoBold, sb, 50, SPACE + (saltoLinea));//descripcion
            g.DrawString(precio.ToString(), fBodyNoBold, sb, 180, SPACE + (saltoLinea));//cantidad
            e.Graphics.DrawString(precioPorCantidad.ToString(), fBodyNoBold, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);//precio por cantidad

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total Gravado:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            subtotal = Formato.NumeroDecimal(Convert.ToDecimal(total) - (Convert.ToDecimal(total) * Convert.ToDecimal(0.18)), 2);

            e.Graphics.DrawString(subtotal.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString(subtotal.ToString(), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total No Gravado:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);

            e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);


            saltoLinea = saltoLinea + 15;
            g.DrawString("IGV " + Convert.ToInt32(iParEN.FirstOrDefault().PorcentajeIgv).ToString() + "%", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            igv = Formato.NumeroDecimal(Convert.ToDecimal(total) * (iParEN.FirstOrDefault().PorcentajeIgv / 100), 2);
            e.Graphics.DrawString(igv.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString(igv.ToString(), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Descuento:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Importe Total:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            e.Graphics.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);

            //g.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 30;
            g.DrawString(Formato.MontoComprobanteEnLetras(total, Cmb.ObtenerTexto(this.cboMoneda).ToUpper()), fBodyNoBold, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            string tipoDoc = this.txtTipoDoc.Text == "01" ? "DNI" : "RUC";

            string datosQR = this.NroRuc + "|" + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + "|" + tipoDoc + "|" + iComEN.nroIdentificacionCliente + "|" + iComEN.serComprobante + "|" + iComEN.nroComprobante + "|" + iComEN.fecComprobante.ToShortDateString() + "|" + total.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string fileName = Path.Combine(RutaQR, DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_QRCode.png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa de la " + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + " ELECTRONICA", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa del comprobante electronico puede ser", fBodyNoBoldFood, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("consultado en https://www.nubefact.com/buscar", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Autorizado mediante resolución de intenencia", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);


            saltoLinea = saltoLinea + 15;
            g.DrawImage(Image.FromFile(fileName), 100, SPACE + saltoLinea, 100, 100);

            saltoLinea = saltoLinea + 100;
            g.DrawString(".", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);


            g.Dispose();
        }
        void pd_PrintPageDetallado(object sender, PrintPageEventArgs e)
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);

            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
            string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "cosfupico.ico";
            g.DrawImage(Image.FromFile(title), 100, 7);

            Font fBody = new Font("Calibri", 8, FontStyle.Bold);
            Font fHead = new Font("Calibri", 9, FontStyle.Bold);
            Font fBodyNoBoldFood = new Font("Calibri", 7, FontStyle.Regular);
            Font fBodyNoBold = new Font("Calibri", 8, FontStyle.Regular);
            Font fBodySerNro = new Font("Calibri", 9, FontStyle.Regular);
            Font fBodyTitle = new Font("Calibri", 10, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);

            g.DrawString(this.NombreEmpresa, fBodyTitle, sb, 30, 100);
            g.DrawString("R.U.C. N° " + this.NroRuc, fHead, sb, 65, 120);
            g.DrawString(this.DireccionEmpresa, fHead, sb, 45, 140);
            g.DrawString(this.Ubigeo, fHead, sb, 70, 155);
            g.DrawString("Tel." + this.Tlf, fHead, sb, 85, 170);
            g.DrawString("E-mail: " + this.Email, fHead, sb, 70, 185);
            g.DrawString("______________________________________________", fBody, sb, 10, 190);

            int SPACE = 240;

            if (Cmb.ObtenerValor(this.cboTipDoc).ToUpper() == "03")
                g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper(), fHead, sb, 100, 205);
            else
                g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);


            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);

            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);

            if (Cmb.ObtenerValor(this.cboTipDoc).ToUpper() == "01")
                g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
            else
                g.DrawString(iComEN.nroIdentificacionCliente.Substring(iComEN.nroIdentificacionCliente.Length - 8, 8), fBodyNoBold, sb, 90, SPACE + 30);

            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);


            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString(this.modoDescriPago(), fBodyNoBold, sb, 90, SPACE + 95); ;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 100);
            g.DrawString("Cant.", fBody, sb, 10, SPACE + 115);
            g.DrawString("Descripción", fBody, sb, 80, SPACE + 115);
            g.DrawString("P. Unit.", fBody, sb, 180, SPACE + 115);
            g.DrawString("Total", fBody, sb, 230, SPACE + 115);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 120);

            int saltoLinea = 120;
            decimal total = 0;
            string subtotal = string.Empty, igv = string.Empty;

            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            formato.LineAlignment = StringAlignment.Far;
            //format.LineAlignment = StringAlignment.;

            foreach (GestionClubDetalleComprobanteDto item in this.lObjDetalle)
            {
                saltoLinea = saltoLinea + 15;
                g.DrawString(item.cantidad.ToString(), fBodyNoBold, sb, 180, SPACE + (saltoLinea));
                g.DrawString(item.desProducto, fBodyNoBold, sb, 50, SPACE + (saltoLinea));
                g.DrawString(item.preVenta.ToString(), fBodyNoBold, sb, 10, SPACE + (saltoLinea));


                string precioPorCantidad = ((Convert.ToDecimal(item.preVenta) * Convert.ToInt32(item.cantidad))).ToString();

                e.Graphics.DrawString(precioPorCantidad, fBodyNoBold, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);

                total += Convert.ToDecimal(item.preVenta) * Convert.ToInt32(item.cantidad);
            }

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total Gravado:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            subtotal = Formato.NumeroDecimal(Convert.ToDecimal(total) - (Convert.ToDecimal(total) * Convert.ToDecimal(0.18)), 2);

            e.Graphics.DrawString(subtotal.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString(subtotal.ToString(), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total No Gravado:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);

            e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);


            saltoLinea = saltoLinea + 15;
            g.DrawString("IGV " + Convert.ToInt32(iParEN.FirstOrDefault().PorcentajeIgv).ToString() + "%", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            igv = Formato.NumeroDecimal(Convert.ToDecimal(total) * (iParEN.FirstOrDefault().PorcentajeIgv / 100), 2);
            e.Graphics.DrawString(igv.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString(igv.ToString(), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Descuento:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Importe Total:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            e.Graphics.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);

            //g.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 30;
            g.DrawString(Formato.MontoComprobanteEnLetras(total, Cmb.ObtenerTexto(this.cboMoneda).ToUpper()), fBodyNoBold, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            string tipoDoc = this.txtTipoDoc.Text == "01" ? "DNI" : "RUC";

            string datosQR = this.NroRuc + "|" + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + "|" + tipoDoc + "|" + iComEN.nroIdentificacionCliente + "|" + iComEN.serComprobante + "|" + iComEN.nroComprobante + "|" + iComEN.fecComprobante.ToShortDateString() + "|" + total.ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string fileName = Path.Combine(RutaQR, DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_QRCode.png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa de la " + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + " ELECTRONICA", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa del comprobante electronico puede ser", fBodyNoBoldFood, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("consultado en https://www.nubefact.com/buscar", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Autorizado mediante resolución de intenencia", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);


            saltoLinea = saltoLinea + 15;
            g.DrawImage(Image.FromFile(fileName), 100, SPACE + saltoLinea, 100, 100);

            saltoLinea = saltoLinea + 100;
            g.DrawString(".", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);


            g.Dispose();
        }

        public void ImprimirPreTicket()
        {
            this.ImprimirComprobante();
        }
        public bool ValidaPagoPendiente()
        {
            this.CalcularPendientePagar();
            bool result = true;
            if (Convert.ToDecimal(this.lblPendiente.Text) != 0)
            {
                Mensaje.OperacionDenegada("Corroborar que se haya pagado correctamente.", this.eTitulo);
                result = false;
            }
            return result;
        }
        public void ActualizarCorrelativoComprobante()
        {
            this.GenerarCorrelativo();
            GestionClubCorrelativoComprobanteDto obj = new GestionClubCorrelativoComprobanteDto();
            obj.tipoDocumento = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            obj.serCorrelativo = this.txtSerDoc.Text.Substring(1);
            obj.nroCorrelativo = this.txtNroDoc.Text;
            GestionClubCorrelativoComprobanteController.ActualizarCorrelativo(obj);
        }
        public void VentanaModificar(GestionClubComprobanteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarComprobante(pObj);
            this.LLenarComprobanteDetaDeBaseDatos(pObj);
            this.MostrarComprobanteDeta();
            this.MostrarTipoCambio();
            this.CalcularTotalYCantidad();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDocId.Focus();
        }
        public void RegistrarCliente()
        {
            frmEditarClientes win = new frmEditarClientes();
            win.wFrm2 = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCliente = Dgv.Franja.PorValor;
            win.Formulario = "Comprobante";
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
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
            if (e.KeyCode == Keys.F2) { this.RegistrarCliente(); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
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

        private void chDeposito_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDeposito.Enabled = !this.txtDeposito.Enabled;
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarTipoCambio();
        }

        private void cboTipDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimpiarCliente();
            this.GenerarCorrelativo();
        }

        private void txtDeposito_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
        }

        private void txtEfectivo_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void txtTransferencia_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
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
