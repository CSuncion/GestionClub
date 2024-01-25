using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsEnvioDirrehumDto
    {
        public int IdEnvio { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Codofin { get; set; }
        public string Cod { get; set; }
        public string Importe12 { get; set; }
        public string Importe24 { get; set; }
    }
}
