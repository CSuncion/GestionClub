namespace GestionClubView.Maestros
{
    partial class frmEditarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProductos));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtOtrImp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtImpDol = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPorDtra = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkAfeDtraNo = new System.Windows.Forms.CheckBox();
            this.chkAfeDtraSi = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkAfeIgvNo = new System.Windows.Forms.CheckBox();
            this.chkAfeIgvSi = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecioSocio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecioNoSocio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUniMed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGrabar,
            this.tsBtnSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(651, 42);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 450;
            // 
            // tsBtnGrabar
            // 
            this.tsBtnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBtnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGrabar.Image")));
            this.tsBtnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGrabar.Name = "tsBtnGrabar";
            this.tsBtnGrabar.Size = new System.Drawing.Size(48, 39);
            this.tsBtnGrabar.Text = "Grabar";
            this.tsBtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnGrabar.Click += new System.EventHandler(this.tsBtnGrabar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(36, 39);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 30);
            this.panel1.TabIndex = 452;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Khaki;
            this.label3.Location = new System.Drawing.Point(233, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 23);
            this.label3.TabIndex = 449;
            this.label3.Text = "DATOS DE PRODUCTOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtArchivo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtOtrImp);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtImpDol);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPorDtra);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.chkAfeDtraNo);
            this.groupBox1.Controls.Add(this.chkAfeDtraSi);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.chkAfeIgvNo);
            this.groupBox1.Controls.Add(this.chkAfeIgvSi);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPrecioSocio);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPrecioNoSocio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboMoneda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboUniMed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 274);
            this.groupBox1.TabIndex = 453;
            this.groupBox1.TabStop = false;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivo.Location = new System.Drawing.Point(416, 209);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(161, 22);
            this.txtArchivo.TabIndex = 222;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(361, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 221;
            this.label9.Text = "Archivo:";
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(127, 209);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(161, 22);
            this.txtStock.TabIndex = 220;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(83, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 219;
            this.label8.Text = "Stock:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 14);
            this.label7.TabIndex = 218;
            this.label7.Text = "Categoria:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(416, 18);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(161, 22);
            this.cboCategoria.TabIndex = 217;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(294, 18);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(18, 22);
            this.txtId.TabIndex = 216;
            this.txtId.Visible = false;
            // 
            // txtOtrImp
            // 
            this.txtOtrImp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtrImp.Location = new System.Drawing.Point(416, 181);
            this.txtOtrImp.Name = "txtOtrImp";
            this.txtOtrImp.Size = new System.Drawing.Size(161, 22);
            this.txtOtrImp.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(344, 184);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 14);
            this.label17.TabIndex = 32;
            this.label17.Text = "Otros Imp.:";
            // 
            // txtImpDol
            // 
            this.txtImpDol.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpDol.Location = new System.Drawing.Point(127, 181);
            this.txtImpDol.Name = "txtImpDol";
            this.txtImpDol.Size = new System.Drawing.Size(161, 22);
            this.txtImpDol.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(78, 184);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 14);
            this.label16.TabIndex = 30;
            this.label16.Text = "Imp. $:";
            // 
            // txtPorDtra
            // 
            this.txtPorDtra.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorDtra.Location = new System.Drawing.Point(416, 153);
            this.txtPorDtra.Name = "txtPorDtra";
            this.txtPorDtra.Size = new System.Drawing.Size(80, 22);
            this.txtPorDtra.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(358, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "% Detra:";
            // 
            // chkAfeDtraNo
            // 
            this.chkAfeDtraNo.AutoSize = true;
            this.chkAfeDtraNo.Location = new System.Drawing.Point(167, 158);
            this.chkAfeDtraNo.Name = "chkAfeDtraNo";
            this.chkAfeDtraNo.Size = new System.Drawing.Size(40, 17);
            this.chkAfeDtraNo.TabIndex = 27;
            this.chkAfeDtraNo.Text = "NO";
            this.chkAfeDtraNo.UseVisualStyleBackColor = true;
            this.chkAfeDtraNo.CheckedChanged += new System.EventHandler(this.chkAfeDtraNo_CheckedChanged);
            // 
            // chkAfeDtraSi
            // 
            this.chkAfeDtraSi.AutoSize = true;
            this.chkAfeDtraSi.Location = new System.Drawing.Point(127, 158);
            this.chkAfeDtraSi.Name = "chkAfeDtraSi";
            this.chkAfeDtraSi.Size = new System.Drawing.Size(34, 17);
            this.chkAfeDtraSi.TabIndex = 26;
            this.chkAfeDtraSi.Text = "SI";
            this.chkAfeDtraSi.UseVisualStyleBackColor = true;
            this.chkAfeDtraSi.CheckedChanged += new System.EventHandler(this.chkAfeDtraSi_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 14);
            this.label14.TabIndex = 25;
            this.label14.Text = "Afecto Detra IGV:";
            // 
            // chkAfeIgvNo
            // 
            this.chkAfeIgvNo.AutoSize = true;
            this.chkAfeIgvNo.Location = new System.Drawing.Point(456, 130);
            this.chkAfeIgvNo.Name = "chkAfeIgvNo";
            this.chkAfeIgvNo.Size = new System.Drawing.Size(40, 17);
            this.chkAfeIgvNo.TabIndex = 24;
            this.chkAfeIgvNo.Text = "NO";
            this.chkAfeIgvNo.UseVisualStyleBackColor = true;
            this.chkAfeIgvNo.CheckedChanged += new System.EventHandler(this.chkAfeIgvNo_CheckedChanged);
            // 
            // chkAfeIgvSi
            // 
            this.chkAfeIgvSi.AutoSize = true;
            this.chkAfeIgvSi.Location = new System.Drawing.Point(416, 130);
            this.chkAfeIgvSi.Name = "chkAfeIgvSi";
            this.chkAfeIgvSi.Size = new System.Drawing.Size(34, 17);
            this.chkAfeIgvSi.TabIndex = 23;
            this.chkAfeIgvSi.Text = "SI";
            this.chkAfeIgvSi.UseVisualStyleBackColor = true;
            this.chkAfeIgvSi.CheckedChanged += new System.EventHandler(this.chkAfeIgvSi_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(344, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 14);
            this.label13.TabIndex = 22;
            this.label13.Text = "Afecto IGV:";
            // 
            // txtPrecioSocio
            // 
            this.txtPrecioSocio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioSocio.Location = new System.Drawing.Point(416, 102);
            this.txtPrecioSocio.Name = "txtPrecioSocio";
            this.txtPrecioSocio.Size = new System.Drawing.Size(161, 22);
            this.txtPrecioSocio.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(335, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "Precio Socio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(40, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 14);
            this.label11.TabIndex = 19;
            this.label11.Text = "Cod. Moneda:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(127, 18);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(161, 22);
            this.txtCodigo.TabIndex = 18;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(127, 237);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(161, 22);
            this.cboEstado.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(74, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Estado:";
            // 
            // txtPrecioNoSocio
            // 
            this.txtPrecioNoSocio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioNoSocio.Location = new System.Drawing.Point(127, 130);
            this.txtPrecioNoSocio.Name = "txtPrecioNoSocio";
            this.txtPrecioNoSocio.Size = new System.Drawing.Size(161, 22);
            this.txtPrecioNoSocio.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Precio No Socio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(127, 102);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(161, 22);
            this.txtPrecio.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(127, 74);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(161, 22);
            this.cboMoneda.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(127, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(450, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Un. Medida:";
            // 
            // cboUniMed
            // 
            this.cboUniMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUniMed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUniMed.FormattingEnabled = true;
            this.cboUniMed.Location = new System.Drawing.Point(416, 74);
            this.cboUniMed.Name = "cboUniMed";
            this.cboUniMed.Size = new System.Drawing.Size(161, 22);
            this.cboUniMed.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod. Producto:";
            // 
            // frmEditarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(651, 367);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "frmEditarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditarProductos_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnGrabar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboUniMed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecioNoSocio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecioSocio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.TextBox txtPorDtra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkAfeDtraNo;
        private System.Windows.Forms.CheckBox chkAfeDtraSi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkAfeIgvNo;
        private System.Windows.Forms.CheckBox chkAfeIgvSi;
        private System.Windows.Forms.TextBox txtOtrImp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtImpDol;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label9;
    }
}