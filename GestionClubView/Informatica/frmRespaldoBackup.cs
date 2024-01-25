using GestionClubController.Controller;
using GestionClubView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;

namespace GestionClubView.Informatica
{
    public partial class frmRespaldoBackup : Form
    {
        public frmPrincipal win;
        GestionClubGeneralController oGenCtrll = new GestionClubGeneralController();
        public frmRespaldoBackup()
        {
            InitializeComponent();
        }

        public void abrirVentana()
        {
            this.Show();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmRespaldoBackup, null);
        }


        private void btnRespaldo_Click(object sender, EventArgs e)
        {
            this.btnRespaldo.Enabled = false;
            this.oGenCtrll.CrearBackupDbFbPol();
            Mensaje.OperacionSatisfactoria("Se genero satisfactoriamente el backup.", this.Text);
            this.btnRespaldo.Enabled = true;
        }

        private void frmRespaldoBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
