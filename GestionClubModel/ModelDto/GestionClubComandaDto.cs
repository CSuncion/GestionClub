using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubComandaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idComanda = "idComanda";
        public const string _idEmpresa = "idEmpresa";
        public const string _tipDocumentoComanda = "tipDocumentoComanda";
        public const string _nroComanda = "nroComanda";
        public const string _idAmbiente = "idAmbiente";
        public const string _idMesa = "idMesa";
        public const string _fecComanda = "fecComanda";
        public const string _idMozo = "idMozo";
        public const string _turnoCaja = "turnoCaja";
        public const string _idCliente = "idCliente";
        public const string _idComprobante = "idComprobante";
        public const string _nroAtencion = "nroAtencion";
        public const string _obsComprobante = "obsComprobante";
        public const string _estadoComanda = "estadoComanda";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public string tipDocumentoComanda { get; set; }
        public string nroComanda { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public DateTime fecComanda { get; set; }
        public int idMozo { get; set; }
        public string turnoCaja { get; set; }
        public int idCliente { get; set; }
        public int idComprobante { get; set; }
        public string nroAtencion { get; set; }
        public string obsComprobante { get; set; }
        public string estadoComanda { get; set; }
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
    public class GestionClubDetalleComandaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idDetalleComanda = "idDetalleComanda";
        public const string _idComanda = "idComanda";
        public const string _idEmpresa = "idEmpresa";
        public const string _idAmbiente = "idAmbiente";
        public const string _idMesa = "idMesa";
        public const string _idMozo = "idMozo";
        public const string _fecDetalleComanda = "fecDetalleComanda";
        public const string _idProducto = "idProducto";
        public const string _desProducto = "desProducto";
        public const string _archivoProducto = "archivoProducto";
        public const string _preVenta = "preVenta";
        public const string _cantidad = "cantidad";
        public const string _preTotal = "preTotal";
        public const string _nroAtencion = "nroAtencion";
        public const string _obsComprobante = "obsComprobante";
        public const string _estadoComanda = "estadoComanda";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idDetalleComanda { get; set; }
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public int idMozo { get; set; }
        public DateTime fecDetalleComanda { get; set; }
        public int idProducto { get; set; }
        public string desProducto { get; set; }
        public string archivoProducto { get; set; }
        public decimal preVenta { get; set; }
        public int cantidad { get; set; }
        public decimal preTotal { get; set; }
        public string nroAtencion { get; set; }
        public string obsComprobante { get; set; }
        public string estadoComanda { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
