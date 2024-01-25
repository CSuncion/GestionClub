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
    public class GestionClubCierreCajaController
    {
        private readonly IGestionClubCierreCajaRepository _iGestionClubCierreCajaRepository;

        public GestionClubCierreCajaController()
        {
            this._iGestionClubCierreCajaRepository = new GestionClubCierreCajaRepository();
        }
        public List<GestionClubCierreCajaDto> ListarCierreCajas()
        {
            return this._iGestionClubCierreCajaRepository.ListarCierreCajas();
        }
        public List<GestionClubCierreCajaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubCierreCajaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubCierreCajaDto> iLisRes = new List<GestionClubCierreCajaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubCierreCajaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubCierreCajaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubCierreCajaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubCierreCajaDto> iLisRes = new List<GestionClubCierreCajaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubCierreCajaDto xOperations in pLista)
            {
                string iTexto = GestionClubCierreCajaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubCierreCajaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubCierreCajaDto._fecCierreCaja: return pObj.fecCierreCaja.ToString();
                case GestionClubCierreCajaDto._montoCierreCaja: return pObj.montoCierreCaja.ToString();
                case GestionClubCierreCajaDto._estadoCierreCaja: return pObj.estadoCierreCaja.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
