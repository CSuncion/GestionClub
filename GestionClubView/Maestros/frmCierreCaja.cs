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
            List<DataGridViewColumn> iLisAmbiente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._fecCierreCaja, "Fecha", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._montoCierreCaja, "Monto", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCierreCajaDto._estadoCierreCaja, "Estado", 150));

            //devolver
            return iLisAmbiente;
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
        private void frmCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
