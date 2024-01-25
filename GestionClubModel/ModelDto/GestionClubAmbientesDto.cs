using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubAmbientesDto
    {

        public const string _idAmbiente = "idAmbiente";
        public const string _idEmpresa = "idEmpresa";
        public const string _codAmbiente = "codAmbiente";
        public const string _desAmbiente = "desAmbiente";
        public const string _estadoAmbiente = "estadoAmbiente";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public int idAmbiente { get; set; }
        public int idEmpresa { get; set; }
        public string codAmbiente { get; set; }
        public string desAmbiente { get; set; }
        public int estadoAmbiente { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }

    }
}
