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
        public const string _serComprobante = "serComprobante";
        public const string _nroComprobante = "nroComprobante";
        public const string _fecComprobante = "fecComprobante";
        public const string _codMoneda = "codMoneda";
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
        public const string _tipMovComprobante = "tipMovComprobante";
        public const string _impEfeComprobante = "impEfeComprobante";
        public const string _impDepComprobante = "impDepComprobante";
        public const string _impTarComprobante = "impTarComprobante";
        public const string _impBruComprobante = "impBruComprobante";
        public const string _impIgvComprobante = "impIgvComprobante";
        public const string _impNetComprobante = "impNetComprobante";
        public const string _impDtrComprobante = "impDtrComprobante";
        public const string _idCliente = "idCliente";
        public const string _obsComprobante = "obsComprobante";
        public const string _estadoComprobante = "estadoComprobante";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idComprobante { get; set; }
        public int idEmpresa { get; set; }
        public string tipComprobante { get; set; }
        public string serComprobante { get; set; }
        public string nroComprobante { get; set; }
        public DateTime fecComprobante { get; set; }
        public string codMoneda { get; set; }
        public decimal impCambio { get; set; }
        public string serGuiaComprobante { get; set; }
        public string nroGuiaComprobante { get; set; }
        public DateTime fecGuiaComprobante { get; set; }
        public int idNroComanda { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public int idMozo { get; set; }
        public string turnoCaja { get; set; }
        public string modPagoComprobante { get; set; }
        public string tipMovComprobante { get; set; }
        public decimal impEfeComprobante { get; set; }
        public decimal impDepComprobante { get; set; }
        public decimal impTarComprobante { get; set; }
        public decimal impBruComprobante { get; set; }
        public decimal impIgvComprobante { get; set; }
        public decimal impNetComprobante { get; set; }
        public decimal impDtrComprobante { get; set; }
        public int idCliente { get; set; }
        public string obsComprobante { get; set; }
        public string estadoComprobante { get; set; }
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
        public decimal preVenta { get; set; }
        public int cantidad { get; set; }
        public decimal preTotal { get; set; }
        public string estadoDetalleComprobante { get; set; }
        public string obsDetalleComprobante { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
