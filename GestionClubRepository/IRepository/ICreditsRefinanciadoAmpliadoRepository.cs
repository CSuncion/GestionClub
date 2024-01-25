using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsRefinanciadoAmpliadoRepository
    {
        void CrearRefinanciadoAmpliado(CreditsRefinanciadoAmpliadoDto pObj);
        CreditsRefinanciadoAmpliadoDto ListarRefinanciadoAmpliadoPorOperacion(CreditsRefinanciadoAmpliadoDto pObj);
        void EliminarRefinanciadoAmpliado(CreditsRefinanciadoAmpliadoDto pObj);
    }
}
