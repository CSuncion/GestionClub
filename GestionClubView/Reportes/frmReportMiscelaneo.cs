using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClubView.Reportes
{
    public partial class frmReportMiscelaneo : Form
    {
        public frmIngresarAnioMesAlmacenCrystal wFrm;
        public frmReportMiscelaneo()
        {
            InitializeComponent();
        }
        public void VentanaVisualizar()
        {
            this.Imprimir();
            this.Show();
        }
        public void Imprimir()
        {
            
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
