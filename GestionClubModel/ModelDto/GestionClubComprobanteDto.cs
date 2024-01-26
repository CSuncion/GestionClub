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
