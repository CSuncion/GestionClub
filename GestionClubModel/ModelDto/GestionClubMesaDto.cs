using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubMesaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idMesa = "idMesa";
        public const string _idEmpresa = "idEmpresa";
        public const string _codMesa = "codMesa";
        public const string _desMesa = "desMesa";
        public const string _desAmbiente = "desAmbiente";
        public const string _idAmbiente = "idAmbiente";
        public const string _estadoMesa = "estadoMesa";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idMesa { get; set; }
        public int idEmpresa { get; set; }
        public string codMesa { get; set; }
        public string desMesa { get; set; }
        public int idAmbiente { get; set; }
        public string estadoMesa { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        public GestionClubAmbientesDto GestionClubAmbientesDto { get; set; }

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
