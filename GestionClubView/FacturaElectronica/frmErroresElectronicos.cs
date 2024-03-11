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

namespace GestionClubView.FacturaElectronica
{
    public partial class frmErroresElectronicos : Form
    {
        public string eTitulo = "Errores Electrónicos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubErrorNubeFactDto> eLisErrores = new List<GestionClubErrorNubeFactDto>();
        public GestionClubResultadoNubeFactController oOpe = new GestionClubResultadoNubeFactController();
        Dgv.Franja eFranjaDgvErrores = Dgv.Franja.PorIndice;
        public string eClaveDgvErrores = string.Empty;
        string eNombreColumnaDgvErrores = "numero";
        string eEncabezadoColumnaDgvErrores = "numero";
        public frmErroresElectronicos()
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
            Dgv.HabilitarDesplazadores(this.DgvErroresElectronicos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvErroresElectronicos, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaAmbienteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubErrorNubeFactDto iOpEN = new GestionClubErrorNubeFactDto();
            iOpEN.Adicionales.CampoOrden = eNombreColumnaDgvErrores;
            this.eLisErrores = GestionClubResultadoNubeFactController.ListadoErrorsNubeFact();
        }
        public void ActualizarDgvAmbientes()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvErroresElectronicos;
            List<GestionClubErrorNubeFactDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvErrores;
            string iClaveBusqueda = eClaveDgvErrores;
            string iColumnaPintura = eNombreColumnaDgvErrores;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubErrorNubeFactDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvErrores;
            List<GestionClubErrorNubeFactDto> iListaErrores = eLisErrores;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipalErrores(iValorBusqueda, iCampoBusqueda, iListaErrores);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisErrores = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisErrores.Add(Dgv.NuevaColumnaTextCadena(GestionClubErrorNubeFactDto._tipo_de_comprobante, "T. Comprobante", 80));
            iLisErrores.Add(Dgv.NuevaColumnaTextCadena(GestionClubErrorNubeFactDto._serie, "Serie", 80));
            iLisErrores.Add(Dgv.NuevaColumnaTextCadena(GestionClubErrorNubeFactDto._numero, "Numero", 80));
            iLisErrores.Add(Dgv.NuevaColumnaTextCadena(GestionClubErrorNubeFactDto._errors, "Error", 200));
            iLisErrores.Add(Dgv.NuevaColumnaTextCadena(GestionClubErrorNubeFactDto._codigo, "Código", 80));

            //devolver
            return iLisErrores;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvErrores;
            this.tstBuscar.Focus();
        }

        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmErrorElectronico, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmErroresElectronicos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvErroresElectronicos, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvErroresElectronicos, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvErroresElectronicos, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvErroresElectronicos, Dgv.Desplazar.Ultimo);
        }

        private void DgvErroresElectronicos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvErroresElectronicos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvErroresElectronicos, this.sst1);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvErrores = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }
    }
}
