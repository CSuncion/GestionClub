using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace GestionClubView.Venta
{
    public partial class frmComprobantes : Form
    {
        public string eTitulo = "Comprobante";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubComprobanteDto> eLisComp = new List<GestionClubComprobanteDto>();
        public GestionClubComprobanteController oOpe = new GestionClubComprobanteController();
        Dgv.Franja eFranjaDgvComprobante = Dgv.Franja.PorIndice;
        public string eClaveDgvComprobante = string.Empty;
        string eNombreColumnaDgvComprobante = "nombreRazSocialCliente";
        string eEncabezadoColumnaDgvComprobante = "nombreRazSocialCliente";
        public frmComprobantes()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            if (!this.ValidaAperturaCaja()) { this.Cerrar(); return; }
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public bool ValidaAperturaCaja()
        {
            bool result = true;
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            gestionClubAperturaCajaDto.caja = Universal.caja;
            gestionClubAperturaCajaDto = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0) { Mensaje.OperacionDenegada("Debe aperturar la caja.", this.eTitulo); result = false; }

            return result;
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaComprobanteDeBaseDatos();
            this.ActualizarDgvComprobante();
            Dgv.HabilitarDesplazadores(this.DgvComprobantes, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvComprobantes, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaComprobanteDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            //Lista comprobantes que no han sido creado por comandas
            GestionClubComprobanteDto iOpEN = new GestionClubComprobanteDto();
            iOpEN.idNroComanda = 0;
            this.eLisComp = GestionClubComprobanteController.ListarComprobantes(iOpEN);
        }
        public void ActualizarDgvComprobante()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvComprobantes;
            List<GestionClubComprobanteDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvComprobante;
            string iClaveBusqueda = eClaveDgvComprobante;
            string iColumnaPintura = eNombreColumnaDgvComprobante;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProducto();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubComprobanteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvComprobante;
            List<GestionClubComprobanteDto> iListaComprobante = eLisComp;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaComprobante);
        }
        public List<DataGridViewColumn> ListarColumnasDgvProducto()
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
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvComprobante;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmComprobante, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvComprobantes, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }
        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            //if (tsbEditar.Enabled == false)
            //{
            //    Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            //}
            //else
            //{
            //    this.AccionModificar();
            //}
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iObjEN = this.EsActoModificarComprobante();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubComprobanteDto EsActoModificarComprobante()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            iObjEN = GestionClubComprobanteController.EsActoModificarComprobante(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarComprobante(GestionClubComprobanteDto pObj)
        {
            pObj.idComprobante = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvComprobantes, GestionClubComprobanteDto._idComprobante));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iObjEN = this.EsActoEliminarComprobante();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            //win.wFrm = this;
            //win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvComprobante = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            //win.VentanaEliminar(iObjEN);
        }
        public GestionClubComprobanteDto EsActoEliminarComprobante()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            //iObjEN = GestionClubProductoController.EsActoEliminarComprobante(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteDto iComEN = this.EsProductoExistente();
            if (iComEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarComprobante win = new frmEditarComprobante();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            //win.VentanaVisualizar(iPerEN);
        }
        public GestionClubComprobanteDto EsProductoExistente()
        {
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();
            this.AsignarComprobante(iObjEN);
            //iObjEN = GestionClubComprobanteController.EsProductoExistente(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprobantes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
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

        private void DgvComprobantes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }
    }
}
