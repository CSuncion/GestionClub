using GestionClubModel.ModelDto;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubResultadoNubeFactController
    {
        public static void AdicionarResultadoNubeFact(GestionClubResultadoNubeFactDto pObj)
        {
            GestionClubResultadoNubeFactRepository obj = new GestionClubResultadoNubeFactRepository();
            obj.AdicionarResultadoNubeFact(pObj);
        }
        public static void AdicionarErrorNubeFact(GestionClubErrorNubeFactDto pObj)
        {
            GestionClubResultadoNubeFactRepository obj = new GestionClubResultadoNubeFactRepository();
            obj.AdicionarErrorNubeFact(pObj);
        }
        public static List<GestionClubResultadoNubeFactDto> ListadoResultadoNubeFact()
        {
            GestionClubResultadoNubeFactRepository obj = new GestionClubResultadoNubeFactRepository();
            return obj.ListadoResultadoNubeFact();
        }
        public static List<GestionClubErrorNubeFactDto> ListadoErrorsNubeFact()
        {
            GestionClubResultadoNubeFactRepository obj = new GestionClubResultadoNubeFactRepository();
            return obj.ListadoErrorsNubeFact();
        }
        public List<GestionClubResultadoNubeFactDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<GestionClubResultadoNubeFactDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubResultadoNubeFactDto> iLisRes = new List<GestionClubResultadoNubeFactDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubResultadoNubeFactController.FiltrarOperationsXTextoEnCualquierPosicion(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubResultadoNubeFactDto> FiltrarOperationsXTextoEnCualquierPosicion(List<GestionClubResultadoNubeFactDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubResultadoNubeFactDto> iLisRes = new List<GestionClubResultadoNubeFactDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubResultadoNubeFactDto xOperations in pLista)
            {
                string iTexto = GestionClubResultadoNubeFactController.ObtenerValorDeCampo(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static GestionClubResultadoNubeFactDto EnBlanco()
        {
            GestionClubResultadoNubeFactDto iPerEN = new GestionClubResultadoNubeFactDto();
            return iPerEN;
        }
        public static string ObtenerValorDeCampo(GestionClubResultadoNubeFactDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubResultadoNubeFactDto._tipo_de_comprobante: return pObj.tipo_de_comprobante.ToString();
                case GestionClubResultadoNubeFactDto._serie: return pObj.serie.ToString();
                case GestionClubResultadoNubeFactDto._numero: return pObj.numero.ToString();
                case GestionClubResultadoNubeFactDto._enlace: return pObj.enlace.ToString();
                case GestionClubResultadoNubeFactDto._sunat_ticket_numero: return pObj.sunat_ticket_numero.ToString();
                case GestionClubResultadoNubeFactDto._aceptada_por_sunat: return pObj.aceptada_por_sunat.ToString();
                case GestionClubResultadoNubeFactDto._sunat_description: return pObj.sunat_description.ToString();
                case GestionClubResultadoNubeFactDto._sunat_note: return pObj.sunat_note.ToString();
                case GestionClubResultadoNubeFactDto._sunat_responsecode: return pObj.sunat_responsecode.ToString();
                case GestionClubResultadoNubeFactDto._sunat_soap_error: return pObj.sunat_soap_error.ToString();
                case GestionClubResultadoNubeFactDto._anulado: return pObj.anulado.ToString();
                case GestionClubResultadoNubeFactDto._pdf_zip_base64: return pObj.pdf_zip_base64.ToString();
                case GestionClubResultadoNubeFactDto._xml_zip_base64: return pObj.xml_zip_base64.ToString();
                case GestionClubResultadoNubeFactDto._cdr_zip_base64: return pObj.cdr_zip_base64.ToString();
                case GestionClubResultadoNubeFactDto._cadena_para_codigo_qr: return pObj.cadena_para_codigo_qr.ToString();
                case GestionClubResultadoNubeFactDto._codigo_hash: return pObj.codigo_hash.ToString();
                case GestionClubResultadoNubeFactDto._key: return pObj.key.ToString();
                case GestionClubResultadoNubeFactDto._enlace_del_pdf: return pObj.enlace_del_pdf.ToString();
                case GestionClubResultadoNubeFactDto._enlace_del_xml: return pObj.enlace_del_xml.ToString();
                case GestionClubResultadoNubeFactDto._enlace_del_cdr: return pObj.enlace_del_cdr.ToString();
            }

            //retorna
            return iValor;
        }
        public List<GestionClubErrorNubeFactDto> ListarDatosParaGrillaPrincipalErrores(string pValorBusqueda, string pCampoBusqueda, List<GestionClubErrorNubeFactDto> pListaOperations)
        {
            //lista resultado
            List<GestionClubErrorNubeFactDto> iLisRes = new List<GestionClubErrorNubeFactDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaOperations; }

            //filtar la lista
            iLisRes = GestionClubResultadoNubeFactController.FiltrarOperationsXTextoEnCualquierPosicionErrores(pListaOperations, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<GestionClubErrorNubeFactDto> FiltrarOperationsXTextoEnCualquierPosicionErrores(List<GestionClubErrorNubeFactDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<GestionClubErrorNubeFactDto> iLisRes = new List<GestionClubErrorNubeFactDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (GestionClubErrorNubeFactDto xOperations in pLista)
            {
                string iTexto = GestionClubResultadoNubeFactController.ObtenerValorDeCampoErrores(xOperations, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xOperations);
                }
            }

            //devolver
            return iLisRes;
        }
        public static GestionClubErrorNubeFactDto EnBlancoErrores()
        {
            GestionClubErrorNubeFactDto iPerEN = new GestionClubErrorNubeFactDto();
            return iPerEN;
        }
        public static string ObtenerValorDeCampoErrores(GestionClubErrorNubeFactDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case GestionClubErrorNubeFactDto._tipo_de_comprobante: return pObj.tipo_de_comprobante.ToString();
                case GestionClubErrorNubeFactDto._serie: return pObj.serie.ToString();
                case GestionClubErrorNubeFactDto._numero: return pObj.numero.ToString();
                case GestionClubErrorNubeFactDto._errors: return pObj.errors.ToString();
                case GestionClubErrorNubeFactDto._codigo: return pObj.codigo.ToString();
            }

            //retorna
            return iValor;
        }

    }
}
