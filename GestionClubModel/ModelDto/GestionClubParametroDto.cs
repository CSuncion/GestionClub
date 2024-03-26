using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubParametroDto
    {

        public const string _RutaLogoEmpresa = "RutaLogoEmpresa";
        public const string _PorcentajeIgv = "PorcentajeIgv";
        public const string _PorcentajeDetra = "PorcentajeDetra";
        public const string _NombreSoles = "NombreSoles";
        public const string _NombreDolares = "NombreDolares";
        public const string _RutaImagenCategoria = "RutaImagenCategoria";
        public const string _RutaImagenProducto = "RutaImagenProducto";
        public const string _RutaImagenMesa = "RutaImagenMesa";
        public const string _RutaImagenQR = "RutaImagenQR";
        public const string _CtaBcoNacion = "CtaBcoNacion";
        public const string _UsuarioAgrega = "UsuarioAgrega";
        public const string _FechaAgrega = "FechaAgrega";
        public const string _UsuarioModifica = "UsuarioModifica";
        public const string _FechaModifica = "FechaModifica";


        public string RutaLogoEmpresa { get; set; }
        public decimal PorcentajeIgv { get; set; }
        public decimal PorcentajeDetra { get; set; }
        public string NombreSoles { get; set; }
        public string NombreDolares { get; set; }
        public string RutaImagenCategoria { get; set; }
        public string RutaImagenProducto { get; set; }
        public string RutaImagenMesa { get; set; }
        public string RutaImagenQR { get; set; }
        public string CtaBcoNacion { get; set; }
        public string UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime FechaModifica { get; set; }
        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
