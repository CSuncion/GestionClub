using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Maestros
{
    public partial class frmProductos : Form
    {
        public string eTitulo = "Registro Productos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubProductoDto> eLisProducto = new List<GestionClubProductoDto>();
        public GestionClubProductoController oOpe = new GestionClubProductoController();
        Dgv.Franja eFranjaDgvProducto = Dgv.Franja.PorIndice;
        public string eClaveDgvProducto = string.Empty;
        string eNombreColumnaDgvProducto = "codProducto";
        string eEncabezadoColumnaDgvProducto = "nombreRazSocialProducto";
        public frmProductos()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaProductoDeBaseDatos();
            this.ActualizarDgvProductos();
            Dgv.HabilitarDesplazadores(this.DgvProductos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvProductos, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaProductoDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubProductoDto iOpEN = new GestionClubProductoDto();
            this.eLisProducto = oOpe.ListarProductos();
        }
        public void ActualizarDgvProductos()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvProductos;
            List<GestionClubProductoDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvProducto;
            string iClaveBusqueda = eClaveDgvProducto;
            string iColumnaPintura = eNombreColumnaDgvProducto;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProducto();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubProductoDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvProducto;
            List<GestionClubProductoDto> iListaProductos = eLisProducto;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaProductos);
        }
        public List<DataGridViewColumn> ListarColumnasDgvProducto()
        {
            //lista resultado
            List<DataGridViewColumn> iLisProducto = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._codProducto, "Código", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._desProducto, "Descripción", 250));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._desCategoria, "Categoria", 150));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._uniMedProducto, "Medida", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._codMoneda, "Moneda", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preCosProducto, "P. Costo", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preVtsProducto, "P. Venta", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preVnsProducto, "P.V. No Soc.", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._afeIgvProducto, "A. IGV", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._afeDtraProducto, "A. Dtra. IGV", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._porDtraProducto, "% Dtra.", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._impDolProducto, "Imp. $", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._impOtrProducto, "Imp. Otro", 80));
            iLisProducto.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._estadoProducto, "Estado", 80));

            //devolver
            return iLisProducto;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvProducto;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmMasterProductos, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
