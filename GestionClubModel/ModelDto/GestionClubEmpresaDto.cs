using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubEmpresaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idEmpresa = "idEmpresa";
        public const string _codEmpresa = "codEmpresa";
        public const string _codSucursalEmpresa = "codSucursalEmpresa";
        public const string _desEmpresa = "desEmpresa";
        public const string _rucEmpresa = "rucEmpresa";
        public const string _eMail = "eMail";
        public const string _direccionEmpresa = "direccionEmpresa";
        public const string _tlfFijoEmpresa = "tlfFijoEmpresa";
        public const string _tlfCelularEmpresa = "tlfCelularEmpresa";
        public const string _estadoEmpresa = "estadoEmpresa";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idEmpresa { get; set; }
        public string codEmpresa { get; set; }
        public int codSucursalEmpresa { get; set; }
        public string desEmpresa { get; set; }
        public string rucEmpresa { get; set; }
        public string eMail { get; set; }
        public string direccionEmpresa { get; set; }
        public string tlfFijoEmpresa { get; set; }
        public string tlfCelularEmpresa { get; set; }
        public string estadoEmpresa { get; set; }
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
