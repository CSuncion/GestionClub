using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsCorrelativoConstanciaNoAdeudoDto
    {
        public const string xIdCorrelativoConstanciaNoAdeudo = "IdCorrelativoConstanciaNoAdeudo";
        public const string xPeriodo = "Periodo";
        public const string xCorrelativo = "Correlativo";
        public const string xFechaCorrelativo = "FechaCorrelativo";
        public const string xDniSolicitante = "DniSolicitante";
        public const string xUsuarioAgrega = "UsuarioAgrega";
        public const string xFechaAgrega = "FechaAgrega";
        public const string xUsuarioModifica = "UsuarioModifica";
        public const string xFechaModifica = "FechaModifica";

        public int IdCorrelativoConstanciaNoAdeudo { get; set; }
        public string Periodo { get; set; }
        public string Correlativo { get; set; }
        public DateTime FechaCorrelativo { get; set; }
        public string DniSolicitante { get; set; }
        public int UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public int UsuarioModifica { get; set; }
        public DateTime FechaModifica { get; set; }

    }
}
