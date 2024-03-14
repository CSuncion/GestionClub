using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
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
    public partial class frmCambiarAprobacionClave : Form
    {
        public frmCambiarAprobacionClave()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Show();
        }
        public void CambiarClaveAprobador()
        {
            GestionClubAccessDto access = new GestionClubAccessDto();
            access.dniAcceso = this.txtDocId.Text.Trim();
            access.ClaveAprobador = UtilGestionClub.Encripta(this.txtClave.Text);
            GestionClubAccessController.ActualizarClaveAprobador(access);
            Mensaje.OperacionSatisfactoria("Se cambio la clave correctamente.", "Cambiar Clave");
            this.Close();
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmCambiarClave, null);
        }
        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            this.CambiarClaveAprobador();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCambiarAprobacionClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
