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
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Maestros
{
    public partial class frmProductos : Form
    {
        public string eTitulo = "Productos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubProductoDto> eLisProducto = new List<GestionClubProductoDto>();
        public GestionClubProductoController oOpe = new GestionClubProductoController();
        Dgv.Franja eFranjaDgvProducto = Dgv.Franja.PorIndice;
        public string eClaveDgvProducto = string.Empty;
        string eNombreColumnaDgvProducto = "desProducto";
        string eEncabezadoColumnaDgvProducto = "desProducto";
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
            this.eLisProducto = GestionClubProductoController.ListarProductos();
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
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._codProducto, "Código", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._desProducto, "Descripción", 250));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._Medida, "Medida", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._Moneda, "Moneda", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._desCategoria, "Categoria", 120));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preCosProducto, "P. Costo", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preVtsProducto, "P. Venta", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._preVnsProducto, "P.V. No Soc.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._afeIgvProducto, "A. IGV", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._afeDtraProducto, "A. Dtra. IGV", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._porDtraProducto, "% Dtra.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._impDolProducto, "Imp. $", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._impOtrProducto, "Imp. Otro", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._Estado, "Estado", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._idProducto, "idProducto", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubProductoDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisDgv;
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
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            if (tsbEditar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubProductoDto iObjEN = this.EsActoModificarProducto();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarProductos win = new frmEditarProductos();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvProducto = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubProductoDto EsActoModificarProducto()
        {
            GestionClubProductoDto iObjEN = new GestionClubProductoDto();
            this.AsignarProducto(iObjEN);
            iObjEN = GestionClubProductoController.EsActoModificarProducto(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarProducto(GestionClubProductoDto pObj)
        {
            pObj.idProducto = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvProductos, GestionClubProductoDto._idProducto));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarProductos win = new frmEditarProductos();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvProducto = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubProductoDto iObjEN = this.EsActoEliminarProducto();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarProductos win = new frmEditarProductos();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvProducto = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubProductoDto EsActoEliminarProducto()
        {
            GestionClubProductoDto iObjEN = new GestionClubProductoDto();
            this.AsignarProducto(iObjEN);
            iObjEN = GestionClubProductoController.EsActoEliminarProducto(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubProductoDto iPerEN = this.EsProductoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarProductos win = new frmEditarProductos();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubProductoDto EsProductoExistente()
        {
            GestionClubProductoDto iObjEN = new GestionClubProductoDto();
            this.AsignarProducto(iObjEN);
            iObjEN = GestionClubProductoController.EsProductoExistente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProductos, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvProducto = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }

        private void DgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvProductos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvProductos, this.sst1);
        }
    }
}
