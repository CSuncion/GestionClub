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
    public class CreditsRetornoDirrehumController
    {
        private readonly ICreditsRetornoDirrehumRepository _iCreditsRetornoDirrehumRepository;
        public CreditsRetornoDirrehumController()
        {
            this._iCreditsRetornoDirrehumRepository = new CreditsRetornoDirrehumRepository();
        }
        public void BuscarProcesoRetornoDirrehum(List<CreditsRetornoDirrehumDto> pObj)
        {
            foreach (CreditsRetornoDirrehumDto obj in pObj)
            {
                this._iCreditsRetornoDirrehumRepository.BuscarProcesoRetornoDirrehum(obj);
            }            
        }
        public List<CreditsRetornoDirrehumDto> SelRetDirrehumAnioMesTrabajado(CreditsRetornoDirrehumDto creditsRetornoDirrehumDto)
        {
            return this._iCreditsRetornoDirrehumRepository.SelRetDirrehumAnioMesTrabajado(creditsRetornoDirrehumDto);
        }
    }
}
