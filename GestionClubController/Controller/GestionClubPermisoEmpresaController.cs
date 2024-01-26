using GestionClubRepository.Repository;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClubModel.ModelDto;
using Comun;

namespace GestionClubController.Controller
{
    public class GestionClubPermisoEmpresaController
    {
        private readonly IGestionClubPermisoEmpresaRepository _iGestionClubPermisoEmpresaRepository;
        public GestionClubPermisoEmpresaController()
        {
            this._iGestionClubPermisoEmpresaRepository = new GestionClubPermisoEmpresaRepository();
        }
        public static GestionClubPermisoEmpresaDto ListarPermisoEmpresaPorCodigo(GestionClubPermisoEmpresaDto pObj)
        {
            GestionClubPermisoEmpresaRepository objPerm = new GestionClubPermisoEmpresaRepository();
            return objPerm.ListarPermisoEmpresaPorCodigo(pObj);
        }
        public static string ObtenerClavePermisoEmpresa(GestionClubPermisoEmpresaDto pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.codEmpresa + "-";
            iClave += pObj.codAcceso;
            return iClave;
        }
        public static GestionClubPermisoEmpresaDto EnBlanco()
        {
            GestionClubPermisoEmpresaDto iPemEN = new GestionClubPermisoEmpresaDto();
            return iPemEN;
        }
        public static GestionClubPermisoEmpresaDto EsEmpresaDeUsuario(GestionClubPermisoEmpresaDto pObj)
        {
            GestionClubPermisoEmpresaDto iPermEmpresa = new GestionClubPermisoEmpresaDto();

            //si no se digito la empresa entonces es true
            if (pObj.codEmpresa == string.Empty)
            {
                iPermEmpresa.Adicionales.EsVerdad = true;
                iPermEmpresa.Adicionales.Mensaje = string.Empty;
                return iPermEmpresa;
            }

            //verificar que se aya escrito el usuario
            if (pObj.codAcceso == string.Empty)
            {
                iPermEmpresa.Adicionales.EsVerdad = false;
                iPermEmpresa.Adicionales.Mensaje = "Primero debes elegir al usuario";
                return iPermEmpresa;
            }

            //si CodigoEmpresa no esta vacio y hay usuario
            iPermEmpresa = GestionClubPermisoEmpresaController.ListarPermisoEmpresaPorCodigo(pObj);
            if (iPermEmpresa.gestionClubEmpresaDto.codEmpresa == string.Empty)
            {
                iPermEmpresa.Adicionales.EsVerdad = false;
                iPermEmpresa.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.codEmpresa + Cadena.Espacios(1) + "no existe";
                return iPermEmpresa;
            }
            else
            {
                //verificar que la empresa este desactivada
                if (iPermEmpresa.gestionClubEmpresaDto.estadoEmpresa == "0") //desactivada
                {
                    iPermEmpresa = GestionClubPermisoEmpresaController.EnBlanco();
                    iPermEmpresa.Adicionales.EsVerdad = false;
                    iPermEmpresa.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.codEmpresa + Cadena.Espacios(1) + "esta desactivada";
                    return iPermEmpresa;
                }
                //if (iPermEmpresa.CodigoPerfil != "01")
                //{
                    if (iPermEmpresa.cPermitir == 0) //no tiene permiso
                    {
                        iPermEmpresa = GestionClubPermisoEmpresaController.EnBlanco();
                        iPermEmpresa.Adicionales.EsVerdad = false;
                        iPermEmpresa.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.codEmpresa + Cadena.Espacios(1) + "no esta autorizada para este usuario";
                        return iPermEmpresa;
                    }
                //}
            }
            //si llega hasta aqui entonces si tiene permiso
            iPermEmpresa.Adicionales.EsVerdad = true;
            return iPermEmpresa;

        }
        public static List<GestionClubPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(GestionClubPermisoEmpresaDto pObj)
        {
            GestionClubPermisoEmpresaRepository iPerm = new GestionClubPermisoEmpresaRepository();
            return iPerm.ListarPermisosEmpresaActivasXUsuarioYAutorizadas(pObj);
        }
    }
}
