namespace GestionClubView.Listas
{
    partial class frmListaMorososSolicitante
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.gbBus = new System.Windows.Forms.GroupBox();
            this.txtBus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.gbBus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(205, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(154, 23);
            this.btnCancelar.TabIndex = 120;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(39, 402);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(159, 23);
            this.btnSeleccionar.TabIndex = 119;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // DgvLista
            // 
            this.DgvLista.BackgroundColor = System.Drawing.Color.White;
            this.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Location = new System.Drawing.Point(11, 60);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.Size = new System.Drawing.Size(386, 336);
            this.DgvLista.TabIndex = 118;
            // 
            // gbBus
            // 
            this.gbBus.Controls.Add(this.txtBus);
            this.gbBus.Location = new System.Drawing.Point(12, 12);
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
            this.txtBus.Size = new System.Drawing.Size(366, 20);
            this.txtBus.TabIndex = 0;
            // 
            // frmListaMorososSolicitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 477);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.DgvLista);
            this.Controls.Add(this.gbBus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmListaMorososSolicitante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Morosos o Solicitante";
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.gbBus.ResumeLayout(false);
            this.gbBus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.DataGridView DgvLista;
        internal System.Windows.Forms.GroupBox gbBus;
        internal System.Windows.Forms.TextBox txtBus;
    }
}