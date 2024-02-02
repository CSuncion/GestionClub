using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubView.Listas;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        public string eTitulo = "Grabar Comanda";
        public bool presionTicket = false;
        public string NombreEmpresa = string.Empty, NroRuc = string.Empty, DireccionEmpresa = string.Empty, Ubigeo = string.Empty, Tlf = string.Empty, Email = string.Empty;
        public frmCobrar()
        {
            InitializeComponent();
        }
        public void VentanaCobrar(GestionClubComandaDto objCom)
        {
            this.InicializaVentana();
            this.CargarProductosSeleccionados();
            this.CargarRutas();
            this.CargarDatosEmpresa();
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtDeposito, true, "Tarjeta", "vvff", 2);
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
        public void CargarDatosEmpresa()
        {
            NombreEmpresa = ConfigurationManager.AppSettings["NombreEmpresa"].ToString();
            NroRuc = ConfigurationManager.AppSettings["NroRuc"].ToString();
            DireccionEmpresa = ConfigurationManager.AppSettings["DireccionEmpresa"].ToString();
            Ubigeo = ConfigurationManager.AppSettings["Ubigeo"].ToString();
            Tlf = ConfigurationManager.AppSettings["Tlf"].ToString();
            Email = ConfigurationManager.AppSettings["Email"].ToString();
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
            this.txtTransferencia.Text = "0";
            this.txtDeposito.Text = "0";

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
            this.lblPendiente.Text = (Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtDeposito.Text) + Convert.ToDecimal(this.txtEfectivo.Text))).ToString();
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
            pObj.modPagoComprobante = this.modoCodigoPago();
            pObj.tipMovComprobante = "01";
            pObj.impEfeComprobante = Convert.ToDecimal(this.txtEfectivo.Text);
            pObj.impDepComprobante = Convert.ToDecimal(this.txtDeposito.Text);
            pObj.impTarComprobante = Convert.ToDecimal(this.txtTransferencia.Text);
            pObj.impBruComprobante = Convert.ToDecimal(this.lblTotal.Text) - Convert.ToDecimal(this.lblTotal.Text) * Convert.ToDecimal(0.18);
            pObj.impIgvComprobante = Convert.ToDecimal(this.lblTotal.Text) * Convert.ToDecimal(0.18);
            pObj.impNetComprobante = Convert.ToDecimal(this.lblTotal.Text);
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
            foreach (ListViewItem item in this.lvProductosSeleccionados.Items)
            {
                pObj.idProducto = Convert.ToInt32(item.ImageKey);
                pObj.preVenta = Convert.ToDecimal(item.SubItems[2].Text);
                pObj.cantidad = Convert.ToInt32(item.SubItems[1].Text);
                pObj.preTotal = (pObj.preVenta * pObj.cantidad);
                if (this.presionTicket)
                    GestionClubComprobanteController.AgregarDetalleComprobante(pObj);
            }

        }

        public string modoCodigoPago()
        {
            string modoPago = string.Empty;
            int cantidadCheck = 0;

            if (this.chEfectivo.Checked) { cantidadCheck++; modoPago = "01"; }
            if (this.chDeposito.Checked) { cantidadCheck++; modoPago = "02"; }
            if (this.chTransferencia.Checked) { cantidadCheck++; modoPago = "03"; }
            if (cantidadCheck > 1) modoPago = "04";

            return modoPago;
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

        public void ImprimirComprobante()
        {
            PrintDocument printDocument = new PrintDocument();
            PaperSize ps = new PaperSize("", 420, 540);
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
            //g.DrawRectangle(Pens.Black, 5, 5, 410, 530);
            string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "cosfupico.ico";
            g.DrawImage(Image.FromFile(title), 100, 7);
            Font fBody = new Font("Calibri", 8, FontStyle.Bold);
            Font fHead = new Font("Calibri", 9, FontStyle.Bold);
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
            g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);
            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);
            int SPACE = 240;
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
            g.DrawString("Descripción", fBody, sb, 95, SPACE + 115);
            g.DrawString("P. Unit.", fBody, sb, 180, SPACE + 115);
            g.DrawString("Total", fBody, sb, 230, SPACE + 115);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 120);

            int saltoLinea = 120;

            foreach (ListViewItem item in this.lvProductosSeleccionados.Items)
            {
                saltoLinea = saltoLinea + 15;
                g.DrawString(item.SubItems[1].Text, fBodyNoBold, sb, 180, SPACE + (saltoLinea));
                g.DrawString(item.SubItems[0].Text, fBodyNoBold, sb, 50, SPACE + (saltoLinea));
                g.DrawString(item.SubItems[2].Text, fBodyNoBold, sb, 10, SPACE + (saltoLinea));
                g.DrawString((Convert.ToDecimal(item.SubItems[2].Text) * Convert.ToInt32(item.SubItems[1].Text)).ToString(), fBodyNoBold, sb, 230, SPACE + (saltoLinea));
            }

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 15;
            g.DrawString("Total Gravado:", fBody, sb, 105, SPACE + saltoLinea);
            g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
            g.DrawString("25.42", fBody, sb, 230, SPACE + saltoLinea);

            g.Dispose();
        }
        public void ImprimirPreTicket()
        {
            this.ImprimirComprobante();
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

        private void tsBtnCobrar_Click(object sender, EventArgs e)
        {
            this.Cobrar();
        }

        private void tsBtnTicket_Click(object sender, EventArgs e)
        {
            this.presionTicket = true;
            this.ImprimirPreTicket();
        }

        private void txtEfectivo_Validated(object sender, EventArgs e)
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

        private void txtDeposito_Validated(object sender, EventArgs e)
        {
            this.CalcularPendientePagar();
        }

        private void chDeposito_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDeposito.Enabled = !this.txtDeposito.Enabled;
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
        }
    }
}
