using CreditsModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.IRepository
{
    public interface ICreditsReportRepository
    {
        List<dynamic> ListarCreditosOtorgados(int anio);
        List<dynamic> ListarTipoCreditos(int anio);
        List<dynamic> ListarTipoCreditoPorAnio(int anio, int codCentroCosto);
        List<dynamic> ListarSaldoFavorSolicitantes(string desde, string hasta);
        List<dynamic> ListarTipoCreditoGeneradoDesembolsado(string desde, string hasta);
        List<dynamic> ListarCreditoEnProceso(string desde, string hasta);
        List<dynamic> ListarCreditoMorosos(string hasta);
        List<dynamic> ListarOperacionesRefinanciamientoAmpliacion(CreditsOperationsDto oCreOpe);
        List<dynamic> ListarComparativoCreditoOtorgados();
        decimal ListarConsultaNoAdeudo(string dni);
        string GenerarCorrelativoConstanciaNoAdeudo(string periodo);
        int ValidaImpresionCorrelativoConstanciaNoAdeudo(string dni);
        string ListaNameAnio();
        List<string> ListaFirmaGerenteFinanza();
        List<CreditsDecomicroDto> ListarDecomicro();
        List<CreditsSaldosFormatoDto> ListaSaldosFormato(string mes, string anio, string producto);
    }
}
