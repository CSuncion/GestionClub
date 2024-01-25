using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubCategoriaDto
    {
        public int idCategoria { get; set; }
        public int idEmpresa { get; set; }
        public string codCategoria { get; set; }
        public string desCategoria { get; set; }
        public int estadoCategoria { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
