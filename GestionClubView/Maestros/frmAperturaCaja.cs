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
    public partial class frmAperturaCaja : Form
    {
        public string eTitulo = "Registro Apertura Caja";
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
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubAperturaCajaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAperturaCaja;
            List<GestionClubAperturaCajaDto> iListaAmbientes = eLisAperturaCaja;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisAmbiente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._fecAperturaCaja, "Fecha", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._montoAperturaCaja, "Monto", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubAperturaCajaDto._estadoAperturaCaja, "Estado", 150));

            //devolver
            return iLisAmbiente;
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAperturaCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
