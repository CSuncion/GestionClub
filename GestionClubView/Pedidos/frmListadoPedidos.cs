using Comun;
using GestionClubModel.ModelDto;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using WinControles.ControlesWindows;

namespace GestionClubView.Pedidos
{
    public partial class frmListadoPedidos : Form
    {
        public frmListadoPedidos()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Show();
        }
        //public void ImprimirComprobante()
        //{
        //    PrintDocument printDocument = new PrintDocument();
        //    PaperSize ps = new PaperSize("", 420, 840);
        //    printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);

        //    printDocument.PrintController = new StandardPrintController();
        //    printDocument.DefaultPageSettings.Margins.Left = 0;
        //    printDocument.DefaultPageSettings.Margins.Right = 0;
        //    printDocument.DefaultPageSettings.Margins.Top = 0;
        //    printDocument.DefaultPageSettings.Margins.Bottom = 0;
        //    printDocument.DefaultPageSettings.PaperSize = ps;
        //    printDocument.Print();

        //}
        //void pd_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    GestionClubComprobanteDto iComEN = new GestionClubComprobanteDto();
        //    this.AsignarComprobanteAlmacen(iComEN);

        //    Graphics g = e.Graphics;
        //    //g.DrawRectangle(Pens.White, 5, 5, 410, 730);
        //    string title = ConfigurationManager.AppSettings["RutaLogo"].ToString() + "cosfupico.ico";
        //    g.DrawImage(Image.FromFile(title), 100, 7);

        //    Font fBody = new Font("Calibri", 8, FontStyle.Bold);
        //    Font fHead = new Font("Calibri", 9, FontStyle.Bold);
        //    Font fBodyNoBoldFood = new Font("Calibri", 7, FontStyle.Regular);
        //    Font fBodyNoBold = new Font("Calibri", 8, FontStyle.Regular);
        //    Font fBodySerNro = new Font("Calibri", 9, FontStyle.Regular);
        //    Font fBodyTitle = new Font("Calibri", 10, FontStyle.Bold);
        //    SolidBrush sb = new SolidBrush(System.Drawing.Color.Black);

        //    g.DrawString(this.NombreEmpresa, fBodyTitle, sb, 30, 100);
        //    g.DrawString("R.U.C. N° " + this.NroRuc, fHead, sb, 65, 120);
        //    g.DrawString(this.DireccionEmpresa, fHead, sb, 45, 140);
        //    g.DrawString(this.Ubigeo, fHead, sb, 70, 155);
        //    g.DrawString("Tel." + this.Tlf, fHead, sb, 85, 170);
        //    g.DrawString("E-mail: " + this.Email, fHead, sb, 70, 185);
        //    g.DrawString("______________________________________________", fBody, sb, 10, 190);

        //    int SPACE = 240;

        //    if (!this.presionTicket)
        //    {
        //        g.DrawString(Cmb.ObtenerTexto(this.cboTipDoc).ToUpper() + " ELECTRONICA", fHead, sb, 80, 205);
        //        g.DrawString(iComEN.serComprobante + " - " + iComEN.nroComprobante, fBodySerNro, sb, 95, 220);
        //        g.DrawString("______________________________________________", fBody, sb, 10, 225);

        //        g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
        //        g.DrawString(iComEN.fecComprobante.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
        //        g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
        //        g.DrawString(iComEN.nombreRazSocialCliente, fBodyNoBold, sb, 90, SPACE + 15);
        //        g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);
        //        g.DrawString(iComEN.nroIdentificacionCliente, fBodyNoBold, sb, 90, SPACE + 30);
        //        g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
        //        g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);
        //    }
        //    else
        //    {
        //        g.DrawString("PRECUENTA", fHead, sb, 90, 205);
        //        g.DrawString("NO ES COMPROBANTE DE PAGO", fBodySerNro, sb, 45, 220);
        //        g.DrawString("______________________________________________", fBody, sb, 10, 225);
        //        g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
        //        g.DrawString(DateTime.Now.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
        //        g.DrawString("Ambiente:", fBody, sb, 10, SPACE + 15);
        //        g.DrawString(this.lblAmbiente.Text, fBodyNoBold, sb, 90, SPACE + 15);
        //        g.DrawString("Mesa:", fBody, sb, 10, SPACE + 30);
        //        g.DrawString(this.lblNroMesa.Text, fBodyNoBold, sb, 90, SPACE + 30);
        //        g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
        //        g.DrawString(string.Empty, fBodyNoBold, sb, 90, SPACE + 45);
        //    }

        //    g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
        //    g.DrawString(Universal.gNombreUsuario, fBodyNoBold, sb, 90, SPACE + 60);

        //    g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
        //    g.DrawString(this.modoDescriPago(), fBodyNoBold, sb, 90, SPACE + 95); ;
        //    g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 100);
        //    g.DrawString("Cant.", fBody, sb, 10, SPACE + 115);
        //    g.DrawString("Descripción", fBody, sb, 80, SPACE + 115);
        //    g.DrawString("P. Unit.", fBody, sb, 180, SPACE + 115);
        //    g.DrawString("Total", fBody, sb, 230, SPACE + 115);
        //    g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 120);

        //    int saltoLinea = 120;
        //    decimal total = 0;
        //    string subtotal = string.Empty, igv = string.Empty;

        //    StringFormat formato = new StringFormat();
        //    formato.Alignment = StringAlignment.Far;
        //    formato.LineAlignment = StringAlignment.Far;
        //    //format.LineAlignment = StringAlignment.;

