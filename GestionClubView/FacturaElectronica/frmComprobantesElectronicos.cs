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
    public partial class frmComprobantesElectronicos : Form
    {
        public string eTitulo = "Comprobantes Electrónicos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubResultadoNubeFactDto> eLisComprobante = new List<GestionClubResultadoNubeFactDto>();
        public GestionClubResultadoNubeFactController oOpe = new GestionClubResultadoNubeFactController();
        Dgv.Franja eFranjaDgvComprobante = Dgv.Franja.PorIndice;
        public string eClaveDgvComprobante = string.Empty;
        string eNombreColumnaDgvComprobante = "numero";
        string eEncabezadoColumnaDgvComprobante = "numero";
        public frmComprobantesElectronicos()
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
            Dgv.HabilitarDesplazadores(this.DgvComprobantesElectronicos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantesElectronicos, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaAmbienteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            GestionClubResultadoNubeFactDto iOpEN = new GestionClubResultadoNubeFactDto();
            iOpEN.Adicionales.CampoOrden = eNombreColumnaDgvComprobante;
            this.eLisComprobante = GestionClubResultadoNubeFactController.ListadoResultadoNubeFact();
        }
        public void ActualizarDgvAmbientes()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvComprobantesElectronicos;
            List<GestionClubResultadoNubeFactDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvComprobante;
            string iClaveBusqueda = eClaveDgvComprobante;
            string iColumnaPintura = eNombreColumnaDgvComprobante;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAmbiente();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubResultadoNubeFactDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvComprobante;
            List<GestionClubResultadoNubeFactDto> iListaComprobantes = eLisComprobante;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaComprobantes);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAmbiente()
        {
            //lista resultado
            List<DataGridViewColumn> iLisComprobante = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._tipo_de_comprobante, "T. Comprobante", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._serie, "Serie", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._numero, "Numero", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._enlace, "Enlace", 200));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._sunat_ticket_numero, "Ticket N°", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._aceptada_por_sunat, "Acep. Sunat", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._sunat_description, "Sunat. Desc.", 150));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._sunat_note, "Sunat Note", 150));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._sunat_responsecode, "Sunat Resp.", 150));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._sunat_soap_error, "Sunat Error", 150));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._anulado, "Anulado", 80));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._pdf_zip_base64, "PDF Base64", 100));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._xml_zip_base64, "XML Base64", 100));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._cdr_zip_base64, "CDR Base64", 100));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._cadena_para_codigo_qr, "Cad. QR", 200));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._codigo_hash, "Cod. Hash", 100));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._key, "Key", 100));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._enlace_del_pdf, "Enl. PDF", 200));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._enlace_del_xml, "Enl. XML", 200));
            iLisComprobante.Add(Dgv.NuevaColumnaTextCadena(GestionClubResultadoNubeFactDto._enlace_del_cdr, "Enl. CDR", 200));

            //devolver
            return iLisComprobante;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvComprobante;
            this.tstBuscar.Focus();
        }

        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmComprobanteElectronicos, null);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprobantesElectronicos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantesElectronicos, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantesElectronicos, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantesElectronicos, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantesElectronicos, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvComprobante = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvComprobantesElectronicos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvComprobantesElectronicos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantesElectronicos, this.sst1);
        }
    }
}
