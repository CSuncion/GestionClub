namespace GestionClubView.Maestros
{
    partial class frmParametro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametro));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.sst1 = new System.Windows.Forms.StatusStrip();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.DgvParametros = new System.Windows.Forms.DataGridView();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.tsPrincipal.SuspendLayout();
            this.sst1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEditar,
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(800, 46);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 111;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // sst1
            // 
            this.sst1.BackColor = System.Drawing.SystemColors.Control;
            this.sst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado});
            this.sst1.Location = new System.Drawing.Point(0, 428);
            this.sst1.Name = "sst1";
            this.sst1.Size = new System.Drawing.Size(800, 22);
            this.sst1.TabIndex = 113;
            this.sst1.Text = "statusStrip1";
            // 
            // tssEstado
            // 
            this.tssEstado.BackColor = System.Drawing.SystemColors.Control;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(10, 17);
            this.tssEstado.Text = ".";
            // 
            // DgvParametros
            // 
            this.DgvParametros.BackgroundColor = System.Drawing.Color.White;
            this.DgvParametros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvParametros.GridColor = System.Drawing.Color.Silver;
            this.DgvParametros.Location = new System.Drawing.Point(0, 46);
            this.DgvParametros.Name = "DgvParametros";
            this.DgvParametros.Size = new System.Drawing.Size(800, 382);
            this.DgvParametros.TabIndex = 114;
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(43, 43);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 43);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // frmParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DgvParametros);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmParametro";
            this.Text = "Parametro de Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParametro_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvParametros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        internal System.Windows.Forms.StatusStrip sst1;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        private System.Windows.Forms.DataGridView DgvParametros;
        private System.Windows.Forms.ToolStripButton tsbEditar;
    }
}