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
    public partial class frmMozosUsuarios : Form
    {
        public string eTitulo = "Usuarios/Mozos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubAccessDto> eLisAccess = new List<GestionClubAccessDto>();
        public GestionClubAccessController oOpe = new GestionClubAccessController();
        Dgv.Franja eFranjaDgvUsuariosMozos = Dgv.Franja.PorIndice;
        public string eClaveDgvUsuariosMozos = string.Empty;
        string eNombreColumnaDgvUsuariosMozos = "dniAcceso";
        string eEncabezadoColumnaDgvUsuariosMozos = "dniAcceso";
        public frmMozosUsuarios()
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
            this.ActualizarListaAccessDeBaseDatos();
            this.ActualizarDgvAccesss();
            Dgv.HabilitarDesplazadores(this.DgvUsuarioMozo, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvUsuarioMozo, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaAccessDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubAccessDto iOpEN = new GestionClubAccessDto();
            this.eLisAccess = oOpe.ListarUsuarioMozos();
        }
        public void ActualizarDgvAccesss()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvUsuarioMozo;
            List<GestionClubAccessDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvUsuariosMozos;
            string iClaveBusqueda = eClaveDgvUsuariosMozos;
            string iColumnaPintura = eNombreColumnaDgvUsuariosMozos;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAccess();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubAccessDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvUsuariosMozos;
            List<GestionClubAccessDto> iListaAccesss = eLisAccess;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAccesss);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAccess()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.codAcc, "Código", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.DniAcc, "Doc. Id.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.PatAcc, "Ape. Paterno", 120));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.MatAcc, "Ape. Materno", 120));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.nombresAcc, "Nombres", 120));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.MailAcc, "E-mail", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.DomAcc, "Domicilio", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.FijAcc, "Fijo", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.MovAcc, "Movil", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto._Estado, "Estado", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto.IdAcc, "idAccess", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubAccessDto._claveObjeto, "claveObjeto", 80, false));



            //devolver
            return iLisDgv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvUsuariosMozos;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmMozosUsuarios, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubAccessDto iObjEN = this.EsActoModificarAccess();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMozosUsuarios win = new frmEditarMozosUsuarios();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvUsuariosMozos = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubAccessDto EsActoModificarAccess()
        {
            GestionClubAccessDto iObjEN = new GestionClubAccessDto();
            this.AsignarAccess(iObjEN);
            iObjEN = GestionClubAccessController.EsActoModificarAccess(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarAccess(GestionClubAccessDto pObj)
        {
            pObj.idAcceso = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvUsuarioMozo, GestionClubAccessDto.IdAcc));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarMozosUsuarios win = new frmEditarMozosUsuarios();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvUsuariosMozos = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubAccessDto iObjEN = this.EsActoEliminarAccess();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMozosUsuarios win = new frmEditarMozosUsuarios();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvUsuariosMozos = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubAccessDto EsActoEliminarAccess()
        {
            GestionClubAccessDto iObjEN = new GestionClubAccessDto();
            this.AsignarAccess(iObjEN);
            iObjEN = GestionClubAccessController.EsActoEliminarAccess(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubAccessDto iPerEN = this.EsAccessExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarMozosUsuarios win = new frmEditarMozosUsuarios();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubAccessDto EsAccessExistente()
        {
            GestionClubAccessDto iObjEN = new GestionClubAccessDto();
            this.AsignarAccess(iObjEN);
            iObjEN = GestionClubAccessController.EsAccessExistente(iObjEN);
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

        private void frmMozosUsuarios_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsuarioMozo, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvUsuariosMozos = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvUsuarioMozo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void DgvUsuarioMozo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvUsuarioMozo, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvUsuarioMozo, this.sst1);
        }
    }
}
