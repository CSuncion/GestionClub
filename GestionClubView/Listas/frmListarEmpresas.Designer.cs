namespace GestionClubView.Listas
{
    partial class frmListarEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarEmpresas));
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.gbBus = new System.Windows.Forms.GroupBox();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.gbBus.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvLista
            // 
            this.DgvLista.BackgroundColor = System.Drawing.Color.White;
            this.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Location = new System.Drawing.Point(9, 93);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.Size = new System.Drawing.Size(386, 343);
            this.DgvLista.TabIndex = 118;
            this.DgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellDoubleClick);
            this.DgvLista.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvLista_ColumnHeaderMouseClick);
            // 
            // gbBus
            // 
            this.gbBus.Controls.Add(this.txtBus);
            this.gbBus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBus.Location = new System.Drawing.Point(10, 45);
            this.gbBus.Name = "gbBus";
            this.gbBus.Size = new System.Drawing.Size(386, 42);
            this.gbBus.TabIndex = 117;
            this.gbBus.TabStop = false;
            this.gbBus.Text = "GroupBox1";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(14, 16);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(366, 22);
            this.txtBus.TabIndex = 0;
            this.txtBus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBus_KeyPress);
            this.txtBus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBus_KeyUp);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSeleccionar,
            this.tsBtnSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(408, 42);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 451;
            // 
            // tsBtnSeleccionar
            // 
            this.tsBtnSeleccionar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionar.Image")));
            this.tsBtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionar.Name = "tsBtnSeleccionar";
            this.tsBtnSeleccionar.Size = new System.Drawing.Size(74, 39);
            this.tsBtnSeleccionar.Text = "Seleccionar";
            this.tsBtnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnSeleccionar.Click += new System.EventHandler(this.tsBtnSeleccionar_Click);
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
            // frmListarEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 448);
            this.ControlBox = false;
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.DgvLista);
            this.Controls.Add(this.gbBus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmListarEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Empresas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListarEmpresas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.gbBus.ResumeLayout(false);
            this.gbBus.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.DataGridView DgvLista;
        internal System.Windows.Forms.GroupBox gbBus;
        internal System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
    }
}