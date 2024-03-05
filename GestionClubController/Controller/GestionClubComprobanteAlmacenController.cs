using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubComprobanteAlmacenController
    {
        private readonly IGestionClubComprobanteAlmacenRepository _iCreditComprobanteRepository;

        public GestionClubComprobanteAlmacenController()
        {
            this._iCreditComprobanteRepository = new GestionClubComprobanteAlmacenRepository();
        }

        public static void EliminarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            obj.EliminarComprobanteAlmacen(pObj);
        }
        public static void EliminarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            obj.EliminarComprobanteDetalleAlmacen(pObj);
        }
        public static void ModificarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            obj.ModificarComprobanteAlmacen(pObj);
        }
        public static void ModificarDetalleComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            obj.ModificarDetalleComprobanteAlmacen(pObj);
        }
        public static int AgregarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            return obj.AgregarComprobanteAlmacen(pObj);
        }
        public static void AgregarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            obj.AgregarComprobanteDetalleAlmacen(pObj);
        }
        public static List<GestionClubComprobanteDetalleAlmacenDto> RefrescarListaComprobanteDeta(List<GestionClubComprobanteDetalleAlmacenDto> pLis)
        {
            List<GestionClubComprobanteDetalleAlmacenDto> iLisRes = new List<GestionClubComprobanteDetalleAlmacenDto>();
            foreach (GestionClubComprobanteDetalleAlmacenDto xComDet in pLis)
            {
                iLisRes.Add(xComDet);
            }
            return iLisRes;
        }
        public static List<GestionClubComprobanteAlmacenDto> ListarComprobantes(GestionClubComprobanteAlmacenDto objEn)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            return obj.ListarComprobanteAlmacen(objEn);
        }
        public static GestionClubComprobanteAlmacenDto ListarComprobanteAlmacenPorId(GestionClubComprobanteAlmacenDto objEn)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            return obj.ListarComprobanteAlmacenPorId(objEn);
        }
        public static List<GestionClubComprobanteDetalleAlmacenDto> ListarComprobanteDetalleAlmacenPorComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto objEn)
        {
            GestionClubComprobanteAlmacenRepository obj = new GestionClubComprobanteAlmacenRepository();
            return obj.ListarComprobanteDetalleAlmacenPorComprobanteAlmacen(objEn);
        }
        public List<GestionClubComprobanteAlmacenDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubComprobanteAlmacenDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubComprobanteAlmacenDto> iLisRes = new List<GestionClubComprobanteAlmacenDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubComprobanteAlmacenController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubComprobanteAlmacenDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubComprobanteAlmacenDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubComprobanteAlmacenDto> iLisRes = new List<GestionClubComprobanteAlmacenDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubComprobanteAlmacenDto xOperations in pLista)
            {
                string iTexto = GestionClubComprobanteAlmacenController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(GestionClubComprobanteAlmacenDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubComprobanteAlmacenDto._nroDocumento: return pObj.nroDocumento;
                case GestionClubComprobanteAlmacenDto._serNroFactura: return pObj.serNroFactura;
                case GestionClubComprobanteAlmacenDto._tipoMovimiento: return pObj.tipoMovimiento;
                case GestionClubComprobanteAlmacenDto._tipFactura: return pObj.tipFactura.ToString();
                case GestionClubComprobanteAlmacenDto._fecFactura: return pObj.fecFactura.ToString();
                case GestionClubComprobanteAlmacenDto._razSocial: return pObj.razSocial;
                case GestionClubComprobanteAlmacenDto._totBru: return pObj.totBru.ToString();
                case GestionClubComprobanteAlmacenDto._estAlmacen: return pObj.estAlmacen;
                case GestionClubComprobanteAlmacenDto._idComprobanteAlmacen: return pObj.idComprobanteAlmacen.ToString();
                case GestionClubComprobanteAlmacenDto._claveObjeto: return pObj.claveObjeto;
            }

            //retorna
            return iValor;
        }
        public static GestionClubComprobanteAlmacenDto EsActoModificarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            //objeto resultado
            GestionClubComprobanteAlmacenDto iPerEN = new GestionClubComprobanteAlmacenDto();

            //validar si existe
            iPerEN = GestionClubComprobanteAlmacenController.EsComprobanteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubComprobanteAlmacenDto EsActoEliminarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            //objeto resultado
            GestionClubComprobanteAlmacenDto iPerEN = new GestionClubComprobanteAlmacenDto();

            //validar si existe
            iPerEN = GestionClubComprobanteAlmacenController.EsComprobanteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubComprobanteAlmacenDto EsComprobanteExistente(GestionClubComprobanteAlmacenDto pObj)
        {
            //objeto resultado
            GestionClubComprobanteAlmacenDto iObjEN = new GestionClubComprobanteAlmacenDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iObjEN = GestionClubComprobanteAlmacenController.BuscarComprobanteAlmacenXId(pObj);
            if (iObjEN.serFactura + iObjEN.nroFactura == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El comprobante " + iObjEN.serFactura + "-" + iObjEN.nroFactura + " no existe";
                return iObjEN;
            }

            //ok         
            return iObjEN;
        }
        public static GestionClubComprobanteAlmacenDto BuscarComprobanteAlmacenXId(GestionClubComprobanteAlmacenDto pObj)
        {
            GestionClubComprobanteAlmacenRepository objRepo = new GestionClubComprobanteAlmacenRepository();
            return objRepo.ListarComprobanteAlmacenPorId(pObj);
        }
        public static GestionClubComprobanteAlmacenDto EnBlanco()
        {
            GestionClubComprobanteAlmacenDto iPerEN = new GestionClubComprobanteAlmacenDto();
            return iPerEN;
        }
        public static GestionClubComprobanteDetalleAlmacenDto EnBlancoDetalle()
        {
            GestionClubComprobanteDetalleAlmacenDto iPerEN = new GestionClubComprobanteDetalleAlmacenDto();
            return iPerEN;
        }
        public static List<GestionClubComprobanteAlmacenDto> ResumenAnioMesAlmacen(string anio, string mes)
        {
            GestionClubComprobanteAlmacenRepository objRepo = new GestionClubComprobanteAlmacenRepository();
            return objRepo.ResumenAnioMesAlmacen(anio, mes);
        }
    }
}
