using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace GestionClubUtil.Util
{
    public class UtilGrilla
    {
        public static void PintarFilaDeGrillaAlternar(DataGridView dgv)
        {
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }
    }
}
