using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubMesaDto
    {
        public int idMesa { get; set; }
        public int idEmpresa { get; set; }
        public string codMesa { get; set; } 
        public string desMesa {  get; set; }
        public int idAmbiente { get; set; } 
        public int estadoMesa { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
