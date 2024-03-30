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
    public partial class frmTipoCambio : Form
    {
        public string eTitulo = "Tipo de Cambio";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubTipoCambioDto> eLisTipoCambio = new List<GestionClubTipoCambioDto>();
        public GestionClubTipoCambioController oOpe = new GestionClubTipoCambioController();
        Dgv.Franja eFranjaDgvTipoCambio = Dgv.Franja.PorIndice;
        public string eClaveDgvTipoCambio = string.Empty;
        string eNombreColumnaDgvTipoCambio = "FechaTipoCambio";
        string eEncabezadoColumnaDgvTipoCambio = "FechaTipoCambio";
        public frmTipoCambio()
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
            this.ActualizarListaTipoCambioDeBaseDatos();
            this.ActualizarDgvTipoCambio();
            Dgv.HabilitarDesplazadores(this.DgvTipoCambio, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvTipoCambio, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaTipoCambioDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubTipoCambioDto iOpEN = new GestionClubTipoCambioDto();
            this.eLisTipoCambio = oOpe.ListarTipoCambio().OrderByDescending(x => x.FechaTipoCambio).ToList();
        }
        public void ActualizarDgvTipoCambio()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvTipoCambio;
            List<GestionClubTipoCambioDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvTipoCambio;
            string iClaveBusqueda = eClaveDgvTipoCambio;
            string iColumnaPintura = eNombreColumnaDgvTipoCambio;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvTipoCambio();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubTipoCambioDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipoCambio;
            List<GestionClubTipoCambioDto> iListaTipoCambio = eLisTipoCambio;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaTipoCambio);
        }
        public List<DataGridViewColumn> ListarColumnasDgvTipoCambio()
        {
            //lista resultado
            List<DataGridViewColumn> iLisTipoCambio = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._FechaTipoCambio, "Fecha", 80));
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._CompraTipoCambio, "Compra", 80));
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._VentaTipoCambio, "Venta", 80));
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._Estado, "Estado", 150));
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._idTipoCambio, "idTipoCambio", 150, false));
            iLisTipoCambio.Add(Dgv.NuevaColumnaTextCadena(GestionClubTipoCambioDto._claveObjeto, "claveObjeto", 150, false));

            //devolver
            return iLisTipoCambio;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvTipoCambio;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmTipoCambio, null);
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarTipoCambio win = new frmEditarTipoCambio();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipoCambio = Dgv.Franja.PorValor;
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
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubTipoCambioDto iPerEN = this.EsActoModificarTipoCambio();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTipoCambio win = new frmEditarTipoCambio();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipoCambio = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public GestionClubTipoCambioDto EsActoModificarTipoCambio()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = GestionClubTipoCambioController.EsActoModificarTipoCambio(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AsignarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            pObj.FechaTipoCambio = Dgv.ObtenerValorCelda(this.DgvTipoCambio, GestionClubTipoCambioDto._FechaTipoCambio);
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
            GestionClubTipoCambioDto iPerEN = this.EsActoEliminarTipoCambio();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTipoCambio win = new frmEditarTipoCambio();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipoCambio = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }
        public GestionClubTipoCambioDto EsActoEliminarTipoCambio()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = GestionClubTipoCambioController.EsActoEliminarTipoCambio(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubTipoCambioDto iPerEN = this.EsTipoCambioExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTipoCambio win = new frmEditarTipoCambio();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubTipoCambioDto EsTipoCambioExistente()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = GestionClubTipoCambioController.EsTipoCambioExistente(iPerEN);
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

        private void frmTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipoCambio, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvTipoCambio = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvTipoCambio_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void DgvTipoCambio_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvTipoCambio, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvTipoCambio, this.sst1);
        }
    }
}
