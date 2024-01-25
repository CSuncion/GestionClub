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
    public class CreditsCorrelativoConstanciaNoAdeudoController
    {
        private readonly ICreditsCorrelativoConstanciaNoAdeudoRepository _iCreditsCorrelativoConstanciaNoAdeudoRepository;
        public CreditsCorrelativoConstanciaNoAdeudoController()
        {
            this._iCreditsCorrelativoConstanciaNoAdeudoRepository = new CreditsCorrelativoConstanciaNoAdeudoRepository();
        }
        public string CrearRefinanciadoAmpliado(CreditsCorrelativoConstanciaNoAdeudoDto pObj)
        {
            return this._iCreditsCorrelativoConstanciaNoAdeudoRepository.CrearCorrelativoConstanciaNoAdeudo(pObj);
        }
    }
}
