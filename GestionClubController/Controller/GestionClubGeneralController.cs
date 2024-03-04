using GestionClubRepository.Repository;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClubModel.ModelDto;

namespace GestionClubController.Controller
{
    public class GestionClubGeneralController
    {
        private readonly IGestionClubGeneralRepository _iGestionClubGeneralRepository;
        public GestionClubGeneralController()
        {
            this._iGestionClubGeneralRepository = new GestionClubGeneralRepository();
        }
        public void CrearBackupDbFbPol()
        {
            this._iGestionClubGeneralRepository.CrearBackupDbFbPol();
        }
        public static List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTabla(string tabla)
        {
            GestionClubGeneralRepository objRepo = new GestionClubGeneralRepository();
            return objRepo.ListarSistemaDetallePorTabla(tabla);
        }
        public static List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTablaPorObs(string tabla, string obs)
        {
            GestionClubGeneralRepository objRepo = new GestionClubGeneralRepository();
            return objRepo.ListarSistemaDetallePorTablaPorObs(tabla, obs);
        }
        public static List<GestionClubSistemaDto> ListarSistema()
        {
            GestionClubGeneralRepository objRepo = new GestionClubGeneralRepository();
            return objRepo.ListarSistema();
        }
        public static GestionClubSistemaDetalleDto EnBlanco()
        {
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();
            return iPerEN;
        }
        public static GestionClubSistemaDetalleDto EsActoModificarDetalleSistema(GestionClubSistemaDetalleDto pObj)
        {
            //objeto resultado
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();

            //validar si existe
            iPerEN = GestionClubGeneralController.EsSistemaDetalleExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubSistemaDetalleDto EsSistemaDetalleExistente(GestionClubSistemaDetalleDto pObj)
        {
            //objeto resultado
            GestionClubSistemaDetalleDto iAmbEN = new GestionClubSistemaDetalleDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubGeneralController.BuscarSistemaDetalleXId(pObj);
            if (iAmbEN.codigo == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El detalle " + pObj.codigo + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubSistemaDetalleDto BuscarSistemaDetalleXId(GestionClubSistemaDetalleDto pObj)
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            return obj.ListarSistemaDetallePorId(pObj);
        }
        public static void AdicionarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            obj.AdicionarSistemaDetalle(pObj);
        }
        public static void ModificarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            obj.ModificarSistemaDetalle(pObj);
        }
        public static void EliminarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            obj.EliminarSistemaDetalle(pObj);
        }
        public static GestionClubSistemaDetalleDto EsActoEliminarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            //objeto resultado
            GestionClubSistemaDetalleDto iPerEN = new GestionClubSistemaDetalleDto();

            //validar si existe
            iPerEN = GestionClubGeneralController.EsSistemaDetalleExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubSistemaDetalleDto EsCodigoSistemaDetalleDisponible(GestionClubSistemaDetalleDto pObj)
        {
            //objeto resultado
            GestionClubSistemaDetalleDto iAmbEN = new GestionClubSistemaDetalleDto();

            //valida cuando el codigo esta vacio
            if (pObj.codigo == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubGeneralController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static GestionClubSistemaDetalleDto ValidaCuandoCodigoYaExiste(GestionClubSistemaDetalleDto pObj)
        {
            //objeto resultado
            GestionClubSistemaDetalleDto iObj = new GestionClubSistemaDetalleDto();

            //validar    
            iObj = GestionClubGeneralController.BuscarSistemaDetalleXCodigo(pObj);
            if (iObj.codigo != string.Empty)
            {
                iObj.Adicionales.EsVerdad = false;
                iObj.Adicionales.Mensaje = "El codigo " + pObj.codigo + " ya existe";
                return iObj;
            }

            //ok
            iObj.Adicionales.EsVerdad = true;
            return iObj;
        }
        public static GestionClubSistemaDetalleDto BuscarSistemaDetalleXCodigo(GestionClubSistemaDetalleDto pObj)
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            return obj.ListarSistemaDetallePorCodigo(pObj);
        }
        public static List<GestionClubSistemaDetalleDto> ListarSistemaDetalle()
        {
            GestionClubGeneralRepository obj = new GestionClubGeneralRepository();
            return obj.ListarSistemaDetalle();
        }
    }
}
