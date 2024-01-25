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
    public class GestionClubClienteController
    {
        private readonly IGestionClubClienteRepository _iCreditClienteRepository;

        public GestionClubClienteController()
        {
            this._iCreditClienteRepository = new GestionClubClienteRepository();
        }
        public List<GestionClubClienteDto> ListarClientes()
        {
            return this._iCreditClienteRepository.ListarClientes();
        }
        public List<GestionClubClienteDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubClienteDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubClienteDto> iLisRes = new List<GestionClubClienteDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubClienteController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubClienteDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubClienteDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubClienteDto> iLisRes = new List<GestionClubClienteDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubClienteDto xOperations in pLista)
            {
                string iTexto = GestionClubClienteController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubClienteDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubClienteDto._codCliente: return pObj.codCliente.ToString();
                case GestionClubClienteDto._tipSocioCliente: return pObj.tipSocioCliente;
                case GestionClubClienteDto._tipCliente: return pObj.tipCliente.ToString();
                case GestionClubClienteDto._nroIdentificacionCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._nombreRazSocialCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._razComercialCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._emailCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._nroCelularCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._representanteCliente: return pObj.nroIdentificacionCliente.ToString();
                case GestionClubClienteDto._estadoCliente: return pObj.nroIdentificacionCliente.ToString();
            }

            //retorna
            return iValor;
        }
    }
}
