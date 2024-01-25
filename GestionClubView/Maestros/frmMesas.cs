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
    public partial class frmMesas : Form
    {
        public string eTitulo = "Registro Mesas";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubMesaDto> eLisMesas = new List<GestionClubMesaDto>();
        public GestionClubMesaController oOpe = new GestionClubMesaController();
        Dgv.Franja eFranjaDgvMesas = Dgv.Franja.PorIndice;
        public string eClaveDgvMesas = string.Empty;
        string eNombreColumnaDgvMesas = "codMesas";
        string eEncabezadoColumnaDgvMesas = "desMesas";
        public frmMesas()
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
            this.ActualizarListaMesasDeBaseDatos();
            this.ActualizarDgvMesas();
            Dgv.HabilitarDesplazadores(this.DgvMesas, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvMesas, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaMesasDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubMesaDto iOpEN = new GestionClubMesaDto();
            this.eLisMesas = oOpe.ListarMesas();
        }
        public void ActualizarDgvMesas()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMesas;
            List<GestionClubMesaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMesas;
            string iClaveBusqueda = eClaveDgvMesas;
            string iColumnaPintura = eNombreColumnaDgvMesas;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMesas();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubMesaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMesas;
            List<GestionClubMesaDto> iListaMesas = eLisMesas;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMesas);
        }
        public List<DataGridViewColumn> ListarColumnasDgvMesas()
        {
            //lista resultado
            List<DataGridViewColumn> iLisAmbiente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._desAmbiente, "Ambiente", 280));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._codMesa, "Código", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._desMesa, "Descripción", 280));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubMesaDto._estadoMesa, "Estado", 150));

            //devolver
            return iLisAmbiente;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMesas;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmMesas, null);
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarMesas win = new frmEditarMesas();
            win.wMes = this;
            win.eOperacion = Universal.Opera.Adicionar;
            //this.eFranjaDgvRefAmp = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMesas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }
    }
}
