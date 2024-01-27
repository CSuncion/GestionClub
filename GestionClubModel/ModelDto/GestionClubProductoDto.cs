using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubProductoDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idProducto = "idProducto";
        public const string _idEmpresa = "idEmpresa";
        public const string _codProducto = "codProducto";
        public const string _desProducto = "desProducto";
        public const string _uniMedProducto = "uniMedProducto";
        public const string _codMoneda = "codMoneda";
        public const string _preCosProducto = "preCosProducto";
        public const string _preVtsProducto = "preVtsProducto";
        public const string _preVnsProducto = "preVnsProducto";
        public const string _afeIgvProducto = "afeIgvProducto";
        public const string _afeDtraProducto = "afeDtraProducto";
        public const string _porDtraProducto = "porDtraProducto";
        public const string _impDolProducto = "impDolProducto";
        public const string _impOtrProducto = "impOtrProducto";
        public const string _obsProducto = "obsProducto";
        public const string _idCategoria = "idCategoria";
        public const string _desCategoria = "desCategoria";
        public const string _estadoProducto = "estadoProducto";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idProducto { get; set; }
        public int idEmpresa { get; set; }
        public string codProducto { get; set; } = string.Empty;
        public string desProducto { get; set; }
        public string uniMedProducto { get; set; } = "01";
        public string codMoneda { get; set; } = "01";
        public decimal preCosProducto { get; set; }
        public decimal preVtsProducto { get; set; }
        public decimal preVnsProducto { get; set; }
        public decimal afeIgvProducto { get; set; }
        public decimal afeDtraProducto { get; set; }
        public decimal porDtraProducto { get; set; }
        public decimal impDolProducto { get; set; }
        public decimal impOtrProducto { get; set; }
        public string obsProducto { get; set; } = string.Empty;
        public int idCategoria { get; set; }
        public string estadoProducto { get; set; } = "01";
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        public GestionClubCategoriaDto GestionClubCategoriaDto { get; set; }

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
