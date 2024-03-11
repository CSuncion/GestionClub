using Comun;
using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionClubRepository.Repository
{
    public class GestionClubResultadoNubeFactRepository : IGestionClubResultadoNubeFactRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubResultadoNubeFactDto xObj = new GestionClubResultadoNubeFactDto();
        private List<GestionClubResultadoNubeFactDto> xLista = new List<GestionClubResultadoNubeFactDto>();
        private GestionClubErrorNubeFactDto xObjErrors = new GestionClubErrorNubeFactDto();
        private List<GestionClubErrorNubeFactDto> xListaErrors = new List<GestionClubErrorNubeFactDto>();
        private GestionClubResultadoNubeFactDto ObjetoResultado(IDataReader iDr)
        {
            GestionClubResultadoNubeFactDto xObjEnc = new GestionClubResultadoNubeFactDto();
            xObjEnc.tipo_de_comprobante = iDr[GestionClubResultadoNubeFactDto._tipo_de_comprobante].ToString();
            xObjEnc.serie = iDr[GestionClubResultadoNubeFactDto._serie].ToString();
            xObjEnc.numero = iDr[GestionClubResultadoNubeFactDto._numero].ToString();
            xObjEnc.enlace = iDr[GestionClubResultadoNubeFactDto._enlace].ToString();
            xObjEnc.aceptada_por_sunat = iDr[GestionClubResultadoNubeFactDto._aceptada_por_sunat].ToString();
            xObjEnc.sunat_description = iDr[GestionClubResultadoNubeFactDto._sunat_description].ToString();
            xObjEnc.sunat_note = iDr[GestionClubResultadoNubeFactDto._sunat_note].ToString();
            xObjEnc.sunat_responsecode = iDr[GestionClubResultadoNubeFactDto._sunat_responsecode].ToString();
            xObjEnc.sunat_soap_error = iDr[GestionClubResultadoNubeFactDto._sunat_soap_error].ToString();
            xObjEnc.anulado = iDr[GestionClubResultadoNubeFactDto._anulado].ToString();
            xObjEnc.pdf_zip_base64 = iDr[GestionClubResultadoNubeFactDto._pdf_zip_base64].ToString();
            xObjEnc.xml_zip_base64 = iDr[GestionClubResultadoNubeFactDto._xml_zip_base64].ToString();
            xObjEnc.cdr_zip_base64 = iDr[GestionClubResultadoNubeFactDto._cdr_zip_base64].ToString();
            xObjEnc.cadena_para_codigo_qr = iDr[GestionClubResultadoNubeFactDto._cadena_para_codigo_qr].ToString();
            xObjEnc.codigo_hash = iDr[GestionClubResultadoNubeFactDto._codigo_hash].ToString();
            xObjEnc.enlace_del_pdf = iDr[GestionClubResultadoNubeFactDto._enlace_del_pdf].ToString();
            xObjEnc.enlace_del_xml = iDr[GestionClubResultadoNubeFactDto._enlace_del_xml].ToString();
            xObjEnc.enlace_del_cdr = iDr[GestionClubResultadoNubeFactDto._enlace_del_cdr].ToString();

            return xObjEnc;
        }
        private GestionClubErrorNubeFactDto ObjetoErrors(IDataReader iDr)
        {
            GestionClubErrorNubeFactDto xObjEnc = new GestionClubErrorNubeFactDto();
            xObjEnc.tipo_de_comprobante = iDr[GestionClubErrorNubeFactDto._tipo_de_comprobante].ToString();
            xObjEnc.serie = iDr[GestionClubErrorNubeFactDto._serie].ToString();
            xObjEnc.numero = iDr[GestionClubErrorNubeFactDto._numero].ToString();
            xObjEnc.errors = iDr[GestionClubErrorNubeFactDto._errors].ToString();
            xObjEnc.codigo = iDr[GestionClubErrorNubeFactDto._codigo].ToString();
            return xObjEnc;
        }

        private GestionClubResultadoNubeFactDto BuscarObjetoResultado(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.ObjetoResultado(xIdr);
            }
            xObjCn.Disconnect();
            return xObj;
        }
        private List<GestionClubResultadoNubeFactDto> ListarObjetosResultado(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.ObjetoResultado(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private List<GestionClubResultadoNubeFactDto> BuscarObjetoPorParametroResultado(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.ObjetoResultado(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private GestionClubErrorNubeFactDto BuscarObjetoErrors(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObjErrors = this.ObjetoErrors(xIdr);
            }
            xObjCn.Disconnect();
            return xObjErrors;
        }
        private List<GestionClubErrorNubeFactDto> ListarObjetosErrors(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaErrors.Add(this.ObjetoErrors(xIdr));
            }
            xObjCn.Disconnect();
            return xListaErrors;
        }
        private List<GestionClubErrorNubeFactDto> BuscarObjetoPorParametroErrors(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaErrors.Add(this.ObjetoErrors(xIdr));
            }
            xObjCn.Disconnect();
            return xListaErrors;
        }
        public void AdicionarResultadoNubeFact(GestionClubResultadoNubeFactDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@tipo_de_comprobante" ,pObj.tipo_de_comprobante),
                    new SqlParameter("@serie" ,pObj.serie),
                    new SqlParameter("@numero" ,pObj.numero),
                    new SqlParameter("@enlace" ,pObj.enlace),
                    new SqlParameter("@aceptada_por_sunat" ,pObj.aceptada_por_sunat),
                    new SqlParameter("@sunat_description" ,pObj.sunat_description),
                    new SqlParameter("@sunat_note" ,pObj.sunat_note),
                    new SqlParameter("@sunat_responsecode" ,pObj.sunat_responsecode),
                    new SqlParameter("@sunat_soap_error" ,pObj.sunat_soap_error),
                    new SqlParameter("@anulado" ,pObj.anulado),
                    new SqlParameter("@pdf_zip_base64" ,pObj.pdf_zip_base64),
                    new SqlParameter("@xml_zip_base64" ,pObj.xml_zip_base64),
                    new SqlParameter("@cdr_zip_base64" ,pObj.cdr_zip_base64),
                    new SqlParameter("@cadena_para_codigo_qr" ,pObj.cadena_para_codigo_qr),
                    new SqlParameter("@codigo_hash" ,pObj.codigo_hash),
                    new SqlParameter("@enlace_del_pdf" ,pObj.enlace_del_pdf),
                    new SqlParameter("@enlace_del_xml" ,pObj.enlace_del_xml),
                    new SqlParameter("@enlace_del_cdr" ,pObj.enlace_del_cdr),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AdicionarResultadoNubeFact");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void AdicionarErrorNubeFact(GestionClubErrorNubeFactDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@tipo_de_comprobante" ,pObj.tipo_de_comprobante),
                    new SqlParameter("@serie" ,pObj.serie),
                    new SqlParameter("@numero" ,pObj.numero),
                    new SqlParameter("@errors" ,pObj.errors),
                    new SqlParameter("@codigo" ,pObj.codigo)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AdicionarErrorNubeFact");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubErrorNubeFactDto> ListadoErrorsNubeFact()
        {
            return this.ListarObjetosErrors("isp_ListadoErrorsNubeFact");
        }
        public List<GestionClubResultadoNubeFactDto> ListadoResultadoNubeFact()
        {
            return this.ListarObjetosResultado("isp_ListadoResultadoNubeFact");
        }
    }
}
