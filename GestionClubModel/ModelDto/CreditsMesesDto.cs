
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsMesesDto
    {
        public const string xIdMes = "Id_Mes";
        public const string xDesMes = "Des_Mes";
        public const string xCortoMes = "Corto_Mes";
        public int Id_Mes { get; set; }
        public string Des_Mes { get; set; }
        public string Corto_Mes { get; set; }
    }
}
