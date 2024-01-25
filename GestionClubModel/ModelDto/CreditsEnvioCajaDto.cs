using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsEnvioCajaDto
    {
        public int IdEnvio { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Cod { get; set; }
        public string Cip { get; set; }
        public string Ben { get; set; }
        public string Le { get; set; }
        public string Dni { get; set; }
        public string AnioMes { get; set; }
        public string Importe { get; set; }
    }
}
