using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubCierreCajaDto
    {
        public int idCierreCaja { get; set; }
        public int idEmpresa { get; set; }
        public DateTime fecCierreCaja { get; set; }
        public decimal montoCierreCaja { get; set; }
        public int estadoCierreCaja { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
