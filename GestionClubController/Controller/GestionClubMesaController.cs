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
    public class GestionClubMesaController
    {
        private readonly IGestionClubMesaRepository _iCreditMesaRepository;

        public GestionClubMesaController()
        {
            this._iCreditMesaRepository = new GestionClubMesaRepository();
        }
        public static List<GestionClubMesaDto> ListarMesas()
        {
            GestionClubMesaRepository oRepo = new GestionClubMesaRepository();
            return oRepo.ListarMesas();
        }
        public List<GestionClubMesaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubMesaDto> pListaOperations)
        {
            //lista GestionClubMesaDto
            List<GestionClubMesaDto> iLisRes = new List<GestionClubMesaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubMesaController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubMesaDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubMesaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubMesaDto> iLisRes = new List<GestionClubMesaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubMesaDto xOperations in pLista)
            {
                string iTexto = GestionClubMesaController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubMesaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubMesaDto._desAmbiente: return pObj.desAmbiente.ToString();
                case GestionClubMesaDto._codMesa: return pObj.codMesas.ToString();
                case GestionClubMesaDto._desMesa: return pObj.desMesas;
                case GestionClubMesaDto._estadoMesa: return pObj.estadoMesa.ToString();
                case GestionClubMesaDto._idMesa: return pObj.idMesa.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubMesaDto EnBlanco()
        {
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();
            return iObjEN;
        }
        public static GestionClubMesaDto EsActoModificarMesa(GestionClubMesaDto pObj)
        {
            //objeto resultado
            GestionClubMesaDto iPerEN = new GestionClubMesaDto();

            //validar si existe
            iPerEN = GestionClubMesaController.EsMesaExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubMesaDto EsMesaExistente(GestionClubMesaDto pObj)
        {
            //objeto resultado
            GestionClubMesaDto iobjEN = new GestionClubMesaDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iobjEN = GestionClubMesaController.BuscarMesaXId(pObj);
            if (iobjEN.codMesas == string.Empty)
            {
                iobjEN.Adicionales.EsVerdad = false;
                iobjEN.Adicionales.Mensaje = "La mesa " + pObj.codMesas + " no existe";
                return iobjEN;
            }

            //ok         
            return iobjEN;
        }
        public static GestionClubMesaDto BuscarMesaXId(GestionClubMesaDto pObj)
        {
            GestionClubMesaRepository objRepository = new GestionClubMesaRepository();
            return objRepository.ListarMesaPorId(pObj);
        }
        public static GestionClubMesaDto EsCodigoMesaDisponible(GestionClubMesaDto pObj)
        {
            //objeto resultado
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();

            //valida cuando el codigo esta vacio
            if (pObj.codMesas == string.Empty) { return iObjEN; }

            //valida cuando existe el codigo
            iObjEN = GestionClubMesaController.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }
        public static GestionClubMesaDto ValidaCuandoCodigoYaExiste(GestionClubMesaDto pObj)
        {
            //objeto resultado
            GestionClubMesaDto iObj = new GestionClubMesaDto();

            //validar    
            iObj = GestionClubMesaController.BuscarMesaXClave(pObj);
            if (iObj.codMesas != string.Empty)
            {
                iObj.Adicionales.EsVerdad = false;
                iObj.Adicionales.Mensaje = "El codigo " + pObj.codMesas + " ya existe";
                return iObj;
            }

            //ok
            iObj.Adicionales.EsVerdad = true;
            return iObj;
        }
        public static GestionClubMesaDto BuscarMesaXClave(GestionClubMesaDto pObj)
        {
            GestionClubMesaRepository objClave = new GestionClubMesaRepository();
            return objClave.ListarMesasPorCodigoPorEmpresa(pObj);
        }
        public static void AdicionarMesa(GestionClubMesaDto pObj)
        {
            GestionClubMesaRepository objRepo = new GestionClubMesaRepository();
            objRepo.AgregarMesa(pObj);
        }
        public static void ModificarMesa(GestionClubMesaDto pObj)
        {
            GestionClubMesaRepository objRepo = new GestionClubMesaRepository();
            objRepo.ModificarMesa(pObj);
        }
        public static void EliminarMesa(GestionClubMesaDto pObj)
        {
            GestionClubMesaRepository objRepo = new GestionClubMesaRepository();
            objRepo.EliminarMesa(pObj);
        }
        public static GestionClubMesaDto EsActoEliminarMesa(GestionClubMesaDto pObj)
        {
            //objeto resultado
            GestionClubMesaDto iObjEN = new GestionClubMesaDto();

            //validar si existe
            iObjEN = GestionClubMesaController.EsMesaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok            
            return iObjEN;
        }
    }
}
