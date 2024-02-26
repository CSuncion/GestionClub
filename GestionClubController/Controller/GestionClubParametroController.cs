using GestionClubModel.ModelDto;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubParametroController
    {
        public static List<GestionClubParametroDto> ListarParametro()
        {
            GestionClubParametroRepository oRepo = new GestionClubParametroRepository();
            return oRepo.ListarParametro();
        }
        public List<GestionClubParametroDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubParametroDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubParametroDto> iLisRes = new List<GestionClubParametroDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubParametroController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubParametroDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubParametroDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubParametroDto> iLisRes = new List<GestionClubParametroDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubParametroDto xOperations in pLista)
            {
                string iTexto = GestionClubParametroController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(GestionClubParametroDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubParametroDto._RutaLogoEmpresa: return pObj.RutaLogoEmpresa.ToString();
                case GestionClubParametroDto._PorcentajeIgv: return pObj.PorcentajeIgv.ToString();
                case GestionClubParametroDto._PorcentajeDetra: return pObj.PorcentajeDetra.ToString();
                case GestionClubParametroDto._NombreSoles: return pObj.NombreSoles.ToString();
                case GestionClubParametroDto._NombreDolares: return pObj.NombreDolares.ToString();
                case GestionClubParametroDto._RutaImagenCategoria: return pObj.RutaImagenCategoria.ToString();
                case GestionClubParametroDto._RutaImagenProducto: return pObj.RutaImagenProducto.ToString();
                case GestionClubParametroDto._RutaImagenMesa: return pObj.RutaImagenMesa.ToString();
                case GestionClubParametroDto._RutaImagenQR: return pObj.RutaImagenQR.ToString();
            }

            //retorna
            return iValor;
        }
        public static GestionClubParametroDto EsActoModificarParametro(GestionClubParametroDto pObj)
        {
            //objeto resultado
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();

            //validar si existe
            iPerEN = GestionClubParametroController.EsParametroExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }
        public static GestionClubParametroDto EsParametroExistente(GestionClubParametroDto pObj)
        {
            //objeto resultado
            GestionClubParametroDto iAmbEN = new GestionClubParametroDto();

            //validar
            //pObj.ClavePersonal = GestionClubAmbienteController.ObtenerClavePersonal(pObj);
            iAmbEN = GestionClubParametroController.BuscarParametroXId(pObj);
            if (iAmbEN.PorcentajeIgv == 0)
            {
                iAmbEN.Adicionales.EsVerdad = false;
                iAmbEN.Adicionales.Mensaje = "El parametro no existe";
                return iAmbEN;
            }

            //ok         
            return iAmbEN;
        }
        public static GestionClubParametroDto BuscarParametroXId(GestionClubParametroDto pObj)
        {
            GestionClubParametroRepository objAmbiente = new GestionClubParametroRepository();
            return objAmbiente.ListarParametro().Where(x => x.PorcentajeIgv == pObj.PorcentajeIgv).First();
        }
        public static GestionClubParametroDto EnBlanco()
        {
            GestionClubParametroDto iPerEN = new GestionClubParametroDto();
            return iPerEN;
        }
        public static void ModificarParametro(GestionClubParametroDto pObj)
        {
            GestionClubParametroRepository objRepo = new GestionClubParametroRepository();
            objRepo.ModificarParametro(pObj);
        }
    }
}
