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
    public class CreditsReportController
    {
        private readonly ICreditsReportRepository _iCreditsReportRepository;
        public CreditsReportController()
        {
            this._iCreditsReportRepository = new CreditsReportRepository();
        }
        public List<dynamic> ListarCreditosOtorgados(int anio)
        {
            return this._iCreditsReportRepository.ListarCreditosOtorgados(anio);
        }
        public List<dynamic> ListarTipoCreditos(int anio)
        {
            return this._iCreditsReportRepository.ListarTipoCreditos(anio);
        }
        public List<dynamic> ListarTipoCreditoPorAnio(int anio, int codCentroCosto)
        {
            return this._iCreditsReportRepository.ListarTipoCreditoPorAnio(anio, codCentroCosto);
        }
        public List<dynamic> ListarSaldoFavorSolicitantes(string desde, string hasta)
        {
            return this._iCreditsReportRepository.ListarSaldoFavorSolicitantes(desde, hasta);
        }
        public List<dynamic> ListarTipoCreditoGeneradoDesembolsado(string desde, string hasta)
        {
            return this._iCreditsReportRepository.ListarTipoCreditoGeneradoDesembolsado(desde, hasta);
        }
        public List<dynamic> ListarCreditoEnProceso(string desde, string hasta)
        {
            return this._iCreditsReportRepository.ListarCreditoEnProceso(desde, hasta);
        }
        public List<dynamic> ListarCreditoMorosos(string hasta)
        {
            return this._iCreditsReportRepository.ListarCreditoMorosos(hasta);
        }
        public List<dynamic> ListarOperacionesRefinanciamientoAmpliacion(CreditsOperationsDto oCreOpe)
        {
            return this._iCreditsReportRepository.ListarOperacionesRefinanciamientoAmpliacion(oCreOpe);
        }
        public List<dynamic> ListarComparativoCreditoOtorgados()
        {
            return this._iCreditsReportRepository.ListarComparativoCreditoOtorgados();
        }
        public decimal ListarConsultaNoAdeudo(string dni)
        {
            return this._iCreditsReportRepository.ListarConsultaNoAdeudo(dni);
        }
        public string GenerarCorrelativoConstanciaNoAdeudo(string periodo)
        {
            return this._iCreditsReportRepository.GenerarCorrelativoConstanciaNoAdeudo(periodo);
        }
        public int ValidaImpresionCorrelativoConstanciaNoAdeudo(string dni)
        {
            return this._iCreditsReportRepository.ValidaImpresionCorrelativoConstanciaNoAdeudo(dni);
        }
        public string ListaNameAnio()
        {
            return this._iCreditsReportRepository.ListaNameAnio();
        }
        public List<string> ListaFirmaGerenteFinanza()
        {
            return this._iCreditsReportRepository.ListaFirmaGerenteFinanza();
        }
        public List<CreditsDecomicroDto> ListarDecomicro()
        {
            return this._iCreditsReportRepository.ListarDecomicro();
        }
        public static List<CreditsSaldosFormatoDto> ListaSaldosFormato(string mes, string anio, string producto)
        {
            ICreditsReportRepository iDeclaracionesReportRepository = new CreditsReportRepository();
            return iDeclaracionesReportRepository.ListaSaldosFormato(mes, anio, producto);
        }
        public List<CreditsSaldosFormatoDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CreditsSaldosFormatoDto> pListaOperations)
        {
            //lista resultado
            List<CreditsSaldosFormatoDto> iLisRes = new List<CreditsSaldosFormatoDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = CreditsReportController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<CreditsSaldosFormatoDto> FiltrarOperationsXTextoEnCualquierPosicion(List<CreditsSaldosFormatoDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CreditsSaldosFormatoDto> iLisRes = new List<CreditsSaldosFormatoDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CreditsSaldosFormatoDto xOperations in pLista)
            {
                string iTexto = CreditsReportController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(CreditsSaldosFormatoDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CreditsSaldosFormatoDto.xConcatenado: return pObj.Concatenado.ToString();
                case CreditsSaldosFormatoDto.xCod: return pObj.Cod;
                case CreditsSaldosFormatoDto.xProducto: return pObj.Producto;
                case CreditsSaldosFormatoDto.xSolicitante: return pObj.Solicitante.ToString();
                case CreditsSaldosFormatoDto.xDNI: return pObj.DNI.ToString();
                case CreditsSaldosFormatoDto.xSer: return pObj.Ser.ToString();
                case CreditsSaldosFormatoDto.xNumero: return pObj.Numero.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
