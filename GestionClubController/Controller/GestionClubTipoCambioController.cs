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
    public class GestionClubTipoCambioController
    {
        private readonly IGestionClubTipoCambioRepository _iGestionClubTipoCambioRepository;

        public GestionClubTipoCambioController()
        {
            this._iGestionClubTipoCambioRepository = new GestionClubTipoCambioRepository();
        }
        public List<GestionClubTipoCambioDto> ListarTipoCambio()
        {
            GestionClubTipoCambioRepository oRepo = new GestionClubTipoCambioRepository();
            return oRepo.ListarTipoCambio();
        }
        public static GestionClubTipoCambioDto ListarTipoCambioPorFecha(GestionClubTipoCambioDto obj)
        {
            GestionClubTipoCambioRepository xObj = new GestionClubTipoCambioRepository();
            return xObj.ListarTipoCambioPorFecha(obj);
        }
        public List<GestionClubTipoCambioDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubTipoCambioDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubTipoCambioDto> iLisRes = new List<GestionClubTipoCambioDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubTipoCambioController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubTipoCambioDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubTipoCambioDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubTipoCambioDto> iLisRes = new List<GestionClubTipoCambioDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubTipoCambioDto xOperations in pLista)
            {
                string iTexto = GestionClubTipoCambioController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static GestionClubTipoCambioDto EnBlanco()
        {
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();
            return iPerEN;
        }
        public static string ObtenerValorDeCampo(GestionClubTipoCambioDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubTipoCambioDto._FechaTipoCambio: return pObj.FechaTipoCambio.ToString();
                case GestionClubTipoCambioDto._CompraTipoCambio: return pObj.CompraTipoCambio.ToString();
                case GestionClubTipoCambioDto._VentaTipoCambio: return pObj.VentaTipoCambio.ToString();
                case GestionClubTipoCambioDto._CEstadoTipoCambio: return pObj.CEstadoTipoCambio.ToString();
                case GestionClubTipoCambioDto._claveObjeto: return pObj.claveObjeto.ToString();
                case GestionClubTipoCambioDto._idTipoCambio: return pObj.idTipoCambio.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubTipoCambioDto ValidaCuandoFechaYaExiste(GestionClubTipoCambioDto pObj)
        {
            //objeto resultado
            GestionClubTipoCambioDto iAperCaja = new GestionClubTipoCambioDto();

            //validar    
            iAperCaja = GestionClubTipoCambioController.ListarTipoCambioPorFecha(pObj);
            if (iAperCaja.idTipoCambio.ToString() != "0")
            {
                iAperCaja.Adicionales.EsVerdad = false;
                iAperCaja.Adicionales.Mensaje = "La fecha " + pObj.FechaTipoCambio + " ya existe";
                return iAperCaja;
            }

            //ok
            iAperCaja.Adicionales.EsVerdad = true;
            return iAperCaja;
        }
        public static GestionClubTipoCambioDto BuscarTipoCambioXId(GestionClubTipoCambioDto pObj)
        {
            GestionClubTipoCambioRepository objTipoCambio = new GestionClubTipoCambioRepository();
            return objTipoCambio.ListarTipoCambioPorId(pObj);
        }
        public static GestionClubTipoCambioDto EsFechaTipoCambioDisponible(GestionClubTipoCambioDto pObj)
        {
            //objeto resultado
            GestionClubTipoCambioDto iAmbEN = new GestionClubTipoCambioDto();

            //valida cuando el codigo esta vacio
            //if (pObj.fecTipoCambio.ToShortDateString() == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubTipoCambioController.ValidaCuandoFechaYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static void AdicionarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            GestionClubTipoCambioRepository objTipoCambio = new GestionClubTipoCambioRepository();
            objTipoCambio.AdicionarTipoCambio(pObj);
        }
        public static GestionClubTipoCambioDto EsActoModificarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            //objeto resultado
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();

            //validar si existe
            iPerEN = GestionClubTipoCambioController.EsTipoCambioExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubTipoCambioDto EsTipoCambioExistente(GestionClubTipoCambioDto pObj)
        {
            //objeto resultado
            GestionClubTipoCambioDto iAmbEN = new GestionClubTipoCambioDto();

            //validar
            //pObj.ClavePersonal = GestionClubTipoCambioController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubTipoCambioController.ListarTipoCambioPorFecha(pObj);
            if (iAmbEN.idTipoCambio == 0)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El Tipo Cambio " + pObj.FechaTipoCambio + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static void ModificarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            GestionClubTipoCambioRepository objTipoCambio = new GestionClubTipoCambioRepository();
            objTipoCambio.ModificarTipoCambio(pObj);
        }
        public static GestionClubTipoCambioDto EsActoEliminarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            //objeto resultado
            GestionClubTipoCambioDto iPerEN = new GestionClubTipoCambioDto();

            //validar si existe
            iPerEN = GestionClubTipoCambioController.EsTipoCambioExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static void EliminarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            GestionClubTipoCambioRepository objTipoCambio = new GestionClubTipoCambioRepository();
            objTipoCambio.EliminarTipoCambio(pObj);
        }

    }
}
