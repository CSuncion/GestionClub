using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubProductoController
    {
        private readonly IGestionClubProductoRepository _iCreditProductoRepository;

        public GestionClubProductoController()
        {
            this._iCreditProductoRepository = new GestionClubProductoRepository();
        }
        public List<GestionClubProductoDto> ListarProductos()
        {
            return this._iCreditProductoRepository.ListarProductos();
        }
        public List<GestionClubProductoDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubProductoDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubProductoDto> iLisRes = new List<GestionClubProductoDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubProductoController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubProductoDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubProductoDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubProductoDto> iLisRes = new List<GestionClubProductoDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubProductoDto xOperations in pLista)
            {
                string iTexto = GestionClubProductoController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubProductoDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubProductoDto._codProducto: return pObj.codProducto.ToString();
                case GestionClubProductoDto._desProducto: return pObj.desProducto;
                case GestionClubProductoDto._uniMedProducto: return pObj.uniMedProducto.ToString();
                case GestionClubProductoDto._codMoneda: return pObj.codMoneda.ToString();
                case GestionClubProductoDto._preCosProducto: return pObj.preCosProducto.ToString();
                case GestionClubProductoDto._preVtsProducto: return pObj.preVtsProducto.ToString();
                case GestionClubProductoDto._preVnsProducto: return pObj.preVnsProducto.ToString();
                case GestionClubProductoDto._afeIgvProducto: return pObj.afeIgvProducto.ToString();
                case GestionClubProductoDto._afeDtraProducto: return pObj.afeDtraProducto.ToString();
                case GestionClubProductoDto._porDtraProducto: return pObj.porDtraProducto.ToString();
                case GestionClubProductoDto._impDolProducto: return pObj.impDolProducto.ToString();
                case GestionClubProductoDto._impOtrProducto: return pObj.impOtrProducto.ToString();
                case GestionClubProductoDto._obsProducto: return pObj.obsProducto.ToString();
                case GestionClubProductoDto._estadoProducto: return pObj.estadoProducto.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
