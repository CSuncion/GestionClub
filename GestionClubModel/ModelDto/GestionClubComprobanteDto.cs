using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubComprobanteDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idComprobante = "idComprobante";
        public const string _idEmpresa = "idEmpresa";
        public const string _tipComprobante = "tipComprobante";
        public const string _serNroComprobante = "serNroComprobante";
        public const string _desTipComprobante = "desTipComprobante";
        public const string _serComprobante = "serComprobante";
        public const string _nroComprobante = "nroComprobante";
        public const string _fecComprobante = "fecComprobante";
        public const string _codMoneda = "codMoneda";
        public const string _desMoneda = "desMoneda";
        public const string _impCambio = "impCambio";
        public const string _serGuiaComprobante = "serGuiaComprobante";
        public const string _nroGuiaComprobante = "nroGuiaComprobante";
        public const string _fecGuiaComprobante = "fecGuiaComprobante";
        public const string _idNroComanda = "idNroComanda";
        public const string _idAmbiente = "idAmbiente";
        public const string _idMesa = "idMesa";
        public const string _idMozo = "idMozo";
        public const string _turnoCaja = "turnoCaja";
        public const string _modPagoComprobante = "modPagoComprobante";
        public const string _desPagoComprobante = "desPagoComprobante";
        public const string _tipMovComprobante = "tipMovComprobante";
        public const string _impEfeComprobante = "impEfeComprobante";
        public const string _impDepComprobante = "impDepComprobante";
        public const string _impTarComprobante = "impTarComprobante";
        public const string _impBruComprobante = "impBruComprobante";
        public const string _impIgvComprobante = "impIgvComprobante";
        public const string _impNetComprobante = "impNetComprobante";
        public const string _impDtrComprobante = "impDtrComprobante";
        public const string _idCliente = "idCliente";
        public const string _nroIdentificacionCliente = "nroIdentificacionCliente";
        public const string _nombreRazSocialCliente = "nombreRazSocialCliente";
        public const string _tipCliente = "tipCliente";
        public const string _obsComprobante = "obsComprobante";
        public const string _estadoComprobante = "estadoComprobante";
        public const string _desEstado = "desEstado";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idComprobante { get; set; }
        public int idEmpresa { get; set; }
        public string tipComprobante { get; set; } = "02";
        public string serNroComprobante { get; set; }
        public string desTipComprobante { get; set; }
        public string serComprobante { get; set; }
        public string nroComprobante { get; set; }
        public DateTime fecComprobante { get; set; } = DateTime.Now;
        public string codMoneda { get; set; } = "01";
        public string desMoneda { get; set; }
        public decimal impCambio { get; set; }
        public string serGuiaComprobante { get; set; }
        public string nroGuiaComprobante { get; set; }
        public DateTime fecGuiaComprobante { get; set; } = DateTime.Now;
        public int idNroComanda { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public int idMozo { get; set; }
        public string turnoCaja { get; set; }
        public string modPagoComprobante { get; set; }
        public string desPagoComprobante { get; set; }
        public string tipMovComprobante { get; set; } = "04";
        public decimal impEfeComprobante { get; set; } = 0;
        public decimal impDepComprobante { get; set; } = 0;
        public decimal impTarComprobante { get; set; } = 0;
        public decimal impBruComprobante { get; set; } = 0;
        public decimal impIgvComprobante { get; set; } = 0;
        public decimal impNetComprobante { get; set; } = 0;
        public decimal impDtrComprobante { get; set; }
        public int idCliente { get; set; }
        public string nroIdentificacionCliente { get; set; }
        public string nombreRazSocialCliente { get; set; }
        public string tipCliente { get; set; } = "01";
        public string obsComprobante { get; set; }
        public string estadoComprobante { get; set; }
        public string desEstado { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
    public class GestionClubDetalleComprobanteDto
    {

        public const string _claveObjeto = "claveObjeto";
        public const string _idDetalleComprobante = "idDetalleComprobante";
        public const string _idComprobante = "idComprobante";
        public const string _idEmpresa = "idEmpresa";
        public const string _idProducto = "idProducto";
        public const string _codProducto = "codProducto";
        public const string _desProducto = "desProducto";
        public const string _preVenta = "preVenta";
        public const string _cantidad = "cantidad";
        public const string _preTotal = "preTotal";
        public const string _estadoDetalleComprobante = "estadoDetalleComprobante";
        public const string _obsDetalleComprobante = "obsDetalleComprobante";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idDetalleComprobante { get; set; }
        public int idComprobante { get; set; }
        public int idEmpresa { get; set; }
        public int idProducto { get; set; }
        public string codProducto { get; set; }
        public string desProducto { get; set; }
        public decimal preVenta { get; set; } = 0;
        public int cantidad { get; set; }
        public decimal preTotal { get; set; }
        public string estadoDetalleComprobante { get; set; }
        public string obsDetalleComprobante { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
