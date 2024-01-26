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
        private readonly IGestionClubAmbienteRepository _iGestionClubAmbienteRepository;

        public GestionClubAmbienteController()
        {
            this._iGestionClubAmbienteRepository = new GestionClubAmbienteRepository();
        }
        public static List<GestionClubAmbientesDto> ListarAmbientes()
        {
            GestionClubAmbienteRepository oRepo = new GestionClubAmbienteRepository();
            return oRepo.ListarAmbientes();
        }
        public List<GestionClubAmbientesDto> ListarAmbientesActivos()
        {
            GestionClubAmbienteRepository oRepo = new GestionClubAmbienteRepository();
            return oRepo.ListarAmbientesActivos();
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
        public static GestionClubAmbientesDto EnBlanco()
        {
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();
            return iPerEN;
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
                case GestionClubAmbientesDto._idAmbiente: return pObj.idAmbiente.ToString();
            }

            //retorna
            return iValor;
        }
        public static string ObtenerClaveAmbiente(GestionClubAmbientesDto pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.codAmbiente;

            //retornar
            return iClave;
        }
        public static GestionClubAmbientesDto EsCodigoPersonalDisponible(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();

            //valida cuando el codigo esta vacio
            if (pObj.codAmbiente == string.Empty) { return iPerEN; }

            //valida cuando existe el codigo
            iPerEN = GestionClubAmbienteController.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok          
            return iPerEN;
        }
        public static GestionClubAmbientesDto ValidaCuandoCodigoYaExiste(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iAmbiente = new GestionClubAmbientesDto();

            //validar    
            iAmbiente = GestionClubAmbienteController.BuscarAmbienteXClave(pObj);
            if (iAmbiente.codAmbiente != string.Empty)
            {
                iAmbiente.Adicionales.EsVerdad = false;
                iAmbiente.Adicionales.Mensaje = "El codigo " + pObj.codAmbiente + " ya existe";
                return iAmbiente;
            }

            //ok
            iAmbiente.Adicionales.EsVerdad = true;
            return iAmbiente;
        }
        public static GestionClubAmbientesDto BuscarAmbienteXClave(GestionClubAmbientesDto pObj)
        {
            GestionClubAmbienteRepository objAmbiente = new GestionClubAmbienteRepository();
            return objAmbiente.ListarAmbientesPorCodigoPorEmpresa(pObj);
        }
        public static GestionClubAmbientesDto BuscarAmbienteXId(GestionClubAmbientesDto pObj)
        {
            GestionClubAmbienteRepository objAmbiente = new GestionClubAmbienteRepository();
            return objAmbiente.ListarAmbientesPorId(pObj);
        }
        public static GestionClubAmbientesDto EsCodigoAmbienteDisponible(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iAmbEN = new GestionClubAmbientesDto();

            //valida cuando el codigo esta vacio
            if (pObj.codAmbiente == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubAmbienteController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static void AdicionarAmbiente(GestionClubAmbientesDto pObj)
        {
            GestionClubAmbienteRepository objAmbiente = new GestionClubAmbienteRepository();
            objAmbiente.AgregarAmbiente(pObj);
        }
        public static GestionClubAmbientesDto EsActoModificarAmbiente(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();

            //validar si existe
            iPerEN = GestionClubAmbienteController.EsAmbienteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubAmbientesDto EsAmbienteExistente(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iAmbEN = new GestionClubAmbientesDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubAmbienteController.BuscarAmbienteXId(pObj);
            if (iAmbEN.codAmbiente == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El ambiente " + pObj.codAmbiente + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static void ModificarAmbiente(GestionClubAmbientesDto pObj)
        {
            GestionClubAmbienteRepository objAmbiente = new GestionClubAmbienteRepository();
            objAmbiente.ModificarAmbiente(pObj);
        }
        public static GestionClubAmbientesDto EsActoEliminarAmbiente(GestionClubAmbientesDto pObj)
        {
            //objeto resultado
            GestionClubAmbientesDto iPerEN = new GestionClubAmbientesDto();

            //validar si existe
            iPerEN = GestionClubAmbienteController.EsAmbienteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static void EliminarAmbiente(GestionClubAmbientesDto pObj)
        {
            GestionClubAmbienteRepository objAmbiente = new GestionClubAmbienteRepository();
            objAmbiente.EliminarAmbiente(pObj);
        }
    }
}
