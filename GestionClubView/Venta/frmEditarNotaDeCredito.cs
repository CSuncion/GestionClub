using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubUtil.Util;
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
    public partial class frmEditarNotaDeCredito : Form
    {
        public frmNotaDeCredito wFrm;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        public GestionClubGeneralController oOpeGral = new GestionClubGeneralController();
        public string eTitulo = "Nota Credito";
        public List<GestionClubDetalleComprobanteDto> lObjDetalle = new List<GestionClubDetalleComprobanteDto>();
        public List<GestionClubDetalleComprobanteDto> lObjDetalleParcial = new List<GestionClubDetalleComprobanteDto>();
        Dgv.Franja eFranjaDgvComDet = Dgv.Franja.PorIndice;
        public string eClaveDgvComDet = string.Empty;
        public string NombreEmpresa = string.Empty, NroRuc = string.Empty, DireccionEmpresa = string.Empty, Ubigeo = string.Empty, Tlf = string.Empty, Email = string.Empty;
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty, RutaQR = string.Empty, RutaLogo = string.Empty;
        public frmEditarNotaDeCredito()
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
            this.MostrarNotaCredito(GestionClubComprobanteController.EnBlanco());
            this.MostrarComprobante(GestionClubComprobanteController.EnBlanco());
            this.GenerarCorrelativo();
            this.MostrarInicialTipoComprobante();
            this.MostrarTipoCambio();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtNroDoc.Focus();
        }
        public void VentanaVisualizar(GestionClubComprobanteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarNotaCredito(pObj);
            this.LLenarComprobanteDetaDeBaseDatos(pObj);
            this.MostrarComprobanteDeta();
            this.MostrarTipoCambio();
            eMas.AccionHabilitarControles(3);
            this.tsbGrabar.Enabled = false;
            this.btnQuitar.Enabled = false;
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
            this.CargarTipoDocumentosComprobante();
            this.CargarTipoDocumentos();
            this.CargarMoneda();

            //this.SetearConCeroModoPago();

            // Deshabilitar al propietario
            this.wFrm.Enabled = false;

            // Mostrar ventana
            this.Show();
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
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cboTipoDocCmp, "vvff");
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerComprobante, true, "Ser. Comprobante", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroComprobante, true, "N°. Comprobante", "vvff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.dtpFecCmp, true,"Fecha Comprobante", "ffff");
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cboMoneda, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDocId, true, "Doc, Identificación", "ffff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtApeNom, this.txtSerDoc, "ffff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cboTipDoc, "ffff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Dtp(this.dtpFecDoc, "ffff");
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGlosa, true, "Observación", "vvff", 200);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, true, "Ser. Doc.", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroDoc, true, "N°. Doc.", "ffff", 11);
            xLis.Add(xCtrl);

            return xLis;
        }
        public void GenerarCorrelativo()
        {
            this.txtSerDoc.Text = string.Empty;
            this.txtNroDoc.Text = string.Empty;
            GestionClubCorrelativoComprobanteDto gestionClubCorrelativoComprobanteDto = new GestionClubCorrelativoComprobanteDto();
            gestionClubCorrelativoComprobanteDto.tipoDocumento = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            gestionClubCorrelativoComprobanteDto = GestionClubCorrelativoComprobanteController.GenerarCorrelativo(gestionClubCorrelativoComprobanteDto);
            this.txtSerDoc.Text = "NC" + gestionClubCorrelativoComprobanteDto.serCorrelativo;
            this.txtNroDoc.Text = gestionClubCorrelativoComprobanteDto.nroCorrelativo;
        }
        public void CargarRutas()
        {
            //variables
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();

            rutaMesa = iParEN.FirstOrDefault().RutaImagenMesa; // ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = iParEN.FirstOrDefault().RutaImagenCategoria;//ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = iParEN.FirstOrDefault().RutaImagenProducto;// ConfigurationManager.AppSettings["RutaProducto"].ToString();
            RutaQR = iParEN.FirstOrDefault().RutaImagenQR;//ConfigurationManager.AppSettings["RutaQR"].ToString();
            RutaLogo = iParEN.FirstOrDefault().RutaLogoEmpresa;//ConfigurationManager.AppSettings["RutaQR"].ToString();
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
            if (this.txtCodProd.ReadOnly == true) { return; }

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
                this.txtCodProd.Focus();
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
            Cmb.Cargar(this.cboTipDoc, GestionClubGeneralController.ListarSistemaDetallePorTablaPorObs(GestionClubEnum.Sistema.DocFac.ToString(), "nota credito").OrderByDescending(x => x.idTabSistemaDetalle).ToList(), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void CargarTipoDocumentosComprobante()
        {
            object obj = GestionClubGeneralController.ListarSistemaDetallePorTablaPorObs(GestionClubEnum.Sistema.DocFac.ToString(), "pedidos")
                .Where(x => x.codigo == "01" || x.codigo == "02")
                .OrderByDescending(x => x.idTabSistemaDetalle).ToList();
            Cmb.Cargar(this.cboTipoDocCmp, obj, GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
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
                        if (this.lObjDetalle[i].cantidad.ToString() == this.nudCantidadProducto.Value.ToString())
                        {
                            var itemToRemove = lObjDetalle.Single(r => r.idProducto.ToString() == this.txtIdProd.Text);
                            this.lObjDetalle.Remove(itemToRemove);
                        }
                        else
                        {
                            Mensaje.OperacionDenegada("La cantidad que esta agregando no es el correcto.", this.wFrm.eTitulo);
                            return;
                        }
                    }
                    else
                    {
                        Mensaje.OperacionDenegada("El producto que esta agregando no es el correcto.", this.wFrm.eTitulo);
                        return;
                    }
                }
            }
            if (this.lObjDetalleParcial.Exists(x => x.idProducto.ToString() == this.txtIdProd.Text))
                this.lObjDetalle.Add(obj);
            else
            {
                Mensaje.OperacionDenegada("El producto que esta agregando no es el correcto.", this.wFrm.eTitulo);
                return;
            }

            this.MostrarComprobanteDeta();
            this.LimpiarCamposDetalleComprobante();
            this.CalcularTotalYCantidad();
            //this.CalcularPendientePagar();
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
            //this.CalcularPendientePagar();
        }
        public bool AdicionarComprobante()
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);

            GenerarArchivoComprobante.NotaCreditoElectronico(iComEN, iParEN);
            string json = string.Empty;

            //1 = envia a nubefact; 0 = no envia a nubefact
            if (ConfigurationManager.AppSettings["flagEnvioNubeFact"].ToString() == "1")
            {
                json = FacturacionElectronicaNubeFact.Main(iComEN.serComprobante + "-" + iComEN.nroComprobante, iParEN);

                if (!this.AdicionarErrors(json, iComEN))
                {
                    this.AdicionarResultado(json);
                }
            }

            this.ActualizarCorrelativoComprobante();
            int identity = GestionClubComprobanteController.AgregarComprobante(iComEN);

            GestionClubDetalleComprobanteDto iDetObjEN = new GestionClubDetalleComprobanteDto();
            this.AsignarDetalleComprobante(iDetObjEN, identity);

            iComEN.idComprobante = Convert.ToInt32(this.txtIdComprobante.Text);
            GestionClubComprobanteController.ModificarComprobanteAnulado(iComEN);
            return false;
        }
        public bool AdicionarErrors(string json, GestionClubComprobanteDto iComEN)
        {
            string[] jsonArray = json.Split('|');

            if (json.Contains("errors"))
            {
                Mensaje.OperacionDenegada(jsonArray[1], this.wFrm.eTitulo);
                GestionClubErrorNubeFactDto errors = new GestionClubErrorNubeFactDto();
                errors.tipo_de_comprobante = iComEN.tipComprobante;
                errors.serie = iComEN.serComprobante;
                errors.numero = iComEN.nroComprobante;
                errors.errors = jsonArray[1].ToString();
                errors.codigo = jsonArray[3].ToString();
                GestionClubResultadoNubeFactController.AdicionarErrorNubeFact(errors);
                return true;
            }
            return false;
        }
        public void AdicionarResultado(string json)
        {
            string[] jsonArray = json.Split('|');
            GestionClubResultadoNubeFactDto resultado = new GestionClubResultadoNubeFactDto();
            resultado.numero = jsonArray[1].ToString();
            resultado.enlace = jsonArray[3].ToString();
            resultado.sunat_ticket_numero = jsonArray[5].ToString();
            resultado.aceptada_por_sunat = jsonArray[7].ToString();
            resultado.sunat_description = jsonArray[9].ToString();
            resultado.sunat_note = jsonArray[11].ToString();
            resultado.sunat_responsecode = jsonArray[13].ToString();
            resultado.sunat_soap_error = jsonArray[15].ToString();
            resultado.pdf_zip_base64 = jsonArray[17].ToString();
            resultado.xml_zip_base64 = jsonArray[19].ToString();
            resultado.cdr_zip_base64 = jsonArray[21].ToString();
            resultado.key = jsonArray[23].ToString();
            resultado.enlace_del_pdf = jsonArray[25].ToString();
            resultado.enlace_del_xml = jsonArray[27].ToString();
            resultado.enlace_del_cdr = jsonArray[29].ToString();
            GestionClubResultadoNubeFactController.AdicionarResultadoNubeFact(resultado);
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
            pObj.serGuiaComprobante = this.txtSerComprobante.Text;
            pObj.nroGuiaComprobante = this.txtNroComprobante.Text;
            pObj.fecGuiaComprobante = Convert.ToDateTime(this.dtpFecCmp.Value.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            pObj.idNroComanda = 0;
            pObj.idAmbiente = 0;
            pObj.idMesa = 0;
            pObj.idMozo = 0;
            pObj.turnoCaja = "01";
            pObj.modPagoComprobante = "01";
            pObj.tipMovComprobante = "10";
            pObj.impEfeComprobante = 0;
            pObj.impDepComprobante = 0;
            pObj.impTarComprobante = 0;

            decimal precioReal = this.lObjDetalle.Exists(x => x.desProducto.ToLower().Contains("cancela")) ?
                (Convert.ToDecimal(this.lObjDetalle.Where(x => x.desProducto.ToLower().Contains("cancela")).Sum(x => x.preTotal)) / (1 + (iParEN.FirstOrDefault().PorcentajeIgv / 100)))
                : (Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) / (1 + (iParEN.FirstOrDefault().PorcentajeIgv / 100)));

            pObj.impBruComprobante = precioReal;

            pObj.impIgvComprobante = precioReal * (iParEN.FirstOrDefault().PorcentajeIgv / 100);

            pObj.impNetComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal));

            pObj.impDtrComprobante = 0;

            pObj.idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            pObj.nombreRazSocialCliente = this.txtApeNom.Text;
            pObj.nroIdentificacionCliente = this.txtDocId.Text;
            pObj.obsComprobante = this.txtGlosa.Text;
            pObj.estadoComprobante = "05";
            pObj.flagCancelado = false;
            pObj.idComprobante = Convert.ToInt32(this.txtIdNC.Text);
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
                pObj.codProducto = obj.codProducto;
                pObj.desProducto = obj.desProducto;
                pObj.preVenta = obj.preVenta;
                pObj.cantidad = obj.cantidad;
                pObj.preTotal = obj.preTotal;

                GestionClubComprobanteController.AgregarDetalleComprobante(pObj);
                //else
                //    GestionClubComprobanteController.ModificarDetalleComprobante(pObj);

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
            this.lObjDetalleParcial.AddRange(this.lObjDetalle);
        }
        public void MostrarComprobante(GestionClubComprobanteDto pObj)
        {
            this.txtIdComprobante.Text = pObj.idComprobante.ToString();
            this.cboMoneda.SelectedValue = pObj.codMoneda;
            this.txtDocId.Text = pObj.nroIdentificacionCliente;
            this.txtApeNom.Text = pObj.nombreRazSocialCliente;
            this.txtIdCliente.Text = pObj.idCliente.ToString();
            this.txtTipoDoc.Text = pObj.tipCliente.ToString();
            this.dtpFecCmp.Value = pObj.fecComprobante;
            this.cboTipoDocCmp.SelectedValue = pObj.tipComprobante;
        }

        public void MostrarNotaCredito(GestionClubComprobanteDto pObj)
        {
            this.txtIdNC.Text = pObj.idComprobante.ToString();
            this.cboMoneda.SelectedValue = pObj.codMoneda;
            this.txtDocId.Text = pObj.nroIdentificacionCliente;
            this.txtApeNom.Text = pObj.nombreRazSocialCliente;
            this.txtIdCliente.Text = pObj.idCliente.ToString();
            this.txtTipoDoc.Text = pObj.tipCliente.ToString();
            this.cboTipDoc.SelectedValue = pObj.tipComprobante;
            this.dtpFecDoc.Value = pObj.fecComprobante;
            this.txtSerDoc.Text = pObj.serComprobante;
            this.txtNroDoc.Text = pObj.nroComprobante;
            this.cboTipDoc.SelectedValue = "04";
            this.cboTipoDocCmp.SelectedValue = pObj.serGuiaComprobante == string.Empty ? "01" : pObj.serGuiaComprobante.Substring(0, 1) == "F" ? "01" : "02";
            this.txtSerComprobante.Text = pObj.serGuiaComprobante;
            this.txtNroComprobante.Text = pObj.nroGuiaComprobante;
            this.dtpFecCmp.Value = pObj.fecGuiaComprobante;
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

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            if (this.AdicionarComprobante()) { return; }

            this.ActualizarStockProducto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El comprobante se adiciono correctamente", this.eTitulo);

            this.ImprimirComprobante();

            this.wFrm.eClaveDgvComprobante = this.ObtenerIdComprobante();
            this.wFrm.ActualizarVentana();

            eMas.AccionPasarTextoPrincipal();
            this.Close();
        }

        public void ActualizarStockProducto()
        {
            GestionClubProductoDto xProducto;
            foreach (GestionClubDetalleComprobanteDto producto in this.lObjDetalle)
            {
                xProducto = new GestionClubProductoDto();
                xProducto.idProducto = producto.idProducto;
                xProducto = GestionClubProductoController.BuscarProductoXId(xProducto);
                if (xProducto.idCategoria == "0103"
                    || xProducto.idCategoria == "0106"
                    || xProducto.idCategoria == "0108"
                    || xProducto.idCategoria == "0112"
                    )
                {
                    xProducto.idProducto = producto.idProducto;
                    xProducto.stockProducto += producto.cantidad;
                    GestionClubProductoController.ActualizarStockProducto(xProducto);
                }
            }
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


        public void ImprimirComprobante()
        {
            PrintDocument printDocument = new PrintDocument();
            PaperSize ps = new PaperSize("", 420, 840);
            printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            printDocument.PrintController = new StandardPrintController();
            printDocument.DefaultPageSettings.Margins.Left = 0;
            printDocument.DefaultPageSettings.Margins.Right = 0;
            printDocument.DefaultPageSettings.Margins.Top = 0;
            printDocument.DefaultPageSettings.Margins.Bottom = 0;
            printDocument.DefaultPageSettings.PaperSize = ps;
            printDocument.Print();
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);

            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
            string title = this.RutaLogo + "logo-cosfup.ico";
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


            g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);
            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);

            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);
            g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);


            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Referencia:", fBody, sb, 10, SPACE + 75);
            g.DrawString(iComEN.serGuiaComprobante + " - " + iComEN.nroGuiaComprobante, fBodyNoBold, sb, 90, SPACE + 75);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString("", fBodyNoBold, sb, 90, SPACE + 95); ;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 100);
            g.DrawString("P. Unit.", fBody, sb, 10, SPACE + 115);
            g.DrawString("Descripción", fBody, sb, 80, SPACE + 115);
            g.DrawString("Cant.", fBody, sb, 180, SPACE + 115);
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
                g.DrawString(item.desProducto.Substring(0, item.desProducto.Length > 20 ? 20 : item.desProducto.Length), fBodyNoBoldFood, sb, 50, SPACE + (saltoLinea));
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

            e.Graphics.DrawString(Formato.NumeroDecimal(iComEN.impBruComprobante.ToString(), 2), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString(subtotal.ToString(), fBody, sb, 230, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total No Gravado:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);

            e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
            //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);


            saltoLinea = saltoLinea + 15;
            g.DrawString("IGV " + Convert.ToInt32(iParEN.FirstOrDefault().PorcentajeIgv).ToString() + "%", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);

            igv = Formato.NumeroDecimal(iComEN.impIgvComprobante.ToString(), 2);

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
            //this.CalcularPendientePagar();
            bool result = true;
            //if (Convert.ToDecimal(this.lblPendiente.Text) != 0)
            //{
            //    Mensaje.OperacionDenegada("Corroborar que se haya pagado correctamente.", this.eTitulo);
            //    result = false;
            //}
            return result;
        }
        public void ActualizarCorrelativoComprobante()
        {
            this.GenerarCorrelativo();
            GestionClubCorrelativoComprobanteDto obj = new GestionClubCorrelativoComprobanteDto();
            obj.tipoDocumento = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            obj.serCorrelativo = this.txtSerDoc.Text.Substring(2);
            obj.nroCorrelativo = this.txtNroDoc.Text;
            GestionClubCorrelativoComprobanteController.ActualizarCorrelativo(obj);
        }
        public void VentanaModificar(GestionClubComprobanteDto pObj)
        {
            this.InicializaVentana();
            this.MostrarComprobante(pObj);
            this.LLenarComprobanteDetaDeBaseDatos(pObj);
            this.MostrarComprobanteDeta();
            this.CalcularTotalYCantidad();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDocId.Focus();
        }
        public void BuscarComprobante()
        {
            GestionClubComprobanteDto gestionClubComprobanteDto = new GestionClubComprobanteDto();
            gestionClubComprobanteDto.tipComprobante = Cmb.ObtenerValor(this.cboTipoDocCmp, string.Empty);
            gestionClubComprobanteDto.serComprobante = this.txtSerComprobante.Text;
            gestionClubComprobanteDto.nroComprobante = this.txtNroComprobante.Text;
            gestionClubComprobanteDto = GestionClubComprobanteController.ListaComprobantePorNroComprobante(gestionClubComprobanteDto);
            if (gestionClubComprobanteDto.estadoComprobante == "04") { Mensaje.OperacionDenegada("Comprobante se encuentra anulado.", this.wFrm.eTitulo); return; }
            this.MostrarComprobante(gestionClubComprobanteDto);
            this.LLenarComprobanteDetaDeBaseDatos(gestionClubComprobanteDto);
            this.MostrarComprobanteDeta();
            this.CalcularTotalYCantidad();
        }
        public void MostrarInicialTipoComprobante()
        {
            this.txtSerComprobante.Text = Cmb.ObtenerTexto(this.cboTipoDocCmp).Substring(0, 1);
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
            //this.CalcularPendientePagar();
            this.AgregarDetalleComprobante();
        }

        private void txtNroComprobante_Validating(object sender, CancelEventArgs e)
        {
            this.BuscarComprobante();
        }

        private void cboTipoDocCmp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarInicialTipoComprobante();
        }

        private void txtSerComprobante_Validating(object sender, CancelEventArgs e)
        {
            //this.BuscarComprobante();
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarTipoCambio();
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


        private void cboTipDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GenerarCorrelativo();
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
