using Comun;
using GestionClubController.Controller;
using GestionClubModel.ModelDto;
using GestionClubUtil.Util;
using GestionClubView.MdiPrincipal;
using GestionClubView.Venta;
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
    public partial class frmAprobacionClave : Form
    {
        GestionClubAccessController oAccess = new GestionClubAccessController();
        UtilGestionClub utilGestionClub = new UtilGestionClub();
        public frmPrincipal wfrm;
        public frmComprobantes wCom;
        public string Accion = string.Empty;
        public frmAprobacionClave()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Show();
            if (this.Accion == "Anticipo")
            {
                this.wCom.Enabled = false;
            }
            else if (this.Accion == "Regularizacion")
            {
                this.wCom.Enabled = false;
            }
        }
        public void AceptarAprobacion()
        {
            List<GestionClubAccessDto> oListAccess = new List<GestionClubAccessDto>();
            oListAccess = oAccess.ListarUsuarioMozos().Where(x => x.levelAcceso == 4).ToList();

            if (oListAccess.Count == 0)
            {
                Mensaje.OperacionDenegada("No existe aprobadores", "Aprobar Proceso");
                return;
            }

            foreach (GestionClubAccessDto item in oListAccess)
            {
                if (item.ClaveAprobador.Trim() == UtilGestionClub.Encripta(this.txtClave.Text.Trim()))
                {
                    if (this.Accion == "NotaCredito")
                    {
                        this.wfrm.InstanciarNotaDeCredito();
                        this.Close();
                        return;
                    }
                    else if (this.Accion == "Anticipo")
                    {
                        this.wCom.AccionAdicionarAnticipo();
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.wCom.AccionAdicionarRegularizarAnticipo();
                        this.Close();
                        return;
                    }
                }
            }
            Mensaje.OperacionDenegada("No ha ingresado correctamente la clave.", "Aprobar Proceso");
            return;
        }
        public void Cerrar()
        {
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmNotaCredito, null);
        }
        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            this.AceptarAprobacion();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            if (this.Accion == "NotaCredito")
            {
                this.Close();
            }
            else if (this.Accion == "Anticipo")
            {
                this.Close();
                this.wCom.Enabled = true;
            }
            else
            {
                this.Close();
                this.wCom.Enabled = true;
            }
        }

        private void frmAprobacionClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Accion == "NotaCredito")
            {
                this.Cerrar();
            }
        }
    }
}
