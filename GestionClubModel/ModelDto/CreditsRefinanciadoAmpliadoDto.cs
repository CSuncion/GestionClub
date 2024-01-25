using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsRefinanciadoAmpliadoDto
    {

        public const string xIdRefinanciadoAmpliado = "IdRefinanciadoAmpliado";
        public const string xIdOperacion = "IdOperacion";
        public const string xEstado = "Estado";
        public const string xDesEstado = "DesEstado";
        public const string xUsuarioAgrega = "UsuarioAgrega";
        public const string xFechaAgrega = "FechaAgrega";
        public const string xUsuarioModifica = "UsuarioModifica";
        public const string xFechaModifica = "FechaModifica";

        public int IdRefinanciadoAmpliado { get; set; }
        public int IdOperacion { get; set; }
        public int Estado { get; set; }
        public string DesEstado { get; set; }
        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int UsuarioModifica { get; set; }
        public DateTime FechaModifica { get; set; }


    }
}
