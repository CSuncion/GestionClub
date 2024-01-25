using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsOperationsRepository
    {
        List<CreditsOperationsDto> TablaOperacDni(CreditsOperationsDto pObj);
        List<CreditsOperationsDto> ListarRefinanciadoAmpliadoPorDni(CreditsOperationsDto pObj);
        List<decimal> ValidarEstadoDeCuenta(CreditsOperationsDto pObj);
    }
}
