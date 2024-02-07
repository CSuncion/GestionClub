namespace GestionClubView.Pedidos
{
    partial class frmComanda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComanda));
            this.lvMesas = new System.Windows.Forms.ListView();
            this.imgMesas = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidadProducto = new System.Windows.Forms.NumericUpDown();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvProductos = new System.Windows.Forms.ListView();
            this.imgProductos = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboAmbiente = new System.Windows.Forms.ComboBox();
            this.gbProductosSeleccionados = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lvProductosSeleccionados = new System.Windows.Forms.ListView();
            this.imgProductosSel = new System.Windows.Forms.ImageList(this.components);
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbRealizarPedido = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvCategorias = new System.Windows.Forms.ListView();
            this.imgCategorias = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboMesero = new System.Windows.Forms.ComboBox();
            this.lblIdComanda = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProducto)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbProductosSeleccionados.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMesas
            // 
            this.lvMesas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvMesas.HideSelection = false;
            this.lvMesas.LargeImageList = this.imgMesas;
            this.lvMesas.Location = new System.Drawing.Point(6, 19);
            this.lvMesas.Name = "lvMesas";
            this.lvMesas.Size = new System.Drawing.Size(302, 195);
            this.lvMesas.SmallImageList = this.imgMesas;
            this.lvMesas.TabIndex = 0;
            this.lvMesas.UseCompatibleStateImageBehavior = false;
            this.lvMesas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvMesas_MouseClick);
            // 
            // imgMesas
            // 
            this.imgMesas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgMesas.ImageSize = new System.Drawing.Size(16, 16);
            this.imgMesas.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvMesas);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 220);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MESAS";
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.btnAgregar);
            this.gbProductos.Controls.Add(this.nudCantidadProducto);
            this.gbProductos.Controls.Add(this.txtProducto);
            this.gbProductos.Controls.Add(this.label1);
            this.gbProductos.Controls.Add(this.lvProductos);
            this.gbProductos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductos.Location = new System.Drawing.Point(332, 106);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(344, 424);
            this.gbProductos.TabIndex = 2;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "PRODUCTOS";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(310, 36);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(28, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidadProducto
            // 
            this.nudCantidadProducto.Location = new System.Drawing.Point(263, 36);
            this.nudCantidadProducto.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudCantidadProducto.Name = "nudCantidadProducto";
            this.nudCantidadProducto.Size = new System.Drawing.Size(41, 22);
            this.nudCantidadProducto.TabIndex = 4;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(6, 35);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(251, 22);
            this.txtProducto.TabIndex = 3;
            this.txtProducto.Tag = "";
            this.txtProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "BUSCAR";
            // 
            // lvProductos
            // 
            this.lvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvProductos.HideSelection = false;
            this.lvProductos.LargeImageList = this.imgProductos;
            this.lvProductos.Location = new System.Drawing.Point(6, 64);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(332, 354);
            this.lvProductos.SmallImageList = this.imgProductos;
            this.lvProductos.TabIndex = 1;
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            this.lvProductos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvProductos_MouseClick);
            // 
            // imgProductos
            // 
            this.imgProductos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgProductos.ImageSize = new System.Drawing.Size(16, 16);
            this.imgProductos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboAmbiente);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 55);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AMBIENTES";
            // 
            // cboAmbiente
            // 
            this.cboAmbiente.FormattingEnabled = true;
            this.cboAmbiente.Location = new System.Drawing.Point(7, 20);
            this.cboAmbiente.Name = "cboAmbiente";
            this.cboAmbiente.Size = new System.Drawing.Size(301, 22);
            this.cboAmbiente.TabIndex = 0;
            this.cboAmbiente.SelectionChangeCommitted += new System.EventHandler(this.cboAmbiente_SelectionChangeCommitted);
            // 
            // gbProductosSeleccionados
            // 
            this.gbProductosSeleccionados.Controls.Add(this.lblIdComanda);
            this.gbProductosSeleccionados.Controls.Add(this.lblCantidad);
            this.gbProductosSeleccionados.Controls.Add(this.label5);
            this.gbProductosSeleccionados.Controls.Add(this.label4);
            this.gbProductosSeleccionados.Controls.Add(this.lblTotal);
            this.gbProductosSeleccionados.Controls.Add(this.btnCobrar);
            this.gbProductosSeleccionados.Controls.Add(this.btnQuitar);
            this.gbProductosSeleccionados.Controls.Add(this.lvProductosSeleccionados);
            this.gbProductosSeleccionados.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductosSeleccionados.Location = new System.Drawing.Point(682, 45);
            this.gbProductosSeleccionados.Name = "gbProductosSeleccionados";
            this.gbProductosSeleccionados.Size = new System.Drawing.Size(401, 485);
            this.gbProductosSeleccionados.TabIndex = 4;
            this.gbProductosSeleccionados.TabStop = false;
            this.gbProductosSeleccionados.Text = "PRODUCTO SELECCIONADOS";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(269, 456);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 14);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "CANTIDAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "(S/) TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(336, 456);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 14);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "0";
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCobrar.Enabled = false;
            this.btnCobrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCobrar.Image")));
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.Location = new System.Drawing.Point(6, 447);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(82, 32);
            this.btnCobrar.TabIndex = 7;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitar.Location = new System.Drawing.Point(94, 447);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(37, 32);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lvProductosSeleccionados
            // 
            this.lvProductosSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvProductosSeleccionados.HideSelection = false;
            this.lvProductosSeleccionados.LargeImageList = this.imgProductosSel;
            this.lvProductosSeleccionados.Location = new System.Drawing.Point(6, 19);
            this.lvProductosSeleccionados.Name = "lvProductosSeleccionados";
            this.lvProductosSeleccionados.Size = new System.Drawing.Size(389, 422);
            this.lvProductosSeleccionados.SmallImageList = this.imgProductosSel;
            this.lvProductosSeleccionados.TabIndex = 0;
            this.lvProductosSeleccionados.UseCompatibleStateImageBehavior = false;
            this.lvProductosSeleccionados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvProductosSeleccionados_MouseClick);
            // 
            // imgProductosSel
            // 
            this.imgProductosSel.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgProductosSel.ImageSize = new System.Drawing.Size(16, 16);
            this.imgProductosSel.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRealizarPedido,
            this.tsbSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(1095, 42);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 449;
            // 
            // tsbRealizarPedido
            // 
            this.tsbRealizarPedido.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbRealizarPedido.Image = ((System.Drawing.Image)(resources.GetObject("tsbRealizarPedido.Image")));
            this.tsbRealizarPedido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRealizarPedido.Name = "tsbRealizarPedido";
            this.tsbRealizarPedido.Size = new System.Drawing.Size(97, 39);
            this.tsbRealizarPedido.Text = "Realizar Pedido";
            this.tsbRealizarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRealizarPedido.Click += new System.EventHandler(this.tsbRealizarPedido_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 39);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvCategorias);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 198);
            this.groupBox2.TabIndex = 450;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CATEGORIAS";
            // 
            // lvCategorias
            // 
            this.lvCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCategorias.HideSelection = false;
            this.lvCategorias.LargeImageList = this.imgCategorias;
            this.lvCategorias.Location = new System.Drawing.Point(9, 21);
            this.lvCategorias.Name = "lvCategorias";
            this.lvCategorias.Size = new System.Drawing.Size(299, 171);
            this.lvCategorias.SmallImageList = this.imgCategorias;
            this.lvCategorias.TabIndex = 2;
            this.lvCategorias.UseCompatibleStateImageBehavior = false;
            this.lvCategorias.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvCategorias_MouseClick);
            // 
            // imgCategorias
            // 
            this.imgCategorias.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgCategorias.ImageSize = new System.Drawing.Size(16, 16);
            this.imgCategorias.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboMesero);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(332, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 55);
            this.groupBox4.TabIndex = 451;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MOZO";
            // 
            // cboMesero
            // 
            this.cboMesero.FormattingEnabled = true;
            this.cboMesero.Location = new System.Drawing.Point(7, 20);
            this.cboMesero.Name = "cboMesero";
            this.cboMesero.Size = new System.Drawing.Size(331, 22);
            this.cboMesero.TabIndex = 0;
            // 
            // lblIdComanda
            // 
            this.lblIdComanda.AutoSize = true;
            this.lblIdComanda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdComanda.Location = new System.Drawing.Point(137, 456);
            this.lblIdComanda.Name = "lblIdComanda";
            this.lblIdComanda.Size = new System.Drawing.Size(13, 14);
            this.lblIdComanda.TabIndex = 465;
            this.lblIdComanda.Text = "0";
            this.lblIdComanda.Visible = false;
            // 
            // frmComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 552);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.gbProductosSeleccionados);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbProductos);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmComanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comanda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComanda_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProducto)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.gbProductosSeleccionados.ResumeLayout(false);
            this.gbProductosSeleccionados.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMesas;
        private System.Windows.Forms.ImageList imgMesas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.ListView lvProductos;
        private System.Windows.Forms.ImageList imgProductos;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboAmbiente;
        private System.Windows.Forms.GroupBox gbProductosSeleccionados;
        private System.Windows.Forms.ListView lvProductosSeleccionados;
        private System.Windows.Forms.NumericUpDown nudCantidadProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvCategorias;
        private System.Windows.Forms.ImageList imgCategorias;
        private System.Windows.Forms.ToolStripButton tsbRealizarPedido;
        internal System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboMesero;
        private System.Windows.Forms.ImageList imgProductosSel;
        private System.Windows.Forms.Label lblIdComanda;
    }
}