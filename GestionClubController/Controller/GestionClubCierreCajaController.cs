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
    public class GestionClubCierreCajaController
    {
        private readonly IGestionClubCierreCajaRepository _iGestionClubCierreCajaRepository;

        public GestionClubCierreCajaController()
        {
            this._iGestionClubCierreCajaRepository = new GestionClubCierreCajaRepository();
        }
        public List<GestionClubCierreCajaDto> ListarCierreCajas()
        {
            GestionClubCierreCajaRepository xObj = new GestionClubCierreCajaRepository();
            return xObj.ListarCierreCajas();
        }
        public static GestionClubCierreCajaDto ListarCierreCajasPorFechaPorCaja(GestionClubCierreCajaDto obj)
        {
            GestionClubCierreCajaRepository xObj = new GestionClubCierreCajaRepository();
            return xObj.ListarCierreCajaPorFechaPorCaja(obj);
        }
        public List<GestionClubCierreCajaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubCierreCajaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubCierreCajaDto> iLisRes = new List<GestionClubCierreCajaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubCierreCajaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubCierreCajaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubCierreCajaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubCierreCajaDto> iLisRes = new List<GestionClubCierreCajaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubCierreCajaDto xOperations in pLista)
            {
                string iTexto = GestionClubCierreCajaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubCierreCajaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubCierreCajaDto._fecCierreCaja: return pObj.fecCierreCaja.ToString();
                case GestionClubCierreCajaDto._montoCierreCaja: return pObj.montoCierreCaja.ToString();
                case GestionClubCierreCajaDto._estadoCierreCaja: return pObj.estadoCierreCaja.ToString();
                case GestionClubCierreCajaDto._claveObjeto: return pObj.claveObjeto.ToString();
                case GestionClubCierreCajaDto._idCierreCaja: return pObj.idCierreCaja.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubCierreCajaDto ValidaCuandoFechaYaExiste(GestionClubCierreCajaDto pObj)
        {
            //objeto resultado
            GestionClubCierreCajaDto iAperCaja = new GestionClubCierreCajaDto();

            //validar    
            iAperCaja = GestionClubCierreCajaController.ListarCierreCajasPorFechaPorCaja(pObj);
            if (iAperCaja.idCierreCaja.ToString() != "0")
            {
                iAperCaja.Adicionales.EsVerdad = false;
                iAperCaja.Adicionales.Mensaje = "La fecha " + pObj.fecCierreCaja + " ya existe";
                return iAperCaja;
            }

            //ok
            iAperCaja.Adicionales.EsVerdad = true;
            return iAperCaja;
        }
        public static GestionClubCierreCajaDto BuscarCierreCajaXId(GestionClubCierreCajaDto pObj)
        {
            GestionClubCierreCajaRepository objCierreCaja = new GestionClubCierreCajaRepository();
            return objCierreCaja.ListarCierreCajaPorId(pObj);
        }
        public static GestionClubCierreCajaDto EsFechaCierreCajaDisponible(GestionClubCierreCajaDto pObj)
        {
            //objeto resultado
            GestionClubCierreCajaDto iAmbEN = new GestionClubCierreCajaDto();

            //valida cuando el codigo esta vacio
            //if (pObj.fecCierreCaja.ToShortDateString() == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubCierreCajaController.ValidaCuandoFechaYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static void AdicionarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            GestionClubCierreCajaRepository objCierreCaja = new GestionClubCierreCajaRepository();
            objCierreCaja.AgregarCierreCaja(pObj);
        }
        public static GestionClubCierreCajaDto EsActoModificarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            //objeto resultado
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();

            //validar si existe
            iPerEN = GestionClubCierreCajaController.EsCierreCajaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubCierreCajaDto EsCierreCajaExistente(GestionClubCierreCajaDto pObj)
        {
            //objeto resultado
            GestionClubCierreCajaDto iAmbEN = new GestionClubCierreCajaDto();

            //validar
            //pObj.ClavePersonal = GestionClubCierreCajaController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubCierreCajaController.ListarCierreCajasPorFechaPorCaja(pObj);
            if (iAmbEN.fecCierreCaja.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El CierreCaja " + pObj.fecCierreCaja.ToShortDateString() + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static void ModificarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            GestionClubCierreCajaRepository objCierreCaja = new GestionClubCierreCajaRepository();
            objCierreCaja.ModificarCierreCaja(pObj);
        }
        public static GestionClubCierreCajaDto EsActoEliminarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            //objeto resultado
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();

            //validar si existe
            iPerEN = GestionClubCierreCajaController.EsCierreCajaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static void EliminarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            GestionClubCierreCajaRepository objCierreCaja = new GestionClubCierreCajaRepository();
            objCierreCaja.EliminarCierreCaja(pObj);
        }
        public static GestionClubCierreCajaDto EnBlanco()
        {
            GestionClubCierreCajaDto iPerEN = new GestionClubCierreCajaDto();
            return iPerEN;
        }
    }
}
