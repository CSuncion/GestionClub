using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Pedidos
{
    public partial class frmComanda : Form
    {
        public string eTitulo = "Registro Comanda";
        public GestionClubAmbienteController oOpeAmbiente = new GestionClubAmbienteController();
        public frmComanda()
        {
            InitializeComponent();
        }

        public void NewWindow()
        {
            //this.Dock = DockStyle.Fill;
            //this.CargarMeses();
            //this.CargarCentroCosto();
            //this.tsTxtAnio.Text = DateTime.Now.Year.ToString();
            this.Show();
        }
        public void CargarAmbientes()
        {
            Cmb.Cargar(this.cboAmbiente, oOpeAmbiente.ListarAmbientesActivos(), GestionClubAmbientesDto._idAmbiente, GestionClubAmbientesDto._desAmbiente);
        }
        private void cargarMesas()
        {
            lvMesas.View = View.LargeIcon;

            lvMesas.Columns.Add("MESAS", 250);
            imgMesas.ImageSize = new Size(40, 40);

            //string[] paths = { };
            //paths = Directory.GetFiles("");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string file = "D:\\Perú Ticcs\\Victor Noriega\\Cosfup\\MVCGestionClub\\GestionClubView\\images\\mesas\\Mesa.png";
                    imgMesas.Images.Add(Image.FromFile(file));
                }

            }
            catch (Exception)
            {

                throw;
            }

            lvMesas.SmallImageList = imgMesas;
            for (int i = 0; i < 10; i++)
            {
                lvMesas.Items.Add("Mesa " + (i + 1), i);
            }

        }

        private void cargarCategorias()
        {
            lvCategorias.View = View.LargeIcon;

            lvCategorias.Columns.Add("CATEGORIAS", 250);
            imgCategorias.ImageSize = new Size(40, 40);

            //string[] paths = { };
            //paths = Directory.GetFiles("");
            int cantidadProductos = 0;
            string[] paths = { };
            paths = Directory.GetFiles("D:\\Perú Ticcs\\Victor Noriega\\Cosfup\\MVCGestionClub\\GestionClubView\\images\\categorias");

            try
            {
                foreach (String path in paths)
                {
                    cantidadProductos += 1;
                    imgCategorias.Images.Add(Image.FromFile(path));
                }

            }
            catch (Exception)
            {

                throw;
            }


            lvCategorias.SmallImageList = imgCategorias;
            for (int i = 0; i < 2; i++)
            {
                lvCategorias.Items.Add("Categoria " + (i + 1), i);
            }

        }

        private void cargarProductos()
        {
            lvProductos.View = View.Details;

            lvProductos.Columns.Add("PRODUCTOS", 220);
            lvProductos.Columns.Add("PRECIO", 80);

            imgProductos.ImageSize = new Size(50, 50);



            int cantidadProductos = 0;

            string[] paths = { };
            paths = Directory.GetFiles("D:\\Perú Ticcs\\Victor Noriega\\Cosfup\\MVCGestionClub\\GestionClubView\\images\\productos");

            try
            {
                foreach (String path in paths)
                {
                    cantidadProductos += 1;
                    imgProductos.Images.Add(Image.FromFile(path));
                }

            }
            catch (Exception)
            {

                throw;
            }

            lvProductos.SmallImageList = imgProductos;
            for (int i = 0; i < cantidadProductos; i++)
            {
                lvProductos.Items.Add(new ListViewItem(new[] { "Producto " + (i + 1), "3.5" }, i));
            }

        }

        private void cargarProductosSeleccionados()
        {
            lvProductosSeleccionados.View = View.Details;

            lvProductosSeleccionados.Columns.Add("PRODUCTOS", 220);
            lvProductosSeleccionados.Columns.Add("CANTIDAD", 80);
            lvProductosSeleccionados.Columns.Add("IMPORTE", 100);
        }

        public void AccionCobrar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmCobrar win = new frmCobrar();
            win.wCom = this;
            win.eOperacion = Universal.Opera.Cobrar;
            //this.eFranjaDgvRefAmp = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmComanda, wMen.tsbComanda);
        }
        private void frmComanda_Load(object sender, EventArgs e)
        {
            this.CargarAmbientes();
            this.cargarMesas();
            this.cargarProductos();
            this.cargarProductosSeleccionados();
            this.cargarCategorias();
        }
        private void lvMesas_MouseClick(object sender, MouseEventArgs e)
        {
            String selected = lvMesas.SelectedItems[0].SubItems[0].Text;
            gbProductos.Text = "PRODUCTOS";
            gbProductos.Text = gbProductos.Text + ": " + selected;

            gbProductosSeleccionados.Text = "PRODUCTO SELECCIONADOS";
            gbProductosSeleccionados.Text = gbProductosSeleccionados.Text + ": " + selected;

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            btnCobrar.Enabled = !btnCobrar.Enabled;
            this.AccionCobrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComanda_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbRealizarPedido_Click(object sender, EventArgs e)
        {
            tsbRealizarPedido.Enabled = !tsbRealizarPedido.Enabled;
            btnCobrar.Enabled = !btnCobrar.Enabled;
        }
    }
}
