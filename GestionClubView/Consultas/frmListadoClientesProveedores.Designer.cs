namespace GestionClubView.Consultas
{
    partial class frmListadoClientesProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoClientesProveedores));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tsSecundario = new System.Windows.Forms.ToolStrip();
            this.tsbPrimero = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.sst1 = new System.Windows.Forms.StatusStrip();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipCliente = new System.Windows.Forms.ComboBox();
            this.txtNomRazSoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroIdentificacion = new System.Windows.Forms.TextBox();
            this.tsPrincipal.SuspendLayout();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.sst1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(800, 42);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 451;
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
            // tsSecundario
            // 
            this.tsSecundario.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSecundario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrimero,
            this.tsbAnterior,
            this.tsbSiguiente,
            this.tsbUltimo,
            this.tsbActualizarTabla,
            this.toolStripSeparator1});
            this.tsSecundario.Location = new System.Drawing.Point(0, 42);
            this.tsSecundario.Name = "tsSecundario";
            this.tsSecundario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSecundario.Size = new System.Drawing.Size(800, 25);
            this.tsSecundario.TabIndex = 452;
            this.tsSecundario.Text = "ToolStrip2";
            // 
            // tsbPrimero
            // 
            this.tsbPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimero.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrimero.Image")));
            this.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimero.Name = "tsbPrimero";
            this.tsbPrimero.Size = new System.Drawing.Size(23, 22);
            this.tsbPrimero.Click += new System.EventHandler(this.tsbPrimero_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnterior.Image")));
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(23, 22);
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("tsbSiguiente.Image")));
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(23, 22);
            this.tsbSiguiente.Click += new System.EventHandler(this.tsbSiguiente_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUltimo.Image")));
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(23, 22);
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // tsbActualizarTabla
            // 
            this.tsbActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarTabla.Image = ((System.Drawing.Image)(resources.GetObject("tsbActualizarTabla.Image")));
            this.tsbActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarTabla.Name = "tsbActualizarTabla";
            this.tsbActualizarTabla.Size = new System.Drawing.Size(23, 22);
            this.tsbActualizarTabla.Text = "Actualiza Grilla";
            this.tsbActualizarTabla.Click += new System.EventHandler(this.tsbActualizarTabla_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // DgvClientes
            // 
            this.DgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.DgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.GridColor = System.Drawing.Color.Silver;
            this.DgvClientes.Location = new System.Drawing.Point(12, 161);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.Size = new System.Drawing.Size(776, 264);
            this.DgvClientes.TabIndex = 453;
            // 
            // sst1
            // 
            this.sst1.BackColor = System.Drawing.SystemColors.Control;
            this.sst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado});
            this.sst1.Location = new System.Drawing.Point(0, 428);
            this.sst1.Name = "sst1";
            this.sst1.Size = new System.Drawing.Size(800, 22);
            this.sst1.TabIndex = 454;
            this.sst1.Text = "statusStrip1";
            // 
            // tssEstado
            // 
            this.tssEstado.BackColor = System.Drawing.SystemColors.Control;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(10, 17);
            this.tssEstado.Text = ".";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNroIdentificacion);
            this.groupBox1.Controls.Add(this.txtNomRazSoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboTipCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 58);
            this.groupBox1.TabIndex = 455;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Khaki;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 449;
            this.label3.Text = "FILTRO";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(175)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 453;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "T. Cliente:";
            // 
            // cboTipCliente
            // 
            this.cboTipCliente.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipCliente.FormattingEnabled = true;
            this.cboTipCliente.Location = new System.Drawing.Point(12, 28);
            this.cboTipCliente.Name = "cboTipCliente";
            this.cboTipCliente.Size = new System.Drawing.Size(161, 22);
            this.cboTipCliente.TabIndex = 6;
            this.cboTipCliente.SelectionChangeCommitted += new System.EventHandler(this.cboTipCliente_SelectionChangeCommitted);
            // 
            // txtNomRazSoc
            // 
            this.txtNomRazSoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomRazSoc.Location = new System.Drawing.Point(346, 28);
            this.txtNomRazSoc.Name = "txtNomRazSoc";
            this.txtNomRazSoc.Size = new System.Drawing.Size(393, 22);
            this.txtNomRazSoc.TabIndex = 9;
            this.txtNomRazSoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomRazSoc_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(343, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre/Raz. Social:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "N° de Identificación:";
            // 
            // txtNroIdentificacion
            // 
            this.txtNroIdentificacion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroIdentificacion.Location = new System.Drawing.Point(179, 28);
            this.txtNroIdentificacion.Name = "txtNroIdentificacion";
            this.txtNroIdentificacion.Size = new System.Drawing.Size(161, 22);
            this.txtNroIdentificacion.TabIndex = 10;
            this.txtNroIdentificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNroIdentificacion_KeyUp);
            // 
            // frmListadoClientesProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvClientes);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsSecundario);
            this.Controls.Add(this.tsPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListadoClientesProveedores";
            this.Text = "Listado Clientes / Proveedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListadoClientesProveedores_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        internal System.Windows.Forms.ToolStrip tsSecundario;
        internal System.Windows.Forms.ToolStripButton tsbPrimero;
        internal System.Windows.Forms.ToolStripButton tsbAnterior;
        internal System.Windows.Forms.ToolStripButton tsbSiguiente;
        internal System.Windows.Forms.ToolStripButton tsbUltimo;
        internal System.Windows.Forms.ToolStripButton tsbActualizarTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView DgvClientes;
        internal System.Windows.Forms.StatusStrip sst1;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipCliente;
        private System.Windows.Forms.TextBox txtNomRazSoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroIdentificacion;
    }
}