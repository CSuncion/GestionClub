using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubUtil.Util
{
    public class UtilFechas
    {
        public List<string> Mes()
        {
            List<string> list = new List<string>();
            string[] arrayMes = {
                                "Enero" ,
                                "Febrero" ,
                                "Marzo" ,
                                "Abril",
                                "Mayo",
                                "Junio",
                                "Julio",
                                "Agosto",
                                "Septiembre",
                                "Octubre",
                                "Noviembre",
                                "Diciembre"
            };
            foreach (string mes in arrayMes)
            {
                list.Add(mes);
            }
            return list;
        }
    }
}
