using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Listas
{
    public partial class frmListarEmpresas : Form
    {
        public enum Condicion
        {
            EmpresasAutorizadasDeUsuario = 0,
        }
        public Form eVentana = new Form();
        public GestionClubPermisoEmpresaDto ePerm = new GestionClubPermisoEmpresaDto();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public frmListarEmpresas()
        {
            InitializeComponent();
        }
        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            ePerm.Adicionales.CampoOrden = GestionClubPermisoEmpresaDto._desEmpresa;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
        }

        public void ActualizaVentana()
        {
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, ePerm.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
            List<GestionClubPermisoEmpresaDto> iLis = new List<GestionClubPermisoEmpresaDto>();
            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.EmpresasAutorizadasDeUsuario: { iLis = GestionClubPermisoEmpresaController.ListarPermisosEmpresaActivasXUsuarioYAutorizadas(ePerm); break; }
            }

            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(iLis);
            //asignando columnas
            iDgv.AsignarColumnaTextCadena(GestionClubPermisoEmpresaDto._codEmpresa, "Codigo", 50);
            iDgv.AsignarColumnaTextCadena(GestionClubPermisoEmpresaDto._desEmpresa, "Descripcion", 276);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, GestionClubPermisoEmpresaDto._codEmpresa);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            ePerm.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
        }

        private void frmListarEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si se selecciono la barra espaciadora
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.DgvLista, ePerm.Adicionales.CampoOrden, this.txtBus, e);
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }
    }
}
