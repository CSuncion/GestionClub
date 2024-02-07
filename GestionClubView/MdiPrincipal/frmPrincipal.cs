using GestionClubUtil.Util;
using GestionClubView.Login;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinControles.ControlesWindows;
using System.Runtime.InteropServices;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubView.Informatica;
using GestionClubView.AcercaDe;
using GestionClubUtil.Enum;
using WinControles;
using GestionClubView.Pedidos;
using GestionClubView.Maestros;

namespace GestionClubView.MdiPrincipal
{
    public partial class frmPrincipal : Form
    {
        GestionClubAccessController oCredAccCtrl = new GestionClubAccessController();
        public string eTitulo = "Gestión Club";
        public frmPrincipal()
        {
            InitializeComponent();
            //this.LoadTheme
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        #region Events
        int lx, ly;
        int sw, sh;
        bool isSize = false;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.NewWindowAccess();
            this.AccesoPorPerfiles();
            if (!this.ValidaAperturaCaja()) { this.InstanciarAperturaCaja(); }

        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.ShowOptionsReport();
        }
        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
            this.isSize = true;
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.MaximizedWindow();

        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.RestoreWindow();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        private void pnlBarTit_MouseMove(object sender, MouseEventArgs e)
        {
            WinPrincipal.ReleaseCapture();
            WinPrincipal.SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
        private void tmOcultarMenu_Tick(object sender, EventArgs e)
        {
            if (this.pnlMenu.Width <= 60)
                this.tmOcultarMenu.Enabled = false;
            else
                this.pnlMenu.Width -= 45;
        }
        private void tmMostrarMenu_Tick(object sender, EventArgs e)
        {
            if (this.pnlMenu.Width >= 285)
                this.tmMostrarMenu.Enabled = false;
            else
                this.pnlMenu.Width += 45;
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            //if (this.pnlMenu.Width == 285)
            //{
            //    this.btnMenu.Location = new Point(22, 6);
            //    this.tmOcultarMenu.Enabled = true;
            //}
            //else if (this.pnlMenu.Width == 60)
            //{
            //    this.btnMenu.Location = new Point(247, 6);
            //    this.tmMostrarMenu.Enabled = true;
            //}
        }
        private void pnlBarTit_DoubleClick(object sender, EventArgs e)
        {
            if (this.isSize)
                this.RestoreWindow();
            else
                this.MaximizedWindow();

        }
        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        // Tsm

        private void tsmRespaldoBackup_Click(object sender, EventArgs e)
        {
            this.InstanciarRespaldoBackup();
        }

        private void tsmAcercaDe_Click(object sender, EventArgs e)
        {
            this.InstanciarAcercaDe();
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("¿Desea salir del sistema?", "Sistema Gestión Club COSFUP"))
                this.Close();
        }



        private void tsmCajaMilitarEnvioGeneraFileMes_Click(object sender, EventArgs e)
        {
            this.InstanciarEnvioGenerarFileMes((int)GestionClubEnum.UndDscto.CajaPensionesCPMP);
        }

        private void tsmDirrehumHaberesEnvioGeneraFile_Click(object sender, EventArgs e)
        {
            this.InstanciarEnvioGenerarFileMes((int)GestionClubEnum.UndDscto.DirrehumHaberes);
        }
        private void tsmDirrehumCombustibleEnvioGeneraFile_Click(object sender, EventArgs e)
        {
            this.InstanciarEnvioGenerarFileMes((int)GestionClubEnum.UndDscto.DirrehumCombustible);
        }

        #endregion

        #region Methods
        public bool ValidaAperturaCaja()
        {
            bool result = true;
            GestionClubAperturaCajaController gestionClubAperturaCajaController = new GestionClubAperturaCajaController();
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            gestionClubAperturaCajaDto = gestionClubAperturaCajaController.ListarAperturaCajasPorFecha(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0) { Mensaje.OperacionDenegada("Debe aperturar la caja.", this.eTitulo); result = false; }

            return result;
        }

