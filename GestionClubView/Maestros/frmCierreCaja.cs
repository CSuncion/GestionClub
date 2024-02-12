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
    public partial class frmCierreCaja : Form
    {
        public string eTitulo = "Cierre Caja";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubCierreCajaDto> eLisCierreCaja = new List<GestionClubCierreCajaDto>();
        public GestionClubCierreCajaController oOpe = new GestionClubCierreCajaController();
        Dgv.Franja eFranjaDgvCierreCaja = Dgv.Franja.PorIndice;
        public string eClaveDgvCierreCaja = string.Empty;
        string eNombreColumnaDgvCierreCaja = "fecCierreCaja";
        string eEncabezadoColumnaDgvCierreCaja = "fecCierreCaja";
        public frmCierreCaja()
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
            this.ActualizarListaCierreCajaDeBaseDatos();
            this.ActualizarDgvCierreCaja();
            Dgv.HabilitarDesplazadores(this.DgvCierreCaja, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCierreCaja, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaCierreCajaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubCierreCajaDto iOpEN = new GestionClubCierreCajaDto();
            this.eLisCierreCaja = oOpe.ListarCierreCajas();
        }
        public void ActualizarDgvCierreCaja()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCierreCaja;
            List<GestionClubCierreCajaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCierreCaja;
            string iClaveBusqueda = eClaveDgvCierreCaja;
            string iColumnaPintura = eNombreColumnaDgvCierreCaja;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubCierreCajaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCierreCaja;
            List<GestionClubCierreCajaDto> iListaAmbientes = eLisCierreCaja;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisCierre = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._fecCierreCaja, "Fecha", 80));
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._montoCierreCaja, "Monto", 80));
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._caja, "Caja", 80));
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._estadoCierreCaja, "Estado", 150));
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._idCierreCaja, "idCierreCaja", 150, false));
            iLisCierre.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._claveObjeto, "claveObjeto", 150, false));

            //devolver
            return iLisCierre;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCierreCaja;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmCierreCaja, null);
        }
        public void AccionAdicionar()
        {
            //GestionClubCierreCajaDto iCierreDto = this.EsActoModificarCierreCaja();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarCierreCaja win = new frmEditarCierreCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCierreCaja = Dgv.Franja.PorValor;
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
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubCierreCajaDto iPerEN = this.EsActoModificarCierreCaja();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCierreCaja win = new frmEditarCierreCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCierreCaja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public GestionClubCierreCajaDto EsActoModificarCierreCaja()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            iPerEN = GestionClubCierreCajaController.EsActoModificarCierreCaja(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AsignarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            pObj.idCierreCaja = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvCierreCaja, GestionClubCierreCajaDto._idCierreCaja));
            pObj.caja = Convert.ToString(Dgv.ObtenerValorCelda(this.DgvCierreCaja, GestionClubCierreCajaDto._caja));
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
            GestionClubCierreCajaDto iPerEN = this.EsActoEliminarCierreCaja();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCierreCaja win = new frmEditarCierreCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCierreCaja = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }
        public GestionClubCierreCajaDto EsActoEliminarCierreCaja()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            iPerEN = GestionClubCierreCajaController.EsActoEliminarCierreCaja(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubCierreCajaDto iPerEN = this.EsCierreCajaExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarCierreCaja win = new frmEditarCierreCaja();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubCierreCajaDto EsCierreCajaExistente()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            this.AsignarCierreCaja(iPerEN);
            iPerEN = GestionClubCierreCajaController.EsCierreCajaExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        private void frmCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCierreCaja, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCierreCaja = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvCierreCaja_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }
    }
}
