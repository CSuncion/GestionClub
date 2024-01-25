using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsDecomicroDto
    {

        public const string xId_Operacion = "Id_Operacion";
        public const string xNumero = "Numero";
        public const string xTipDocId = "TipDocId";
        public const string xDni_Solicitante = "Dni_Solicitante";
        public const string xPaterno = "Paterno";
        public const string xMaterno = "Materno";
        public const string xNombres = "Nombres";
        public const string xTipo_Persona = "Tipo_Persona";
        public const string xMod_Cred = "Mod_Cred";
        public const string xMovil = "Movil";
        public const string xDomicilio = "Domicilio";
        public const string xDepartamento = "Departamento";
        public const string xProvincia = "Provincia";
        public const string xDistrito = "Distrito";
        public const string xVencimiento = "Vencimiento";
        public const string xEstado = "Estado";
        public const string xCredito = "Credito";
        public const string xPagos = "Pagos";
        public const string xPendiente = "Pendiente";
        public const string xDias_Atrasos = "Dias_Atrasos";
        public const string xRet_Fecha = "Ret_Fecha";

        public decimal Id_Operacion { get; set; }
        public string Numero { get; set; }
        public int TipDocId { get; set; }
        public string Dni_Solicitante { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public int Tipo_Persona { get; set; }
        public int Mod_Cred { get; set; }
        public string Movil { get; set; }
        public string Domicilio { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Vencimiento { get; set; }
        public string Estado { get; set; }
        public decimal Credito { get; set; }
        public decimal Pagos { get; set; }
        public decimal Pendiente { get; set; }
        public int Dias_Atrasos { get; set; }
        public DateTime Ret_Fecha { get; set; }
    }
}
