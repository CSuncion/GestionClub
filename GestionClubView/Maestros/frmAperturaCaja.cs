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
    public partial class frmAperturaCaja : Form
    {
        public string eTitulo = "Apertura Caja";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubAperturaCajaDto> eLisAperturaCaja = new List<GestionClubAperturaCajaDto>();
        public GestionClubAperturaCajaController oOpe = new GestionClubAperturaCajaController();
        Dgv.Franja eFranjaDgvAperturaCaja = Dgv.Franja.PorIndice;
        public string eClaveDgvAperturaCaja = string.Empty;
        string eNombreColumnaDgvAperturaCaja = "fecAperturaCaja";
        string eEncabezadoColumnaDgvAperturaCaja = "fecAperturaCaja";
        public frmAperturaCaja()
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
            this.ActualizarListaAperturaCajaDeBaseDatos();
            this.ActualizarDgvAperturaCaja();
            Dgv.HabilitarDesplazadores(this.DgvAperturaCaja, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAperturaCaja, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaAperturaCajaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubAperturaCajaDto iOpEN = new GestionClubAperturaCajaDto();
            this.eLisAperturaCaja = oOpe.ListarAperturaCajas();
        }
        public void ActualizarDgvAperturaCaja()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAperturaCaja;
            List<GestionClubAperturaCajaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAperturaCaja;
            string iClaveBusqueda = eClaveDgvAperturaCaja;
            string iColumnaPintura = eNombreColumnaDgvAperturaCaja;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAperturaCaja();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubAperturaCajaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAperturaCaja;
            List<GestionClubAperturaCajaDto> iListaAperturaCaja = eLisAperturaCaja;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAperturaCaja);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAperturaCaja()
        {
            //lista resultado
            List<DataGridViewColumn> iLisAperturaCaja = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._fecAperturaCaja, "Fecha", 80));
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._montoAperturaCaja, "Monto", 80));
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._caja, "Caja", 80));
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._Estado, "Estado", 150));
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._idAperturaCaja, "idAperturaCaja", 150, false));
            iLisAperturaCaja.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._claveObjeto, "claveObjeto", 150, false));

            //devolver
            return iLisAperturaCaja;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvAperturaCaja;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmAperturaCaja, null);
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarAperturaCaja win = new frmEditarAperturaCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAperturaCaja = Dgv.Franja.PorValor;
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
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubAperturaCajaDto iPerEN = this.EsActoModificarAperturaCaja();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAperturaCaja win = new frmEditarAperturaCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvAperturaCaja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public GestionClubAperturaCajaDto EsActoModificarAperturaCaja()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            iPerEN = GestionClubAperturaCajaController.EsActoModificarAperturaCaja(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AsignarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            pObj.idAperturaCaja = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvAperturaCaja, GestionClubAperturaCajaDto._idAperturaCaja));
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
            GestionClubAperturaCajaDto iPerEN = this.EsActoEliminarAperturaCaja();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAperturaCaja win = new frmEditarAperturaCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvAperturaCaja = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }
        public GestionClubAperturaCajaDto EsActoEliminarAperturaCaja()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            iPerEN = GestionClubAperturaCajaController.EsActoEliminarAperturaCaja(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubAperturaCajaDto iPerEN = this.EsAperturaCajaExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAperturaCaja win = new frmEditarAperturaCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubAperturaCajaDto EsAperturaCajaExistente()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            this.AsignarAperturaCaja(iPerEN);
            iPerEN = GestionClubAperturaCajaController.EsAperturaCajaExistente(iPerEN);
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

        private void frmAperturaCaja_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAperturaCaja, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAperturaCaja = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvAperturaCaja_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); 
        }

        private void DgvAperturaCaja_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvAperturaCaja, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAperturaCaja, this.sst1);
        }
    }
}
