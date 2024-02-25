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

namespace GestionClubView.Stock_Restaurante
{
    public partial class frmIngresosCompras : Form
    {
        public string eTitulo = "Registro Ingresos";
        int eVaBD = 1;//0 : no , 1 : si
        public List<GestionClubComprobanteAlmacenDto> eLisComp = new List<GestionClubComprobanteAlmacenDto>();
        public GestionClubComprobanteAlmacenController oOpe = new GestionClubComprobanteAlmacenController();
        Dgv.Franja eFranjaDgvComprobanteAlmacen = Dgv.Franja.PorIndice;
        public string eClaveDgvComprobanteAlmacen = string.Empty;
        string eNombreColumnaDgvComprobanteAlmacen = GestionClubComprobanteAlmacenDto._razSocial;
        string eEncabezadoColumnaDgvComprobanteAlmacen = GestionClubComprobanteAlmacenDto._razSocial;
        public frmIngresosCompras()
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
            this.ActualizarListaComprobanteAlmacenDeBaseDatos();
            this.ActualizarDgvComprobanteAlmacen();
            Dgv.HabilitarDesplazadores(this.DgvIngresos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvIngresos, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaComprobanteAlmacenDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            //Lista ComprobanteAlmacens que no han sido creado por comandas
            GestionClubComprobanteAlmacenDto iOpEN = new GestionClubComprobanteAlmacenDto();
            this.eLisComp = GestionClubComprobanteAlmacenController.ListarComprobantes(iOpEN);
        }
        public void ActualizarDgvComprobanteAlmacen()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvIngresos;
            List<GestionClubComprobanteAlmacenDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvComprobanteAlmacen;
            string iClaveBusqueda = eClaveDgvComprobanteAlmacen;
            string iColumnaPintura = eNombreColumnaDgvComprobanteAlmacen;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProducto();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<GestionClubComprobanteAlmacenDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvComprobanteAlmacen;
            List<GestionClubComprobanteAlmacenDto> iListaComprobanteAlmacen = eLisComp;

            //ejecutar y retornar
            return oOpe.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaComprobanteAlmacen);
        }
        public List<DataGridViewColumn> ListarColumnasDgvProducto()
        {
            //lista resultado
            List<DataGridViewColumn> iLisDgv = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._nroDocumento, "N° Documento", 90));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._serNroFactura, "Documento", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._fecFactura, "Fecha", 100));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._tipoMovimiento, "T. Mov.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._tipFactura, "T. Fac.", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._razSocial, "Raz. Social", 150));
            iLisDgv.Add(Dgv.NuevaColumnaTextNumerico(GestionClubComprobanteAlmacenDto._totBru, "Total", 80, 2));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._estAlmacen, "Estado", 80));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._idComprobanteAlmacen, "idComprobanteAlmacen", 80, false));
            iLisDgv.Add(Dgv.NuevaColumnaTextCadena(GestionClubComprobanteAlmacenDto._claveObjeto, "claveObjeto", 80, false));

            //devolver
            return iLisDgv;
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvComprobanteAlmacen;
            this.tstBuscar.Focus();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmIngresosCompras, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            GestionClubComprobanteAlmacenDto iObjEN = this.EsActoModificarComprobanteAlmacen();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarIngresosCompras win = new frmEditarIngresosCompras();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvComprobanteAlmacen = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iObjEN);
        }
        public GestionClubComprobanteAlmacenDto EsActoModificarComprobanteAlmacen()
        {
            GestionClubComprobanteAlmacenDto iObjEN = new GestionClubComprobanteAlmacenDto();
            this.AsignarComprobanteAlmacen(iObjEN);
            iObjEN = GestionClubComprobanteAlmacenController.EsActoModificarComprobanteAlmacen(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AsignarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            pObj.idComprobanteAlmacen = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvIngresos, GestionClubComprobanteAlmacenDto._idComprobanteAlmacen));
        }
        public void AccionAdicionar()
        {
            //DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            //if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditarIngresosCompras win = new frmEditarIngresosCompras();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvComprobanteAlmacen = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteAlmacenDto iObjEN = this.EsActoEliminarComprobanteAlmacen();
            if (iObjEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarIngresosCompras win = new frmEditarIngresosCompras();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvComprobanteAlmacen = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iObjEN);
        }
        public GestionClubComprobanteAlmacenDto EsActoEliminarComprobanteAlmacen()
        {
            GestionClubComprobanteAlmacenDto iObjEN = new GestionClubComprobanteAlmacenDto();
            this.AsignarComprobanteAlmacen(iObjEN);
            iObjEN = GestionClubComprobanteAlmacenController.EsActoEliminarComprobanteAlmacen(iObjEN);
            if (iObjEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iObjEN.Adicionales.Mensaje, eTitulo);
            }
            return iObjEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubComprobanteAlmacenDto iComEN = this.EsProductoExistente();
            if (iComEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarIngresosCompras win = new frmEditarIngresosCompras();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            //win.VentanaVisualizar(iPerEN);
        }
        public GestionClubComprobanteAlmacenDto EsProductoExistente()
        {
            GestionClubComprobanteAlmacenDto iObjEN = new GestionClubComprobanteAlmacenDto();
            this.AsignarComprobanteAlmacen(iObjEN);
            //iObjEN = GestionClubComprobanteAlmacenController.EsComprobanteExistente(iObjEN);
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

        private void frmIngresosCompras_FormClosing(object sender, FormClosingEventArgs e)
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
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIngresos, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvComprobanteAlmacen = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvIngresos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }

        private void DgvIngresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvIngresos, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvIngresos, this.sst1);
        }
    }
}
