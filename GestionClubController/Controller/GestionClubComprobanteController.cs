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
    public class GestionClubComprobanteController
    {
        private readonly IGestionClubComprobanteRepository _iCreditComprobanteRepository;

        public GestionClubComprobanteController()
        {
            this._iCreditComprobanteRepository = new GestionClubComprobanteRepository();
        }

        public static void EliminarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.EliminarComprobante(pObj);
        }
        public static void ModificarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.ModificarComprobante(pObj);
        }
        public static void ModificarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.ModificarDetalleComprobante(pObj);
        }
        public static int AgregarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.AgregarComprobante(pObj);
        }
        public static void AgregarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.AgregarDetalleComprobante(pObj);
        }
        public static List<GestionClubDetalleComprobanteDto> RefrescarListaComprobanteDeta(List<GestionClubDetalleComprobanteDto> pLis)
        {
            List<GestionClubDetalleComprobanteDto> iLisRes = new List<GestionClubDetalleComprobanteDto>();
            foreach (GestionClubDetalleComprobanteDto xComDet in pLis)
            {
                iLisRes.Add(xComDet);
            }
            return iLisRes;
        }
        public static List<GestionClubComprobanteDto> ListarComprobantes(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesSinComanda(objEn);
        }
        public static List<GestionClubComprobanteDto> ListarComprobantesNotaDeCredito(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesNotaDeCredito(objEn);
        }
        public static GestionClubComprobanteDto ListarComprobantesPorId(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesPorId(objEn);
        }
        public static List<GestionClubDetalleComprobanteDto> ListarDetallesComprobantesPorComprobante(GestionClubDetalleComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarDetallesComprobantesPorComprobante(objEn);
        }
        public List<GestionClubComprobanteDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubComprobanteDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubComprobanteDto> iLisRes = new List<GestionClubComprobanteDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubComprobanteController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubComprobanteDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubComprobanteDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubComprobanteDto> iLisRes = new List<GestionClubComprobanteDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubComprobanteDto xOperations in pLista)
            {
                string iTexto = GestionClubComprobanteController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(GestionClubComprobanteDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubComprobanteDto._serNroComprobante: return pObj.serNroComprobante;
                case GestionClubComprobanteDto._desTipComprobante: return pObj.desTipComprobante;
                case GestionClubComprobanteDto._fecComprobante: return pObj.fecComprobante.ToString();
                case GestionClubComprobanteDto._desMoneda: return pObj.desMoneda;
                case GestionClubComprobanteDto._nroIdentificacionCliente: return pObj.nroIdentificacionCliente;
                case GestionClubComprobanteDto._nombreRazSocialCliente: return pObj.nombreRazSocialCliente;
                case GestionClubComprobanteDto._desPagoComprobante: return pObj.desPagoComprobante;
                case GestionClubComprobanteDto._impNetComprobante: return pObj.impNetComprobante.ToString();
                case GestionClubComprobanteDto._estadoComprobante: return pObj.estadoComprobante;
                case GestionClubComprobanteDto._idComprobante: return pObj.idComprobante.ToString();
                case GestionClubComprobanteDto._claveObjeto: return pObj.claveObjeto;
            }

            //retorna
            return iValor;
        }
        public static GestionClubComprobanteDto EsActoModificarComprobante(GestionClubComprobanteDto pObj)
        {
            //objeto resultado
            GestionClubComprobanteDto iPerEN = new GestionClubComprobanteDto();

            //validar si existe
            iPerEN = GestionClubComprobanteController.EsComprobanteExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubComprobanteDto EsComprobanteExistente(GestionClubComprobanteDto pObj)
        {
            //objeto resultado
            GestionClubComprobanteDto iObjEN = new GestionClubComprobanteDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iObjEN = GestionClubComprobanteController.BuscarComprobanteXId(pObj);
            if (iObjEN.serComprobante + iObjEN.nroComprobante == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El comprobante " + iObjEN.serComprobante + "-" + iObjEN.nroComprobante + " no existe";
                return iObjEN;
            }

            //ok         
            return iObjEN;
        }
        public static GestionClubComprobanteDto BuscarComprobanteXId(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository objRepo = new GestionClubComprobanteRepository();
            return objRepo.ListarComprobantesPorId(pObj);
        }
        public static GestionClubComprobanteDto EnBlanco()
        {
            GestionClubComprobanteDto iPerEN = new GestionClubComprobanteDto();
            return iPerEN;
        }
        public static GestionClubDetalleComprobanteDto EnBlancoDetalle()
        {
            GestionClubDetalleComprobanteDto iPerEN = new GestionClubDetalleComprobanteDto();
            return iPerEN;
        }

        public static GestionClubComprobanteDto ListaComprobantePorNroComprobante(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListaComprobantePorNroComprobante(objEn);
        }


        public static List<GestionClubComprobanteDto> ListarComprobantesFacturaYBoletaPorFecha(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesFacturaYBoletaPorFecha(objEn);
        }
        public static List<GestionClubComprobanteDto> ListarComprobantesFacturaYBoletaPorFechaDesdeHasta(DateTime fecDesde, DateTime fecHasta)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesFacturaYBoletaPorFechaDesdeHasta(fecDesde, fecHasta);
        }
        public static List<GestionClubComprobanteDto> ListarComprobantes()
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantes();
        }
        public static List<dynamic> VentaAnualMensual(string anio)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.VentaAnualMensual(anio);
        }
        public static List<dynamic> VentaAnualMensualPorTipo(string anio, string tipo)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.VentaAnualMensualPorTipo(anio, tipo);
        }
        public static List<dynamic> ListarVentasPorCategoriaProductos(string anio, string categoria, string producto)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarVentasPorCategoriaProductos(anio, categoria, producto);
        }
        public static List<GestionClubDetalleComprobanteDto> ListarResumenVentasAnual(string anio, string categoria)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarResumenVentasAnual(anio, categoria);
        }
        public static List<GestionClubDetalleComprobanteDto> TopVentaProductos(string anio)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.TopVentaProductos(anio);
        }
        public static bool ValidaExisteClienteComprobante(GestionClubClienteDto cliente)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            List<GestionClubComprobanteDto> comprobante = obj.ListarComprobantes().Where(x => x.idCliente == cliente.idCliente).ToList();
            if (comprobante.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static bool ValidaExisteProductoComprobante(GestionClubProductoDto producto)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            List<GestionClubDetalleComprobanteDto> comprobante = obj.ListarDetallesComprobantes().Where(x => x.idProducto == producto.idProducto).ToList();
            if (comprobante.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static void ModificarComprobanteAnulado(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.ModificarComprobanteAnulado(pObj);
        }
        public static List<GestionClubComprobanteDto> ListarComprobantesConComanda(GestionClubComprobanteDto objEn)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.ListarComprobantesConComanda(objEn);
        }

    }
}