        //    foreach (ListViewItem item in this.lvProductosSeleccionados.Items)
        //    {
        //        saltoLinea = saltoLinea + 15;
        //        g.DrawString(item.SubItems[2].Text, fBodyNoBold, sb, 180, SPACE + (saltoLinea));
        //        g.DrawString(item.SubItems[0].Text, fBodyNoBold, sb, 50, SPACE + (saltoLinea));
        //        g.DrawString(item.SubItems[1].Text, fBodyNoBold, sb, 10, SPACE + (saltoLinea));


        //        string precioPorCantidad = ((Convert.ToDecimal(item.SubItems[2].Text) * Convert.ToInt32(item.SubItems[1].Text))).ToString();

        //        e.Graphics.DrawString(precioPorCantidad, fBodyNoBold, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);

        //        total += Convert.ToDecimal(item.SubItems[2].Text) * Convert.ToInt32(item.SubItems[1].Text);
        //    }

        //    saltoLinea = saltoLinea + 5;
        //    g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 15;
        //    g.DrawString("Total Gravado:", fBody, sb, 90, SPACE + saltoLinea);
        //    g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
        //    subtotal = Formato.NumeroDecimal(Convert.ToDecimal(total) - (Convert.ToDecimal(total) * Convert.ToDecimal(0.18)), 2);

        //    e.Graphics.DrawString(subtotal.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
        //    //g.DrawString(subtotal.ToString(), fBody, sb, 230, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 15;
        //    g.DrawString("Total No Gravado:", fBody, sb, 90, SPACE + saltoLinea);
        //    g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);

        //    e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
        //    //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);


        //    saltoLinea = saltoLinea + 15;
        //    g.DrawString("IGV 18%:", fBody, sb, 90, SPACE + saltoLinea);
        //    g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
        //    igv = Formato.NumeroDecimal(Convert.ToDecimal(total) * Convert.ToDecimal(0.18), 2);
        //    e.Graphics.DrawString(igv.ToString(), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
        //    //g.DrawString(igv.ToString(), fBody, sb, 230, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 15;
        //    g.DrawString("Descuento:", fBody, sb, 90, SPACE + saltoLinea);
        //    g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
        //    e.Graphics.DrawString("0.00", fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);
        //    //g.DrawString("0.00", fBody, sb, 230, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 15;
        //    g.DrawString("Importe Total:", fBody, sb, 90, SPACE + saltoLinea);
        //    g.DrawString("S/", fBody, sb, 180, SPACE + saltoLinea);
        //    e.Graphics.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, new RectangleF(180, SPACE + (saltoLinea), 80, fBodyNoBold.Height), formato);

        //    //g.DrawString(Formato.NumeroDecimal(total.ToString(), 2), fBody, sb, 230, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 30;
        //    g.DrawString(Formato.MontoComprobanteEnLetras(total, Cmb.ObtenerTexto(this.cboMoneda).ToUpper()), fBodyNoBold, sb, 10, SPACE + saltoLinea);

        //    saltoLinea = saltoLinea + 5;
        //    g.DrawString("______________________________________________", fBody, sb, 10, SPACE + saltoLinea);

        //    if (!this.presionTicket)
        //    {

        //        string tipoDoc = this.txtTipoDoc.Text == "01" ? "DNI" : "RUC";

        //        string datosQR = this.NroRuc + "|" + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + "|" + tipoDoc + "|" + iComEN.nroIdentificacionCliente + "|" + iComEN.serComprobante + "|" + iComEN.nroComprobante + "|" + iComEN.fecComprobante.ToShortDateString() + "|" + total.ToString();
        //        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //        QRCodeData qrCodeData = qrGenerator.CreateQrCode(datosQR, QRCodeGenerator.ECCLevel.Q);
        //        QRCode qrCode = new QRCode(qrCodeData);
        //        Bitmap qrCodeImage = qrCode.GetGraphic(20);

        //        string fileName = Path.Combine(RutaQR, DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_QRCode.png");
        //        qrCodeImage.Save(fileName, ImageFormat.Png);

        //        saltoLinea = saltoLinea + 15;
        //        g.DrawString("Representación impresa de la " + Cmb.ObtenerTexto(cboTipDoc).ToUpper() + " ELECTRONICA", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

        //        saltoLinea = saltoLinea + 15;
        //        g.DrawString("Representación impresa del comprobante electronico puede ser", fBodyNoBoldFood, sb, 10, SPACE + saltoLinea);

        //        saltoLinea = saltoLinea + 15;
        //        g.DrawString("consultado en https://www.nubefact.com/buscar", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);

        //        saltoLinea = saltoLinea + 15;
        //        g.DrawString("Autorizado mediante resolución de intenencia", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);


        //        saltoLinea = saltoLinea + 15;
        //        g.DrawImage(Image.FromFile(fileName), 100, SPACE + saltoLinea, 100, 100);

        //        saltoLinea = saltoLinea + 100;
        //        g.DrawString(".", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);
        //    }
        //    else
        //    {
        //        saltoLinea = saltoLinea + 30;
        //        g.DrawString(".", fBodyNoBoldFood, sb, 30, SPACE + saltoLinea);
        //    }

        //    g.Dispose();
        //}
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmListadoPedidos, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbEnPreparacion_Click(object sender, EventArgs e)
        {
            //this.ImprimirComprobante();
        }
    }
}
