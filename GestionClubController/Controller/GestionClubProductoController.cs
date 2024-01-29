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
    public class GestionClubProductoController
    {
        private readonly IGestionClubProductoRepository _iCreditProductoRepository;

        public GestionClubProductoController()
        {
            this._iCreditProductoRepository = new GestionClubProductoRepository();
        }
        public static List<GestionClubProductoDto> ListarProductos()
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            return obj.ListarProductos();
        }
        public static List<GestionClubProductoDto> ListarProductosActivos()
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            return obj.ListarProductosActivos();
        }
        public static List<GestionClubProductoDto> ListarProductosActivosPorCategoria(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            return obj.ListarProductosActivosPorCategoria(pObj);
        }
        public List<GestionClubProductoDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubProductoDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubProductoDto> iLisRes = new List<GestionClubProductoDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubProductoController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubProductoDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubProductoDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubProductoDto> iLisRes = new List<GestionClubProductoDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubProductoDto xOperations in pLista)
            {
                string iTexto = GestionClubProductoController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubProductoDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubProductoDto._codProducto: return pObj.codProducto.ToString();
                case GestionClubProductoDto._desProducto: return pObj.desProducto;
                case GestionClubProductoDto._uniMedProducto: return pObj.uniMedProducto.ToString();
                case GestionClubProductoDto._codMoneda: return pObj.codMoneda.ToString();
                case GestionClubProductoDto._preCosProducto: return pObj.preCosProducto.ToString();
                case GestionClubProductoDto._preVtsProducto: return pObj.preVtsProducto.ToString();
                case GestionClubProductoDto._preVnsProducto: return pObj.preVnsProducto.ToString();
                case GestionClubProductoDto._afeIgvProducto: return pObj.afeIgvProducto.ToString();
                case GestionClubProductoDto._afeDtraProducto: return pObj.afeDtraProducto.ToString();
                case GestionClubProductoDto._porDtraProducto: return pObj.porDtraProducto.ToString();
                case GestionClubProductoDto._impDolProducto: return pObj.impDolProducto.ToString();
                case GestionClubProductoDto._impOtrProducto: return pObj.impOtrProducto.ToString();
                case GestionClubProductoDto._obsProducto: return pObj.obsProducto.ToString();
                case GestionClubProductoDto._estadoProducto: return pObj.estadoProducto.ToString();
                case GestionClubProductoDto._idProducto: return pObj.idProducto.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubProductoDto EsActoModificarProducto(GestionClubProductoDto pObj)
        {
            //objeto resultado
            GestionClubProductoDto iPerEN = new GestionClubProductoDto();

            //validar si existe
            iPerEN = GestionClubProductoController.EsProductoExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubProductoDto EsProductoExistente(GestionClubProductoDto pObj)
        {
            //objeto resultado
            GestionClubProductoDto iAmbEN = new GestionClubProductoDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubProductoController.BuscarProductoXId(pObj);
            if (iAmbEN.codProducto == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "La Producto " + pObj.codProducto + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubProductoDto BuscarProductoXId(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository objRepo = new GestionClubProductoRepository();
            return objRepo.ListarProductoPorId(pObj);
        }
        public static GestionClubProductoDto EsActoEliminarProducto(GestionClubProductoDto pObj)
        {
            //objeto resultado
            GestionClubProductoDto iObjEN = new GestionClubProductoDto();

            //validar si existe
            iObjEN = GestionClubProductoController.EsProductoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
        public static GestionClubProductoDto EnBlanco()
        {
            GestionClubProductoDto iPerEN = new GestionClubProductoDto();
            return iPerEN;
        }
        public static GestionClubProductoDto EsCodigoProductoDisponible(GestionClubProductoDto pObj)
        {
            //objeto resultado
            GestionClubProductoDto iAmbEN = new GestionClubProductoDto();

            //valida cuando el codigo esta vacio
            if (pObj.codProducto == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubProductoController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static GestionClubProductoDto ValidaCuandoCodigoYaExiste(GestionClubProductoDto pObj)
        {
            //objeto resultado
            GestionClubProductoDto iAmbiente = new GestionClubProductoDto();

            //validar    
            iAmbiente = GestionClubProductoController.BuscarProductoXClave(pObj);
            if (iAmbiente.codProducto != string.Empty)
            {
                iAmbiente.Adicionales.EsVerdad = false;
                iAmbiente.Adicionales.Mensaje = "El codigo " + pObj.codProducto + " ya existe";
                return iAmbiente;
            }

            //ok
            iAmbiente.Adicionales.EsVerdad = true;
            return iAmbiente;
        }
        public static GestionClubProductoDto BuscarProductoXClave(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            return obj.ListarProductoPorCodigoPorEmpresa(pObj);
        }
        public static void EliminarProducto(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            obj.EliminarProducto(pObj);
        }
        public static void ModificarProducto(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            obj.ModificarProducto(pObj);
        }
        public static void AdicionarProducto(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            obj.AgregarProducto(pObj);
        }
    }
}
