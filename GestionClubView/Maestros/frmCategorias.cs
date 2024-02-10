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
using GestionClubController.Controller;
using WinControles;

namespace GestionClubView.Maestros
{
    public partial class frmCategorias : Form
    {
        public string eTitulo = "Categorias";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubCategoriaDto> eLisCategoria = new List<GestionClubCategoriaDto>();
        public GestionClubCategoriaController oOpe = new GestionClubCategoriaController();
        Dgv.Franja eFranjaDgvCategoria = Dgv.Franja.PorIndice;
        public string eClaveDgvCategoria = string.Empty;
        string eNombreColumnaDgvCategoria = "desCategoria";
        string eEncabezadoColumnaDgvCategoria = "desCategoria";
        public frmCategorias()
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
            this.ActualizarListaCategoriaDeBaseDatos();
            this.ActualizarDgvCategorias();
            Dgv.HabilitarDesplazadores(this.DgvCategorias, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCategorias, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaCategoriaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubCategoriaDto iOpEN = new GestionClubCategoriaDto();
            this.eLisCategoria = GestionClubCategoriaController.ListarCategorias();
        }
        public void ActualizarDgvCategorias()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCategorias;
            List<GestionClubCategoriaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCategoria;
            string iClaveBusqueda = eClaveDgvCategoria;
            string iColumnaPintura = eNombreColumnaDgvCategoria;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCategoria();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubCategoriaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCategoria;
            List<GestionClubCategoriaDto> iListaAmbientes = eLisCategoria;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCategoria()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._codCategoria, "Código", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._desCategoria, "Descripción", 280));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._estadoCategoria, "Estado", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._idCategoria, "idCategoria", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._claveObjeto, "claveObjeto", 80, false));
            //devolver
            return iLisDgv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCategoria;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmCategorias, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubCategoriaDto iObjEN = this.EsActoModificarCategoria();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCategorias win = new frmEditarCategorias();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCategoria = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubCategoriaDto EsActoModificarCategoria()
        {
            GestionClubCategoriaDto iObjEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iObjEN);
            iObjEN = GestionClubCategoriaController.EsActoModificarCategoria(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarCategoria(GestionClubCategoriaDto pObj)
        {
            pObj.idCategoria = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvCategorias, GestionClubCategoriaDto._idCategoria));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarCategorias win = new frmEditarCategorias();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCategoria = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubCategoriaDto iObjEN = this.EsActoEliminarCategoria();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCategorias win = new frmEditarCategorias();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCategoria = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubCategoriaDto EsActoEliminarCategoria()
        {
            GestionClubCategoriaDto iObjEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iObjEN);
            iObjEN = GestionClubCategoriaController.EsActoEliminarCategoria(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubCategoriaDto iPerEN = this.EsCategoriaExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCategorias win = new frmEditarCategorias();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubCategoriaDto EsCategoriaExistente()
        {
            GestionClubCategoriaDto iObjEN = new GestionClubCategoriaDto();
            this.AsignarCategoria(iObjEN);
            iObjEN = GestionClubCategoriaController.EsCategoriaExistente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        private void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCategorias, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCategoria = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvCategorias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }
    }
}
