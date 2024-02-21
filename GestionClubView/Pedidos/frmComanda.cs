using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Pedidos
{
    public partial class frmComanda : Form
    {
        public string eTitulo = "Comanda";
        public GestionClubAmbienteController oOpeAmbiente = new GestionClubAmbienteController();
        public GestionClubMesaController oOpeMesa = new GestionClubMesaController();
        GestionClubAccessController oOpeAcc = new GestionClubAccessController();
        GestionClubComandaController oOpeCom = new GestionClubComandaController();
        public List<GestionClubMesaDto> lObjMesas = new List<GestionClubMesaDto>();
        public List<GestionClubCategoriaDto> lObjCategoria = new List<GestionClubCategoriaDto>();
        public List<GestionClubProductoDto> lObjProductos = new List<GestionClubProductoDto>();
        public List<GestionClubProductoDto> lObjProductosParcial = new List<GestionClubProductoDto>();
        public List<GestionClubDetalleComandaDto> lObjDetalleComanda = new List<GestionClubDetalleComandaDto>();
        public List<GestionClubDetalleComandaDto> lObjDetalleComandaParcial = new List<GestionClubDetalleComandaDto>();
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty;
        public int eVaBDProducto = 1, eVaBDMesa = 1;
        public int seleccionaMesa = 0, seleccionaProducto = 0, seleccionaProductoSeleccionados = 0, realizoPedido = 0;
        public string keyMesa = string.Empty;
        public frmPrincipal wFrm;

        public frmComanda()
        {
            InitializeComponent();
        }

        public void NewWindow()
        {
            if (!this.ValidaAperturaCaja())
            {
                this.Cerrar();
                //this.wFrm.InstanciarAperturaCaja();
                return;
            }

            this.CargarRutas();
            this.CargarAmbientes();
            this.CargarMeseros();
            this.cargarMesas();
            this.CargarCategorias();
            this.CargarProductoDesdeBD();
            this.CargarProductosSeleccionados();
            this.MostrarComanda(GestionClubMesaController.EnBlanco());
            this.Show();
        }
        public bool ValidaAperturaCaja()
        {
            bool result = true;
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            gestionClubAperturaCajaDto.caja = Universal.caja;
            gestionClubAperturaCajaDto = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0)
            {
                Mensaje.OperacionDenegada("Debe aperturar la caja.", this.eTitulo);
                result = false;
            }

            return result;
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
            objEn.gradoAcceso = 3;
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
            this.lvMesas.Clear();
            this.imgMesas.Images.Clear();
            this.CargarMesasPorAmbienteDesdeBaseDeDatos();

            if (this.lObjMesas.Count == 0) { this.lvMesas.Items.Clear(); return; }

            this.lvMesas.View = View.LargeIcon;
            this.lvMesas.Columns.Add("MESAS", 250);

            this.imgMesas.ImageSize = new System.Drawing.Size(40, 40);

            try
            {
                foreach (GestionClubMesaDto oObjEn in this.lObjMesas)
                {
                    string file = string.Empty;
                    if (oObjEn.sitMesa == "01")
                        file = this.rutaMesa + "Mesa.png";
                    else
                        file = this.rutaMesa + "Mesa4.png";

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
            this.lvMesas.Refresh();
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
            imgCategorias.ImageSize = new System.Drawing.Size(40, 40);

            try
            {
                foreach (GestionClubCategoriaDto oObjEn in lObjCategoria)
                {
                    string path = this.rutaCategoria + (oObjEn.archivoCategoria == string.Empty ? "no-foto.png" : oObjEn.archivoCategoria);
                    imgCategorias.Images.Add(oObjEn.codCategoria.ToString(), Image.FromFile(path));
                }
            }
            catch (Exception)
            {
                throw;
            }

            lvCategorias.SmallImageList = imgCategorias;

            foreach (GestionClubCategoriaDto oObjEn in lObjCategoria)
            {
                lvCategorias.Items.Add(new ListViewItem(new[] { oObjEn.desCategoria.ToString() }, oObjEn.codCategoria.ToString()));
            }
        }
        public void CargarCategoriaDesdeBaseDeDatos()
        {
            this.lObjCategoria = GestionClubCategoriaController.ListarCategoriasActivos();
        }
        public void CargarProductoDesdeBD()
        {
            this.lObjProductos = GestionClubProductoController.ListarProductosActivos();
            this.lObjProductosParcial = this.lObjProductos;
        }
        public void CargarProductosSegunBusqueda(int hizoClickCategoria, GestionClubProductoDto obj)
        {
            //this.lvProductosSeleccionados.Items.Clear();
            this.lvProductos.Items.Clear();
            this.lvProductos.Clear();
            this.lvProductos.Columns.Clear();
            //this.txtProducto.Text = string.Empty;

            obj = new GestionClubProductoDto();
            if (hizoClickCategoria == 1)
                this.MostrarProductoPorCategoriaSeleccionada(hizoClickCategoria, obj);

            //validar si es acto ir a la bd
            if ((this.txtProducto.Text.Trim() != string.Empty && eVaBDProducto == 0) || hizoClickCategoria == 1)
                this.CargarProductoDesdeBaseFiltro(hizoClickCategoria, obj);

            lvProductos.View = View.Details;

            lvProductos.Columns.Add("PRODUCTOS", 220);
            lvProductos.Columns.Add("PRECIO", 80);

            imgProductos.ImageSize = new System.Drawing.Size(50, 50);

            try
            {
                foreach (GestionClubProductoDto oObjEn in this.lObjProductos)
                {
                    string path = this.rutaProducto + (oObjEn.archivoProducto == string.Empty ? "no-foto.png" : oObjEn.archivoProducto);
                    this.imgProductos.Images.Add(oObjEn.idProducto.ToString(), Image.FromFile(path));
                }
            }
            catch (Exception)
            {
                throw;
            }

            this.lvProductos.SmallImageList = imgProductos;

            foreach (GestionClubProductoDto oObjEn in this.lObjProductos)
            {
                this.lvProductos.Items.Add(new ListViewItem(new[] { oObjEn.desProducto.ToString(), oObjEn.preCosProducto.ToString() }, oObjEn.idProducto.ToString()));
            }
        }
        public void CargarProductoDesdeBaseFiltro(int clickCategoria, GestionClubProductoDto obj)
        {
            if (clickCategoria == 0)
            {
                this.lObjProductos = this.lObjProductosParcial.Where(x => x.desProducto.ToUpper().Contains(this.txtProducto.Text.ToUpper())).ToList();
            }
            else
            {
                //this.lObjProductos = GestionClubProductoController.ListarProductosActivosPorCategoria(obj);
                //this.lObjProductosParcial = this.lObjProductos;
                //this.lObjProductos = this.lObjProductosParcial.Where(x => x.idCategoria == obj.idCategoria).ToList();
                this.lObjProductos = this.lObjProductosParcial.Where(x => x.idCategoria == obj.idCategoria && x.desProducto.ToUpper().Contains(this.txtProducto.Text.ToUpper())).ToList();
            }

            clickCategoria = 0;
        }
        public void ActualizarVentanaAlBuscarValorProducto(KeyEventArgs pE)
        {
            //if (this.lObjProductosParcial.Count == 0) { return; }
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
                        if (this.txtProducto.Text != string.Empty && this.txtProducto.Text.Length > 3) { eVaBDProducto = 0; }
                        this.ActualizarLvProducto();
                        eVaBDProducto = 1;
                        break;
                    }
            }
        }
        public void ActualizarLvProducto()
        {
            this.CargarProductosSegunBusqueda(0, null);
            //this.lObjProductos = this.lObjProductosParcial.Where(x => x.desProducto.ToUpper().Contains(this.txtProducto.Text.ToUpper())).ToList();            
        }
        public void CargarProductosSeleccionados()
        {
            this.lvProductosSeleccionados.Items.Clear();
            this.lvProductosSeleccionados.Clear();
            this.lvProductosSeleccionados.Columns.Clear();
            this.lvProductosSeleccionados.Clear();

            lvProductosSeleccionados.View = View.LargeIcon;

            lvProductosSeleccionados.Columns.Add("PRODUCTOS", 230);
            lvProductosSeleccionados.Columns.Add("CANTIDAD", 70);
            lvProductosSeleccionados.Columns.Add("IMPORTE", 70);
            lvProductosSeleccionados.Columns.Add("IdDetalleComanda", 100);
            lvProductosSeleccionados.Columns[3].Width = 0;

            lvProductosSeleccionados.Columns[1].TextAlign = HorizontalAlignment.Center;
            lvProductosSeleccionados.Columns[2].TextAlign = HorizontalAlignment.Right;
        }

        public void AccionCobrar()
        {
            GestionClubComandaDto iComObj = new GestionClubComandaDto();//this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }
            this.AsignarComanda(iComObj);
            frmCobrar win = new frmCobrar();
            win.wCom = this;
            win.eOperacion = Universal.Opera.Cobrar;
            //this.eFranjaDgvRefAmp = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaCobrar(iComObj);
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
            //this.CargarProductosSegunBusqueda(0, null);
        }

        public void MostrarProductoPorCategoriaSeleccionada(int clickCategoria, GestionClubProductoDto obj)
        {
            clickCategoria = 1;
            obj.idCategoria = Convert.ToString(lvCategorias.SelectedItems[0].ImageKey);
        }

        public void AgregarProductoSeleccionados()
        {

            lvProductosSeleccionados.View = View.Details;
            this.lvProductosSeleccionados.SmallImageList = this.imgProductosSel;

            if (this.nudCantidadProducto.Value == 0) { Mensaje.OperacionDenegada("Ingrese una cantidad.", this.eTitulo); return; }

            if (this.seleccionaProducto == 0) { Mensaje.OperacionDenegada("Seleccione Producto.", this.eTitulo); return; }

            if (this.lvProductosSeleccionados.Items.Count > 0)
            {
                for (int i = 0; i < this.lvProductosSeleccionados.Items.Count; i++)
                {
                    if (this.lvProductosSeleccionados.Items[i].ImageKey == this.lvProductos.SelectedItems[0].ImageKey.ToString())
                        this.lvProductosSeleccionados.Items[i].Remove();
                }
            }
            else
            {
                this.lblCantidad.Text = "0";
                this.lblTotal.Text = "0";
            }
            this.imgProductosSel.ImageSize = new System.Drawing.Size(50, 50);

            this.imgProductosSel.Images.Add(this.lvProductos.SelectedItems[0].ImageKey.ToString(), this.imgProductos.Images[this.lvProductos.SelectedItems[0].ImageKey]);

            int idDetalleComanda = 0;
            if (this.lObjDetalleComanda.Count > 0)
                if (this.lObjDetalleComanda.Exists(x => x.idProducto.ToString() == lvProductos.SelectedItems[0].ImageKey.ToString()))
                    idDetalleComanda = this.lObjDetalleComanda.Find(x => x.idProducto.ToString() == lvProductos.SelectedItems[0].ImageKey.ToString()).idDetalleComanda;
                else
                    idDetalleComanda = 0;
            else
                idDetalleComanda = 0;


            this.lvProductosSeleccionados.Items.Add(new ListViewItem(new[] { lvProductos.SelectedItems[0].SubItems[0].Text, nudCantidadProducto.Value.ToString(), lvProductos.SelectedItems[0].SubItems[1].Text, idDetalleComanda.ToString() }, lvProductos.SelectedItems[0].ImageKey.ToString()));

            this.lblCantidad.Text = (Convert.ToInt32(this.lblCantidad.Text) + Convert.ToInt32(nudCantidadProducto.Value)).ToString();
            this.lblTotal.Text = (Convert.ToDecimal(this.lblTotal.Text) + Convert.ToInt32(nudCantidadProducto.Value) * Convert.ToDecimal(this.lvProductos.SelectedItems[0].SubItems[1].Text)).ToString();

            this.nudCantidadProducto.Value = 0;
        }
        public void MostrarProductosPedidosEnComandaBD()
        {
            lvProductosSeleccionados.View = View.Details;

            GestionClubDetalleComandaDto objEn = new GestionClubDetalleComandaDto();
            objEn.idMesa = Convert.ToInt32(this.lvMesas.SelectedItems[0].ImageKey);
            this.lvProductosSeleccionados.Items.Clear();

            this.lObjDetalleComanda = GestionClubComandaController.ListarDetalleComandaPorMesaYPendienteCobrar(objEn);
            this.lObjDetalleComandaParcial.AddRange(this.lObjDetalleComanda);

            this.lblCantidad.Text = "0";
            this.lblTotal.Text = "0";

            foreach (GestionClubDetalleComandaDto detalle in this.lObjDetalleComanda)
            {
                this.lblIdComanda.Text = this.lObjDetalleComanda.FirstOrDefault().idComanda.ToString();
                this.imgProductosSel.ImageSize = new System.Drawing.Size(50, 50);
                this.imgProductosSel.Images.Add(detalle.idProducto.ToString(), Image.FromFile(this.rutaProducto + (detalle.archivoProducto == string.Empty ? "no-foto.png" : detalle.archivoProducto)));
                this.lvProductosSeleccionados.SmallImageList = this.imgProductosSel;

                this.lvProductosSeleccionados.SmallImageList = imgProductosSel;
                this.lvProductosSeleccionados.Items.Add(new ListViewItem(new[] { detalle.desProducto.ToString(), detalle.cantidad.ToString(), detalle.preVenta.ToString(), detalle.idDetalleComanda.ToString() }, detalle.idProducto.ToString()));

                this.lblCantidad.Text = (Convert.ToInt32(this.lblCantidad.Text) + Convert.ToInt32(detalle.cantidad.ToString())).ToString();
                this.lblTotal.Text = (Convert.ToDecimal(this.lblTotal.Text) + Convert.ToInt32(detalle.cantidad.ToString()) * Convert.ToDecimal(detalle.preVenta)).ToString();
            }
        }
        public void QuitarProductoSeleccionado()
        {
            if (this.seleccionaProductoSeleccionados == 0) { Mensaje.OperacionDenegada("Seleccione Producto que desea quitar.", eTitulo); return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.EliminarDetalleComanda();

            this.lvProductosSeleccionados.SelectedItems[0].Remove();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El pedido se elimino correctamente", this.eTitulo);

            this.seleccionaProductoSeleccionados = 0;
        }

        public void EliminarDetalleComanda()
        {
            GestionClubDetalleComandaDto obj = new GestionClubDetalleComandaDto();
            obj.idDetalleComanda = Convert.ToInt32(this.lvProductosSeleccionados.SelectedItems[0].SubItems[3].Text);
            GestionClubComandaController.EliminarDetalleComanda(obj);
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
            if (this.realizoPedido == 1)
                result = true;
            else
            {
                if (this.lvProductosSeleccionados.Items.Count > 0)
                {
                    result = Mensaje.DeseasRealizarOperacion("Hay productos pendientes para realizar pedido.", this.eTitulo);
                    if (!result)
                        this.ResetearFocusSeleccionadoMesa();

                }
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

        public void Adicionar()
        {
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.AdicionarComanda();
            this.ActualizarCorrelativoComprobante();
            this.ModificarSituacionMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Comanda se adiciono correctamente", this.eTitulo);

        }
        public void AdicionarComanda()
        {
            GestionClubComandaDto iObjEN = new GestionClubComandaDto();
            this.AsignarComanda(iObjEN);
            int identity = GestionClubComandaController.AgregarComanda(iObjEN);



            GestionClubDetalleComandaDto iDetObjEN = new GestionClubDetalleComandaDto();
            this.AsignarDetalleComanda(iDetObjEN, identity);
            foreach (GestionClubDetalleComandaDto item in this.lObjDetalleComanda)
            {
                GestionClubComandaController.AgregarDetalleComanda(item);
            }
        }
        public void Modificar()
        {
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            this.ModificarComanda();
            this.ModificarSituacionMesa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Comanda se modifico correctamente", this.eTitulo);

        }
        public void ModificarComanda()
        {
            GestionClubComandaDto iObjEN = new GestionClubComandaDto();
            this.AsignarComanda(iObjEN);
            GestionClubComandaController.ModificarComanda(iObjEN);

            GestionClubDetalleComandaDto iDetObjEN = new GestionClubDetalleComandaDto();
            this.AsignarDetalleComanda(iDetObjEN, Convert.ToInt32(this.lblIdComanda.Text));

            foreach (GestionClubDetalleComandaDto obj in this.lObjDetalleComanda)
            {
                if (this.lObjDetalleComandaParcial.Exists(x => x.idProducto == obj.idProducto))
                    GestionClubComandaController.ModificarDetalleComanda(obj);
                else
                    GestionClubComandaController.AgregarDetalleComanda(obj);
            }

        }
        public string GenerarCorrelativo()
        {
            GestionClubCorrelativoComprobanteDto gestionClubCorrelativoComprobanteDto = new GestionClubCorrelativoComprobanteDto();
            gestionClubCorrelativoComprobanteDto.tipoDocumento = "CO";
            gestionClubCorrelativoComprobanteDto = GestionClubCorrelativoComprobanteController.GenerarCorrelativo(gestionClubCorrelativoComprobanteDto);
            return gestionClubCorrelativoComprobanteDto.nroCorrelativo;
        }
        public void ActualizarCorrelativoComprobante()
        {
            ;
            GestionClubCorrelativoComprobanteDto obj = new GestionClubCorrelativoComprobanteDto();
            obj.tipoDocumento = "CO";
            obj.serCorrelativo = "";
            obj.nroCorrelativo = this.GenerarCorrelativo();
            GestionClubCorrelativoComprobanteController.ActualizarCorrelativo(obj);
        }
        public void AsignarComanda(GestionClubComandaDto pObj)
        {
            pObj.tipDocumentoComanda = "CO";
            pObj.nroComanda = this.GenerarCorrelativo();
            pObj.idAmbiente = Convert.ToInt32(Cmb.ObtenerValor(this.cboAmbiente, string.Empty));
            pObj.idMesa = Convert.ToInt32(this.lvMesas.SelectedItems[0].ImageKey);
            pObj.fecComanda = DateTime.Now;
            pObj.idMozo = Convert.ToInt32(Cmb.ObtenerValor(this.cboMesero, string.Empty));
            pObj.turnoCaja = "01";
            pObj.idCliente = 0;
            pObj.idComprobante = 0;
            pObj.nroAtencion = "01";
            pObj.obsComprobante = string.Empty;
            pObj.estadoComanda = "01";
            pObj.idComanda = Convert.ToInt32(this.lblIdComanda.Text);
        }

        public void AsignarDetalleComanda(GestionClubDetalleComandaDto pObj, int identity)
        {
            this.lObjDetalleComanda.Clear();

            foreach (ListViewItem item in this.lvProductosSeleccionados.Items)
            {
                pObj = new GestionClubDetalleComandaDto();
                pObj.idComanda = identity;
                pObj.idAmbiente = Convert.ToInt32(Cmb.ObtenerValor(this.cboAmbiente, string.Empty));
                pObj.idMesa = Convert.ToInt32(this.lvMesas.SelectedItems[0].ImageKey);
                pObj.fecDetalleComanda = DateTime.Now;
                pObj.idMozo = Convert.ToInt32(Cmb.ObtenerValor(this.cboMesero, string.Empty));
                pObj.idProducto = Convert.ToInt32(item.ImageKey);
                pObj.idDetalleComanda = Convert.ToInt32(item.SubItems[3].Text);
                pObj.cantidad = Convert.ToInt32(item.SubItems[1].Text);
                pObj.preVenta = Convert.ToDecimal(item.SubItems[2].Text);
                pObj.preTotal = (pObj.preVenta * pObj.cantidad);
                pObj.nroAtencion = "01";
                pObj.obsComprobante = string.Empty;
                pObj.estadoComanda = "01";

                this.lObjDetalleComanda.Add(pObj);
            }
        }
        public void ModificarSituacionMesa()
        {
            GestionClubMesaDto obj = new GestionClubMesaDto();
            obj = this.lObjMesas.Find(x => x.idMesa == Convert.ToInt32(this.lvMesas.SelectedItems[0].ImageKey));
            obj.sitMesa = "02";
            GestionClubMesaController.ModificarMesa(obj);
        }

        public void CambiarDeEstadoBotonesPorMesas()
        {
            if (this.lObjDetalleComanda.Count > 0)
            {
                this.btnCobrar.Enabled = true;
            }
            else
            {
                this.btnCobrar.Enabled = false;
            }
        }
        public void LimpiarLvSeleccionados()
        {
            this.lvProductosSeleccionados.Items.Clear();
        }

        public void Aceptar()
        {
            if (!this.ValidarQueHayProductoSeleccionados())
            {
                this.eVaBDMesa = 0;
                //tsbRealizarPedido.Enabled = !tsbRealizarPedido.Enabled;
                this.btnCobrar.Enabled = !this.btnCobrar.Enabled;
                this.BloquearMesa();
                if (this.lblIdComanda.Text == "0")
                    this.Adicionar();
                else
                    this.Modificar();

                this.realizoPedido = 1;
            }
        }
        public void SeleccionarMesa()
        {
            this.seleccionaProducto = 0;
            this.seleccionaMesa = 1;
            this.lObjDetalleComanda.Clear();
            this.MostrarProductosPedidosEnComandaBD();
            if (this.lObjDetalleComanda.Count > 0)
            {
                this.MostrarProductoPorMesaSeleccionada();
                this.CambiarDeEstadoBotonesPorMesas();
                return;
            }

            if (!this.ValidarQueSeleccioneMesa())
                if (this.ValidaLaListaProductoSeleccionados())
                {
                    this.MostrarProductoPorMesaSeleccionada();
                    this.CambiarDeEstadoBotonesPorMesas();
                }

        }
        private void lvMesas_MouseClick(object sender, MouseEventArgs e)
        {
            this.SeleccionarMesa();
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
            //if (!this.ValidarQueSeleccioneMesa())
            this.CargarProductosSegunBusqueda(1, null);
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
            this.Aceptar();

        }
        private void cboAmbiente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cargarMesas();
            this.CargarProductosSeleccionados();
        }
    }
}
