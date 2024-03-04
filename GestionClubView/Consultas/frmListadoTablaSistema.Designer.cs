namespace GestionClubView.Maestros
{
    partial class frmListadoTablaSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoTablaSistema));
            this.DgvSistema = new System.Windows.Forms.DataGridView();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.DgvSistemaDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSistema)).BeginInit();
            this.tsPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSistemaDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSistema
            // 
            this.DgvSistema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSistema.BackgroundColor = System.Drawing.Color.White;
            this.DgvSistema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSistema.GridColor = System.Drawing.Color.Silver;
            this.DgvSistema.Location = new System.Drawing.Point(12, 40);
            this.DgvSistema.Name = "DgvSistema";
            this.DgvSistema.Size = new System.Drawing.Size(776, 190);
            this.DgvSistema.TabIndex = 114;
            this.DgvSistema.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSistema_CellEnter);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(800, 37);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 115;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 34);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // DgvSistemaDetalle
            // 
            this.DgvSistemaDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSistemaDetalle.BackgroundColor = System.Drawing.Color.White;
            this.DgvSistemaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvSistemaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSistemaDetalle.GridColor = System.Drawing.Color.Silver;
            this.DgvSistemaDetalle.Location = new System.Drawing.Point(12, 236);
            this.DgvSistemaDetalle.Name = "DgvSistemaDetalle";
            this.DgvSistemaDetalle.Size = new System.Drawing.Size(776, 190);
            this.DgvSistemaDetalle.TabIndex = 116;
            this.DgvSistemaDetalle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvSistemaDetalle_CellMouseDoubleClick);
            // 
            // frmListadoTablaSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.DgvSistemaDetalle);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.DgvSistema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListadoTablaSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTablaSistema_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSistema)).EndInit();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSistemaDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        internal System.Windows.Forms.DataGridView DgvSistema;
        internal System.Windows.Forms.DataGridView DgvSistemaDetalle;
    }
}