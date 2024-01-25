using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace GestionClubUtil.Util
{
    public class UtilGestionClub
    {
        public string Encripta(string wTexto)
        {
            string str = "";
            byte num1 = checked((byte)Strings.Len(Strings.Trim(wTexto)));
            byte num2 = 1;
            while ((uint)num2 <= (uint)num1)
            {
                str += Conversions.ToString(Strings.Chr(checked(Strings.Asc(Strings.Mid(wTexto, (int)num2, 1)) + (int)num2 * 2)));
                checked { ++num2; }
            }
            return str;
        }
    }
}
