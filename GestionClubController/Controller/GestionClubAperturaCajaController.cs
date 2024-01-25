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
    public class GestionClubAperturaCajaController
    {
        private readonly IGestionClubAperturaCajaRepository _iGestionClubAperturaCajaRepository;

        public GestionClubAperturaCajaController()
        {
            this._iGestionClubAperturaCajaRepository = new GestionClubAperturaCajaRepository();
        }
        public List<GestionClubAperturaCajaDto> ListarAperturaCajas()
        {
            return this._iGestionClubAperturaCajaRepository.ListarAperturaCajas();
        }
        public List<GestionClubAperturaCajaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubAperturaCajaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubAperturaCajaDto> iLisRes = new List<GestionClubAperturaCajaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubAperturaCajaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubAperturaCajaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubAperturaCajaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubAperturaCajaDto> iLisRes = new List<GestionClubAperturaCajaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubAperturaCajaDto xOperations in pLista)
            {
                string iTexto = GestionClubAperturaCajaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubAperturaCajaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubAperturaCajaDto._fecAperturaCaja: return pObj.fecAperturaCaja.ToString();
                case GestionClubAperturaCajaDto._montoAperturaCaja: return pObj.montoAperturaCaja.ToString();
                case GestionClubAperturaCajaDto._estadoAperturaCaja: return pObj.estadoAperturaCaja.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
