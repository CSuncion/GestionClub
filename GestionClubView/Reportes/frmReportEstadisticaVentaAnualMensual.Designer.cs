namespace GestionClubView.Reportes
{
    partial class frmReportEstadisticaVentaAnualMensual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportEstadisticaVentaAnualMensual));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.rvVentaAnualMensual = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalir});
            this.tsPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(800, 45);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 452;
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
            // rvVentaAnualMensual
            // 
            this.rvVentaAnualMensual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvVentaAnualMensual.LocalReport.ReportEmbeddedResource = "GestionClubView.Reportes.rptEstadisticaVentaAnualMensual.rdlc";
            this.rvVentaAnualMensual.Location = new System.Drawing.Point(0, 45);
            this.rvVentaAnualMensual.Name = "rvVentaAnualMensual";
            this.rvVentaAnualMensual.ServerReport.BearerToken = null;
            this.rvVentaAnualMensual.Size = new System.Drawing.Size(800, 405);
            this.rvVentaAnualMensual.TabIndex = 453;
            // 
            // frmReportEstadisticaVentaAnualMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvVentaAnualMensual);
            this.Controls.Add(this.tsPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportEstadisticaVentaAnualMensual";
            this.Text = "Venta Anual - Mensual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportEstadisticaVentaAnualMensual_FormClosing);
            this.Load += new System.EventHandler(this.frmReportEstadisticaVentaAnualMensual_Load);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private Microsoft.Reporting.WinForms.ReportViewer rvVentaAnualMensual;
    }
}