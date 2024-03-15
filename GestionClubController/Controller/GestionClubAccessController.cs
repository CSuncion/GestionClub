using Comun;
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
    public class GestionClubAccessController
    {
        private readonly IGestionClubAccessRepository _iCreditAccessRepository;

        public GestionClubAccessController()
        {
            this._iCreditAccessRepository = new GestionClubAccessRepository();
        }
        public GestionClubAccessDto EsUsuarioValido(GestionClubAccessDto pObj)
        {
            GestionClubAccessDto iUsuEN = new GestionClubAccessDto();

            //si no hay codigousuario entonces es true
            if (pObj.dniAcceso == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = "";
                return iUsuEN;
            }

            //aqui CodigoUsuario no esta vacio
            iUsuEN = this._iCreditAccessRepository.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.dniAcceso == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "No existe usuario con este codigo : " + Cadena.Espacios(1) + pObj.dniAcceso;
                return iUsuEN;
            }
            else
            {
                if (iUsuEN.sitAcceso == "02") //desactivado
                {
                    iUsuEN = GestionClubAccessController.EnBlanco();
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "El usuario" + Cadena.Espacios(1) + pObj.dniAcceso + Cadena.Espacios(1) + "esta desactivado";
                    return iUsuEN;
                }
            }
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }
        public GestionClubAccessDto EsContrasenaDeUsuario(GestionClubAccessDto pObj)
        {
            GestionClubAccessDto iUsuEN = new GestionClubAccessDto();

            //si no se digito contraseña entonces es true
            if (pObj.passAcceso == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = string.Empty;
                return iUsuEN;
            }

            //si CodigoUsuario no esta vacio y clave tampoco
            string xClave = pObj.passAcceso;
            iUsuEN = this._iCreditAccessRepository.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.passAcceso.Trim() == xClave)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = string.Empty;
                return iUsuEN;
            }
            else
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "La clave es Incorrecta";
                return iUsuEN;
            }

        }
        public static GestionClubAccessDto EnBlanco()
        {
            GestionClubAccessDto iUsuEN = new GestionClubAccessDto();
            return iUsuEN;
        }
        public List<string> ListarSubPrivilegiosAcceso(int idAcceso)
        {
            return this._iCreditAccessRepository.ListarSubPrivilegiosAcceso(idAcceso);
        }
        public List<GestionClubAccessDto> ListarUsuarioMeserosActivos(GestionClubAccessDto obj)
        {
            return this._iCreditAccessRepository.ListarUsuarioMeserosActivos(obj);
        }
        public List<GestionClubAccessDto> ListarUsuarioMozos()
        {
            GestionClubAccessRepository objAcceso = new GestionClubAccessRepository();
            return objAcceso.ListarUsuarioMozos();
        }
        public static void EliminarAcceso(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objAcceso = new GestionClubAccessRepository();
            objAcceso.EliminarAcceso(pObj);
        }
        public static void ModificarAcceso(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objAcceso = new GestionClubAccessRepository();
            objAcceso.ModificarAcceso(pObj);
        }
        public static void AdicionarAcceso(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objAcceso = new GestionClubAccessRepository();
            objAcceso.AdicionarAcceso(pObj);
        }
        public List<GestionClubAccessDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubAccessDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubAccessDto> iLisRes = new List<GestionClubAccessDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubAccessController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubAccessDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubAccessDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubAccessDto> iLisRes = new List<GestionClubAccessDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubAccessDto xOperations in pLista)
            {
                string iTexto = GestionClubAccessController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubAccessDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubAccessDto.codAcc: return pObj.codAcceso.ToString();
                case GestionClubAccessDto.nombreAcc: return pObj.nombreAcceso.ToString();
                case GestionClubAccessDto.DniAcc: return pObj.dniAcceso.ToString();
                case GestionClubAccessDto.PassAcc: return pObj.passAcceso.ToString();
                case GestionClubAccessDto.PatAcc: return pObj.paternoAcceso.ToString();
                case GestionClubAccessDto.MatAcc: return pObj.maternoAcceso.ToString();
                case GestionClubAccessDto.nombresAcc: return pObj.nombresAcceso.ToString();
                case GestionClubAccessDto.MailAcc: return pObj.mailAcceso.ToString();
                case GestionClubAccessDto.DomAcc: return pObj.domicilioAcceso.ToString();
                case GestionClubAccessDto.DptoAcc: return pObj.dptoAcceso.ToString();
                case GestionClubAccessDto.ProvAcc: return pObj.provAcceso.ToString();
                case GestionClubAccessDto.DistAcc: return pObj.distAcceso.ToString();
                case GestionClubAccessDto.FijAcc: return pObj.fijoAcceso.ToString();
                case GestionClubAccessDto.MovAcc: return pObj.movilAcceso.ToString();
                case GestionClubAccessDto.LevAcc: return pObj.levelAcceso.ToString();
                case GestionClubAccessDto.SitAcc: return pObj.sitAcceso.ToString();
                case GestionClubAccessDto.FecAcc: return pObj.fechaAcceso.ToString();
                case GestionClubAccessDto.Of1: return pObj.ofc1.ToString();
                case GestionClubAccessDto.Of2: return pObj.ofc2.ToString();
                case GestionClubAccessDto.Of3: return pObj.ofc3.ToString();
                case GestionClubAccessDto.Of4: return pObj.ofc4.ToString();
                case GestionClubAccessDto.CipAcc: return pObj.cipAcceso.ToString();
                case GestionClubAccessDto.CodfinAcc: return pObj.codofinAcceso.ToString();
                case GestionClubAccessDto.GradAcc: return pObj.gradoAcceso.ToString();
                case GestionClubAccessDto.xPnp: return pObj.pnp.ToString();
                case GestionClubAccessDto.CargAcc: return pObj.cargoAcceso.ToString();
                case GestionClubAccessDto.IdAcc: return pObj.idAcceso.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubAccessDto EsActoModificarAccess(GestionClubAccessDto pObj)
        {
            //objeto resultado
            GestionClubAccessDto iPerEN = new GestionClubAccessDto();

            //validar si existe
            iPerEN = GestionClubAccessController.EsAccessExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubAccessDto EsAccessExistente(GestionClubAccessDto pObj)
        {
            //objeto resultado
            GestionClubAccessDto iAmbEN = new GestionClubAccessDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubAccessController.BuscarAccessXId(pObj);
            if (iAmbEN.dniAcceso == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El Cliente " + pObj.dniAcceso + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubAccessDto BuscarAccessXId(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objRepo = new GestionClubAccessRepository();
            return objRepo.ListarUsuarioMozosPorId(pObj);
        }
        public static GestionClubAccessDto EsActoEliminarAccess(GestionClubAccessDto pObj)
        {
            //objeto resultado
            GestionClubAccessDto iObjEN = new GestionClubAccessDto();

            //validar si existe
            iObjEN = GestionClubAccessController.EsAccessExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
        public static GestionClubAccessDto EsCodigoAccesoDisponible(GestionClubAccessDto pObj)
        {
            //objeto resultado
            GestionClubAccessDto iAmbEN = new GestionClubAccessDto();

            //valida cuando el codigo esta vacio
            if (pObj.codAcceso == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubAccessController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }

        public static GestionClubAccessDto ValidaCuandoCodigoYaExiste(GestionClubAccessDto pObj)
        {
            //objeto resultado
            GestionClubAccessDto iAcceso = new GestionClubAccessDto();

            //validar    
            iAcceso = GestionClubAccessController.BuscarUsuarioXCodigo(pObj);
            if (iAcceso.codAcceso != string.Empty)
            {
                iAcceso.Adicionales.EsVerdad = false;
                iAcceso.Adicionales.Mensaje = "El codigo " + pObj.codAcceso + " ya existe";
                return iAcceso;
            }

            //ok
            iAcceso.Adicionales.EsVerdad = true;
            return iAcceso;
        }
        public static GestionClubAccessDto BuscarUsuarioXCodigo(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objRepo = new GestionClubAccessRepository();
            return objRepo.BuscarUsuarioXCodigo(pObj);
        }
        public static void ActualizarClaveAprobador(GestionClubAccessDto pObj)
        {
            GestionClubAccessRepository objAcceso = new GestionClubAccessRepository();
            objAcceso.ActualizarClaveAprobador(pObj);
        }
    }
}