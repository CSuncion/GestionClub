using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubProductoDto
    {
        public int idProducto { get; set; }
        public int idEmpresa { get; set; }
        public string codProducto { get; set; }
        public string desProducto { get; set; }
        public string uniMedProducto { get; set; }
        public string codMoneda { get; set; }
        public decimal preCosProducto { get; set; }
        public decimal preVtsProducto { get; set; }
        public decimal preVnsProducto { get; set; }
        public decimal afeIgvProducto { get; set; }
        public decimal afeDtraProducto { get; set; }
        public decimal porDtraProducto { get; set; }
        public decimal impDolProducto { get; set; }
        public decimal impOtrProducto { get; set; }
        public string obsProducto { get; set; }
        public int idCategoria { get; set; }
        public int estadoProducto { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
