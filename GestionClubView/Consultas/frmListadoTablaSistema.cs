using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections;
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
using static WinControles.ControlesWindows.Dgv;

namespace GestionClubView.Maestros
{
    public partial class frmListadoTablaSistema : Form
    {
        string eNombreColumna = GestionClubSistemaDetalleDto._codigo;
        string eEncabezadoColumna = "nroSistema";
        public string eClaveDgvIte = string.Empty;
        Dgv.Franja eFranja = Dgv.Franja.PorIndice;
        int eIndiceFilaAnterior = 0;
        public string eTitulo = "Tabla Sistema";
        Dgv.Franja eFranjaDgvTablaSistema = Dgv.Franja.PorIndice;
        public frmListadoTablaSistema()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarDgvTab();
            this.ActualizarVentana();
        }
        public void ActualizarDgvTab()
        {
            GestionClubSistemaDto iTabEN = new GestionClubSistemaDto();
            iTabEN.Adicionales.CampoOrden = GestionClubSistemaDto._titSistema;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvSistema;
            iDgv.RefrescarDatosGrilla(GestionClubGeneralController.ListarSistema());
            //asignar columnas
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDto._titSistema, "Nombre", 380);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDto._claveObjeto, "Clave", 90, false);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._idTabSistema, "Sistema", 90, false);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._nroSistema, "Numero", 90, false);
        }
        public void ActualizarVentana()
        {
            //this.TituloItems();
            this.ActualizarDgvIte();
            //this.HabilitarAcciones();
        }
        public void ActualizarDgvIte()
        {
            eIndiceFilaAnterior = Dgv.ObtenerIndiceRegistroXFranja(this.DgvSistemaDetalle);
            this.ActualizarDatosDgvIte();
            Dgv.PintarColumna(this.DgvSistemaDetalle, eNombreColumna);
            Dgv.PosicionarFranja(this.DgvSistemaDetalle, eFranja, eIndiceFilaAnterior, eClaveDgvIte);
        }
        public void ActualizarDatosDgvIte()
        {
            GestionClubSistemaDetalleDto iIteEN = new GestionClubSistemaDetalleDto();
            iIteEN.nroSistema = Dgv.ObtenerValorCelda(this.DgvSistema, GestionClubSistemaDto._claveObjeto);
            iIteEN.Adicionales.CampoOrden = eNombreColumna;
            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvSistemaDetalle;
            iDgv.RefrescarDatosGrilla(GestionClubGeneralController.ListarSistemaDetallePorTabla(iIteEN.nroSistema));
            //asignar columnas
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._codigo, "Codigo", 70);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._descri, "Nombre", 310);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._claveObjeto, "Clave", 90, false);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._idTabSistemaDetalle, "SistemaDetalle", 90, false);
            iDgv.AsignarColumnaTextCadena(GestionClubSistemaDetalleDto._idTabSistema, "Sistema", 90, false);
        }
        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            //Hashtable iLisPer = GestionClubPermisoEmpresaController.ListarPermisoEmpresaPorCodigo("005", DgvIte.Rows.Count);

            //ejecutar metodo
            //Tst.HabilitarItems(iTs1, iLisPer);
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmConsultaTablaSistema, null);
        }
        public void AccionAdicionar()
        {
            frmEditarTablaSistema win = new frmEditarTablaSistema();
            //win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public GestionClubSistemaDetalleDto EsActoModificarDetalleSistema()
        {
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iPerEN);
            iPerEN = GestionClubGeneralController.EsActoModificarDetalleSistema(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        public void AsignarDetalleSistema(GestionClubSistemaDetalleDto pObj)
        {
            pObj.idTabSistemaDetalle = Convert.ToInt32(Dgv.ObtenerValorCelda(this.DgvSistemaDetalle, GestionClubSistemaDetalleDto._idTabSistemaDetalle));
        }
        public GestionClubSistemaDetalleDto EsActoEliminarSistemaDetalle()
        {
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iPerEN);
            iPerEN = GestionClubGeneralController.EsActoEliminarSistemaDetalle(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
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
            GestionClubSistemaDetalleDto iPerEN = this.EsActoModificarDetalleSistema();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTablaSistema win = new frmEditarTablaSistema();
            //win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTablaSistema = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubSistemaDetalleDto iPerEN = this.EsActoEliminarSistemaDetalle();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTablaSistema win = new frmEditarTablaSistema();
            //win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTablaSistema = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            GestionClubSistemaDetalleDto iPerEN = this.EsSistemaDetalleExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditarTablaSistema win = new frmEditarTablaSistema();
            //win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }
        public GestionClubSistemaDetalleDto EsSistemaDetalleExistente()
        {
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();
            this.AsignarDetalleSistema(iPerEN);
            iPerEN = GestionClubGeneralController.EsSistemaDetalleExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }
        private void DgvSistema_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ActualizarVentana();
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTablaSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void DgvSistemaDetalle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex); ;
        }
    }
}
