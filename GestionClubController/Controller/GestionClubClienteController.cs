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
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            return obj.ListarClientes();
        }
        public static List<GestionClubClienteDto> ListarClientesActivos()
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            return obj.ListarClientesActivos();
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
                case GestionClubClienteDto._nombreRazSocialCliente: return pObj.nombreRazSocialCliente.ToString();
                case GestionClubClienteDto._razComercialCliente: return pObj.razComercialCliente.ToString();
                case GestionClubClienteDto._emailCliente: return pObj.emailCliente.ToString();
                case GestionClubClienteDto._nroCelularCliente: return pObj.nroCelularCliente.ToString();
                case GestionClubClienteDto._representanteCliente: return pObj.representanteCliente.ToString();
                case GestionClubClienteDto._estadoCliente: return pObj.estadoCliente.ToString();
                case GestionClubClienteDto._idCliente: return pObj.idCliente.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubClienteDto EsActoModificarCliente(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iPerEN = new GestionClubClienteDto();

            //validar si existe
            iPerEN = GestionClubClienteController.EsClienteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubClienteDto EsClienteExistente(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iAmbEN = new GestionClubClienteDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubClienteController.BuscarClienteXId(pObj);
            if (iAmbEN.nroIdentificacionCliente == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El Cliente " + pObj.nroIdentificacionCliente + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubClienteDto EsClienteExistenteSinComprobante(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iAmbEN = new GestionClubClienteDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubClienteController.BuscarClienteXId(pObj);
            if (iAmbEN.nroIdentificacionCliente == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El Cliente " + pObj.nroIdentificacionCliente + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubClienteDto BuscarClienteXId(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository objRepo = new GestionClubClienteRepository();
            return objRepo.ListarClientePorId(pObj);
        }
        public static GestionClubClienteDto EsActoEliminarCliente(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iObjEN = new GestionClubClienteDto();

            //validar si existe
            iObjEN = GestionClubClienteController.EsClienteExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
        public static GestionClubClienteDto EsActoEliminarClienteSinComprobante(GestionClubClienteDto pObj)
        {
            GestionClubClienteDto iObjEN = new GestionClubClienteDto();

            //validar si existe
            iObjEN = GestionClubClienteController.EsClienteExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
        public static GestionClubClienteDto EnBlanco()
        {
            GestionClubClienteDto iPerEN = new GestionClubClienteDto();
            return iPerEN;
        }
        public static GestionClubClienteDto EsCodigoClienteDisponible(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iAmbEN = new GestionClubClienteDto();

            //valida cuando el codigo esta vacio
            if (pObj.codCliente == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubClienteController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static GestionClubClienteDto ValidaCuandoCodigoYaExiste(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iAmbiente = new GestionClubClienteDto();

            //validar    
            iAmbiente = GestionClubClienteController.BuscarClienteXClave(pObj);
            if (iAmbiente.nroIdentificacionCliente != string.Empty)
            {
                iAmbiente.Adicionales.EsVerdad = false;
                iAmbiente.Adicionales.Mensaje = "El codigo " + pObj.nroIdentificacionCliente + " ya existe";
                return iAmbiente;
            }

            //ok
            iAmbiente.Adicionales.EsVerdad = true;
            return iAmbiente;
        }
        public static GestionClubClienteDto BuscarClienteXClave(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            return obj.ListarClientePorNroDocumentoPorEmpresa(pObj);
        }
        public static void EliminarCliente(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            obj.EliminarCliente(pObj);
        }
        public static void ModificarCliente(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            obj.ModificarCliente(pObj);
        }
        public static void AdicionarCliente(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            obj.AgregarCliente(pObj);
        }

        public static GestionClubClienteDto EsClienteActivoValido(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iCliEN = new GestionClubClienteDto();

            //valida cuando el codigo esta vacio
            if (pObj.nroIdentificacionCliente == string.Empty) { return iCliEN; }

            //valida cuando el codigo no existe
            iCliEN = GestionClubClienteController.EsClienteExistentePorNroDocumento(pObj);
            if (iCliEN.Adicionales.EsVerdad == false) { return iCliEN; }


            //valida cuando esta desactivado
            GestionClubClienteDto iCliDesEN = GestionClubClienteController.ValidaCuandoClienteEstaDesactivado(iCliEN);
            if (iCliDesEN.Adicionales.EsVerdad == false) { return iCliDesEN; }

            //ok
            return iCliEN;
        }
        public static GestionClubClienteDto ValidaCuandoClienteEstaDesactivado(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iCliEN = new GestionClubClienteDto();

            //validar                 
            if (pObj.estadoCliente == "02")//desactivado
            {
                iCliEN.Adicionales.EsVerdad = false;
                iCliEN.Adicionales.Mensaje = "El cliente " + pObj.nroIdentificacionCliente + " esta desactivado";
                return iCliEN;
            }

            //ok
            iCliEN.Adicionales.EsVerdad = true;
            return iCliEN;
        }
        public static GestionClubClienteDto EsClienteExistentePorNroDocumento(GestionClubClienteDto pObj)
        {
            //objeto resultado
            GestionClubClienteDto iAmbEN = new GestionClubClienteDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubClienteController.BuscarClienteXNroDocumento(pObj);
            if (iAmbEN.nroIdentificacionCliente == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El Cliente " + pObj.nroIdentificacionCliente + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubClienteDto BuscarClienteXNroDocumento(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository objRepo = new GestionClubClienteRepository();
            return objRepo.ListarClientePorNroDocumentoPorEmpresa(pObj);
        }
        public List<GestionClubClienteDto> ListarClientePorTipoPorNroIdePorNomRaz(GestionClubClienteDto pObj)
        {
            GestionClubClienteRepository obj = new GestionClubClienteRepository();
            return obj.ListarClientePorTipoPorNroIdePorNomRaz(pObj);
        }
    }
}
