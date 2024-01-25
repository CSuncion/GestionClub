using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using CreditsRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsController.Controller
{
    public class CreditsSolicitanteController
    {
        private readonly ICreditsSolicitantesRepository _iCreditsSolicitanteRepository;
        public CreditsSolicitanteController()
        {
            this._iCreditsSolicitanteRepository = new CreditsSolicitantesRepository();
        }
        public CreditsSolicitantesDto ListarSolicitantesPorDni(CreditsSolicitantesDto pObj)
        {
            ICreditsSolicitantesRepository iDeclaracionesSolicitanteRepository = new CreditsSolicitantesRepository();
            return iDeclaracionesSolicitanteRepository.ListarSolicitantesPorDni(pObj);
        }
    }
}
