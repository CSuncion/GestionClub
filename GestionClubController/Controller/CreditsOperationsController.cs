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
    public class CreditsOperationsController
    {
        private readonly ICreditsOperationsRepository _iCreditsOperationsRepository;
        public CreditsOperationsController()
        {
            this._iCreditsOperationsRepository = new CreditsOperationsRepository();
        }
        public static List<CreditsOperationsDto> TablaOperacDni(CreditsOperationsDto pObj)
        {
            ICreditsOperationsRepository iDeclaracionesRegistroVentaRepository = new CreditsOperationsRepository();
            return iDeclaracionesRegistroVentaRepository.TablaOperacDni(pObj);
        }
        public List<CreditsOperationsDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CreditsOperationsDto> pListaOperations)
        {
            //lista resultado
            List<CreditsOperationsDto> iLisRes = new List<CreditsOperationsDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = CreditsOperationsController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<CreditsOperationsDto> FiltrarOperationsXTextoEnCualquierPosicion(List<CreditsOperationsDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CreditsOperationsDto> iLisRes = new List<CreditsOperationsDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CreditsOperationsDto xOperations in pLista)
            {
                string iTexto = CreditsOperationsController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(CreditsOperationsDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CreditsOperationsDto.Tip: return pObj.Tipo.ToString();
                case CreditsOperationsDto.xSer: return pObj.Ser;
                case CreditsOperationsDto.Nro: return pObj.Numero;
                case CreditsOperationsDto.Product: return pObj.Producto.ToString();
                case CreditsOperationsDto.Fec: return pObj.Fecha.ToString();
                case CreditsOperationsDto.Aproba: return pObj.Aprobado.ToString();
                case CreditsOperationsDto.xCredito: return pObj.Credito.ToString();
                case CreditsOperationsDto.Pla: return pObj.Plazo.ToString();
                case CreditsOperationsDto.xInforme: return pObj.Informe.ToString();
                case CreditsOperationsDto.xAnio: return pObj.Anio.ToString();
                case CreditsOperationsDto.xVoucher: return pObj.Voucher.ToString();
                case CreditsOperationsDto.xFeDesembolso: return pObj.FeDesembolso.ToString();
                case CreditsOperationsDto.xCondicion: return pObj.Condicion.ToString();
                case CreditsOperationsDto.IdOper: return pObj.Id_Operacion.ToString();
                case CreditsOperationsDto.DniSolic: return pObj.Dni_Solicitante.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<CreditsOperationsDto> ListarRefinanciadoAmpliadoPorDni(CreditsOperationsDto pObj)
        {
            ICreditsOperationsRepository iDeclaracionesRegistroVentaRepository = new CreditsOperationsRepository();
            return iDeclaracionesRegistroVentaRepository.ListarRefinanciadoAmpliadoPorDni(pObj);
        }

        public static List<decimal> ValidarEstadoDeCuenta(CreditsOperationsDto pObj)
        {
            ICreditsOperationsRepository iDeclaracionesRegistroVentaRepository = new CreditsOperationsRepository();
            return iDeclaracionesRegistroVentaRepository.ValidarEstadoDeCuenta(pObj);
        }
    }
}
