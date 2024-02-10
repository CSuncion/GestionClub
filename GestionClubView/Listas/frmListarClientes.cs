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
using System.Windows.Forms;
using WinControles.ControlesWindows;
using static GestionClubView.Listas.frmListarEmpresas;

namespace GestionClubView.Listas
{
    public partial class frmListarClientes : Form
    {

        public enum Condicion
        {
            Clientes,
        }
        public Form eVentana = new Form();
        public GestionClubClienteDto eCli = new GestionClubClienteDto();
        public List<GestionClubClienteDto> eLisCli = new List<GestionClubClienteDto>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        GestionClubClienteController oCli = new GestionClubClienteController();
        public string tipCliente = string.Empty;
        public frmListarClientes()
        {
            InitializeComponent();
        }
        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eCli.Adicionales.CampoOrden = GestionClubClienteDto._nombreRazSocialCliente;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Nombre/Raz. Social";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
            this.txtBus.Focus();
        }

        public void ActualizaVentana()
        {
            this.ActualizarListaAuxiliarsDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eCli.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(GestionClubClienteDto._nroIdentificacionCliente, "Doc.Identificación", 120);
            iDgv.AsignarColumnaTextCadena(GestionClubClienteDto._nombreRazSocialCliente, "Nombre/Raz. Social", 260);
        }

        public void ActualizarListaAuxiliarsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Clientes: { this.eLisCli = oCli.ListarClientes().Where(x => x.tipCliente == this.tipCliente).ToList(); break; }

            }
        }

        public List<GestionClubClienteDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eCli.Adicionales.CampoOrden;
            List<GestionClubClienteDto> iListaAuxiliars = this.eLisCli;

            //ejecutar y retornar
            return oCli.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAuxiliars);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, GestionClubClienteDto._nroIdentificacionCliente);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eCli.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizaVentana();
                        break;
                    }
            }
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
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

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void frmListarClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }
    }
}
