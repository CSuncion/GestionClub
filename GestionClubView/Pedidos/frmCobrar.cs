using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;

namespace GestionClubView.Pedidos
{
    public partial class frmCobrar : Form
    {
        public frmComanda wCom;
        Masivo eMas = new Masivo();
        public Universal.Opera eOperacion;
        public List<GestionClubDetalleComandaDto> lObjDetalle = new List<GestionClubDetalleComandaDto>();
        public string rutaMesa = string.Empty, rutaCategoria = string.Empty, rutaProducto = string.Empty;
        public frmCobrar()
        {
            InitializeComponent();
        }
        public void VentanaCobrar(GestionClubComandaDto objCom)
        {
            this.InicializaVentana();
            this.CargarProductosSeleccionados();
            this.CargarRutas();
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
            //this.ActualizarVentana();
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtEfectivo, true, "Efectivo", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtYape, true, "Yape", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTarjeta, true, "Tarjeta", "vvff", 2);
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
        public void MostrarProductosPedidosEnComandaBD(GestionClubComandaDto objCom)
        {
            lvProductosSeleccionados.View = View.Details;

            GestionClubDetalleComandaDto objEn = new GestionClubDetalleComandaDto();
            objEn.idMesa = objCom.idMesa;
            this.lvProductosSeleccionados.Items.Clear();

            this.lObjDetalle = GestionClubComandaController.ListarDetalleComandaPorMesaYPendienteCobrar(objEn);

            this.lblFecha.Text = this.lObjDetalle.FirstOrDefault().fecDetalleComanda.ToString();
            this.lblAmbiente.Text = this.lObjDetalle.FirstOrDefault().desAmbiente;
            this.lblNroMesa.Text = this.lObjDetalle.FirstOrDefault().desMesas;

            this.txtEfectivo.Text = "0";
            this.txtYape.Text = "0";
            this.txtTransferencia.Text = "0";
            this.txtTarjeta.Text = "0";

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
            this.lblPendiente.Text = (Convert.ToDecimal(this.lblTotal.Text) - (Convert.ToDecimal(this.txtTransferencia.Text) + Convert.ToDecimal(this.txtTarjeta.Text) + Convert.ToDecimal(this.txtYape.Text) + Convert.ToDecimal(this.txtEfectivo.Text))).ToString();
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

        private void chYape_CheckedChanged(object sender, EventArgs e)
        {
            this.txtYape.Enabled = !this.txtYape.Enabled;
        }

        private void tsBtnCobrar_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

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

        private void txtDocId_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtDocId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDocId_Validating(object sender, CancelEventArgs e)
        {

        }

        private void chTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTarjeta.Enabled = !this.txtTarjeta.Enabled;
        }

        private void chTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTransferencia.Enabled = !this.txtTransferencia.Enabled;
        }
    }
}
