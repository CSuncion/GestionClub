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
    public partial class frmCategorias : Form
    {
        public string eTitulo = "Registro Categorias";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubCategoriaDto> eLisCategoria = new List<GestionClubCategoriaDto>();
        public GestionClubCategoriaController oOpe = new GestionClubCategoriaController();
        Dgv.Franja eFranjaDgvCategoria = Dgv.Franja.PorIndice;
        public string eClaveDgvCategoria = string.Empty;
        string eNombreColumnaDgvCategoria = "codCategoria";
        string eEncabezadoColumnaDgvCategoria = "desCategoria";
        public frmCategorias()
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
            this.ActualizarListaCategoriaDeBaseDatos();
            this.ActualizarDgvCategorias();
            Dgv.HabilitarDesplazadores(this.DgvCategorias, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCategorias, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaCategoriaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubCategoriaDto iOpEN = new GestionClubCategoriaDto();
            this.eLisCategoria = oOpe.ListarCategorias();
        }
        public void ActualizarDgvCategorias()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCategorias;
            List<GestionClubCategoriaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCategoria;
            string iClaveBusqueda = eClaveDgvCategoria;
            string iColumnaPintura = eNombreColumnaDgvCategoria;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCategoria();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubCategoriaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCategoria;
            List<GestionClubCategoriaDto> iListaAmbientes = eLisCategoria;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCategoria()
        {
            //lista resultado
            List<DataGridViewColumn> iLisAmbiente = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._codCategoria, "Código", 80));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._desCategoria, "Descripción", 280));
            iLisAmbiente.Add(Dgv.NuevaColumnaTextCadena(GestionClubCategoriaDto._estadoCategoria, "Estado", 150));

            //devolver
            return iLisAmbiente;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCategoria;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmCategorias, null);
        }
        private void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
