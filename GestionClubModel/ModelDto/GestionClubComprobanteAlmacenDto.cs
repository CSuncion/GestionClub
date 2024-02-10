using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubComprobanteAlmacenDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idComprobanteAlmacen = "idComprobanteAlmacen";
        public const string _idEmpresa = "idEmpresa";
        public const string _codAlmacen = "codAlmacen";
        public const string _anoProceso = "anoProceso";
        public const string _mesProceso = "mesProceso";
        public const string _tipoMovimiento = "tipoMovimiento";
        public const string _nroDocumento = "nroDocumento";
        public const string _fecAlmacen = "fecAlmacen";
        public const string _tipCliente = "tipCliente";
        public const string _nroRuc = "nroRuc";
        public const string _razSocial = "razSocial";
        public const string _tipFactura = "tipFactura";
        public const string _serNroFactura = "serNroFactura";
        public const string _serFactura = "serFactura";
        public const string _nroFactura = "nroFactura";
        public const string _fecFactura = "fecFactura";
        public const string _guiaRe = "guiaRe";
        public const string _fecGui = "fecGui";
        public const string _totVta = "totVta";
        public const string _totIgv = "totIgv";
        public const string _totBru = "totBru";
        public const string _estAlmacen = "estAlmacen";
        public const string _Obsope = "Obsope";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idComprobanteAlmacen { get; set; }
        public int idEmpresa { get; set; }
        public string codAlmacen { get; set; }
        public string anoProceso { get; set; }
        public string mesProceso { get; set; }
        public string tipoMovimiento { get; set; }
        public string nroDocumento { get; set; }
        public DateTime fecAlmacen { get; set; }
        public string tipCliente { get; set; }
        public string nroRuc { get; set; }
        public string razSocial { get; set; }
        public string tipFactura { get; set; }
        public string serNroFactura { get; set; }
        public string serFactura { get; set; }
        public string nroFactura { get; set; }
        public DateTime fecFactura { get; set; }
        public string guiaRe { get; set; }
        public DateTime fecGui { get; set; }
        public decimal totVta { get; set; }
        public decimal totIgv { get; set; }
        public decimal totBru { get; set; }
        public string estAlmacen { get; set; }
        public string Obsope { get; set; }
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
    public class GestionClubComprobanteDetalleAlmacenDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idComprobanteDetalleAlmacen = "idComprobanteDetalleAlmacen";
        public const string _idComprobanteAlmacen = "idComprobanteAlmacen";
        public const string _idEmpresa = "idEmpresa";
        public const string _codAlmacen = "codAlmacen";
        public const string _anoProceso = "anoProceso";
        public const string _mesProceso = "mesProceso";
        public const string _tipoMovimiento = "tipoMovimiento";
        public const string _nroDocumento = "nroDocumento";
        public const string _nroDocCorrelativo = "nroDocCorrelativo";
        public const string _fechaAlmacen = "fechaAlmacen";
        public const string _tipoFactura = "tipoFactura";
        public const string _serFactura = "serFactura";
        public const string _nroFactura = "nroFactura";
        public const string _fecFactura = "fecFactura";
        public const string _idProducto = "idProducto";
        public const string _codProducto = "codProducto";
        public const string _desProducto = "desProducto";
        public const string _uniMedida = "uniMedida";
        public const string _precioCosto = "precioCosto";
        public const string _cantidad = "cantidad";
        public const string _totCosto = "totCosto";
        public const string _estAlmacen = "estAlmacen";
        public const string _obsOperacion = "obsOperacion";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idComprobanteDetalleAlmacen { get; set; }
        public int idComprobanteAlmacen { get; set; }
        public int idEmpresa { get; set; }
        public string codAlmacen { get; set; }
        public string anoProceso { get; set; }
        public string mesProceso { get; set; }
        public string tipoMovimiento { get; set; }
        public string nroDocumento { get; set; }
        public string nroDocCorrelativo { get; set; }
        public DateTime fechaAlmacen { get; set; }
        public string tipoFactura { get; set; }
        public string serFactura { get; set; }
        public string nroFactura { get; set; }
        public DateTime fecFactura { get; set; }
        public int idProducto { get; set; }
        public string codProducto { get; set; }
        public string desProducto { get; set; }
        public string uniMedida { get; set; }
        public decimal precioCosto { get; set; }
        public int cantidad { get; set; }
        public decimal totCosto { get; set; }
        public string estAlmacen { get; set; }
        public string obsOperacion { get; set; }
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