        public void AccesoPorPerfiles()
        {
            List<int> listMenu = new List<int>();
            listMenu = oCredAccCtrl.ListarSubPrivilegiosAcceso(Universal.gIdAcceso);
            for (int i = 0; i < listMenu.Count; i++)
            {
                //if (listMenu[i] == 1)
                //{

                //}

                //if (listMenu[i] == 2)
                //{
                this.tsmInformatica.Visible = true;
                //}
            }
            this.tsmInformatica.Visible = true;
        }
        private void LoadTheme()
        {
            var themeColor = WinTheme.GetAccentColor();

            pnlLogo.BackColor = themeColor;
            pnlMenu.BackColor = themeColor;

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
            foreach (Button button in this.pnlMenu.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
        }

        public void NewWindowAccess()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.frmPrincipal = this;
            frmLogin.NewWindow();
        }
        public void RestoreWindow()
        {
            this.isSize = false;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        public void MaximizedWindow()
        {
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
            this.isSize = true;
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        public void EliminarTodasLasVentanasAbiertas()
        {
            //obtener la lista de ventanas a eliminar
            List<Form> iLisVenEli = this.ObtenerListaDeVentanasAbiertas();

            //obtener el numero de formularios abiertos
            int iNumeroVentanasAbiertas = iLisVenEli.Count;

            //ir eliminando cada ventana 
            for (int i = 0; i < iNumeroVentanasAbiertas; i++)
            {
                iLisVenEli[i].Close();
            }
        }
        public List<Form> ObtenerListaDeVentanasAbiertas()
        {
            //lista resultado
            List<Form> iLisRes = new List<Form>();

            //solo excepto el wMenu y el wAcceso
            foreach (Form xWin in Application.OpenForms)
            {
                if (xWin.Name != "frmPrincipal" && xWin.Name != "frmLogin")
                {
                    iLisRes.Add(xWin);
                }
            }

            //devolver
            return iLisRes;
        }
        public void EliminarTodosLosTabVentanas()
        {
            int iNroTabPage = this.tbcContainer.TabPages.Count;

            //eliminar todos los tabpage pero desde el indice 1
            for (int i = 0; i < iNroTabPage; i++)
            {
                this.tbcContainer.TabPages.RemoveAt(0);
            }
        }
        public void FormatoVentanaHijoPrincipal(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir, int PAncVen, int pAltVen)
        {
            pItem.Enabled = false;
            if (pAccDir != null) { pAccDir.Enabled = false; }
            this.tbcContainer.Visible = true;
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = Color.White;
            TabCtrl.InsertarVentanaConTabPage(this.tbcContainer, pWin, PAncVen, pAltVen);
        }

        public void InstanciarRespaldoBackup()
        {
            frmRespaldoBackup win = new frmRespaldoBackup();
            this.FormatoVentanaHijoPrincipal(win, this.tsmRespaldoBackup, null, 0, 0);
            win.abrirVentana();
        }
        public void InstanciarAcercaDe()
        {
            frmAcercaDe win = new frmAcercaDe();
            this.FormatoVentanaHijoPrincipal(win, this.tsmAcercaDe, null, 0, 0);
            win.NewWindow();
        }

        public void InstanciarComanda()
        {
            frmComanda win = new frmComanda();
            this.FormatoVentanaHijoPrincipal(win, this.tsmComanda, this.tsbComanda, 0, 0);
            win.NewWindow();
        }

        public void InstanciarCategorias()
        {
            frmCategorias win = new frmCategorias();
            this.FormatoVentanaHijoPrincipal(win, this.tsmCategorias, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarComprobante()
        {
            frmComprobantes win = new frmComprobantes();
            this.FormatoVentanaHijoPrincipal(win, this.tsmComprobante, null, 0, 0);
            win.NewWindow();
        }

        public void InstanciarEnvioGenerarFileMes(int uniDscto)
        {
            //frmEnvioGeneraFileMes win = new frmEnvioGeneraFileMes();
            //switch (uniDscto)
            //{
            //    case (int)GestionClubEnum.UndDscto.DirrehumHaberes:
            //        this.FormatoVentanaHijoPrincipal(win, this.tsmDirrehumHaberesEnvioGeneraFile, null, 0, 0);
            //        break;
            //    case (int)GestionClubEnum.UndDscto.DirrehumCombustible:
            //        this.FormatoVentanaHijoPrincipal(win, this.tsmDirrehumCombustibleEnvioGeneraFile, null, 0, 0);
            //        break;
            //    case (int)GestionClubEnum.UndDscto.CajaPensionesCPMP:
            //        this.FormatoVentanaHijoPrincipal(win, this.tsmCajaMilitarEnvioGeneraFileMes, null, 0, 0);
            //        break;
            //}


            //win.NewWindow(uniDscto);
        }
        public void InstanciarMasterProducto()
        {
            frmProductos win = new frmProductos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMasterProductos, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarMasterProveedores()
        {
            frmProveedores win = new frmProveedores();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMasterProveedores, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarMasterClientes()
        {
            frmClientes win = new frmClientes();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMasterClientes, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarAperturaCaja()
        {
            frmAperturaCaja win = new frmAperturaCaja();
            this.FormatoVentanaHijoPrincipal(win, this.tsmAperturaCaja, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarCierreCaja()
        {
            frmCierreCaja win = new frmCierreCaja();
            this.FormatoVentanaHijoPrincipal(win, this.tsmCierreCaja, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarListadoPedido()
        {
            frmListadoPedidos win = new frmListadoPedidos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmListadoPedidos, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarMesas()
        {
            frmMesas win = new frmMesas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMesas, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarMozosUsuarios()
        {
            frmMozosUsuarios win = new frmMozosUsuarios();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMozosUsuarios, null, 0, 0);
            win.NewWindow();
        }

        public void InstanciarAmbientes()
        {
            frmAmbientes win = new frmAmbientes();
            this.FormatoVentanaHijoPrincipal(win, this.tsmAmbientes, null, 0, 0);
            win.NewWindow();
        }

        public void ShowOptionsReport()
        {
            //if (this.pnlBtnFinanzas.Visible)
            //{
            //    this.pnlBtnFinanzas.Visible = false;
            //    this.btnInformatica.Location = new Point(3, 170);
            //    this.pnlInformatica.Location = new Point(3, 170);
            //    this.pnlBtnInformatica.Location = new Point(0, 208);
            //}
            //else
            //{
            //    this.pnlBtnFinanzas.Visible = true;
            //    this.btnInformatica.Location = new Point(3, 508);
            //    this.pnlInformatica.Location = new Point(3, 508);
            //    this.pnlBtnInformatica.Location = new Point(0, 547);
            //}
        }

        private void tsmComanda_Click(object sender, EventArgs e)
        {
            this.InstanciarComanda();
        }

        private void tsmMasterProductos_Click(object sender, EventArgs e)
        {
            this.InstanciarMasterProducto();
        }

        private void tsmMasterProveedores_Click(object sender, EventArgs e)
        {
            this.InstanciarMasterProveedores();
        }

        private void tsmMasterClientes_Click(object sender, EventArgs e)
        {
            this.InstanciarMasterClientes();
        }

        private void tsmAperturaCaja_Click(object sender, EventArgs e)
        {
            this.InstanciarAperturaCaja();
        }

        private void tsmCierreCaja_Click(object sender, EventArgs e)
        {
            this.InstanciarCierreCaja();
        }

        private void tsmListadoPedidos_Click(object sender, EventArgs e)
        {
            this.InstanciarListadoPedido();
        }

        private void tsmMesas_Click(object sender, EventArgs e)
        {
            this.InstanciarMesas();
        }

        private void tsmMozosUsuarios_Click(object sender, EventArgs e)
        {
            this.InstanciarMozosUsuarios();
        }

        private void tsmAmbientes_Click(object sender, EventArgs e)
        {
            this.InstanciarAmbientes();
        }

        private void tsbComanda_Click(object sender, EventArgs e)
        {
            this.InstanciarComanda();
        }

        private void tsmCategorias_Click(object sender, EventArgs e)
        {
            this.InstanciarCategorias();
        }

        private void tsmComprobante_Click(object sender, EventArgs e)
        {
            this.InstanciarComprobante();
        }

        public void ShowOptionsGestionClub()
        {
            //if (this.pnlBtnInformatica.Visible)
            //{
            //    this.pnlBtnInformatica.Visible = false;
            //this.btnGestionClub.Location = new Point(3, 170);
            //this.pnlGestionClub.Location = new Point(3, 170);
            //}
            //else
            //{
            //    this.pnlBtnInformatica.Visible = true;
            //this.btnGestionClub.Location = new Point(3, 400);
            //this.pnlGestionClub.Location = new Point(3, 400);
            //}
        }

        public void CerrarVentanaHijo(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir)
        {
            pItem.Enabled = true;
            if (pAccDir != null) { pAccDir.Enabled = true; }
            TabCtrl.EliminarTabPageAlCerrarVentana(this.tbcContainer, pWin);
            if (this.tbcContainer.TabPages.Count == 0)
            {
                this.tbcContainer.Visible = false;
                this.BackColor = Color.Gray;
            }
        }
        #endregion
    }
}
