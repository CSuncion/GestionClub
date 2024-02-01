namespace GestionClubView.MdiPrincipal
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.tssStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcContainer = new System.Windows.Forms.TabControl();
            this.pnlBarTit = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tmOcultarMenu = new System.Windows.Forms.Timer(this.components);
            this.tmMostrarMenu = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMasterProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMasterProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMasterClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmParametrosVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMesas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMozosUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAperturaCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCierreCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAmbientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmComanda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmListadoPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdicionComprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBoleta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNotaCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInformatica = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRespaldoBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAccDir = new System.Windows.Forms.ToolStrip();
            this.tsbComanda = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.tsmComprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu.SuspendLayout();
            this.ssStatusBar.SuspendLayout();
            this.pnlBarTit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tsAccDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            resources.ApplyResources(this.pnlMenu, "pnlMenu");
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Name = "pnlMenu";
            // 
            // pnlLogo
            // 
            resources.ApplyResources(this.pnlLogo, "pnlLogo");
            this.pnlLogo.Name = "pnlLogo";
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatusBar});
            resources.ApplyResources(this.ssStatusBar, "ssStatusBar");
            this.ssStatusBar.Name = "ssStatusBar";
            // 
            // tssStatusBar
            // 
            this.tssStatusBar.BackColor = System.Drawing.Color.Transparent;
            this.tssStatusBar.Name = "tssStatusBar";
            resources.ApplyResources(this.tssStatusBar, "tssStatusBar");
            // 
            // tbcContainer
            // 
            resources.ApplyResources(this.tbcContainer, "tbcContainer");
            this.tbcContainer.Name = "tbcContainer";
            this.tbcContainer.SelectedIndex = 0;
            this.tbcContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // pnlBarTit
            // 
            this.pnlBarTit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.pnlBarTit.Controls.Add(this.btnRestaurar);
            this.pnlBarTit.Controls.Add(this.btnMinimizar);
            this.pnlBarTit.Controls.Add(this.btnMaximizar);
            this.pnlBarTit.Controls.Add(this.btnCerrar);
            resources.ApplyResources(this.pnlBarTit, "pnlBarTit");
            this.pnlBarTit.Name = "pnlBarTit";
            this.pnlBarTit.DoubleClick += new System.EventHandler(this.pnlBarTit_DoubleClick);
            this.pnlBarTit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBarTit_MouseMove);
            // 
            // btnRestaurar
            // 
            resources.ApplyResources(this.btnRestaurar, "btnRestaurar");
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnRestaurar.Image = global::GestionClubView.Properties.Resources.Icono_Restaurar;
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMinimizar
            // 
            resources.ApplyResources(this.btnMinimizar, "btnMinimizar");
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnMinimizar.Image = global::GestionClubView.Properties.Resources.Icono_Minimizar;
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            resources.ApplyResources(this.btnMaximizar, "btnMaximizar");
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnMaximizar.Image = global::GestionClubView.Properties.Resources.Icono_Maximizar;
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            resources.ApplyResources(this.btnCerrar, "btnCerrar");
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCerrar.Image = global::GestionClubView.Properties.Resources.ICON_CERRARF;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tmOcultarMenu
            // 
            this.tmOcultarMenu.Interval = 15;
            this.tmOcultarMenu.Tick += new System.EventHandler(this.tmOcultarMenu_Tick);
            // 
            // tmMostrarMenu
            // 
            this.tmMostrarMenu.Interval = 15;
            this.tmMostrarMenu.Tick += new System.EventHandler(this.tmMostrarMenu_Tick);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maestrosToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.tsmInformatica,
            this.tsmAcercaDe});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMasterProductos,
            this.tsmMasterProveedores,
            this.tsmMasterClientes,
            this.tsmParametrosVentas,
            this.tsmMesas,
            this.tsmMozosUsuarios,
            this.tsmAperturaCaja,
            this.tsmCierreCaja,
            this.tsmAmbientes,
            this.tsmCategorias});
            resources.ApplyResources(this.maestrosToolStripMenuItem, "maestrosToolStripMenuItem");
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            // 
            // tsmMasterProductos
            // 
            resources.ApplyResources(this.tsmMasterProductos, "tsmMasterProductos");
            this.tsmMasterProductos.Name = "tsmMasterProductos";
            this.tsmMasterProductos.Click += new System.EventHandler(this.tsmMasterProductos_Click);
            // 
            // tsmMasterProveedores
            // 
            resources.ApplyResources(this.tsmMasterProveedores, "tsmMasterProveedores");
            this.tsmMasterProveedores.Name = "tsmMasterProveedores";
            this.tsmMasterProveedores.Click += new System.EventHandler(this.tsmMasterProveedores_Click);
            // 
            // tsmMasterClientes
            // 
            resources.ApplyResources(this.tsmMasterClientes, "tsmMasterClientes");
            this.tsmMasterClientes.Name = "tsmMasterClientes";
            this.tsmMasterClientes.Click += new System.EventHandler(this.tsmMasterClientes_Click);
            // 
            // tsmParametrosVentas
            // 
            resources.ApplyResources(this.tsmParametrosVentas, "tsmParametrosVentas");
            this.tsmParametrosVentas.Name = "tsmParametrosVentas";
            // 
            // tsmMesas
            // 
            resources.ApplyResources(this.tsmMesas, "tsmMesas");
            this.tsmMesas.Name = "tsmMesas";
            this.tsmMesas.Click += new System.EventHandler(this.tsmMesas_Click);
            // 
            // tsmMozosUsuarios
            // 
            resources.ApplyResources(this.tsmMozosUsuarios, "tsmMozosUsuarios");
            this.tsmMozosUsuarios.Name = "tsmMozosUsuarios";
            this.tsmMozosUsuarios.Click += new System.EventHandler(this.tsmMozosUsuarios_Click);
            // 
            // tsmAperturaCaja
            // 
            resources.ApplyResources(this.tsmAperturaCaja, "tsmAperturaCaja");
            this.tsmAperturaCaja.Name = "tsmAperturaCaja";
            this.tsmAperturaCaja.Click += new System.EventHandler(this.tsmAperturaCaja_Click);
            // 
            // tsmCierreCaja
            // 
            resources.ApplyResources(this.tsmCierreCaja, "tsmCierreCaja");
            this.tsmCierreCaja.Name = "tsmCierreCaja";
            this.tsmCierreCaja.Click += new System.EventHandler(this.tsmCierreCaja_Click);
            // 
            // tsmAmbientes
            // 
            resources.ApplyResources(this.tsmAmbientes, "tsmAmbientes");
            this.tsmAmbientes.Name = "tsmAmbientes";
            this.tsmAmbientes.Click += new System.EventHandler(this.tsmAmbientes_Click);
            // 
            // tsmCategorias
            // 
            resources.ApplyResources(this.tsmCategorias, "tsmCategorias");
            this.tsmCategorias.Name = "tsmCategorias";
            this.tsmCategorias.Click += new System.EventHandler(this.tsmCategorias_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmComanda,
            this.tsmComprobante,
            this.tsmListadoPedidos,
            this.tsmEdicionComprobante});
            resources.ApplyResources(this.pedidosToolStripMenuItem, "pedidosToolStripMenuItem");
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            // 
            // tsmComanda
            // 
            resources.ApplyResources(this.tsmComanda, "tsmComanda");
            this.tsmComanda.Name = "tsmComanda";
            this.tsmComanda.Click += new System.EventHandler(this.tsmComanda_Click);
            // 
            // tsmListadoPedidos
            // 
            resources.ApplyResources(this.tsmListadoPedidos, "tsmListadoPedidos");
            this.tsmListadoPedidos.Name = "tsmListadoPedidos";
            this.tsmListadoPedidos.Click += new System.EventHandler(this.tsmListadoPedidos_Click);
            // 
            // tsmEdicionComprobante
            // 
            this.tsmEdicionComprobante.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFactura,
            this.tsmBoleta,
            this.tsmNotaCredito});
            resources.ApplyResources(this.tsmEdicionComprobante, "tsmEdicionComprobante");
            this.tsmEdicionComprobante.Name = "tsmEdicionComprobante";
            // 
            // tsmFactura
            // 
            resources.ApplyResources(this.tsmFactura, "tsmFactura");
            this.tsmFactura.Name = "tsmFactura";
            // 
            // tsmBoleta
            // 
            resources.ApplyResources(this.tsmBoleta, "tsmBoleta");
            this.tsmBoleta.Name = "tsmBoleta";
            // 
            // tsmNotaCredito
            // 
            resources.ApplyResources(this.tsmNotaCredito, "tsmNotaCredito");
            this.tsmNotaCredito.Name = "tsmNotaCredito";
            // 
            // tsmInformatica
            // 
            this.tsmInformatica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRespaldoBackup});
            resources.ApplyResources(this.tsmInformatica, "tsmInformatica");
            this.tsmInformatica.Name = "tsmInformatica";
            // 
            // tsmRespaldoBackup
            // 
            resources.ApplyResources(this.tsmRespaldoBackup, "tsmRespaldoBackup");
            this.tsmRespaldoBackup.Name = "tsmRespaldoBackup";
            this.tsmRespaldoBackup.Click += new System.EventHandler(this.tsmRespaldoBackup_Click);
            // 
            // tsmAcercaDe
            // 
            resources.ApplyResources(this.tsmAcercaDe, "tsmAcercaDe");
            this.tsmAcercaDe.Name = "tsmAcercaDe";
            this.tsmAcercaDe.Click += new System.EventHandler(this.tsmAcercaDe_Click);
            // 
            // tsAccDir
            // 
            resources.ApplyResources(this.tsAccDir, "tsAccDir");
            this.tsAccDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsAccDir.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsAccDir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbComanda,
            this.toolStripSeparator4,
            this.tsbSalir});
            this.tsAccDir.Name = "tsAccDir";
            // 
            // tsbComanda
            // 
            resources.ApplyResources(this.tsbComanda, "tsbComanda");
            this.tsbComanda.Name = "tsbComanda";
            this.tsbComanda.Click += new System.EventHandler(this.tsbComanda_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsbSalir
            // 
            resources.ApplyResources(this.tsbSalir, "tsbSalir");
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // tsmComprobante
            // 
            resources.ApplyResources(this.tsmComprobante, "tsmComprobante");
            this.tsmComprobante.Name = "tsmComprobante";
            this.tsmComprobante.Click += new System.EventHandler(this.tsmComprobante_Click);
            // 
            // frmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcContainer);
            this.Controls.Add(this.tsAccDir);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlBarTit);
            this.Controls.Add(this.ssStatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Resize += new System.EventHandler(this.frmPrincipal_Resize);
            this.pnlMenu.ResumeLayout(false);
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            this.pnlBarTit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsAccDir.ResumeLayout(false);
            this.tsAccDir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.StatusStrip ssStatusBar;
        internal System.Windows.Forms.ToolStripStatusLabel tssStatusBar;
        internal System.Windows.Forms.TabControl tbcContainer;
        internal System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlBarTit;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Timer tmOcultarMenu;
        private System.Windows.Forms.Timer tmMostrarMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmInformatica;
        internal System.Windows.Forms.ToolStripMenuItem tsmRespaldoBackup;
        private System.Windows.Forms.ToolStrip tsAccDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        internal System.Windows.Forms.ToolStripMenuItem tsmAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmParametrosVentas;
        private System.Windows.Forms.ToolStripMenuItem tsmEdicionComprobante;
        private System.Windows.Forms.ToolStripMenuItem tsmFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmBoleta;
        private System.Windows.Forms.ToolStripMenuItem tsmNotaCredito;
        internal System.Windows.Forms.ToolStripMenuItem tsmMasterProductos;
        internal System.Windows.Forms.ToolStripMenuItem tsmMasterProveedores;
        internal System.Windows.Forms.ToolStripMenuItem tsmMasterClientes;
        internal System.Windows.Forms.ToolStripMenuItem tsmAperturaCaja;
        internal System.Windows.Forms.ToolStripMenuItem tsmCierreCaja;
        internal System.Windows.Forms.ToolStripMenuItem tsmListadoPedidos;
        internal System.Windows.Forms.ToolStripMenuItem tsmMesas;
        internal System.Windows.Forms.ToolStripMenuItem tsmMozosUsuarios;
        internal System.Windows.Forms.ToolStripMenuItem tsmAmbientes;
        internal System.Windows.Forms.ToolStripMenuItem tsmComanda;
        internal System.Windows.Forms.ToolStripButton tsbComanda;
        internal System.Windows.Forms.ToolStripMenuItem tsmCategorias;
        internal System.Windows.Forms.ToolStripMenuItem tsmComprobante;
    }
}