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
    public class CreditsPagosController
    {
        private readonly ICreditsPagosRepository _iCreditsPagosRepository;
        public CreditsPagosController()
        {
            this._iCreditsPagosRepository = new CreditsPagosRepository();
        }
        public void ActualizaMesAnioImpago(CreditsPagosDto pObj)
        {
            this._iCreditsPagosRepository.ActualizaMesAnioImpago(pObj);
        }

        public List<CreditsPagosDto> RastreaDeudasImpagas(CreditsPagosDto creditsPagosDto)
        {
            return this._iCreditsPagosRepository.RastreaDeudasImpagas(creditsPagosDto);
        }
        public void ProcesoReprogramaPagosMesAnioImpago(CreditsPagosDto pObj)
        {
            this._iCreditsPagosRepository.ProcesoReprogramaPagosMesAnioImpago(pObj);
        }
        public static List<CreditsPagosDto> EnvioMesAnioIdOperacion(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.EnvioMesAnioIdOperacion(creditsPagosDto);
        }
        public static List<CreditsPagosDto> EnvioMesAnioIdOperacionCaja(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.EnvioMesAnioIdOperacionCaja(creditsPagosDto);
        }
        public List<CreditsPagosDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CreditsPagosDto> pListaOperations)
        {
            //lista resultado
            List<CreditsPagosDto> iLisRes = new List<CreditsPagosDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = CreditsPagosController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<CreditsPagosDto> FiltrarOperationsXTextoEnCualquierPosicion(List<CreditsPagosDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CreditsPagosDto> iLisRes = new List<CreditsPagosDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CreditsPagosDto xOperations in pLista)
            {
                string iTexto = CreditsPagosController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(CreditsPagosDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CreditsPagosDto.xFecha: return pObj.Fecha.ToString();
                case CreditsPagosDto.xCODOFIN: return pObj.CodoFin;
                case CreditsPagosDto.xCIP: return pObj.Cip;
                case CreditsPagosDto.xNRODNI: return pObj.NroDni;
                case CreditsPagosDto.xAPENOM: return pObj.ApeNom;
                case CreditsPagosDto.xDni: return pObj.Dni;
                case CreditsPagosDto.xDni_Ser_Numero: return pObj.Dni_Ser_Numero.ToString();
                case CreditsPagosDto.xGrado: return pObj.Grado.ToString();
                case CreditsPagosDto.xNOMBRE: return pObj.Nombre.ToString();
                case CreditsPagosDto.xResultado: return pObj.Resultado.ToString();
                case CreditsPagosDto.xEnvio: return pObj.Envio.ToString();
                case CreditsPagosDto.xInicia: return pObj.Inicia.ToString();
            }

            //retorna
            return iValor;
        }

        public List<CreditsPagosDto> TablaPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TablaPagosMesAnioCodofin(creditsPagosDto);
        }
        public CreditsPagosDto TotalPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TotalPagosMesAnioCodofin(creditsPagosDto);
        }
        public int InsertTbPagos(CreditsPagosDto pObj)
        {
            return this._iCreditsPagosRepository.InsertTbPagos(pObj);
        }
        public void ActualizaTbPagos(CreditsPagosDto pObj)
        {
            this._iCreditsPagosRepository.ActualizaTbPagos(pObj);
        }

        public List<CreditsPagosDto> TablaPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TablaPagosMesAnioCodofinCO(creditsPagosDto);
        }
        public CreditsPagosDto TotalPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TotalPagosMesAnioCodofinCO(creditsPagosDto);
        }
        public int InsertEnvioPagoCO(CreditsPagosDto pObj)
        {
            return this._iCreditsPagosRepository.InsertEnvioPagoCO(pObj);
        }

        public void ActualizaPagosCobranza(CreditsPagosDto pObj)
        {
            this._iCreditsPagosRepository.ActualizaPagosCobranza(pObj);
        }

        public List<CreditsPagosDto> TablaPagosMesAnio(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TablaPagosMesAnio(creditsPagosDto);
        }
        public CreditsPagosDto TraeDescuentoDirrehum(CreditsPagosDto creditsPagosDto)
        {
            ICreditsPagosRepository iCreditsPagosRepository = new CreditsPagosRepository();
            return iCreditsPagosRepository.TraeDescuentoDirrehum(creditsPagosDto);
        }
    }
}
