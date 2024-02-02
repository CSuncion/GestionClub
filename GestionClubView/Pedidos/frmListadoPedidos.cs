using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

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
            g.DrawString("CIRCULO DE OFICIALES DE LA FF.PP.", fBodyTitle, sb, 30, 100);
            g.DrawString("R.U.C. N° 20136926455", fHead, sb, 65, 120);
            g.DrawString("Calle Lopez DE AYALA NRO. 1684", fHead, sb, 45, 140);
            g.DrawString("Lima - Lima - San Borja", fHead, sb, 70, 155);
            g.DrawString("Tel.(01)457-8384", fHead, sb, 85, 170);
            g.DrawString("E-mail: cosfup@gmail.com", fHead, sb, 70, 185);
            g.DrawString("______________________________________________", fBody, sb, 10, 190);
            g.DrawString("BOLETA ELECTRONICA", fHead, sb, 80, 205);
            g.DrawString("B001 - 0004420", fBodySerNro, sb, 95, 220);
            g.DrawString("______________________________________________", fBody, sb, 10, 225);
            int SPACE = 240;
            g.DrawString("Fecha Emisión:", fBody, sb, 10, SPACE);
            g.DrawString(DateTime.Now.ToShortDateString(), fBodyNoBold, sb, 90, SPACE);
            g.DrawString("Cliente:", fBody, sb, 10, SPACE + 15);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBodyNoBold, sb, 90, SPACE + 15);
            g.DrawString("R.U.C./N°Doc.:", fBody, sb, 10, SPACE + 30);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBodyNoBold, sb, 90, SPACE + 30);
            g.DrawString("Dirección:", fBody, sb, 10, SPACE + 45);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBodyNoBold, sb, 90, SPACE + 45);
            g.DrawString("Cajero:", fBody, sb, 10, SPACE + 60);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBodyNoBold, sb, 90, SPACE + 60);

            g.DrawString("Forma de Pago:", fBody, sb, 10, SPACE + 95);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBodyNoBold, sb, 90, SPACE + 95);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 100);
            g.DrawString("Cant.", fBody, sb, 10, SPACE + 115);
            g.DrawString("Descripción", fBody, sb, 95, SPACE + 115);
            g.DrawString("P. Unit.", fBody, sb, 180, SPACE + 115);
            g.DrawString("Total", fBody, sb, 230, SPACE + 115);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 120);
            g.DrawString("1", fBodyNoBold, sb, 10, SPACE + 135);
            g.DrawString("ACADEMIA DE NATACION", fBodyNoBold, sb, 40, SPACE + 135);
            g.DrawString("30.00", fBodyNoBold, sb, 180, SPACE + 135);
            g.DrawString("30.00", fBodyNoBold, sb, 230, SPACE + 135);
            g.DrawString("______________________________________________", fBody, sb, 10, SPACE + 140);
            g.DrawString("Total Gravado:", fBody, sb, 105, SPACE + 155);
            g.DrawString("S/", fBody, sb, 180, SPACE + 155);
            g.DrawString("25.42", fBody, sb, 230, SPACE + 155);

            g.Dispose();
        }
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
            this.ImprimirComprobante();
        }
    }
}
