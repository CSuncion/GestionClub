using GestionClubModel.ModelDto;
using GestionClubView.Maestros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace GestionClubView.Consultas
{
    public partial class frmListadoDeComprobante : Form
    {
        public frmEditarCierreCaja wFrm;
        public Universal.Opera eOperacion;
        public Dgv.Franja eFranjaDgvCierreCaja = Dgv.Franja.PorIndice;
        public frmListadoDeComprobante()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
            this.tstBuscar.Focus();
        }

    }
}
