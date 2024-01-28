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
    public class GestionClubCategoriaController
    {
        private readonly IGestionClubCategoriaRepository _iCreditCategoriaRepository;

        public GestionClubCategoriaController()
        {
            this._iCreditCategoriaRepository = new GestionClubCategoriaRepository();
        }
        public static List<GestionClubCategoriaDto> ListarCategorias()
        {
            GestionClubCategoriaRepository oRepo = new GestionClubCategoriaRepository();
            return oRepo.ListarCategorias();
        }
        public List<GestionClubCategoriaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubCategoriaDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubCategoriaDto> iLisRes = new List<GestionClubCategoriaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubCategoriaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubCategoriaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubCategoriaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubCategoriaDto> iLisRes = new List<GestionClubCategoriaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubCategoriaDto xOperations in pLista)
            {
                string iTexto = GestionClubCategoriaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubCategoriaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubCategoriaDto._codCategoria: return pObj.codCategoria.ToString();
                case GestionClubCategoriaDto._desCategoria: return pObj.desCategoria;
                case GestionClubCategoriaDto._estadoCategoria: return pObj.estadoCategoria.ToString();
                case GestionClubCategoriaDto._idCategoria: return pObj.idCategoria.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubCategoriaDto EsActoModificarCategoria(GestionClubCategoriaDto pObj)
        {
            //objeto resultado
            GestionClubCategoriaDto iPerEN = new GestionClubCategoriaDto();

            //validar si existe
            iPerEN = GestionClubCategoriaController.EsCategoriaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubCategoriaDto EsCategoriaExistente(GestionClubCategoriaDto pObj)
        {
            //objeto resultado
            GestionClubCategoriaDto iAmbEN = new GestionClubCategoriaDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubCategoriaController.BuscarCategoriaXId(pObj);
            if (iAmbEN.codCategoria == string.Empty)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "La categoria " + pObj.codCategoria + " no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubCategoriaDto BuscarCategoriaXId(GestionClubCategoriaDto pObj)
        {
            GestionClubCategoriaRepository objRepo = new GestionClubCategoriaRepository();
            return objRepo.ListarCategoriaPorId(pObj);
        }
        public static GestionClubCategoriaDto EsActoEliminarCategoria(GestionClubCategoriaDto pObj)
        {
            //objeto resultado
            GestionClubCategoriaDto iObjEN = new GestionClubCategoriaDto();

            //validar si existe
            iObjEN = GestionClubCategoriaController.EsCategoriaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
        public static GestionClubCategoriaDto EnBlanco()
        {
            GestionClubCategoriaDto iPerEN = new GestionClubCategoriaDto();
            return iPerEN;
        }
        public static GestionClubCategoriaDto EsCodigoCategoriaDisponible(GestionClubCategoriaDto pObj)
        {
            //objeto resultado
            GestionClubCategoriaDto iAmbEN = new GestionClubCategoriaDto();

            //valida cuando el codigo esta vacio
            if (pObj.codCategoria == string.Empty) { return iAmbEN; }

            //valida cuando existe el codigo
            iAmbEN = GestionClubCategoriaController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAmbEN.Adicionales.EsVerdad == false) { return iAmbEN; }

            //ok          
            return iAmbEN;
        }
        public static GestionClubCategoriaDto ValidaCuandoCodigoYaExiste(GestionClubCategoriaDto pObj)
        {
            //objeto resultado
            GestionClubCategoriaDto iAmbiente = new GestionClubCategoriaDto();

            //validar    
            iAmbiente = GestionClubCategoriaController.BuscarCategoriaXClave(pObj);
            if (iAmbiente.codCategoria != string.Empty)
            {
                iAmbiente.Adicionales.EsVerdad = false;
                iAmbiente.Adicionales.Mensaje = "El codigo " + pObj.codCategoria + " ya existe";
                return iAmbiente;
            }

            //ok
            iAmbiente.Adicionales.EsVerdad = true;
            return iAmbiente;
        }
        public static GestionClubCategoriaDto BuscarCategoriaXClave(GestionClubCategoriaDto pObj)
        {
            GestionClubCategoriaRepository obj = new GestionClubCategoriaRepository();
            return obj.ListarCategoriaPorCodigoPorEmpresa(pObj);
        }
        public static void EliminarCategoria(GestionClubCategoriaDto pObj)
        {
            GestionClubCategoriaRepository obj = new GestionClubCategoriaRepository();
            obj.EliminarCategoria(pObj);
        }
        public static void ModificarCategoria(GestionClubCategoriaDto pObj)
        {
            GestionClubCategoriaRepository obj = new GestionClubCategoriaRepository();
            obj.ModificarCategoria(pObj);
        }
        public static void AdicionarCategoria(GestionClubCategoriaDto pObj)
        {
            GestionClubCategoriaRepository obj = new GestionClubCategoriaRepository();
            obj.AgregarCategoria(pObj);
        }
        public static List<GestionClubCategoriaDto> ListarCategoriasActivos()
        {
            GestionClubCategoriaRepository oRepo = new GestionClubCategoriaRepository();
            return oRepo.ListarCategoriasActivos();
        }
    }
}
