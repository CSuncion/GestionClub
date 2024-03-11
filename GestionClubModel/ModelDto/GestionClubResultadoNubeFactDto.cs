using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubResultadoNubeFactDto
    {
        public const string _tipo_de_comprobante = "tipo_de_comprobante";
        public const string _serie = "serie";
        public const string _numero = "numero";
        public const string _enlace = "enlace";
        public const string _sunat_ticket_numero = "sunat_ticket_numero";
        public const string _aceptada_por_sunat = "aceptada_por_sunat";
        public const string _sunat_description = "sunat_description";
        public const string _sunat_note = "sunat_note";
        public const string _sunat_responsecode = "sunat_responsecode";
        public const string _sunat_soap_error = "sunat_soap_error";
        public const string _anulado = "anulado";
        public const string _pdf_zip_base64 = "pdf_zip_base64";
        public const string _xml_zip_base64 = "xml_zip_base64";
        public const string _cdr_zip_base64 = "cdr_zip_base64";
        public const string _cadena_para_codigo_qr = "cadena_para_codigo_qr";
        public const string _codigo_hash = "codigo_hash";
        public const string _key = "key";
        public const string _enlace_del_pdf = "enlace_del_pdf";
        public const string _enlace_del_xml = "enlace_del_xml";
        public const string _enlace_del_cdr = "enlace_del_cdr";

        public string tipo_de_comprobante { get; set; } = string.Empty;
        public string serie { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
        public string enlace { get; set; } = string.Empty;
        public string sunat_ticket_numero { get; set; } = string.Empty;
        public string aceptada_por_sunat { get; set; } = string.Empty;
        public string sunat_description { get; set; } = string.Empty;
        public string sunat_note { get; set; } = string.Empty;
        public string sunat_responsecode { get; set; } = string.Empty;
        public string sunat_soap_error { get; set; } = string.Empty;
        public string anulado { get; set; } = string.Empty;
        public string pdf_zip_base64 { get; set; } = string.Empty;
        public string xml_zip_base64 { get; set; } = string.Empty;
        public string cdr_zip_base64 { get; set; } = string.Empty;
        public string cadena_para_codigo_qr { get; set; } = string.Empty;
        public string codigo_hash { get; set; } = string.Empty;
        public string key { get; set; } = string.Empty;
        public string enlace_del_pdf { get; set; } = string.Empty;
        public string enlace_del_xml { get; set; } = string.Empty;
        public string enlace_del_cdr { get; set; } = string.Empty;
        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
    public class GestionClubErrorNubeFactDto
    {
        public const string _tipo_de_comprobante = "tipo_de_comprobante";
        public const string _serie = "serie";
        public const string _numero = "numero";
        public const string _errors = "errors";
        public const string _codigo = "codigo";
        public string tipo_de_comprobante { get; set; } = string.Empty;
        public string serie { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
        public string errors { get; set; } = string.Empty;
        public string codigo { get; set; } = string.Empty;
        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
