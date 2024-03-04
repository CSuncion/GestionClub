using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubSistemaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idTabSistema = "idTabSistema";
        public const string _nroSistema = "nroSistema";
        public const string _titSistema = "titSistema";
        public const string _titBrvSistema = "titBrvSistema";
        public const string _estSistema = "estSistema";
        public const string _obsSistema = "obsSistema";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idTabSistema { get; set; }
        public string nroSistema { get; set; }
        public string titSistema { get; set; }
        public string titBrvSistema { get; set; }
        public string estSistema { get; set; }
        public string obsSistema { get; set; }
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

    public class GestionClubSistemaDetalleDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idTabSistemaDetalle = "idTabSistemaDetalle";
        public const string _idTabSistema = "idTabSistema";
        public const string _codigo = "codigo";
        public const string _descri = "descri";
        public const string _desbrv = "desbrv";
        public const string _monIni = "monIni";
        public const string _monFin = "monFin";
        public const string _monBas = "monBas";
        public const string _valMes = "valMes";
        public const string _valDia = "valDia";
        public const string _estado = "estado";
        public const string _obsSistemaDetalle = "obsSistemaDetalle";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";
        public const string _nroSistema = "nroSistema";
        public const string _titSistema = "titSistema";

        public string claveObjeto { get; set; }
        public int idTabSistemaDetalle { get; set; }
        public int idTabSistema { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string descri { get; set; }
        public string desbrv { get; set; }
        public decimal monIni { get; set; }
        public decimal monFin { get; set; } = 0;
        public decimal monBas { get; set; } = 0;
        public int valMes { get; set; } = 0;
        public int valDia { get; set; } = 0;
        public string estado { get; set; } = "01";
        public string obsSistemaDetalle { get; set; } = string.Empty;
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        public string nroSistema { get; set; }
        public string titSistema { get; set; }
        public GestionClubSistemaDto gestionClubSistemaDto { get; set; }
        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

    }
}
