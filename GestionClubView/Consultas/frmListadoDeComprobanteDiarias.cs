﻿using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.Maestros;
using GestionClubView.MdiPrincipal;
using GestionClubView.Reportes;
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

namespace GestionClubView.Consultas
{
    public partial class frmListadoDeComprobanteDiarias : Form
    {
        public enum Condicion
        {
            Comprobantes,
        }

        public frmEditarCierreCaja wFrm;
        public Universal.Opera eOperacion;
        public string eTitulo = "Comprobante";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubComprobanteDto> eLisComp = new List<GestionClubComprobanteDto>();
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        Dgv.Franja eFranjaDgvComprobante = Dgv.Franja.PorIndice;
        public string eClaveDgvComprobante = string.Empty;
        string eNombreColumnaDgvComprobante = "idComprobante";
        string eEncabezadoColumnaDgvComprobante = "nombreRazSocialCliente";
        public Form eVentana = new Form();
        public string eTituloVentana;
        public Condicion eCondicionLista;

        public frmListadoDeComprobanteDiarias()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.ActualizarVentana();
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaComprobanteDeBaseDatos();
            this.ActualizarDgvComprobante();
            Dgv.HabilitarDesplazadores(this.DgvComprobantes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantes, this.sst1);
        }
        public void ActualizarListaComprobanteDeBaseDatos()
        {
            this.dtpFecHasta.Value = DateTime.Now;

            DateTime fecDesde = this.dtpFecDesde.Value;
            DateTime fecHasta = this.dtpFecHasta.Value;

            if (!Fecha.EsMayorQue(fecHasta.ToShortDateString(), fecDesde.ToShortDateString()))
            { Mensaje.OperacionDenegada("Valide las fechas seleccionada", this.eTitulo); return; }

            this.eLisComp = GestionClubComprobanteController.ListarComprobantesFacturaYBoletaPorFechaDesdeHasta(fecDesde, fecHasta);
        }
        public void ActualizarDgvComprobante()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvComprobantes;
            List<GestionClubComprobanteDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvComprobante;
            string iClaveBusqueda = eClaveDgvComprobante;
            string iColumnaPintura = eNombreColumnaDgvComprobante;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvComprobante();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
            UtilGrilla.PintarFilaDeGrillaAlternar(iGrilla);
        }

        public List<GestionClubComprobanteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = string.Empty;
            string iCampoBusqueda = eNombreColumnaDgvComprobante;
            List<GestionClubComprobanteDto> iListaComprobante = eLisComp;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaComprobante);
        }
        public List<DataGridViewColumn> ListarColumnasDgvComprobante()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._serNroComprobante, "Comprobante", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desTipComprobante, "T.Comp.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._fecComprobante, "Fecha", 100));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desMoneda, "Moneda", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._nroIdentificacionCliente, "N° Id.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._nombreRazSocialCliente, "Cliente", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desPagoComprobante, "M. Pago", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextNumerico(GestionClubComprobanteDto._impNetComprobante, "Total", 80, 2));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._desEstado, "Estado", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._idComprobante, "idComprobante", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisDgv;
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        //Txt.CursorAlUltimo(this.tstBuscar);
                        break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        //Txt.CursorAlUltimo(this.tstBuscar);
                        break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        //if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmVentasDiarias, null);
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoDeComprobante_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvComprobante = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.ActualizarVentana();
        }
    }
}
