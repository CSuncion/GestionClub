namespace GestionClubView.Maestros
{
    partial class frmEditarTablaSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarTablaSistema));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNroSistema = new System.Windows.Forms.TextBox();
            this.txtIdTablaDetalle = new System.Windows.Forms.TextBox();
            this.txtTabla = new System.Windows.Forms.TextBox();
            this.txtAbrevia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdTabla = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tsPrincipal.Size = new System.Drawing.Size(354, 42);
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
            this.panel1.Size = new System.Drawing.Size(354, 30);
            this.panel1.TabIndex = 452;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Khaki;
            this.label3.Location = new System.Drawing.Point(97, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 23);
            this.label3.TabIndex = 449;
            this.label3.Text = "DATOS DE DETALLE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNroSistema);
            this.groupBox1.Controls.Add(this.txtIdTablaDetalle);
            this.groupBox1.Controls.Add(this.txtTabla);
            this.groupBox1.Controls.Add(this.txtAbrevia);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIdTabla);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 165);
            this.groupBox1.TabIndex = 453;
            this.groupBox1.TabStop = false;
            // 
            // txtNroSistema
            // 
            this.txtNroSistema.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroSistema.Location = new System.Drawing.Point(300, 23);
            this.txtNroSistema.Name = "txtNroSistema";
            this.txtNroSistema.ReadOnly = true;
            this.txtNroSistema.Size = new System.Drawing.Size(18, 22);
            this.txtNroSistema.TabIndex = 223;
            this.txtNroSistema.Visible = false;
            // 
            // txtIdTablaDetalle
            // 
            this.txtIdTablaDetalle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTablaDetalle.Location = new System.Drawing.Point(279, 51);
            this.txtIdTablaDetalle.Name = "txtIdTablaDetalle";
            this.txtIdTablaDetalle.ReadOnly = true;
            this.txtIdTablaDetalle.Size = new System.Drawing.Size(18, 22);
            this.txtIdTablaDetalle.TabIndex = 222;
            this.txtIdTablaDetalle.Visible = false;
            // 
            // txtTabla
            // 
            this.txtTabla.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTabla.Location = new System.Drawing.Point(112, 20);
            this.txtTabla.Name = "txtTabla";
            this.txtTabla.ReadOnly = true;
            this.txtTabla.Size = new System.Drawing.Size(161, 22);
            this.txtTabla.TabIndex = 221;
            // 
            // txtAbrevia
            // 
            this.txtAbrevia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbrevia.Location = new System.Drawing.Point(112, 104);
            this.txtAbrevia.Name = "txtAbrevia";
            this.txtAbrevia.Size = new System.Drawing.Size(161, 22);
            this.txtAbrevia.TabIndex = 220;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 219;
            this.label6.Text = "Abrevia:";
            // 
            // txtIdTabla
            // 
            this.txtIdTabla.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTabla.Location = new System.Drawing.Point(279, 23);
            this.txtIdTabla.Name = "txtIdTabla";
            this.txtIdTabla.ReadOnly = true;
            this.txtIdTabla.Size = new System.Drawing.Size(18, 22);
            this.txtIdTabla.TabIndex = 218;
            this.txtIdTabla.Visible = false;
            // 
            // cboEstado
            // 
            this.cboEstado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(112, 132);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(161, 22);
            this.cboEstado.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(112, 48);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(161, 22);
            this.txtCodigo.TabIndex = 217;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(112, 76);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(161, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 216;
            this.label5.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla:";
            // 
            // frmEditarTablaSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(354, 251);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "frmEditarTablaSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Detalle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditarMesas_FormClosing);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdTabla;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAbrevia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTabla;
        private System.Windows.Forms.TextBox txtIdTablaDetalle;
        private System.Windows.Forms.TextBox txtNroSistema;
    }
}