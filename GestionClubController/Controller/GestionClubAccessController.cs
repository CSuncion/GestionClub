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
                if (iUsuEN.sitAcceso == 0) //desactivado
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
        public List<int> ListarSubPrivilegiosAcceso(int idAcceso)
        {
            return this._iCreditAccessRepository.ListarSubPrivilegiosAcceso(idAcceso);
        }
        public List<GestionClubAccessDto> ListarUsuarioMeserosActivos(GestionClubAccessDto obj)
        {
            return this._iCreditAccessRepository.ListarUsuarioMeserosActivos(obj);
        }
    }
}
