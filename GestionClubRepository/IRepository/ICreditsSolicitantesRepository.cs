using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsSolicitantesRepository
    {
        CreditsSolicitantesDto ListarSolicitantesPorDni(CreditsSolicitantesDto pObj);
    }
}
