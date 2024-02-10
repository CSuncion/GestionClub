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
    public partial class frmClientes : Form
    {
        public string eTitulo = "Clientes";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubClienteDto> eLisCliente = new List<GestionClubClienteDto>();
        public GestionClubClienteController oOpe = new GestionClubClienteController();
        Dgv.Franja eFranjaDgvCliente = Dgv.Franja.PorIndice;
        public string eClaveDgvCliente = string.Empty;
        string eNombreColumnaDgvCliente = "codCliente";
        string eEncabezadoColumnaDgvCliente = "nombreRazSocialCliente";
        public frmClientes()
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
            this.ActualizarListaClienteDeBaseDatos();
            this.ActualizarDgvClientes();
            Dgv.HabilitarDesplazadores(this.DgvClientes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvClientes, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaClienteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubClienteDto iOpEN = new GestionClubClienteDto();
            this.eLisCliente = oOpe.ListarClientes();
        }
        public void ActualizarDgvClientes()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvClientes;
            List<GestionClubClienteDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCliente;
            string iClaveBusqueda = eClaveDgvCliente;
            string iColumnaPintura = eNombreColumnaDgvCliente;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCliente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubClienteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCliente;
            List<GestionClubClienteDto> iListaClientes = eLisCliente;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaClientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCliente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._codCliente, "Código", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._tipSocioCliente, "T. Socio", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._tipCliente, "T. Cliente", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nroIdentificacionCliente, "N° Id.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nombreRazSocialCliente, "Nombre/Raz. Social", 250));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._razComercialCliente, "Raz. Comercial", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._emailCliente, "E-mail", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nroCelularCliente, "N° Cel.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._representanteCliente, "Rep.", 100));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._estadoCliente, "Estado", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._idCliente, "idCliente", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisDgv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCliente;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmMasterClientes, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubClienteDto iObjEN = this.EsActoModificarCliente();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarClientes win = new frmEditarClientes();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCliente = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubClienteDto EsActoModificarCliente()
        {
            GestionClubClienteDto iObjEN = new GestionClubClienteDto();
            this.AsignarCliente(iObjEN);
            iObjEN = GestionClubClienteController.EsActoModificarCliente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarCliente(GestionClubClienteDto pObj)
        {
            pObj.idCliente = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvClientes, GestionClubClienteDto._idCliente));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarClientes win = new frmEditarClientes();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCliente = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubClienteDto iObjEN = this.EsActoEliminarCliente();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarClientes win = new frmEditarClientes();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCliente = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubClienteDto EsActoEliminarCliente()
        {
            GestionClubClienteDto iObjEN = new GestionClubClienteDto();
            this.AsignarCliente(iObjEN);
            iObjEN = GestionClubClienteController.EsActoEliminarCliente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubClienteDto iPerEN = this.EsClienteExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarClientes win = new frmEditarClientes();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubClienteDto EsClienteExistente()
        {
            GestionClubClienteDto iObjEN = new GestionClubClienteDto();
            this.AsignarCliente(iObjEN);
            iObjEN = GestionClubClienteController.EsClienteExistente(iObjEN);
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

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCliente = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }
    }
}
