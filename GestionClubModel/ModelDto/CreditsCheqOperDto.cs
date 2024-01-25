using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public  class CreditsCheqOperDto
    {
        public const string xIdChequeOperac = "Id_Cheque_Operac";
        public const string xDeCheqOperac = "De_CheqOperac";
        public int Id_Cheque_Operac { get; set; }
        public string De_CheqOperac { get; set; }

    }
}
