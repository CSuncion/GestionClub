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
    public partial class frmParametro : Form
    {
        public string eTitulo = "Parametros";
        public List<GestionClubParametroDto> eLis = new List<GestionClubParametroDto>();
        public GestionClubParametroController oOpe = new GestionClubParametroController();
        string eNombreColumnaDgvParametro = "PorcentajeIgv";
        string eEncabezadoColumnaDgvAmbiente = "PorcentajeIgv";
        Dgv.Franja eFranjaDgvParametro = Dgv.Franja.PorIndice;
        public string eClaveDgvParametro = string.Empty;
        public frmParametro()
        {
            InitializeComponent();
        }
        public void AbrirVentana()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaAmbienteDeBaseDatos();
            this.ActualizarDgvAmbientes();
            Dgv.ActualizarBarraEstado(this.DgvParametros, this.sst1);
        }
        public void ActualizarListaAmbienteDeBaseDatos()
        {
            //ir a la bd
            GestionClubParametroDto iOpEN = new GestionClubParametroDto();
            iOpEN.Adicionales.CampoOrden = eNombreColumnaDgvParametro;
            this.eLis = GestionClubParametroController.ListarParametro();
        }
        public void ActualizarDgvAmbientes()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvParametros;
            List<GestionClubParametroDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvParametro;
            string iClaveBusqueda = eClaveDgvParametro;
            string iColumnaPintura = eNombreColumnaDgvParametro;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubParametroDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = string.Empty;
            string iCampoBusqueda = eNombreColumnaDgvParametro;
            List<GestionClubParametroDto> iListaAmbientes = eLis;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAmbientes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisParametro = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._RutaLogoEmpresa, "Ruta Logo", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._PorcentajeIgv, "IGV", 80));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._PorcentajeDetra, "Detra", 80));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._NombreSoles, "Soles", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._NombreDolares, "Dolares", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._RutaImagenCategoria, "Ruta Categoria", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._RutaImagenProducto, "Ruta Producto", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._RutaImagenMesa, "Ruta Mesa", 130));
            iLisParametro.Add(Dgv.NuevaColumnaTextCadena(GestionClubParametroDto._RutaImagenQR, "Ruta QR", 130));

            //devolver
            return iLisParametro;
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmParametrosVentas, null);
        }
        public void AccionModificar()
        {
            GestionClubParametroDto iPerEN = this.EsActoModificarParametro();
            //si existe
            frmEditarParametro win = new frmEditarParametro();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvParametro = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public GestionClubParametroDto EsActoModificarParametro()
        {
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();
            this.AsignarParametro(iPerEN);
            iPerEN = GestionClubParametroController.EsActoModificarParametro(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iPerEN;
        }
        public void AsignarParametro(GestionClubParametroDto pObj)
        {
            pObj.PorcentajeIgv = Convert.ToDecimal(Dgv.ObtenerValorCelda(this.DgvParametros, GestionClubParametroDto._PorcentajeIgv));
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParametro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }
    }
}
