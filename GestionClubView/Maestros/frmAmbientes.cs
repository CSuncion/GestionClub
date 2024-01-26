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

namespace GestionClubView.Maestros
{
    public partial class frmAmbientes : Form
    {
        public string eTitulo = "Registro Ambientes";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubAmbientesDto> eLisAmbiente = new List<GestionClubAmbientesDto>();
        public GestionClubAmbienteController oOpe = new GestionClubAmbienteController();
        Dgv.Franja eFranjaDgvAmbiente = Dgv.Franja.PorIndice;
        public string eClaveDgvAmbiente = string.Empty;
        string eNombreColumnaDgvAmbiente = "codAmbiente";
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
            this.eLisAmbiente = oOpe.ListarAmbientes();
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
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAmbientesDto._estadoAmbiente, "Estado", 150));

            //devolver
            return iLisAmbiente;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvAmbiente;
            this.tstBuscar.Focus();
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarAmbientes win = new frmEditarAmbientes();
            win.wAmb = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAmbiente= Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmAmbientes, null);
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
    }
}
