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

        public string claveObjeto { get; set; }
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public string tipoDocumentoComanda { get; set; }
        public string nroComanda { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public DateTime fecMesa { get; set; }
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
        public int idDetalleComanda { get; set; }
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public int idMozo { get; set; }
        public DateTime fecDetallaComanda { get; set; }
        public int idProducto { get; set; }
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
