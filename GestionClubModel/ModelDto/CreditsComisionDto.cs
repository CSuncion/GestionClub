using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsComisionDto
    {
        public int id_Comision { get; set; }
        public int IdUniDscto { get; set; }
        public DateTime FechaComision { get; set; }
        public decimal ImporteComision { get; set; }
        public int TpComision { get; set; }
        public int FgComision { get; set; }

    }
}
