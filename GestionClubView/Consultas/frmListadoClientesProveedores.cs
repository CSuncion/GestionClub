using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Enum;
using GestionClubUtil.Util;
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

namespace GestionClubView.Consultas
{
    public partial class frmListadoClientesProveedores : Form
    {
        public string eTitulo = "Clientes / Proveedores";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubClienteDto> eLisCliente = new List<GestionClubClienteDto>();
        public GestionClubClienteController oOpe = new GestionClubClienteController();
        Dgv.Franja eFranjaDgvCliente = Dgv.Franja.PorIndice;
        public string eClaveDgvCliente = string.Empty;
        string eNombreColumnaDgvCliente = "idCliente";
        string eEncabezadoColumnaDgvCliente = "nombreRazSocialCliente";
        public frmListadoClientesProveedores()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.CargarTipoCliente();
            this.ActualizarVentana();
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        public void CargarTipoCliente()
        {
            Cmb.Cargar(this.cboTipCliente, GestionClubGeneralController.ListarSistemaDetallePorTabla(GestionClubEnum.Sistema.TipoCliente.ToString()), GestionClubSistemaDetalleDto._codigo, GestionClubSistemaDetalleDto._descri);
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaClienteDeBaseDatos();
            this.ActualizarDgvClientes();
            Dgv.HabilitarDesplazadores(this.DgvClientes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvClientes, this.sst1);
        }
        public void ActualizarListaClienteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if ((this.txtNroIdentificacion.Text.Trim() != string.Empty || this.txtNomRazSoc.Text.Trim() != string.Empty) && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubClienteDto iOpEN = new GestionClubClienteDto();
            iOpEN.tipCliente = Cmb.ObtenerValor(this.cboTipCliente, string.Empty);
            iOpEN.nroIdentificacionCliente = this.txtNroIdentificacion.Text;
            iOpEN.nombreRazSocialCliente = this.txtNomRazSoc.Text;
            this.eLisCliente = oOpe.ListarClientePorTipoPorNroIdePorNomRaz(iOpEN);
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
            UtilGrilla.PintarFilaDeGrillaAlternar(iGrilla);
        }
        public List<GestionClubClienteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = this.txtNroIdentificacion.Text;
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
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmClientesProveedores, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtNroIdentificacion); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvClientes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtNroIdentificacion); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        //if (this.txtNroIdentificacion.Text != string.Empty || this.txtNomRazSoc.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoClientesProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void cboTipCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ActualizarVentana();
        }

        private void txtNroIdentificacion_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void txtNomRazSoc_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.ActualizarVentana();
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
    }
}
