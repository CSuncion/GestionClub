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
    public class GestionClubAperturaCajaController
    {
        private readonly IGestionClubAperturaCajaRepository _iGestionClubAperturaCajaRepository;

        public GestionClubAperturaCajaController()
        {
            this._iGestionClubAperturaCajaRepository = new GestionClubAperturaCajaRepository();
        }
        public List<GestionClubAperturaCajaDto> ListarAperturaCajas()
        {
            GestionClubAperturaCajaRepository obj = new GestionClubAperturaCajaRepository();
            return obj.ListarAperturaCajas();
        }
        public static GestionClubAperturaCajaDto ListarAperturaCajasPorFecha(GestionClubAperturaCajaDto obj)
        {
            GestionClubAperturaCajaRepository xObj = new GestionClubAperturaCajaRepository();
            return xObj.ListarAperturaCajasPorFecha(obj);
        }
        public List<GestionClubAperturaCajaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubAperturaCajaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubAperturaCajaDto> iLisRes = new List<GestionClubAperturaCajaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubAperturaCajaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubAperturaCajaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubAperturaCajaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubAperturaCajaDto> iLisRes = new List<GestionClubAperturaCajaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubAperturaCajaDto xOperations in pLista)
            {
                string iTexto = GestionClubAperturaCajaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static GestionClubAperturaCajaDto EnBlanco()
        {
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();
            return iPerEN;
        }
        public static string ObtenerValorDeCampo(GestionClubAperturaCajaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubAperturaCajaDto._fecAperturaCaja: return pObj.fecAperturaCaja.ToString();
                case GestionClubAperturaCajaDto._montoAperturaCaja: return pObj.montoAperturaCaja.ToString();
                case GestionClubAperturaCajaDto._estadoAperturaCaja: return pObj.estadoAperturaCaja.ToString();
                case GestionClubAperturaCajaDto._claveObjeto: return pObj.claveObjeto.ToString();
                case GestionClubAperturaCajaDto._idAperturaCaja: return pObj.idAperturaCaja.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubAperturaCajaDto ValidaCuandoFechaYaExiste(GestionClubAperturaCajaDto pObj)
        {
            //objeto resultado
            GestionClubAperturaCajaDto iAperCaja = new GestionClubAperturaCajaDto();

            //validar    
            iAperCaja = GestionClubAperturaCajaController.ListarAperturaCajasPorFecha(pObj);
            if (iAperCaja.idAperturaCaja.ToString() != "0")
            {
                iAperCaja.Adicionales.EsVerdad = false;
                iAperCaja.Adicionales.Mensaje = "La fecha " + pObj.fecAperturaCaja + " ya existe";
                return iAperCaja;
            }

            //ok
            iAperCaja.Adicionales.EsVerdad = true;
            return iAperCaja;
        }
        public static GestionClubAperturaCajaDto BuscarAperturaCajaXId(GestionClubAperturaCajaDto pObj)
        {
            GestionClubAperturaCajaRepository objAperturaCaja = new GestionClubAperturaCajaRepository();
            return objAperturaCaja.ListarAperturaCajaPorId(pObj);
        }
        public static GestionClubAperturaCajaDto EsFechaAperturaCajaDisponible(GestionClubAperturaCajaDto pObj)
        {
            //objeto resultado
            GestionClubAperturaCajaDto iAmbEN = new GestionClubAperturaCajaDto();

            //valida cuando el codigo esta vacio
            //if (pObj.fecAperturaCaja.ToShortDateString() == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubAperturaCajaController.ValidaCuandoFechaYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static void AdicionarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            GestionClubAperturaCajaRepository objAperturaCaja = new GestionClubAperturaCajaRepository();
            objAperturaCaja.AgregarAperturaCaja(pObj);
        }
        public static GestionClubAperturaCajaDto EsActoModificarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            //objeto resultado
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();

            //validar si existe
            iPerEN = GestionClubAperturaCajaController.EsAperturaCajaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubAperturaCajaDto EsAperturaCajaExistente(GestionClubAperturaCajaDto pObj)
        {
            //objeto resultado
            GestionClubAperturaCajaDto iAmbEN = new GestionClubAperturaCajaDto();

            //validar
            //pObj.ClavePersonal = GestionClubAperturaCajaController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubAperturaCajaController.ListarAperturaCajasPorFecha(pObj);
            if (iAmbEN.fecAperturaCaja.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El AperturaCaja " + pObj.fecAperturaCaja + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static void ModificarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            GestionClubAperturaCajaRepository objAperturaCaja = new GestionClubAperturaCajaRepository();
            objAperturaCaja.ModificarAperturaCaja(pObj);
        }
        public static GestionClubAperturaCajaDto EsActoEliminarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            //objeto resultado
            GestionClubAperturaCajaDto iPerEN = new GestionClubAperturaCajaDto();

            //validar si existe
            iPerEN = GestionClubAperturaCajaController.EsAperturaCajaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static void EliminarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            GestionClubAperturaCajaRepository objAperturaCaja = new GestionClubAperturaCajaRepository();
            objAperturaCaja.EliminarAperturaCaja(pObj);
        }
    }
}
