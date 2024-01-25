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
    public class GestionClubMesaController
    {
        private readonly IGestionClubMesaRepository _iCreditMesaRepository;

        public GestionClubMesaController()
        {
            this._iCreditMesaRepository = new GestionClubMesaRepository();
        }
        public List<GestionClubMesaDto> ListarMesas()
        {
            return this._iCreditMesaRepository.ListarMesas();
        }
        public List<GestionClubMesaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubMesaDto> pListaOperations)
        {
            //lista GestionClubMesaDto
            List<GestionClubMesaDto> iLisRes = new List<GestionClubMesaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubMesaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubMesaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubMesaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubMesaDto> iLisRes = new List<GestionClubMesaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubMesaDto xOperations in pLista)
            {
                string iTexto = GestionClubMesaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubMesaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubMesaDto._desAmbiente: return pObj.GestionClubAmbientesDto.desAmbiente.ToString();
                case GestionClubMesaDto._codMesa: return pObj.codMesa.ToString();
                case GestionClubMesaDto._desMesa: return pObj.desMesa;
                case GestionClubMesaDto._estadoMesa: return pObj.estadoMesa.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
