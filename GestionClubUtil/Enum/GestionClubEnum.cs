using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubUtil.Enum
{
    public class GestionClubEnum
    {
        public enum Bd
        {
            DbFbpol = 0
        }
        public enum UndDscto
        {
            DirrehumHaberes = 1,
            CajaPensionesCPMP = 2,
            DirrehumCombustible = 3,
            Fonbiepol = 8,
        }
        public static class Sistema
        {
            public static string Estado = "11";
            public static string Moneda = "08";
            public static string UndMedida = "12";
            public static string TipoSocio = "14";
            public static string TipoCliente = "09";
            public static string DocFac = "01";
            public static string Caja = "17";
            public static string PrimerNivel = "18";
            public static string SegundoNivel = "19";
            public static string Mes = "20";
        }
    }
}
