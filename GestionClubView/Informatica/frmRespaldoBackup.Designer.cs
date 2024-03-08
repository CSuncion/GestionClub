namespace GestionClubView.Informatica
{
    partial class frmRespaldoBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespaldoBackup));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.btnRespaldo = new System.Windows.Forms.Button();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(406, 38);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 447;
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(33, 35);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // btnRespaldo
            // 
            this.btnRespaldo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRespaldo.Image = ((System.Drawing.Image)(resources.GetObject("btnRespaldo.Image")));
            this.btnRespaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRespaldo.Location = new System.Drawing.Point(101, 28);
            this.btnRespaldo.Name = "btnRespaldo";
            this.btnRespaldo.Size = new System.Drawing.Size(215, 51);
            this.btnRespaldo.TabIndex = 448;
            this.btnRespaldo.Text = "Respaldar COSFUP";
            this.btnRespaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRespaldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRespaldo.UseVisualStyleBackColor = true;
            this.btnRespaldo.Click += new System.EventHandler(this.btnRespaldo_Click);
            // 
            // frmRespaldoBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 91);
            this.Controls.Add(this.btnRespaldo);
            this.Controls.Add(this.tsPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRespaldoBackup";
            this.Text = "Respaldo Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRespaldoBackup_FormClosing);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.Button btnRespaldo;
        private System.Windows.Forms.ToolStripButton tsbSalir;
    }
}