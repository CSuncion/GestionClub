using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Venta
{
    public partial class frmComprobantes : Form
    {
        public string eTitulo = "Comprobante";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubComprobanteDto> eLisComp = new List<GestionClubComprobanteDto>();
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        Dgv.Franja eFranjaDgvComprobante = Dgv.Franja.PorIndice;
        public string eClaveDgvComprobante = string.Empty;
        string eNombreColumnaDgvComprobante = "nombreRazSocialCliente";
        string eEncabezadoColumnaDgvComprobante = "nombreRazSocialCliente";
        public string NombreEmpresa = string.Empty, NroRuc = string.Empty, DireccionEmpresa = string.Empty, Ubigeo = string.Empty, Tlf = string.Empty, Email = string.Empty;
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty, RutaQR = string.Empty;
        public frmComprobantes()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            if (!this.ValidaAperturaCaja()) { this.Cerrar(); return; }
            if (!this.ValidaTipoCambio()) { this.Cerrar(); return; }
            this.Dock = DockStyle.Fill;
            this.Show();
            this.CargarDatosEmpresa();
            this.CargarRutas();
            this.ActualizarVentana();
            Dgv.HabilitarDesplazadores(this.DgvComprobantes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantes, this.sst1);
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
        public void CargarRutas()
        {
            //variables
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();

            rutaMesa = iParEN.FirstOrDefault().RutaImagenMesa; // ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = iParEN.FirstOrDefault().RutaImagenCategoria;//ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = iParEN.FirstOrDefault().RutaImagenProducto;// ConfigurationManager.AppSettings["RutaProducto"].ToString();
            RutaQR = iParEN.FirstOrDefault().RutaImagenQR;//ConfigurationManager.AppSettings["RutaQR"].ToString();
        }
        public bool ValidaAperturaCaja()
        {
            bool result = true;
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            gestionClubAperturaCajaDto.caja = Universal.caja;
            gestionClubAperturaCajaDto = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0) { Mensaje.OperacionDenegada("Debe aperturar la caja.", this.eTitulo); result = false; }

            return result;
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
        public void ActualizarVentana()
        {
            this.ActualizarListaComprobanteDeBaseDatos();
            this.ActualizarDgvComprobante();
            Dgv.HabilitarDesplazadores(this.DgvComprobantes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantes, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaComprobanteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            //Lista comprobantes que no han sido creado por comandas
            GestionClubComprobanteDto iOpEN = new GestionClubComprobanteDto();
            iOpEN.idNroComanda = 0;
            this.eLisComp = GestionClubComprobanteController.ListarComprobantes(iOpEN).Where(x => x.caja == Universal.caja.ToString()).ToList();
        }
        public void ActualizarDgvComprobante()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvComprobantes;
            List<GestionClubComprobanteDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvComprobante;
            string iClaveBusqueda = eClaveDgvComprobante;
            string iColumnaPintura = eNombreColumnaDgvComprobante;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvComprobante();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubComprobanteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvComprobante;
            List<GestionClubComprobanteDto> iListaComprobante = eLisComp;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaComprobante);
        }
        public List<DataGridViewColumn> ListarColumnasDgvComprobante()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._serNroComprobante, "Comprobante", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desTipComprobante, "T.Comp.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._fecComprobante, "Fecha", 100));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desMoneda, "Moneda", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._nroIdentificacionCliente, "N° Id.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._nombreRazSocialCliente, "Cliente", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desPagoComprobante, "M. Pago", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextNumerico(GestionClubComprobanteDto._impNetComprobante, "Total", 80, 2));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desEstado, "Estado", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._idComprobante, "idComprobante", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisDgv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvComprobante;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmComprobante, wMen.tsbComprobante);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }
        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            //if (tsbEditar.Enabled == false)
            //{
            //    Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            //}
            //else
            //{
            //    this.AccionModificar();
            //}
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iObjEN = this.EsActoModificarComprobante();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubComprobanteDto EsActoModificarComprobante()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            iObjEN = GestionClubComprobanteController.EsActoModificarComprobante(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarComprobante(GestionClubComprobanteDto pObj)
        {
            pObj.idComprobante = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvComprobantes, GestionClubComprobanteDto._idComprobante));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iObjEN = this.EsActoEliminarComprobante();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            //win.wFrm = this;
            //win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            //win.VentanaEliminar(iObjEN);
        }
        public GestionClubComprobanteDto EsActoEliminarComprobante()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            //iObjEN = GestionClubProductoController.EsActoEliminarComprobante(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iComEN = this.EsComprobanteExistente();
            if (iComEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            win.FormularioActivo = 0;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iComEN);
        }
        public GestionClubComprobanteDto EsComprobanteExistente()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            iObjEN = GestionClubComprobanteController.EsComprobanteExistente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public string modoDescriPago(GestionClubComprobanteDto pObj)
        {
            string modoPago = string.Empty;
            int cantidadCheck = 0;

            if (pObj.impEfeComprobante > 0) { cantidadCheck++; modoPago = "EFECTIVO"; }
            if (pObj.impDepComprobante > 0) { cantidadCheck++; modoPago = "DEPOSITO"; }
            if (pObj.impTarComprobante > 0) { cantidadCheck++; modoPago = "TRANSFERENCIA"; }
            if (cantidadCheck > 1) modoPago = "MIXTO";

            return modoPago;
        }
        public void ImprimirComprobante(bool detallado, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (detallado)
                {
                    PrintDocument printDocument = new PrintDocument();
                    PaperSize ps = new PaperSize("", 420, 840);
                    printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPageDetallado);
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.DefaultPageSettings.Margins.Left = 0;
                    printDocument.DefaultPageSettings.Margins.Right = 0;
                    printDocument.DefaultPageSettings.Margins.Top = 0;
                    printDocument.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    printDocument.Print();
                }
                else
                {
                    PrintDocument printDocument = new PrintDocument();
                    PaperSize ps = new PaperSize("", 420, 840);
                    printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPageConsumo);
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.DefaultPageSettings.Margins.Left = 0;
                    printDocument.DefaultPageSettings.Margins.Right = 0;
                    printDocument.DefaultPageSettings.Margins.Top = 0;
                    printDocument.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument.DefaultPageSettings.PaperSize = ps;
                    printDocument.Print();
                }
            }
        }
        void pd_PrintPageConsumo(object sender, PrintPageEventArgs e)
        {
            List<GestionClubParametroDto> iParEN = GestionClubParametroController.ListarParametro();
            GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iComEN);

            iComEN = this.eLisComp.Find(x => x.idComprobante == iComEN.idComprobante);

            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
            string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "logo-cosfup.ico";
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

            g.DrawString(iComEN.desTipComprobante.ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);


            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);

            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);

            if (iComEN.tipComprobante.ToUpper() == "01")
                g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
            else
                g.DrawString(iComEN.nroIdentificacionCliente.Substring(iComEN.nroIdentificacionCliente.Length - 8, 8), fBodyNoBold, sb, 90, SPACE + 30);

            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);


            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString(this.modoDescriPago(iComEN), fBodyNoBold, sb, 90, SPACE + 95); ;
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

            List<GestionClubDetalleComprobanteDto> lObjDetalle = new List<GestionClubDetalleComprobanteDto>();
            GestionClubDetalleComprobanteDto obj = new GestionClubDetalleComprobanteDto();
            obj.idComprobante = iComEN.idComprobante;
            lObjDetalle = GestionClubComprobanteController.ListarDetallesComprobantesPorComprobante(obj);

            foreach (GestionClubDetalleComprobanteDto item in lObjDetalle)
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
            g.DrawString(Formato.MontoComprobanteEnLetras(total, iComEN.desMoneda.ToUpper()), fBodyNoBold, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            string tipoDoc = iComEN.tipCliente == "01" ? "DNI" : "RUC";

            string datosQR = this.NroRuc + "|" + iComEN.desTipComprobante.ToUpper() + "|" + tipoDoc + "|" + iComEN.nroIdentificacionCliente + "|" + iComEN.serComprobante + "|" + iComEN.nroComprobante + "|" + iComEN.fecComprobante.ToShortDateString() + "|" + total.ToString();
            string fileName = Path.Combine(RutaQR, iComEN.serComprobante + '-' + iComEN.nroComprobante + "_QRCode.png");
            if (!File.Exists(fileName))
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                qrCodeImage.Save(fileName, ImageFormat.Png);
            }

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa de la " + iComEN.desTipComprobante.ToUpper() + " ELECTRONICA", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

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

            iComEN = this.eLisComp.Find(x => x.idComprobante == iComEN.idComprobante);

            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
            string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "logo-cosfup.ico";
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

            g.DrawString(iComEN.desTipComprobante.ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);


            g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);

            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);

            if (iComEN.tipComprobante.ToUpper() == "01")
                g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
            else
                g.DrawString(iComEN.nroIdentificacionCliente.Substring(iComEN.nroIdentificacionCliente.Length - 8, 8), fBodyNoBold, sb, 90, SPACE + 30);

            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);


            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString(this.modoDescriPago(iComEN), fBodyNoBold, sb, 90, SPACE + 95); ;
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

            List<GestionClubDetalleComprobanteDto> lObjDetalle = new List<GestionClubDetalleComprobanteDto>();
            GestionClubDetalleComprobanteDto obj = new GestionClubDetalleComprobanteDto();
            obj.idComprobante = iComEN.idComprobante;
            lObjDetalle = GestionClubComprobanteController.ListarDetallesComprobantesPorComprobante(obj);

            foreach (GestionClubDetalleComprobanteDto item in lObjDetalle)
            {
                saltoLinea = saltoLinea + 15;
                g.DrawString(item.cantidad.ToString(), fBodyNoBold, sb, 180, SPACE + (saltoLinea));
                g.DrawString(item.desProducto.Substring(0, item.desProducto.Length > 20 ? 20 : item.desProducto.Length), fBodyNoBold, sb, 50, SPACE + (saltoLinea));
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
            g.DrawString(Formato.MontoComprobanteEnLetras(total, iComEN.desMoneda.ToUpper()), fBodyNoBold, sb, 10, SPACE + saltoLinea);

            saltoLinea = saltoLinea + 5;
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

            string tipoDoc = iComEN.tipCliente == "01" ? "DNI" : "RUC";

            string datosQR = this.NroRuc + "|" + iComEN.desTipComprobante.ToUpper() + "|" + tipoDoc + "|" + iComEN.nroIdentificacionCliente + "|" + iComEN.serComprobante + "|" + iComEN.nroComprobante + "|" + iComEN.fecComprobante.ToShortDateString() + "|" + total.ToString();
            string fileName = Path.Combine(RutaQR, iComEN.serComprobante + '-' + iComEN.nroComprobante + "_QRCode.png");
            if (!File.Exists(fileName))
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                qrCodeImage.Save(fileName, ImageFormat.Png);
            }

            saltoLinea = saltoLinea + 15;
            g.DrawString("Representación impresa de la " + iComEN.desTipComprobante.ToUpper() + " ELECTRONICA", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

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

        public void AccionAdicionarAnticipo()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarAnticipo win = new frmEditarAnticipo();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionAdicionarRegularizarAnticipo()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarRegularizacionAnticipo win = new frmEditarRegularizacionAnticipo();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }


        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprobantes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Primero);
        }

        private void pruebafactura_Click(object sender, EventArgs e)
        {
            //FacturacionElectronicaNubeFact.Main();
        }

        private void tsbAnticipo_Click(object sender, EventArgs e)
        {
            this.AccionAdicionarAnticipo();
        }

        private void tsbAdRegAnt_Click(object sender, EventArgs e)
        {
            this.AccionAdicionarRegularizarAnticipo();
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvComprobante = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvComprobantes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }

        private void DgvComprobantes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvComprobantes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantes, this.sst1);
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            bool detallado = false;
            if (Mensaje.DeseasRealizarOperacion("¿Desea comprobante detallado?", this.eTitulo))
                detallado = true;
            else
                detallado = false;

            this.ImprimirComprobante(detallado, 1);
        }
    }
}
