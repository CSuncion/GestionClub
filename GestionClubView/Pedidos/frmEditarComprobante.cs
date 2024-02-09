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
        public string NombreEmpresa = string.Empty, NroRuc = string.Empty, DireccionEmpresa = string.Empty, Ubigeo = string.Empty, Tlf = string.Empty, Email = string.Empty;
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty, RutaQR = string.Empty;
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
            this.GenerarCorrelativo();
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

            this.CargarDatosEmpresa();
            this.CargarRutas();
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
            xCtrl.TxtTodo(this.txtSerDoc, true, "Ser. Doc.", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNroDoc, true, "N°. Doc.", "ffff", 11);
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
        public void GenerarCorrelativo()
        {
            GestionClubCorrelativoComprobanteDto gestionClubCorrelativoComprobanteDto = new GestionClubCorrelativoComprobanteDto();
            gestionClubCorrelativoComprobanteDto.tipoDocumento = Cmb.ObtenerValor(this.cboTipDoc, string.Empty);
            gestionClubCorrelativoComprobanteDto = GestionClubCorrelativoComprobanteController.GenerarCorrelativo(gestionClubCorrelativoComprobanteDto);
            this.txtSerDoc.Text = Cmb.ObtenerTexto(this.cboTipDoc).Substring(0, 1) + gestionClubCorrelativoComprobanteDto.serCorrelativo;
            this.txtNroDoc.Text = gestionClubCorrelativoComprobanteDto.nroCorrelativo;
        }
        public void CargarRutas()
        {
            rutaMesa = ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = ConfigurationManager.AppSettings["RutaProducto"].ToString();
            RutaQR = ConfigurationManager.AppSettings["RutaQR"].ToString();
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
            Cmb.Cargar(this.cboTipDoc, GestionClubGeneralController.ListarSistemaDetallePorTablaPorObs(GestionClubEnum.Sistema.DocFac.ToString(), "pedidos"), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
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
            this.ActualizarCorrelativoComprobante();
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
            pObj.impDepComprobante = Convert.ToDecimal(this.txtDeposito.Text);
            pObj.impTarComprobante = Convert.ToDecimal(this.txtTransferencia.Text);
            pObj.impBruComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) - Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * Convert.ToDecimal(0.18);
            pObj.impIgvComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal)) * Convert.ToDecimal(0.18);
            pObj.impNetComprobante = Convert.ToDecimal(this.lObjDetalle.Sum(x => x.preTotal));
            pObj.impDtrComprobante = 0;
            pObj.idCliente = Convert.ToInt32(this.txtIdCliente.Text);
            pObj.nombreRazSocialCliente = this.txtApeNom.Text;
            pObj.nroIdentificacionCliente = this.txtDocId.Text;
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
            if (this.chDeposito.Checked) { cantidadCheck++; modoPago = "02"; }
            if (this.chTransferencia.Checked) { cantidadCheck++; modoPago = "03"; }
            if (cantidadCheck > 1) modoPago = "04";

            return modoPago;
        }
        public void CalcularPendientePagar()
        {
            this.lblPendiente.Text = (Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtDeposito.Text) + Convert.ToDecimal(this.txtEfectivo.Text))).ToString();
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
        public void Grabar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            this.CalcularPendientePagar();

            if (this.ValidaPagoPendiente() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.AdicionarComprobante();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El comprobante se adiciono correctamente", this.eTitulo);

            this.ImprimirComprobante();

            //this.wFrm.eClaveDgvComprobante = this.ObtenerIdAmbiente();
            this.wFrm.ActualizarVentana();

            eMas.AccionPasarTextoPrincipal();
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
            g.DrawString("IGV 18%:", fBody, sb, 90, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            igv = Formato.NumeroDecimal(Convert.ToDecimal(total) * Convert.ToDecimal(0.18), 2);
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
            obj.serCorrelativo = this.txtSerDoc.Text;
            obj.nroCorrelativo = this.txtNroDoc.Text;
            GestionClubCorrelativoComprobanteController.ActualizarCorrelativo(obj);
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

        private void chDeposito_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDeposito.Enabled = !this.txtDeposito.Enabled;
        }

        private void cboTipDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GenerarCorrelativo();
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
