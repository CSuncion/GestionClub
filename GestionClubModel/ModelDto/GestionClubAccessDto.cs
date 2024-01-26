using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubAccessDto
    {
        private Adicional _Additionals = new Adicional();
        //campos nombres
        public const string IdAcc = "idAcceso";
        public const string codAcc = "codAcceso";
        public const string nombreAcc = "nombreAcceso";
        public const string DniAcc = "dniAcceso";
        public const string PassAcc = "passAcceso";
        public const string PatAcc = "paternoAcceso";
        public const string MatAcc = "maternoAcceso";
        public const string nombresAcc = "nombresAcceso";
        public const string MailAcc = "mailAcceso";
        public const string DomAcc = "domicilioAcceso";
        public const string DptoAcc = "dptoAcceso";
        public const string ProvAcc = "provAcceso";
        public const string DistAcc = "distAcceso";
        public const string FijAcc = "fijoAcceso";
        public const string MovAcc = "movilAcceso";
        public const string LevAcc = "levelAcceso";
        public const string SitAcc = "sitAcceso";
        public const string FecAcc = "fechaAcceso";
        public const string Of1 = "ofc1";
        public const string Of2 = "ofc2";
        public const string Of3 = "ofc3";
        public const string Of4 = "ofc4";
        public const string CipAcc = "cipAcceso";
        public const string CodfinAcc = "codofinAcceso";
        public const string GradAcc = "gradoAcceso";
        public const string xPnp = "pnp";
        public const string CargAcc = "cargoAcceso";

        public int idAcceso { get; set; }
        public string codAcceso { get; set; } = string.Empty;
        public string nombreAcceso { get; set; } = string.Empty;
        public string dniAcceso { get; set; } = string.Empty;
        public string passAcceso { get; set; } = string.Empty;
        public string paternoAcceso { get; set; } = string.Empty;
        public string maternoAcceso { get; set; } = string.Empty;
        public string nombresAcceso { get; set; } = string.Empty;
        public string mailAcceso { get; set; } = string.Empty;
        public string domicilioAcceso { get; set; } = string.Empty;
        public Nullable<int> dptoAcceso { get; set; }
        public Nullable<int> provAcceso { get; set; }
        public Nullable<int> distAcceso { get; set; }
        public string fijoAcceso { get; set; } = string.Empty;
        public string movilAcceso { get; set; } = string.Empty;
        public Nullable<int> levelAcceso { get; set; }
        public Nullable<int> sitAcceso { get; set; }
        public Nullable<System.DateTime> fechaAcceso { get; set; }
        public Nullable<int> ofc1 { get; set; }
        public Nullable<int> ofc2 { get; set; }
        public Nullable<int> ofc3 { get; set; }
        public Nullable<int> ofc4 { get; set; }
        public string cipAcceso { get; set; } = string.Empty;
        public string codofinAcceso { get; set; } = string.Empty;
        public Nullable<decimal> gradoAcceso { get; set; }
        public Nullable<int> pnp { get; set; }
        public string cargoAcceso { get; set; } = string.Empty;

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
