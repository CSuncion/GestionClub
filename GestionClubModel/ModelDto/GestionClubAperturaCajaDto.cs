using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubAperturaCajaDto
    {

        public const string _idAperturaCaja = "idAperturaCaja";
        public const string _idEmpresa = "idEmpresa";
        public const string _fecAperturaCaja = "fecAperturaCaja";
        public const string _montoAperturaCaja = "montoAperturaCaja";
        public const string _estadoAperturaCaja = "estadoAperturaCaja";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public int idAperturaCaja { get; set; }
        public int idEmpresa { get; set; }
        public DateTime fecAperturaCaja { get; set; }
        public decimal montoAperturaCaja { get; set; }
        public int estadoAperturaCaja { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}
