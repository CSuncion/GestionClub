using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsProcesoEnvioDto
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int User { get; set; }
        public int UnidDscto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
