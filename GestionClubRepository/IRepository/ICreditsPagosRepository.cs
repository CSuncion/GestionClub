using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsPagosRepository
    {
        void ActualizaMesAnioImpago(CreditsPagosDto pObj);
        List<CreditsPagosDto> RastreaDeudasImpagas(CreditsPagosDto creditsPagosDto);
        void ProcesoReprogramaPagosMesAnioImpago(CreditsPagosDto pObj);
        List<CreditsPagosDto> EnvioMesAnioIdOperacion(CreditsPagosDto creditsPagosDto);
        List<CreditsPagosDto> EnvioMesAnioIdOperacionCaja(CreditsPagosDto creditsPagosDto);
        List<CreditsPagosDto> TablaPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto);
        CreditsPagosDto TotalPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto);
        int InsertTbPagos(CreditsPagosDto pObj);
        void ActualizaTbPagos(CreditsPagosDto pObj);
        List<CreditsPagosDto> TablaPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto);
        CreditsPagosDto TotalPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto);
        int InsertEnvioPagoCO(CreditsPagosDto pObj);
        void ActualizaPagosCobranza(CreditsPagosDto pObj);
        List<CreditsPagosDto> TablaPagosMesAnio(CreditsPagosDto creditsPagosDto);
        CreditsPagosDto TraeDescuentoDirrehum(CreditsPagosDto creditsPagosDto);
    }
}
