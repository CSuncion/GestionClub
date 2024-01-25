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
    public class GestionClubAmbienteController
    {
        private readonly IGestionClubAmbienteRepository _iCreditAmbienteRepository;

        public GestionClubAmbienteController()
        {
            this._iCreditAmbienteRepository = new GestionClubAmbienteRepository();
        }
        public List<GestionClubAmbientesDto> ListarAmbientes()
        {
            return this._iCreditAmbienteRepository.ListarAmbientes();
        }
        public List<GestionClubAmbientesDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubAmbientesDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubAmbientesDto> iLisRes = new List<GestionClubAmbientesDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubAmbienteController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubAmbientesDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubAmbientesDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubAmbientesDto> iLisRes = new List<GestionClubAmbientesDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubAmbientesDto xOperations in pLista)
            {
                string iTexto = GestionClubAmbienteController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubAmbientesDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubAmbientesDto._codAmbiente: return pObj.codAmbiente.ToString();
                case GestionClubAmbientesDto._desAmbiente: return pObj.desAmbiente;
                case GestionClubAmbientesDto._estadoAmbiente: return pObj.estadoAmbiente.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
