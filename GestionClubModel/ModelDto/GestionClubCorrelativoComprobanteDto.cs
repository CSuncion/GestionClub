using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubCorrelativoComprobanteDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idCorrelativoComprobante = "idCorrelativoComprobante";
        public const string _idEmpresa = "idEmpresa";
        public const string _tipoDocumento = "tipoDocumento";
        public const string _caja = "caja";
        public const string _serCorrelativo = "serCorrelativo";
        public const string _nroCorrelativo = "nroCorrelativo";
        public const string _estado = "estado";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idCorrelativoComprobante { get; set; } = 0;
        public int idEmpresa { get; set; }
        public string tipoDocumento { get; set; }
        public string caja { get; set; }
        public string serCorrelativo { get; set; }
        public string nroCorrelativo { get; set; }
        public string estado { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
