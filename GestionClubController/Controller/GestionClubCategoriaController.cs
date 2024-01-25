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
    public class GestionClubCategoriaController
    {
        private readonly IGestionClubCategoriaRepository _iCreditCategoriaRepository;

        public GestionClubCategoriaController()
        {
            this._iCreditCategoriaRepository = new GestionClubCategoriaRepository();
        }
        public List<GestionClubCategoriaDto> ListarCategorias()
        {
            return this._iCreditCategoriaRepository.ListarCategorias();
        }
        public List<GestionClubCategoriaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubCategoriaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubCategoriaDto> iLisRes = new List<GestionClubCategoriaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubCategoriaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubCategoriaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubCategoriaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubCategoriaDto> iLisRes = new List<GestionClubCategoriaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubCategoriaDto xOperations in pLista)
            {
                string iTexto = GestionClubCategoriaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubCategoriaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubCategoriaDto._codCategoria: return pObj.codCategoria.ToString();
                case GestionClubCategoriaDto._desCategoria: return pObj.desCategoria;
                case GestionClubCategoriaDto._estadoCategoria: return pObj.estadoCategoria.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
