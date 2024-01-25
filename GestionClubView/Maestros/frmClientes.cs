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
using WinControles.ControlesWindows;

namespace GestionClubView.Maestros
{
    public partial class frmClientes : Form
    {
        public string eTitulo = "Registro Clientes";
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
            List<DataGridViewColumn> iLisCliente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._codCliente, "Código", 80));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._tipSocioCliente, "T. Socio", 80));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._tipCliente, "T. Cliente", 80));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nroIdentificacionCliente, "N° Id.", 80));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nombreRazSocialCliente, "Nombre/Raz. Social", 250));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._razComercialCliente, "Raz. Comercial", 150));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._emailCliente, "E-mail", 150));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._nroCelularCliente, "N° Cel.", 80));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._representanteCliente, "Rep.", 100));
            iLisCliente.Add(Dgv.NuevaColumnaTextCadena(GestionClubClienteDto._estadoCliente, "Estado", 80));

            //devolver
            return iLisCliente;
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
