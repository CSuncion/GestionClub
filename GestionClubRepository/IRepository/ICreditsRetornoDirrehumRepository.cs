using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsRetornoDirrehumRepository
    {
        void BuscarProcesoRetornoDirrehum(CreditsRetornoDirrehumDto pObj);
        List<CreditsRetornoDirrehumDto> SelRetDirrehumAnioMesTrabajado(CreditsRetornoDirrehumDto creditsRetornoDirrehumDto);
    }
}
