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
    public partial class frmAmbientes : Form
    {
        public string eTitulo = "Ambientes";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubAmbientesDto> eLisAmbiente = new List<GestionClubAmbientesDto>();
        public GestionClubAmbienteController oOpe = new GestionClubAmbienteController();
        Dgv.Franja eFranjaDgvAmbiente = Dgv.Franja.PorIndice;
        public string eClaveDgvAmbiente = string.Empty;
        string eNombreColumnaDgvAmbiente = "desAmbiente";
        string eEncabezadoColumnaDgvAmbiente = "desAmbiente";
        public frmAmbientes()
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
            this.ActualizarListaAmbienteDeBaseDatos();
            this.ActualizarDgvAmbientes();
            Dgv.HabilitarDesplazadores(this.DgvAmbientes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAmbientes, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaAmbienteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubAmbientesDto iOpEN = new GestionClubAmbientesDto();
            iOpEN.Adicionales.CampoOrden = eNombreColumnaDgvAmbiente;
            this.eLisAmbiente = GestionClubAmbienteController.ListarAmbientes();
        }
        public void ActualizarDgvAmbientes()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAmbientes;
            List<GestionClubAmbientesDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAmbiente;
            string iClaveBusqueda = eClaveDgvAmbiente;
            string iColumnaPintura = eNombreColumnaDgvAmbiente;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubAmbientesDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAmbiente;
            List<GestionClubAmbientesDto> iListaAmbientes = eLisAmbiente;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisAmbiente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._codAmbiente, "Código", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._desAmbiente, "Descripción", 280));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._Estado, "Estado", 150));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._idAmbiente, "idAmbiente", 80, false));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisAmbiente;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvAmbiente;
            this.tstBuscar.Focus();
        }

        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmAmbientes, null);
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarAmbientes win = new frmEditarAmbientes();
            win.wAmb = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAmbiente = Dgv.Franja.PorValor;
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
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubAmbientesDto iPerEN = this.EsActoModificarAmbiente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAmbientes win = new frmEditarAmbientes();
            win.wAmb = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvAmbiente = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public GestionClubAmbientesDto EsActoModificarAmbiente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            iPerEN = GestionClubAmbienteController.EsActoModificarAmbiente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AsignarAmbiente(GestionClubAmbientesDto pObj)
        {
            pObj.idAmbiente = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvAmbientes, GestionClubAmbientesDto._idAmbiente));
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
            GestionClubAmbientesDto iPerEN = this.EsActoEliminarAmbiente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAmbientes win = new frmEditarAmbientes();
            win.wAmb = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvAmbiente = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }
        public GestionClubAmbientesDto EsActoEliminarAmbiente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            iPerEN = GestionClubAmbienteController.EsActoEliminarAmbiente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubAmbientesDto iPerEN = this.EsAmbienteExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarAmbientes win = new frmEditarAmbientes();
            win.wAmb = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubAmbientesDto EsAmbienteExistente()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            this.AsignarAmbiente(iPerEN);
            iPerEN = GestionClubAmbienteController.EsAmbienteExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        private void frmAmbientes_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAmbiente = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, Dgv.Desplazar.Anterior);

        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, Dgv.Desplazar.Siguiente);

        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAmbientes, Dgv.Desplazar.Ultimo);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void DgvAmbientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }
    }
}
