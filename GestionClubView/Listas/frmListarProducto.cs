﻿using Comun;
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
    public partial class frmListarProducto : Form
    {

        public enum Condicion
        {
            Productos,
            ProductosComprobante,
            ProductosStock,
            ProductoAnticipo,
            ProductoSinAnticipo
        }
        public Form eVentana = new Form();
        public GestionClubProductoDto eCli = new GestionClubProductoDto();
        public List<GestionClubProductoDto> eLisCli = new List<GestionClubProductoDto>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        GestionClubProductoController oPro = new GestionClubProductoController();
        public frmListarProducto()
        {
            InitializeComponent();
        }
        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eCli.Adicionales.CampoOrden = GestionClubProductoDto._desProducto;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Código";
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
            iDgv.AsignarColumnaTextCadena(GestionClubProductoDto._codProducto, "Código", 120);
            iDgv.AsignarColumnaTextCadena(GestionClubProductoDto._desProducto, "Descripción", 260);
        }

        public void ActualizarListaAuxiliarsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
           switch (eCondicionLista)
            {
                case Condicion.Productos: { this.eLisCli = GestionClubProductoController.ListarProductos(); break; }
                case Condicion.ProductosComprobante:
                    {
                        this.eLisCli = GestionClubProductoController.ListarProductos()
                            .Where(x => !x.idCategoria.StartsWith("01")
                            && (x.idCategoria != "0303"
                            && x.idCategoria != "0601")
                            ).ToList(); break;
                    }
                case Condicion.ProductosStock:
                    {
                        this.eLisCli = GestionClubProductoController.ListarProductos().Where(x => x.idCategoria == "0103"
                || x.idCategoria == "0106"
                || x.idCategoria == "0108"
                || x.idCategoria == "0112").ToList(); break;
                    }
                case Condicion.ProductoAnticipo:
                    {
                        this.eLisCli = GestionClubProductoController.ListarProductos().Where(x => x.idCategoria == "0303"
                        || x.idCategoria == "0601").
                        ToList(); break;
                    }
                case Condicion.ProductoSinAnticipo:
                    {
                        this.eLisCli = GestionClubProductoController.ListarProductos()
                            .Where(x => x.idCategoria != "0303"
                                        && x.idCategoria != "0601"
                                        && x.idCategoria != "0103"
                                        && x.idCategoria != "0106"
                                        && x.idCategoria != "0108"
                                        && x.idCategoria != "0112")
                            .ToList(); break;
                    }
            }
        }

        public List<GestionClubProductoDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eCli.Adicionales.CampoOrden;
            List<GestionClubProductoDto> iListaAuxiliars = this.eLisCli;

            //ejecutar y retornar
            return oPro.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAuxiliars);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, GestionClubProductoDto._codProducto);
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

        private void frmListarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }
    }
}
