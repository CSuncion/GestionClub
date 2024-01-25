using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsPagosDto
    {
        public const string xDni = "Dni";
        public const string xTipo = "Tipo";
        public const string xIdOperacion = "Id_Operacion";
        public const string xFecha = "Fecha";
        public const string xCODOFIN = "CODOFIN";
        public const string xCIP = "CIP";
        public const string xNROBEN = "NROBEN";
        public const string xNRODNI = "NRODNI";
        public const string xAPENOM = "APENOM";
        public const string xDni_Ser_Numero = "Dni_Ser_Numero";
        public const string xGrado = "Grado";
        public const string xNOMBRE = "NOMBRE";
        public const string xResultado = "Resultado";
        public const string xTope = "Tope";
        public const string xEnvio = "Envio";
        public const string xInicia = "Inicia";

        public decimal Id_Pago { get; set; }
        public decimal IdOperacion { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int Cuota { get; set; }
        public decimal Amortizacion { get; set; }
        public decimal Interes { get; set; }
        public decimal Seguro { get; set; }
        public decimal Gastos { get; set; }
        public decimal Igv { get; set; }
        public decimal Comision1 { get; set; }
        public decimal Comision2 { get; set; }
        public decimal Porcentaje { get; set; }
        public DateTime Env_Fecha { get; set; }
        public DateTime Ret_Fecha { get; set; }
        public decimal Ret_Amortizacion { get; set; }
        public decimal Ret_Interes { get; set; }
        public decimal Ret_Seguro { get; set; }
        public decimal Ret_Gastos { get; set; }
        public decimal Ret_Igv { get; set; }
        public decimal Ret_Comision1 { get; set; }
        public decimal Ret_Comision2 { get; set; }
        public int Fg { get; set; }
        public decimal IdAccesoEnvia { get; set; }
        public decimal IdAccesoCobra { get; set; }
        public decimal Ant_Amortizacion { get; set; }
        public decimal Ant_Interes { get; set; }
        public decimal Ant_Seguro { get; set; }
        public decimal Ant_Gastos { get; set; }
        public decimal Ant_Igv { get; set; }
        public decimal Ant_Comision1 { get; set; }
        public decimal Ant_Comision2 { get; set; }
        public decimal MasIgv { get; set; }
        public decimal Queda { get; set; }
        public int Periodo { get; set; }
        public decimal Id_ProcesoPagos { get; set; }
        public int Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string CodoFin { get; set; }
        public string Dni { get; set; }
        public string Dni_Ser_Numero { get; set; }
        public string Grado { get; set; }
        public string Nombre { get; set; }
        public decimal Resultado { get; set; }
        public decimal Tope { get; set; }
        public decimal Envio { get; set; }
        public decimal Inicia { get; set; }
        public int selTope { get; set; }
        public string Cip { get; set; }
        public string NroBen { get; set; }
        public string NroDni { get; set; }
        public string ApeNom { get; set; }
        public decimal Parcial { get; set; }
        public decimal Total { get; set; } = 0;
        public string Dni_Solicitante { get; set; }
        public decimal Descuenta { get; set; }
        public CreditsOperationsDto CreditsOperationsDto { get; set; }
    }
}
