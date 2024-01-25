using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubAperturaCajaDto
    {
        public int idAperturaCaja { get; set; }
        public int idEmpresa { get; set; }
        public DateTime fecAperturaCaja { get; set; }
        public decimal montoAperturaCaja { get; set; }
        public int estadoAperturaCaja { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
