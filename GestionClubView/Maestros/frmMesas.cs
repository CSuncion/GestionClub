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
    public partial class frmMesas : Form
    {
        public string eTitulo = "Mesas";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubMesaDto> eLisMesas = new List<GestionClubMesaDto>();
        public GestionClubMesaController oOpe = new GestionClubMesaController();
        Dgv.Franja eFranjaDgvMesas = Dgv.Franja.PorIndice;
        public string eClaveDgvMesas = string.Empty;
        string eNombreColumnaDgvMesas = "desMesas";
        string eEncabezadoColumnaDgvMesas = "desMesas";
        public frmMesas()
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
            this.ActualizarListaMesasDeBaseDatos();
            this.ActualizarDgvMesas();
            Dgv.HabilitarDesplazadores(this.DgvMesas, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvMesas, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaMesasDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubMesaDto iOpEN = new GestionClubMesaDto();
            iOpEN.Adicionales.CampoOrden = eNombreColumnaDgvMesas;
            this.eLisMesas = GestionClubMesaController.ListarMesas();
        }
        public void ActualizarDgvMesas()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMesas;
            List<GestionClubMesaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMesas;
            string iClaveBusqueda = eClaveDgvMesas;
            string iColumnaPintura = eNombreColumnaDgvMesas;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMesas();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubMesaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMesas;
            List<GestionClubMesaDto> iListaMesas = eLisMesas;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMesas);
        }
        public List<DataGridViewColumn> ListarColumnasDgvMesas()
        {
            //lista resultado
            List<DataGridViewColumn> iLisGv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._desAmbiente, "Ambiente", 200));
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._codMesa, "Código", 80));
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._desMesa, "Descripción", 280));
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._Estado, "Estado", 150));
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._idMesa, "idMesa", 80, false));
            iLisGv.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisGv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMesas;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmMesas, null);
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarMesas win = new frmEditarMesas();
            win.wMes = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMesas = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubMesaDto iObjEN = this.EsActoModificarMesa();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMesas win = new frmEditarMesas();
            win.wMes = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMesas = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubMesaDto EsActoModificarMesa()
        {
            GestionClubMesaDto iobjEN = new GestionClubMesaDto();
            this.AsignarMesa(iobjEN);
            iobjEN = GestionClubMesaController.EsActoModificarMesa(iobjEN);
            if (iobjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iobjEN.Adicionales.Mensaje, eTitulo);
            }
            return iobjEN;
        }
        public void AsignarMesa(GestionClubMesaDto pObj)
        {
            pObj.idMesa = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvMesas, GestionClubMesaDto._idMesa));
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

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubMesaDto iObjEN = this.EsActoEliminarMesa();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMesas win = new frmEditarMesas();
            win.wMes = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMesas = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubMesaDto EsActoEliminarMesa()
        {
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();
            this.AsignarMesa(iObjEN);
            iObjEN = GestionClubMesaController.EsActoEliminarMesa(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubMesaDto iPerEN = this.EsMesaExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMesas win = new frmEditarMesas();
            win.wMes = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubMesaDto EsMesaExistente()
        {
            GestionClubMesaDto iPerEN = new GestionClubMesaDto();
            this.AsignarMesa(iPerEN);
            iPerEN = GestionClubMesaController.EsMesaExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMesas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMesas, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMesas = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvMesas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }
    }
}
