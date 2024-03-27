namespace GestionClubView.Venta
{
    partial class frmEditarAnticipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarAnticipo));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdComprobante = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtApeNom = new System.Windows.Forms.TextBox();
            this.txtDocId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtGlosa = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTipoCambio = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecDoc = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTipDoc = new System.Windows.Forms.ComboBox();
            this.txtSerDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvComprobanteDeta = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.nudCantidadProducto = new System.Windows.Forms.NumericUpDown();
            this.txtIdProd = new System.Windows.Forms.TextBox();
            this.txtDesProd = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.chTransferencia = new System.Windows.Forms.CheckBox();
            this.txtDeposito = new System.Windows.Forms.TextBox();
            this.chDeposito = new System.Windows.Forms.CheckBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.chEfectivo = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkCancelado = new System.Windows.Forms.CheckBox();
            this.tsPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvComprobanteDeta)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProducto)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGrabar,
            this.tsbSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(732, 42);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 450;
            // 
            // tsbGrabar
            // 
            this.tsbGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbGrabar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGrabar.Image")));
            this.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGrabar.Name = "tsbGrabar";
            this.tsbGrabar.Size = new System.Drawing.Size(48, 39);
            this.tsbGrabar.Text = "Grabar";
            this.tsbGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGrabar.Click += new System.EventHandler(this.tsbGrabar_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 23);
            this.panel1.TabIndex = 452;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Khaki;
            this.label3.Location = new System.Drawing.Point(6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 449;
            this.label3.Text = "DATOS DE CLIENTE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdComprobante);
            this.groupBox1.Controls.Add(this.txtTipoDoc);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.txtApeNom);
            this.groupBox1.Controls.Add(this.txtDocId);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 49);
            this.groupBox1.TabIndex = 453;
            this.groupBox1.TabStop = false;
            // 
            // txtIdComprobante
            // 
            this.txtIdComprobante.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdComprobante.Location = new System.Drawing.Point(672, 22);
            this.txtIdComprobante.Name = "txtIdComprobante";
            this.txtIdComprobante.ReadOnly = true;
            this.txtIdComprobante.Size = new System.Drawing.Size(18, 22);
            this.txtIdComprobante.TabIndex = 452;
            this.txtIdComprobante.Visible = false;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDoc.Location = new System.Drawing.Point(648, 20);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(18, 22);
            this.txtTipoDoc.TabIndex = 451;
            this.txtTipoDoc.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(624, 19);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(18, 22);
            this.txtIdCliente.TabIndex = 450;
            this.txtIdCliente.Visible = false;
            // 
            // txtApeNom
            // 
            this.txtApeNom.Location = new System.Drawing.Point(213, 20);
            this.txtApeNom.Name = "txtApeNom";
            this.txtApeNom.ReadOnly = true;
            this.txtApeNom.Size = new System.Drawing.Size(405, 21);
            this.txtApeNom.TabIndex = 449;
            // 
            // txtDocId
            // 
            this.txtDocId.Location = new System.Drawing.Point(72, 20);
            this.txtDocId.MaxLength = 8;
            this.txtDocId.Name = "txtDocId";
            this.txtDocId.Size = new System.Drawing.Size(135, 21);
            this.txtDocId.TabIndex = 447;
            this.txtDocId.DoubleClick += new System.EventHandler(this.txtDocId_DoubleClick);
            this.txtDocId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocId_KeyDown);
            this.txtDocId.Validating += new System.ComponentModel.CancelEventHandler(this.txtDocId_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 446;
            this.label13.Text = "Cliente:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 26);
            this.panel2.TabIndex = 454;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 19);
            this.label1.TabIndex = 449;
            this.label1.Text = "DATOS DE COMPROBANTE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkCancelado);
            this.groupBox4.Controls.Add(this.txtGlosa);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtTipoCambio);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.cboMoneda);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtNroDoc);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dtpFecDoc);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboTipDoc);
            this.groupBox4.Controls.Add(this.txtSerDoc);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(706, 98);
            this.groupBox4.TabIndex = 458;
            this.groupBox4.TabStop = false;
            // 
            // txtGlosa
            // 
            this.txtGlosa.Location = new System.Drawing.Point(68, 71);
            this.txtGlosa.MaxLength = 8;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(529, 21);
            this.txtGlosa.TabIndex = 463;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(20, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 462;
            this.label17.Text = "Glosa:";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(478, 44);
            this.txtTipoCambio.MaxLength = 8;
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(119, 21);
            this.txtTipoCambio.TabIndex = 461;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(410, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 14);
            this.label16.TabIndex = 460;
            this.label16.Text = "T. Cambio:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(478, 20);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(119, 21);
            this.cboMoneda.TabIndex = 457;
            this.cboMoneda.SelectionChangeCommitted += new System.EventHandler(this.cboMoneda_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(417, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 14);
            this.label14.TabIndex = 456;
            this.label14.Text = "Moneda:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(270, 44);
            this.txtNroDoc.MaxLength = 8;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(135, 21);
            this.txtNroDoc.TabIndex = 455;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(213, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 14);
            this.label12.TabIndex = 454;
            this.label12.Text = "N°. Doc.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(209, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 453;
            this.label10.Text = "Ser. Doc.:";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.CustomFormat = "dd/MM/yyyy";
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(68, 44);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(135, 21);
            this.dtpFecDoc.TabIndex = 452;
            this.dtpFecDoc.Value = new System.DateTime(2024, 1, 23, 17, 39, 40, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 451;
            this.label9.Text = "Tip. Doc.:";
            // 
            // cboTipDoc
            // 
            this.cboTipDoc.FormattingEnabled = true;
            this.cboTipDoc.Location = new System.Drawing.Point(68, 20);
            this.cboTipDoc.Name = "cboTipDoc";
            this.cboTipDoc.Size = new System.Drawing.Size(135, 21);
            this.cboTipDoc.TabIndex = 450;
            this.cboTipDoc.SelectionChangeCommitted += new System.EventHandler(this.cboTipDoc_SelectionChangeCommitted);
            // 
            // txtSerDoc
            // 
            this.txtSerDoc.Location = new System.Drawing.Point(270, 20);
            this.txtSerDoc.MaxLength = 8;
            this.txtSerDoc.Name = "txtSerDoc";
            this.txtSerDoc.Size = new System.Drawing.Size(135, 21);
            this.txtSerDoc.TabIndex = 447;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 446;
            this.label7.Text = "Fec.:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 25);
            this.panel3.TabIndex = 459;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(9, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 449;
            this.label2.Text = "DATOS DE PEDIDO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvComprobanteDeta);
            this.groupBox2.Location = new System.Drawing.Point(10, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 135);
            this.groupBox2.TabIndex = 460;
            this.groupBox2.TabStop = false;
            // 
            // DgvComprobanteDeta
            // 
            this.DgvComprobanteDeta.BackgroundColor = System.Drawing.Color.White;
            this.DgvComprobanteDeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvComprobanteDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvComprobanteDeta.GridColor = System.Drawing.Color.Silver;
            this.DgvComprobanteDeta.Location = new System.Drawing.Point(6, 19);
            this.DgvComprobanteDeta.Name = "DgvComprobanteDeta";
            this.DgvComprobanteDeta.Size = new System.Drawing.Size(453, 104);
            this.DgvComprobanteDeta.TabIndex = 461;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.nudCantidadProducto);
            this.groupBox3.Controls.Add(this.txtIdProd);
            this.groupBox3.Controls.Add(this.txtDesProd);
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.txtCodProd);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 53);
            this.groupBox3.TabIndex = 461;
            this.groupBox3.TabStop = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(431, 20);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(79, 21);
            this.txtPrecio.TabIndex = 452;
            // 
            // nudCantidadProducto
            // 
            this.nudCantidadProducto.Location = new System.Drawing.Point(516, 20);
            this.nudCantidadProducto.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudCantidadProducto.Name = "nudCantidadProducto";
            this.nudCantidadProducto.Size = new System.Drawing.Size(41, 21);
            this.nudCantidadProducto.TabIndex = 451;
            // 
            // txtIdProd
            // 
            this.txtIdProd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProd.Location = new System.Drawing.Point(598, 20);
            this.txtIdProd.Name = "txtIdProd";
            this.txtIdProd.ReadOnly = true;
            this.txtIdProd.Size = new System.Drawing.Size(18, 22);
            this.txtIdProd.TabIndex = 450;
            this.txtIdProd.Visible = false;
            // 
            // txtDesProd
            // 
            this.txtDesProd.Location = new System.Drawing.Point(157, 20);
            this.txtDesProd.Name = "txtDesProd";
            this.txtDesProd.ReadOnly = true;
            this.txtDesProd.Size = new System.Drawing.Size(268, 21);
            this.txtDesProd.TabIndex = 449;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(563, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(29, 22);
            this.btnAgregar.TabIndex = 462;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(72, 20);
            this.txtCodProd.MaxLength = 8;
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(79, 21);
            this.txtCodProd.TabIndex = 447;
            this.txtCodProd.DoubleClick += new System.EventHandler(this.txtCodProd_DoubleClick);
            this.txtCodProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProd_KeyDown);
            this.txtCodProd.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProd_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 446;
            this.label4.Text = "Producto:";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(10, 473);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(84, 34);
            this.btnQuitar.TabIndex = 463;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtTransferencia);
            this.groupBox5.Controls.Add(this.chTransferencia);
            this.groupBox5.Controls.Add(this.txtDeposito);
            this.groupBox5.Controls.Add(this.chDeposito);
            this.groupBox5.Controls.Add(this.txtEfectivo);
            this.groupBox5.Controls.Add(this.chEfectivo);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.lblPendiente);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(484, 332);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(234, 135);
            this.groupBox5.TabIndex = 464;
            this.groupBox5.TabStop = false;
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.Enabled = false;
            this.txtTransferencia.Location = new System.Drawing.Point(115, 74);
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.Size = new System.Drawing.Size(79, 21);
            this.txtTransferencia.TabIndex = 466;
            this.txtTransferencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferencia_KeyDown);
            this.txtTransferencia.Validated += new System.EventHandler(this.txtTransferencia_Validated);
            // 
            // chTransferencia
            // 
            this.chTransferencia.AutoSize = true;
            this.chTransferencia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chTransferencia.Location = new System.Drawing.Point(6, 75);
            this.chTransferencia.Name = "chTransferencia";
            this.chTransferencia.Size = new System.Drawing.Size(103, 18);
            this.chTransferencia.TabIndex = 465;
            this.chTransferencia.Text = "Transferencia:";
            this.chTransferencia.UseVisualStyleBackColor = true;
            this.chTransferencia.CheckedChanged += new System.EventHandler(this.chTransferencia_CheckedChanged);
            // 
            // txtDeposito
            // 
            this.txtDeposito.Enabled = false;
            this.txtDeposito.Location = new System.Drawing.Point(115, 47);
            this.txtDeposito.Name = "txtDeposito";
            this.txtDeposito.Size = new System.Drawing.Size(79, 21);
            this.txtDeposito.TabIndex = 464;
            this.txtDeposito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeposito_KeyDown);
            this.txtDeposito.Validated += new System.EventHandler(this.txtDeposito_Validated);
            // 
            // chDeposito
            // 
            this.chDeposito.AutoSize = true;
            this.chDeposito.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chDeposito.Location = new System.Drawing.Point(56, 48);
            this.chDeposito.Name = "chDeposito";
            this.chDeposito.Size = new System.Drawing.Size(53, 18);
            this.chDeposito.TabIndex = 463;
            this.chDeposito.Text = "Visa:";
            this.chDeposito.UseVisualStyleBackColor = true;
            this.chDeposito.CheckedChanged += new System.EventHandler(this.chDeposito_CheckedChanged);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Enabled = false;
            this.txtEfectivo.Location = new System.Drawing.Point(115, 20);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(79, 21);
            this.txtEfectivo.TabIndex = 462;
            this.txtEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEfectivo_KeyDown);
            this.txtEfectivo.Validated += new System.EventHandler(this.txtEfectivo_Validated);
            // 
            // chEfectivo
            // 
            this.chEfectivo.AutoSize = true;
            this.chEfectivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chEfectivo.Location = new System.Drawing.Point(39, 21);
            this.chEfectivo.Name = "chEfectivo";
            this.chEfectivo.Size = new System.Drawing.Size(70, 18);
            this.chEfectivo.TabIndex = 461;
            this.chEfectivo.Text = "Efectivo:";
            this.chEfectivo.UseVisualStyleBackColor = true;
            this.chEfectivo.CheckedChanged += new System.EventHandler(this.chEfectivo_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 14);
            this.label15.TabIndex = 460;
            this.label15.Text = "(S/) Pendiente";
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendiente.Location = new System.Drawing.Point(112, 109);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(13, 14);
            this.lblPendiente.TabIndex = 459;
            this.lblPendiente.Text = "0";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(351, 487);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 14);
            this.lblCantidad.TabIndex = 468;
            this.lblCantidad.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(351, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 467;
            this.label5.Text = "CANTIDAD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(418, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 14);
            this.label6.TabIndex = 466;
            this.label6.Text = "(S/) TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(418, 487);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 14);
            this.lblTotal.TabIndex = 465;
            this.lblTotal.Text = "0";
            // 
            // chkCancelado
            // 
            this.chkCancelado.AutoSize = true;
            this.chkCancelado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCancelado.Location = new System.Drawing.Point(603, 72);
            this.chkCancelado.Name = "chkCancelado";
            this.chkCancelado.Size = new System.Drawing.Size(83, 18);
            this.chkCancelado.TabIndex = 464;
            this.chkCancelado.Text = "Cancelado";
            this.chkCancelado.UseVisualStyleBackColor = true;
            // 
            // frmEditarAnticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 519);
            this.ControlBox = false;
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "frmEditarAnticipo";
            this.Text = "Anticipo / Detracción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComprobante_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvComprobanteDeta)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProducto)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbGrabar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdCliente;
        internal System.Windows.Forms.TextBox txtApeNom;
        internal System.Windows.Forms.TextBox txtDocId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFecDoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipDoc;
        internal System.Windows.Forms.TextBox txtSerDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DgvComprobanteDeta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdProd;
        internal System.Windows.Forms.TextBox txtDesProd;
        internal System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCantidadProducto;
        internal System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.CheckBox chTransferencia;
        private System.Windows.Forms.TextBox txtDeposito;
        private System.Windows.Forms.CheckBox chDeposito;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.CheckBox chEfectivo;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.TextBox txtIdComprobante;
        internal System.Windows.Forms.TextBox txtTipoCambio;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtGlosa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkCancelado;
    }
}