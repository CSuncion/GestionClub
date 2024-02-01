namespace GestionClubView.Pedidos
{
    partial class frmCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrar));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnCobrar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTicket = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtApeNom = new System.Windows.Forms.TextBox();
            this.txtDocId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lvProductosSeleccionados = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblIdNroComanda = new System.Windows.Forms.Label();
            this.lblIdMozo = new System.Windows.Forms.Label();
            this.lblIdAmbiente = new System.Windows.Forms.Label();
            this.lblIdMesa = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.txtTransferencia = new System.Windows.Forms.TextBox();
            this.chTransferencia = new System.Windows.Forms.CheckBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.chTarjeta = new System.Windows.Forms.CheckBox();
            this.txtYape = new System.Windows.Forms.TextBox();
            this.chYape = new System.Windows.Forms.CheckBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.chEfectivo = new System.Windows.Forms.CheckBox();
            this.lblNroMesa = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAmbiente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.imgProductosSel = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.tsPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCobrar,
            this.tsBtnTicket,
            this.tsbSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(684, 45);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 449;
            // 
            // tsBtnCobrar
            // 
            this.tsBtnCobrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBtnCobrar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCobrar.Image")));
            this.tsBtnCobrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCobrar.Name = "tsBtnCobrar";
            this.tsBtnCobrar.Size = new System.Drawing.Size(46, 42);
            this.tsBtnCobrar.Text = "Cobrar";
            this.tsBtnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnCobrar.Click += new System.EventHandler(this.tsBtnCobrar_Click);
            // 
            // tsBtnTicket
            // 
            this.tsBtnTicket.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBtnTicket.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnTicket.Image")));
            this.tsBtnTicket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTicket.Name = "tsBtnTicket";
            this.tsBtnTicket.Size = new System.Drawing.Size(43, 42);
            this.tsBtnTicket.Text = "Ticket";
            this.tsBtnTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnTicket.Click += new System.EventHandler(this.tsBtnTicket_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 42);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 19);
            this.label3.TabIndex = 449;
            this.label3.Text = "DATOS DE COMENSAL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 32);
            this.panel1.TabIndex = 451;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.txtApeNom);
            this.groupBox1.Controls.Add(this.txtDocId);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 49);
            this.groupBox1.TabIndex = 452;
            this.groupBox1.TabStop = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(636, 15);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(18, 22);
            this.txtIdCliente.TabIndex = 450;
            this.txtIdCliente.Visible = false;
            // 
            // txtApeNom
            // 
            this.txtApeNom.Location = new System.Drawing.Point(213, 15);
            this.txtApeNom.Name = "txtApeNom";
            this.txtApeNom.ReadOnly = true;
            this.txtApeNom.Size = new System.Drawing.Size(417, 21);
            this.txtApeNom.TabIndex = 449;
            // 
            // txtDocId
            // 
            this.txtDocId.Location = new System.Drawing.Point(72, 15);
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
            this.label13.Location = new System.Drawing.Point(17, 17);
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
            this.panel2.Location = new System.Drawing.Point(1, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 32);
            this.panel2.TabIndex = 453;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 449;
            this.label1.Text = "DATOS DE PEDIDO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCantidad);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.lvProductosSeleccionados);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(262, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 239);
            this.groupBox2.TabIndex = 454;
            this.groupBox2.TabStop = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(274, 222);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 14);
            this.lblCantidad.TabIndex = 14;
            this.lblCantidad.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(274, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "CANTIDAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "(S/) TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(341, 222);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 14);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "0";
            // 
            // lvProductosSeleccionados
            // 
            this.lvProductosSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvProductosSeleccionados.HideSelection = false;
            this.lvProductosSeleccionados.Location = new System.Drawing.Point(6, 20);
            this.lvProductosSeleccionados.Name = "lvProductosSeleccionados";
            this.lvProductosSeleccionados.Size = new System.Drawing.Size(395, 182);
            this.lvProductosSeleccionados.TabIndex = 10;
            this.lvProductosSeleccionados.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblIdNroComanda);
            this.groupBox3.Controls.Add(this.lblIdMozo);
            this.groupBox3.Controls.Add(this.lblIdAmbiente);
            this.groupBox3.Controls.Add(this.lblIdMesa);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblPendiente);
            this.groupBox3.Controls.Add(this.txtTransferencia);
            this.groupBox3.Controls.Add(this.chTransferencia);
            this.groupBox3.Controls.Add(this.txtTarjeta);
            this.groupBox3.Controls.Add(this.chTarjeta);
            this.groupBox3.Controls.Add(this.txtYape);
            this.groupBox3.Controls.Add(this.chYape);
            this.groupBox3.Controls.Add(this.txtEfectivo);
            this.groupBox3.Controls.Add(this.chEfectivo);
            this.groupBox3.Controls.Add(this.lblNroMesa);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblAmbiente);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblFecha);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 239);
            this.groupBox3.TabIndex = 455;
            this.groupBox3.TabStop = false;
            // 
            // lblIdNroComanda
            // 
            this.lblIdNroComanda.AutoSize = true;
            this.lblIdNroComanda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdNroComanda.Location = new System.Drawing.Point(6, 222);
            this.lblIdNroComanda.Name = "lblIdNroComanda";
            this.lblIdNroComanda.Size = new System.Drawing.Size(13, 14);
            this.lblIdNroComanda.TabIndex = 464;
            this.lblIdNroComanda.Text = "0";
            this.lblIdNroComanda.Visible = false;
            // 
            // lblIdMozo
            // 
            this.lblIdMozo.AutoSize = true;
            this.lblIdMozo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdMozo.Location = new System.Drawing.Point(25, 222);
            this.lblIdMozo.Name = "lblIdMozo";
            this.lblIdMozo.Size = new System.Drawing.Size(13, 14);
            this.lblIdMozo.TabIndex = 463;
            this.lblIdMozo.Text = "0";
            this.lblIdMozo.Visible = false;
            // 
            // lblIdAmbiente
            // 
            this.lblIdAmbiente.AutoSize = true;
            this.lblIdAmbiente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdAmbiente.Location = new System.Drawing.Point(152, 47);
            this.lblIdAmbiente.Name = "lblIdAmbiente";
            this.lblIdAmbiente.Size = new System.Drawing.Size(13, 14);
            this.lblIdAmbiente.TabIndex = 462;
            this.lblIdAmbiente.Text = "0";
            this.lblIdAmbiente.Visible = false;
            // 
            // lblIdMesa
            // 
            this.lblIdMesa.AutoSize = true;
            this.lblIdMesa.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdMesa.Location = new System.Drawing.Point(134, 61);
            this.lblIdMesa.Name = "lblIdMesa";
            this.lblIdMesa.Size = new System.Drawing.Size(13, 14);
            this.lblIdMesa.TabIndex = 461;
            this.lblIdMesa.Text = "0";
            this.lblIdMesa.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(24, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 14);
            this.label15.TabIndex = 460;
            this.label15.Text = "(S/) Pendiente";
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendiente.Location = new System.Drawing.Point(115, 189);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(13, 14);
            this.lblPendiente.TabIndex = 459;
            this.lblPendiente.Text = "0";
            // 
            // txtTransferencia
            // 
            this.txtTransferencia.Enabled = false;
            this.txtTransferencia.Location = new System.Drawing.Point(115, 159);
            this.txtTransferencia.Name = "txtTransferencia";
            this.txtTransferencia.Size = new System.Drawing.Size(79, 21);
            this.txtTransferencia.TabIndex = 458;
            this.txtTransferencia.Validated += new System.EventHandler(this.txtTransferencia_Validated);
            // 
            // chTransferencia
            // 
            this.chTransferencia.AutoSize = true;
            this.chTransferencia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chTransferencia.Location = new System.Drawing.Point(6, 160);
            this.chTransferencia.Name = "chTransferencia";
            this.chTransferencia.Size = new System.Drawing.Size(103, 18);
            this.chTransferencia.TabIndex = 457;
            this.chTransferencia.Text = "Transferencia:";
            this.chTransferencia.UseVisualStyleBackColor = true;
            this.chTransferencia.CheckedChanged += new System.EventHandler(this.chTransferencia_CheckedChanged);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Enabled = false;
            this.txtTarjeta.Location = new System.Drawing.Point(115, 132);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(79, 21);
            this.txtTarjeta.TabIndex = 456;
            this.txtTarjeta.Validated += new System.EventHandler(this.txtTarjeta_Validated);
            // 
            // chTarjeta
            // 
            this.chTarjeta.AutoSize = true;
            this.chTarjeta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chTarjeta.Location = new System.Drawing.Point(43, 133);
            this.chTarjeta.Name = "chTarjeta";
            this.chTarjeta.Size = new System.Drawing.Size(66, 18);
            this.chTarjeta.TabIndex = 455;
            this.chTarjeta.Text = "Tarjeta:";
            this.chTarjeta.UseVisualStyleBackColor = true;
            this.chTarjeta.CheckedChanged += new System.EventHandler(this.chTarjeta_CheckedChanged);
            // 
            // txtYape
            // 
            this.txtYape.Enabled = false;
            this.txtYape.Location = new System.Drawing.Point(115, 105);
            this.txtYape.Name = "txtYape";
            this.txtYape.Size = new System.Drawing.Size(79, 21);
            this.txtYape.TabIndex = 454;
            this.txtYape.Validated += new System.EventHandler(this.txtYape_Validated);
            // 
            // chYape
            // 
            this.chYape.AutoSize = true;
            this.chYape.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chYape.Location = new System.Drawing.Point(54, 106);
            this.chYape.Name = "chYape";
            this.chYape.Size = new System.Drawing.Size(55, 18);
            this.chYape.TabIndex = 453;
            this.chYape.Text = "Yape:";
            this.chYape.UseVisualStyleBackColor = true;
            this.chYape.CheckedChanged += new System.EventHandler(this.chYape_CheckedChanged);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Enabled = false;
            this.txtEfectivo.Location = new System.Drawing.Point(115, 78);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(79, 21);
            this.txtEfectivo.TabIndex = 452;
            this.txtEfectivo.Validated += new System.EventHandler(this.txtEfectivo_Validated);
            // 
            // chEfectivo
            // 
            this.chEfectivo.AutoSize = true;
            this.chEfectivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chEfectivo.Location = new System.Drawing.Point(39, 79);
            this.chEfectivo.Name = "chEfectivo";
            this.chEfectivo.Size = new System.Drawing.Size(70, 18);
            this.chEfectivo.TabIndex = 451;
            this.chEfectivo.Text = "Efectivo:";
            this.chEfectivo.UseVisualStyleBackColor = true;
            this.chEfectivo.CheckedChanged += new System.EventHandler(this.chEfectivo_CheckedChanged);
            // 
            // lblNroMesa
            // 
            this.lblNroMesa.AutoSize = true;
            this.lblNroMesa.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroMesa.Location = new System.Drawing.Point(115, 61);
            this.lblNroMesa.Name = "lblNroMesa";
            this.lblNroMesa.Size = new System.Drawing.Size(13, 14);
            this.lblNroMesa.TabIndex = 18;
            this.lblNroMesa.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(54, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "N° Mesa:";
            // 
            // lblAmbiente
            // 
            this.lblAmbiente.AutoSize = true;
            this.lblAmbiente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmbiente.Location = new System.Drawing.Point(115, 47);
            this.lblAmbiente.Name = "lblAmbiente";
            this.lblAmbiente.Size = new System.Drawing.Size(31, 14);
            this.lblAmbiente.TabIndex = 16;
            this.lblAmbiente.Text = "Sala";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ambiente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fecha y Ahora:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(115, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(13, 14);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "0";
            // 
            // imgProductosSel
            // 
            this.imgProductosSel.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgProductosSel.ImageSize = new System.Drawing.Size(16, 16);
            this.imgProductosSel.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 32);
            this.panel3.TabIndex = 456;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 19);
            this.label2.TabIndex = 449;
            this.label2.Text = "DATOS DE COMPROBANTE";
            // 
            // groupBox4
            // 
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
            this.groupBox4.Location = new System.Drawing.Point(12, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(660, 84);
            this.groupBox4.TabIndex = 457;
            this.groupBox4.TabStop = false;
            // 
            // cboMoneda
            // 
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(506, 20);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(135, 21);
            this.cboMoneda.TabIndex = 457;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(444, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 14);
            this.label14.TabIndex = 456;
            this.label14.Text = "Moneda:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(293, 47);
            this.txtNroDoc.MaxLength = 8;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(135, 21);
            this.txtNroDoc.TabIndex = 455;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(236, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 14);
            this.label12.TabIndex = 454;
            this.label12.Text = "N°. Doc.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(232, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 453;
            this.label10.Text = "Ser. Doc.:";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.CustomFormat = "dd/MM/yyyy";
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(72, 47);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(135, 21);
            this.dtpFecDoc.TabIndex = 452;
            this.dtpFecDoc.Value = new System.DateTime(2024, 1, 23, 17, 39, 40, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 451;
            this.label9.Text = "Tip. Doc.:";
            // 
            // cboTipDoc
            // 
            this.cboTipDoc.FormattingEnabled = true;
            this.cboTipDoc.Location = new System.Drawing.Point(72, 20);
            this.cboTipDoc.Name = "cboTipDoc";
            this.cboTipDoc.Size = new System.Drawing.Size(135, 21);
            this.cboTipDoc.TabIndex = 450;
            // 
            // txtSerDoc
            // 
            this.txtSerDoc.Location = new System.Drawing.Point(293, 20);
            this.txtSerDoc.MaxLength = 8;
            this.txtSerDoc.Name = "txtSerDoc";
            this.txtSerDoc.Size = new System.Drawing.Size(135, 21);
            this.txtSerDoc.TabIndex = 447;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 446;
            this.label7.Text = "Fec.:";
            // 
            // frmCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 559);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsPrincipal);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grabar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCobrar_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnCobrar;
        private System.Windows.Forms.ToolStripButton tsBtnTicket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtApeNom;
        internal System.Windows.Forms.TextBox txtDocId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListView lvProductosSeleccionados;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNroMesa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAmbiente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.CheckBox chEfectivo;
        private System.Windows.Forms.TextBox txtTransferencia;
        private System.Windows.Forms.CheckBox chTransferencia;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.CheckBox chTarjeta;
        private System.Windows.Forms.TextBox txtYape;
        private System.Windows.Forms.CheckBox chYape;
        private System.Windows.Forms.ImageList imgProductosSel;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.Label lblIdMesa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.TextBox txtSerDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipDoc;
        private System.Windows.Forms.DateTimePicker dtpFecDoc;
        internal System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIdNroComanda;
        private System.Windows.Forms.Label lblIdMozo;
        private System.Windows.Forms.Label lblIdAmbiente;
        private System.Windows.Forms.TextBox txtIdCliente;
    }
}