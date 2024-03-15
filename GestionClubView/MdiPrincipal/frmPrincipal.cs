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
using GestionClubView.Venta;
using GestionClubView.Stock_Restaurante;
using GestionClubView.Consultas;
using GestionClubView.Reportes;
using GestionClubView.FacturaElectronica;

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
            this.InstanciarSeleccionarCaja();
            this.ConfiguracionCajas();

        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.ShowOptionsReport();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("¿Desea salir del sistema?", "Sistema Gestión Club COSFUP"))
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
            GestionClubAperturaCajaDto gestionClubAperturaCajaDto = new GestionClubAperturaCajaDto();
            gestionClubAperturaCajaDto.fecAperturaCaja = DateTime.Now;
            //gestionClubAperturaCajaDto.caja = 
            gestionClubAperturaCajaDto = GestionClubAperturaCajaController.ListarAperturaCajasPorFechaPorCaja(gestionClubAperturaCajaDto);

            if (gestionClubAperturaCajaDto.idAperturaCaja == 0) { Mensaje.OperacionDenegada("Debe aperturar la caja.", this.eTitulo); result = false; }

            return result;
        }

        public void AccesoPorPerfiles()
        {

            List<string> listMenu = new List<string>();

            listMenu = oCredAccCtrl.ListarSubPrivilegiosAcceso(Universal.gIdAcceso);


            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                for (int i = 0; i < listMenu.Count; i++)
                {
                    if (item.Name == listMenu[i])
                    {
                        if (listMenu[i + 1] == "true")
                            item.Visible = true;
                        else
                            item.Visible = false;
                    }
                    i++;
                }
            }
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                //item.DropDownItems.Remove(this.toolStripSeparator1);
                for (int i = 0; i < item.DropDownItems.Count; i++)
                {
                    for (int j = 0; j < listMenu.Count; j++)
                    {
                        if (item.DropDownItems[i].Name == "tsmAjustesSalidas")
                        {
                            i += 1;
                        }

                        if (item.DropDownItems[i].Name == listMenu[j])
                        {
                            if (listMenu[j + 1] == "true")
                                item.DropDownItems[i].Visible = true;
                            else
                                item.DropDownItems[i].Visible = false;
                        }
                        j++;
                    }
                }
            }

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
        public void ConfiguracionCajas()
        {
            if (Universal.caja == "01")
            {
                this.tsmComprobante.Visible = false;
                this.tsbComprobante.Visible = false;
            }
            if (Universal.caja == "02")
            {
                this.tsmPedidos.Visible = false;
                this.tsbComanda.Visible = false;
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
            this.FormatoVentanaHijoPrincipal(win, this.tsmComprobante, this.tsbComprobante, 0, 0);
            win.NewWindow();
        }
        public void InstanciarIngresosCompras()
        {
            frmIngresosCompras win = new frmIngresosCompras();
            this.FormatoVentanaHijoPrincipal(win, this.tsmIngresosCompras, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarListaClientesProveedores()
        {
            frmListadoClientesProveedores win = new frmListadoClientesProveedores();
            this.FormatoVentanaHijoPrincipal(win, this.tsmClientesProveedores, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarListaComprobantesVentaDiarias()
        {
            frmListadoDeComprobanteDiarias win = new frmListadoDeComprobanteDiarias();
            this.FormatoVentanaHijoPrincipal(win, this.tsmVentasDiarias, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarNotaDeCredito()
        {
            frmNotaDeCredito win = new frmNotaDeCredito();
            this.FormatoVentanaHijoPrincipal(win, this.tsmNotaCredito, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarAprobacionClave()
        {
            frmAprobacionClave win = new frmAprobacionClave();
            this.FormatoVentanaHijoPrincipal(win, this.tsmNotaCredito, null, 0, 0);
            win.wfrm = this;
            win.NewWindow();
        }
        public void InstanciarAjusteIngresos()
        {
            frmAjusteIngresos win = new frmAjusteIngresos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmAjustesIngresos, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarAjusteSalidas()
        {
            frmAjusteSalidas win = new frmAjusteSalidas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmAjustesSalidas, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarTablaSistema()
        {
            frmTablaSistema win = new frmTablaSistema();
            this.FormatoVentanaHijoPrincipal(win, this.tsmTablaSistema, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarListadoTablaSistema()
        {
            frmListadoTablaSistema win = new frmListadoTablaSistema();
            this.FormatoVentanaHijoPrincipal(win, this.tsmConsultaTablaSistema, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarReporteListadoTablaSistema()
        {
            frmReportListaSistemaDetalle win = new frmReportListaSistemaDetalle();
            this.FormatoVentanaHijoPrincipal(win, this.tsmReporteTablaSistema, null, 0, 0);
            win.VentanaVisualizar();
        }
        public void InstanciarReporteResumenAlmacen()
        {
            frmIngresarAnioMesAlmacen win = new frmIngresarAnioMesAlmacen();
            this.FormatoVentanaHijoPrincipal(win, this.tsmResumenAlmacen, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteResumenIngresoSalida()
        {
            frmIngresarAnioMesIngresoSalida win = new frmIngresarAnioMesIngresoSalida();
            this.FormatoVentanaHijoPrincipal(win, this.tsmCuadroSalidaIngreso, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarRecalcularStock()
        {
            frmRecalcularStockAnioMes win = new frmRecalcularStockAnioMes();
            this.FormatoVentanaHijoPrincipal(win, this.tsmRecalcularStock, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarComprobanteElectronico()
        {
            frmComprobantesElectronicos win = new frmComprobantesElectronicos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmComprobanteElectronicos, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarCambiarClave()
        {
            frmCambiarAprobacionClave win = new frmCambiarAprobacionClave();
            this.FormatoVentanaHijoPrincipal(win, this.tsmCambiarClave, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarErroresElectronicos()
        {
            frmErroresElectronicos win = new frmErroresElectronicos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmErrorElectronico, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarUsuarioMozo()
        {
            frmMozosUsuarios win = new frmMozosUsuarios();
            this.FormatoVentanaHijoPrincipal(win, this.tsmMozosUsuarios, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarTipoCambio()
        {
            frmTipoCambio win = new frmTipoCambio();
            this.FormatoVentanaHijoPrincipal(win, this.tsmTipoCambio, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarReporteListarPrecios()
        {
            frmEscogerCategoriaListaPrecios win = new frmEscogerCategoriaListaPrecios();
            this.FormatoVentanaHijoPrincipal(win, this.tsmListaPrecios, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteRegistroVentas()
        {
            frmIngresarAnioMesVentaAnual win = new frmIngresarAnioMesVentaAnual();
            this.FormatoVentanaHijoPrincipal(win, this.tsmRegistroVentas, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteRegistroVentasPorFecha()
        {
            frmEscogerListaVentasPorFechas win = new frmEscogerListaVentasPorFechas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmListaVentaFechas, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteListadoClienteProveedores()
        {
            frmEscogerTipoNombreDniListadoClientes win = new frmEscogerTipoNombreDniListadoClientes();
            this.FormatoVentanaHijoPrincipal(win, this.tsmListaClienteProveedores, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteEstadisticaVentaAnualMensual()
        {
            frmIngresarAnioVentaAnual win = new frmIngresarAnioVentaAnual();
            this.FormatoVentanaHijoPrincipal(win, this.tsmVentaAnualesMes, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteTopProductosVendidos()
        {
            frmIngresarAnioTopVentaProductos win = new frmIngresarAnioTopVentaProductos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmTopProductos, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteEstadisticaVentaAnualMensualPorTipo()
        {
            frmIngresarAnioTipoVentaAnual win = new frmIngresarAnioTipoVentaAnual();
            this.FormatoVentanaHijoPrincipal(win, this.tsmVentaAnualesMesesPorTipo, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteEstadisticaVentaCategoriaProducto()
        {
            frmEscogerAnioCategoriaProductoVentas win = new frmEscogerAnioCategoriaProductoVentas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmVentaAnualesMesesPorTipo, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarReporteEstadisticaVentaProducto()
        {
            frmEscogerAnioCategoriaVentas win = new frmEscogerAnioCategoriaVentas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmResumenDeVentasAnual, null, 0, 0);
            win.VentanaSeleccionar();
        }
        public void InstanciarParametros()
        {
            frmParametro win = new frmParametro();
            this.FormatoVentanaHijoPrincipal(win, this.tsmParametrosVentas, null, 0, 0);
            win.AbrirVentana();
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
        public void InstanciarSeleccionarCaja()
        {
            frmSeleccionarCaja win = new frmSeleccionarCaja();
            win.wFrm = this;
            this.FormatoVentanaHijoPrincipal(win, this.tsmSeleccionarCaja, null, 0, 0);
            win.VentanaSeleccionar();
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

        public void tsmAperturaCaja_Click(object sender, EventArgs e)
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

        private void tsmIngresosCompras_Click(object sender, EventArgs e)
        {
            this.InstanciarIngresosCompras();
        }

        private void tsmClientesProveedores_Click(object sender, EventArgs e)
        {
            this.InstanciarListaClientesProveedores();
        }

        private void tsmVentasDiarias_Click(object sender, EventArgs e)
        {
            this.InstanciarListaComprobantesVentaDiarias();
        }

        private void tsbComprobante_Click(object sender, EventArgs e)
        {
            this.InstanciarComprobante();
        }

        private void tsmMozosUsuarios_Click_1(object sender, EventArgs e)
        {
            this.InstanciarUsuarioMozo();
        }

        private void tsmTipoCambio_Click(object sender, EventArgs e)
        {
            this.InstanciarTipoCambio();
        }

        private void tsmListaPrecios_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteListarPrecios();
        }

        private void tsmRegistroVentas_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteRegistroVentas();
        }

        private void tsmListaVentaFechas_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteRegistroVentasPorFecha();
        }

        private void tsmListaClienteProveedores_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteListadoClienteProveedores();
        }

        private void tsmTopProductos_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteTopProductosVendidos();
        }

        private void tsmVentaAnualesMes_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteEstadisticaVentaAnualMensual();
        }

        private void tsmVentaAnualesMesesPorTipo_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteEstadisticaVentaAnualMensualPorTipo();
        }

        private void tsmVentasPorCategoriasProductos_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteEstadisticaVentaCategoriaProducto();
        }

        private void tsmResumenDeVentasAnual_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteEstadisticaVentaProducto();
        }

        private void tsmParametrosVentas_Click(object sender, EventArgs e)
        {
            this.InstanciarParametros();
        }

        private void tsmAjustesIngresos_Click(object sender, EventArgs e)
        {
            this.InstanciarAjusteIngresos();
        }

        private void tsmAjustesSalidas_Click(object sender, EventArgs e)
        {
            this.InstanciarAjusteSalidas();
        }

        private void tsmTablaSistema_Click(object sender, EventArgs e)
        {
            this.InstanciarTablaSistema();
        }

        private void tsmConsultaTablaSistema_Click(object sender, EventArgs e)
        {
            this.InstanciarListadoTablaSistema();
        }

        private void tsmReporteTablaSistema_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteListadoTablaSistema();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tsmResumenAlmacen_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteResumenAlmacen();
        }

        private void tsmCuadroSalidaIngreso_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteResumenIngresoSalida();
        }

        private void tsmRecalcularStock_Click(object sender, EventArgs e)
        {
            this.InstanciarRecalcularStock();
        }

        private void tsmErrorElectronico_Click(object sender, EventArgs e)
        {
            this.InstanciarErroresElectronicos();
        }

        private void tsmComprobanteElectronicos_Click(object sender, EventArgs e)
        {
            this.InstanciarComprobanteElectronico();
        }

        private void tsmCambiarClave_Click(object sender, EventArgs e)
        {
            this.InstanciarCambiarClave();
        }

        private void tsmNotaCredito_Click(object sender, EventArgs e)
        {
            this.InstanciarAprobacionClave();
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
