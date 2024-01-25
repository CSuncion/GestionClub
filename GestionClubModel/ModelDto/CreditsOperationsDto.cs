using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsOperationsDto
    {
        //campos nombres
        public const string IdOper = "Id_Operacion";
        public const string Tip = "Tipo";
        public const string xSer = "Ser";
        public const string Nro = "Numero";
        public const string Product = "Producto";
        public const string NameProduct = "NameProducto";
        public const string Numro = "Num";
        public const string Fec = "Fecha";
        public const string UnDscto = "Unid_Dscto";
        public const string DniSolic = "Dni_Solicitante";
        public const string Prove = "Proveedor";
        public const string Mon = "Moneda";
        public const string TpCamb = "TpCambio";
        public const string Aproba = "Aprobado";
        public const string Pla = "Plazo";
        public const string Inter = "Interes";
        public const string Seg = "Seguro";
        public const string GastosAd = "GastosAdm";
        public const string xIgv = "IGV";
        public const string xObs = "Obs";
        public const string xProvedor = "Provedor";
        public const string xPeGracia = "PeGracia";
        public const string xFg = "Fg";
        public const string xVencimiento = "Vencimiento";
        public const string xIdAcceso = "IdAcceso";
        public const string xCuota = "Cuota";
        public const string xLoteId = "LoteId";
        public const string xIdTpOperac = "Id_TpOperac";
        public const string xDesTpOperac = "Des_TpOperac";
        public const string xCortaTpOperac = "Corta_TpOperac";
        public const string xF1 = "F1";
        public const string xIdProveedor = "Id_Proveedor";
        public const string xDesProveedor = "Des_Proveedor";
        public const string xRuc = "RUC";
        public const string xRepresentante = "Representante";
        public const string xDni = "DNI";
        public const string xDireccion = "Direccion";
        public const string xDpto = "Dpto";
        public const string xProv = "Prov";
        public const string xDist = "Dist";
        public const string xFijo = "Fijo";
        public const string xMovil = "Movil";
        public const string xMail = "Mail";
        public const string xCondicion = "Condicion";
        public const string xIdUnidDscto = "IdUnidDscto";
        public const string xDesUnidDscto = "DesUnidDscto";
        public const string xDesCortaUDscto = "DesCortaUDscto";
        public const string xCredito = "CREDITO";
        public const string xPagos = "PAGOS";
        public const string xIdOrden = "Id_Orden";
        public const string xAprobacion = "Aprobacion";
        public const string xVFecha = "V_Fecha";
        public const string xOrden = "Orden";
        public const string xInforme = "Informe";
        public const string xAnio = "Anio";
        public const string xVoucher = "Voucher";
        public const string xFeDesembolso = "FeDesembolso";
        public const string xIdCriterio = "IdCriterio";
        public const string xDesEstado = "DesEstado";
        public const string xEstado = "Estado";
        public const string xDesSubEstado = "DesSubEstado";
        public const string VerFal = "VerdadFalso";

        private Additional _Additionals = new Additional();
        public int Id_Operacion { get; set; }
        public int Tipo { get; set; }
        public string Ser { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public int Producto { get; set; }
        public string NameProducto { get; set; } = string.Empty;
        public string Num { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int UnidDscto { get; set; }
        public string Dni_Solicitante { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public int Moneda { get; set; }
        public decimal TpCambio { get; set; }
        public decimal Aprobado { get; set; }
        public int Plazo { get; set; }
        public decimal Interes { get; set; }
        public decimal Seguro { get; set; }
        public decimal GastosAdm { get; set; }
        public decimal IGV { get; set; }
        public string Obs { get; set; } = string.Empty;
        public int Provedor { get; set; }
        public int PeGracia { get; set; }
        public int Fg { get; set; }
        public DateTime Vencimiento { get; set; }
        public int IdAcceso { get; set; }
        public int Cuota { get; set; }
        public int LoteId { get; set; }
        public int IdTpOperac { get; set; }
        public string DesTpOperac { get; set; } = string.Empty;
        public string Corta_TpOperac { get; set; } = string.Empty;
        public string F1 { get; set; } = string.Empty;
        public int IdProveedor { get; set; }
        public string Des_Proveedor { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string Representante { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int Dpto { get; set; }
        public int Prov { get; set; }
        public int Dist { get; set; }
        public string Fijo { get; set; } = string.Empty;
        public string Movil { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public int Condicion { get; set; }
        public int IdUnidDscto { get; set; }
        public string DesUnidDscto { get; set; } = string.Empty;
        public string DesCortaUDscto { get; set; } = string.Empty;
        public int Credito { get; set; }
        public int Pagos { get; set; }
        public int IdOrden { get; set; }
        public int Aprobacion { get; set; }
        public DateTime VFecha { get; set; }
        public int Orden { get; set; }
        public int Informe { get; set; }
        public int Anio { get; set; }
        public DateTime Voucher { get; set; }
        public DateTime FeDesembolso { get; set; }
        public int IdCriterio { get; set; }
        public int Estado { get; set; }
        public string DesEstado { get; set; } = string.Empty;
        public string DesSubEstado { get; set; } = string.Empty;
        public Boolean VerdadFalso { get; set; } = false;
        public Additional Additionals
        {
            get { return this._Additionals; }
            set { this._Additionals = value; }
        }
    }
}
