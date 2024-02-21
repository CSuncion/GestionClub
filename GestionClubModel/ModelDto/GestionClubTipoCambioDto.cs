using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubTipoCambioDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idTipoCambio = "idTipoCambio";
        public const string _FechaTipoCambio = "FechaTipoCambio";
        public const string _CompraTipoCambio = "CompraTipoCambio";
        public const string _VentaTipoCambio = "VentaTipoCambio";
        public const string _CEstadoTipoCambio = "CEstadoTipoCambio";
        public const string _UsuarioAgrega = "UsuarioAgrega";
        public const string _FechaAgrega = "FechaAgrega";
        public const string _UsuarioModifica = "UsuarioModifica";
        public const string _FechaModifica = "FechaModifica";


        public string claveObjeto { get; set; }
        public string idTipoCambio { get; set; }
        public string FechaTipoCambio { get; set; }
        public decimal CompraTipoCambio { get; set; }
        public decimal VentaTipoCambio { get; set; }
        public string CEstadoTipoCambio { get; set; }
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
