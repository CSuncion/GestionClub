using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Pedidos
{
    public partial class frmComanda : Form
    {
        public string eTitulo = "Registro Comanda";
        public GestionClubAmbienteController oOpeAmbiente = new GestionClubAmbienteController();
        public GestionClubMesaController oOpeMesa = new GestionClubMesaController();
        GestionClubAccessController oOpeAcc = new GestionClubAccessController();
        public List<GestionClubMesaDto> lObjMesas = new List<GestionClubMesaDto>();
        public List<GestionClubCategoriaDto> lObjCategoria = new List<GestionClubCategoriaDto>();
        public List<GestionClubProductoDto> lObjProductos = new List<GestionClubProductoDto>();
        public List<GestionClubProductoDto> lObjProductosParcial = new List<GestionClubProductoDto>();
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty;
        public int eVaBDProducto = 1, eVaBDMesa = 1;
        public int seleccionaMesa = 0, seleccionaProducto = 0, seleccionaProductoSeleccionados = 0;
        public string keyMesa = string.Empty;

        public frmComanda()
        {
            InitializeComponent();
        }

        public void NewWindow()
        {
            this.CargarRutas();
            this.CargarAmbientes();
            this.CargarMeseros();
            this.cargarMesas();
            this.CargarCategorias();
            this.CargarProductosSeleccionados();
            this.MostrarComanda(GestionClubMesaController.EnBlanco());
            this.Show();
        }
        public void CargarRutas()
        {
            rutaMesa = ConfigurationManager.AppSettings["RutaMesa"].ToString();
            rutaCategoria = ConfigurationManager.AppSettings["RutaCategoria"].ToString();
            rutaProducto = ConfigurationManager.AppSettings["RutaProducto"].ToString();
        }
        public void CargarMeseros()
        {
            GestionClubAccessDto objEn = new GestionClubAccessDto();
            objEn.gradoAcceso = 4;
            Cmb.Cargar(this.cboMesero, oOpeAcc.ListarUsuarioMeserosActivos(objEn), GestionClubAccessDto.IdAcc, GestionClubAccessDto.nombresAcc);
        }
        public void CargarAmbientes()
        {
            Cmb.Cargar(this.cboAmbiente, oOpeAmbiente.ListarAmbientesActivos(), GestionClubAmbientesDto._idAmbiente, GestionClubAmbientesDto._desAmbiente);
        }
        public void cargarMesas()
        {
            this.seleccionaMesa = 0;
            this.lvProductos.Items.Clear();
            this.lvMesas.Items.Clear();
            this.CargarMesasPorAmbienteDesdeBaseDeDatos();

            if (this.lObjMesas.Count == 0) { this.lvMesas.Items.Clear(); return; }

            this.lvMesas.View = View.LargeIcon;
            this.lvMesas.Columns.Add("MESAS", 250);

            this.imgMesas.ImageSize = new Size(40, 40);

            try
            {
                foreach (GestionClubMesaDto oObjEn in lObjMesas)
                {
                    string file = this.rutaMesa + "Mesa.png";
                    this.imgMesas.Images.Add(oObjEn.idMesa.ToString(), Image.FromFile(file));
                }
            }
            catch (Exception)
            {
                throw;
            }

            this.lvMesas.SmallImageList = this.imgMesas;

            foreach (GestionClubMesaDto oObjEn in lObjMesas)
            {
                this.lvMesas.Items.Add(new ListViewItem(new[] { oObjEn.desMesas.ToString() }, oObjEn.idMesa.ToString()));
            }
        }

        public void CargarMesasPorAmbienteDesdeBaseDeDatos()
        {
            GestionClubMesaDto oObjEn = new GestionClubMesaDto();
            oObjEn.idAmbiente = Convert.ToInt32(this.cboAmbiente.SelectedValue);
            this.lObjMesas = GestionClubMesaController.ListarMesasPorAmbientePorEmpresa(oObjEn);
        }

        public void CargarCategorias()
        {
            this.lvCategorias.Items.Clear();

            this.CargarCategoriaDesdeBaseDeDatos();

            lvCategorias.View = View.LargeIcon;

            lvCategorias.Columns.Add("CATEGORIAS", 250);
            imgCategorias.ImageSize = new Size(40, 40);

            try
            {
                foreach (GestionClubCategoriaDto oObjEn in lObjCategoria)
                {
                    string path = this.rutaCategoria + oObjEn.archivoCategoria;
                    imgCategorias.Images.Add(oObjEn.idCategoria.ToString(), Image.FromFile(path));
                }
            }
            catch (Exception)
            {
                throw;
            }

            lvCategorias.SmallImageList = imgCategorias;

            foreach (GestionClubCategoriaDto oObjEn in lObjCategoria)
            {
                lvCategorias.Items.Add(new ListViewItem(new[] { oObjEn.desCategoria.ToString() }, oObjEn.idCategoria.ToString()));
            }
        }
        public void CargarCategoriaDesdeBaseDeDatos()
        {
            this.lObjCategoria = GestionClubCategoriaController.ListarCategoriasActivos();
        }
        public void CargarProductos(int hizoClickCategoria, GestionClubProductoDto obj)
        {
            this.lvProductosSeleccionados.Items.Clear();
            this.lvProductos.Items.Clear();
            this.lvProductos.Columns.Clear();
            //this.txtProducto.Text = string.Empty;

            obj = new GestionClubProductoDto();
            if (hizoClickCategoria == 1)
                this.MostrarProductoPorCategoriaSeleccionada(hizoClickCategoria, obj);

            //validar si es acto ir a la bd
            if (txtProducto.Text.Trim() == string.Empty && eVaBDProducto != 0)
                this.CargarProductoDesdeBaseDeDatos(hizoClickCategoria, obj);

            lvProductos.View = View.Details;

            lvProductos.Columns.Add("PRODUCTOS", 220);
            lvProductos.Columns.Add("PRECIO", 80);

            imgProductos.ImageSize = new Size(50, 50);

            try
            {
                foreach (GestionClubProductoDto oObjEn in this.lObjProductos)
                {
                    string path = this.rutaProducto + oObjEn.archivoProducto;
                    imgProductos.Images.Add(oObjEn.idProducto.ToString(), Image.FromFile(path));
                }
            }
            catch (Exception)
            {
                throw;
            }

            lvProductos.SmallImageList = imgProductos;

            foreach (GestionClubProductoDto oObjEn in this.lObjProductos)
            {
                lvProductos.Items.Add(new ListViewItem(new[] { oObjEn.desProducto.ToString(), oObjEn.preCosProducto.ToString() }, oObjEn.idProducto.ToString()));
            }
        }
        public void CargarProductoDesdeBaseDeDatos(int clickCategoria, GestionClubProductoDto obj)
        {
            if (clickCategoria == 0)
            {
                this.lObjProductos = GestionClubProductoController.ListarProductosActivos();
                this.lObjProductosParcial = this.lObjProductos;
            }
            else
            {
                this.lObjProductos = GestionClubProductoController.ListarProductosActivosPorCategoria(obj);
                this.lObjProductosParcial = this.lObjProductos;
            }

            clickCategoria = 0;
        }
        public void ActualizarVentanaAlBuscarValorProducto(KeyEventArgs pE)
        {
            if (this.lObjProductosParcial.Count == 0) { return; }
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    { break; }
                default:
                    {
                        if (this.txtProducto.Text != string.Empty) { eVaBDProducto = 0; }
                        this.ActualizarLvProducto();
                        eVaBDProducto = 1;
                        break;
                    }
            }
        }
        public void ActualizarLvProducto()
        {
            this.lObjProductos = this.lObjProductosParcial.Where(x => x.desProducto.ToUpper().Contains(this.txtProducto.Text.ToUpper())).ToList();
            this.CargarProductos(0, null);
        }
        public void CargarProductosSeleccionados()
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
        public void MostrarComanda(GestionClubMesaDto pObj)
        {
            this.cboAmbiente.SelectedValue = pObj.idAmbiente;
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmComanda, wMen.tsbComanda);
        }
        public void MostrarProductoPorMesaSeleccionada()
        {
            this.seleccionaMesa = 1;
            String selected = lvMesas.SelectedItems[0].SubItems[0].Text;
            this.gbProductos.Text = "PRODUCTOS";
            this.gbProductos.Text = gbProductos.Text + ": " + selected;

            this.gbProductosSeleccionados.Text = "PRODUCTO SELECCIONADOS";
            this.gbProductosSeleccionados.Text = gbProductosSeleccionados.Text + ": " + selected;
            this.keyMesa = this.lvMesas.SelectedItems[0].ImageKey;
            this.CargarProductos(0, null);
        }

        public void MostrarProductoPorCategoriaSeleccionada(int clickCategoria, GestionClubProductoDto obj)
        {
            clickCategoria = 1;
            obj.idCategoria = Convert.ToInt32(lvCategorias.SelectedItems[0].ImageKey);
        }

        public void AgregarProductoSeleccionados()
        {
            if (this.nudCantidadProducto.Value == 0) { Mensaje.OperacionDenegada("Ingrese una cantidad.", this.eTitulo); return; }

            if (this.seleccionaProducto == 0) { Mensaje.OperacionDenegada("Seleccione Producto.", this.eTitulo); return; }

            if (this.lvProductosSeleccionados.Items.Count > 0)
            {
                for (int i = 0; i < this.lvProductosSeleccionados.Items.Count; i++)
                {
                    if (this.lvProductosSeleccionados.Items[i].ImageKey == lvProductos.SelectedItems[0].ImageKey.ToString())
                        this.lvProductosSeleccionados.Items[i].Remove();
                }
            }

            this.lvProductosSeleccionados.Items.Add(new ListViewItem(new[] { lvProductos.SelectedItems[0].SubItems[0].Text, nudCantidadProducto.Value.ToString(), lvProductos.SelectedItems[0].SubItems[1].Text }, lvProductos.SelectedItems[0].ImageKey.ToString()));
            this.nudCantidadProducto.Value = 0;
        }
        public void QuitarProductoSeleccionado()
        {
            if (this.seleccionaProductoSeleccionados == 0) { Mensaje.OperacionDenegada("Seleccione Producto que desea quitar.", eTitulo); return; }
            this.lvProductosSeleccionados.SelectedItems[0].Remove();

            this.seleccionaProductoSeleccionados = 0;
        }
        public bool ValidarQueSeleccioneMesa()
        {
            bool result = false;

            if (this.seleccionaMesa == 0)
            {
                Mensaje.OperacionDenegada("Seleccione Mesa.", eTitulo);
                result = true;
            }
            return result;

        }
        public bool ValidarQueHayProductoSeleccionados()
        {
            bool result = false;

            if (this.lvProductosSeleccionados.Items.Count == 0)
            {
                Mensaje.OperacionDenegada("Seleccione Productos.", eTitulo);
                result = true;
            }
            return result;

        }
        public bool ValidaLaListaProductoSeleccionados()
        {
            bool result = true;
            if (this.lvProductosSeleccionados.Items.Count > 0)
            {
                result = Mensaje.DeseasRealizarOperacion("Hay productos pendientes para realizar pedido.", this.eTitulo);
                if (!result)
                    this.ResetearFocusSeleccionadoMesa();

            }
            return result;
        }
        public void ResetearFocusSeleccionadoMesa()
        {
            for (int i = 0; i < this.lvMesas.Items.Count; i++)
            {
                this.lvMesas.Items[i].Selected = false;
            }
            for (int i = 0; i < this.lvMesas.Items.Count; i++)
            {
                if (this.lvMesas.Items[i].ImageKey == keyMesa)
                {
                    this.lvMesas.Items[i].Selected = true;
                }
            }
        }
        public void BloquearMesa()
        {
            Image newImage = Image.FromFile(this.rutaMesa + "Mesa4.png");
            Image previousImage = this.imgMesas.Images[this.imgMesas.Images.Keys.IndexOf(keyMesa)];

            this.imgMesas.Images.RemoveByKey(keyMesa);
            // add a new image
            this.imgMesas.Images.Add(keyMesa, newImage);
            previousImage.Dispose();
        }
        private void lvMesas_MouseClick(object sender, MouseEventArgs e)
        {
            this.seleccionaMesa = 1;
            if (!this.ValidarQueSeleccioneMesa())
                if (this.ValidaLaListaProductoSeleccionados())
                {
                    this.MostrarProductoPorMesaSeleccionada();
                }
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

        private void lvCategorias_MouseClick(object sender, MouseEventArgs e)
        {
            this.CargarProductos(1, null);
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValorProducto(e);
        }

        private void lvProductos_MouseClick(object sender, MouseEventArgs e)
        {
            this.seleccionaProducto = 1;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.QuitarProductoSeleccionado();
        }

        private void lvProductosSeleccionados_MouseClick(object sender, MouseEventArgs e)
        {
            this.seleccionaProductoSeleccionados = 1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!this.ValidarQueSeleccioneMesa())
                this.AgregarProductoSeleccionados();
        }

        private void tsbRealizarPedido_Click(object sender, EventArgs e)
        {
            if (!this.ValidarQueHayProductoSeleccionados())
            {
                this.eVaBDMesa = 0;
                tsbRealizarPedido.Enabled = !tsbRealizarPedido.Enabled;
                btnCobrar.Enabled = !btnCobrar.Enabled;
                this.BloquearMesa();
            }

        }

        private void cboAmbiente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cargarMesas();
        }
    }
}
