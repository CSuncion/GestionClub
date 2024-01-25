using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubEmpresaDto
    {
        public int idEmpresa { get; set; }
        public string codEmpresa { get; set; }
        public int codSucursalEmpresa { get; set; }
        public string desEmpresa { get; set; }
        public string rucEmpresa { get; set; }
        public string direccionEmpresa { get; set; }
        public string tlfFijoEmpresa { get; set; }
        public string tlfCelularEmpresa { get; set; }
        public int estadoEmpresa { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
