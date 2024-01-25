using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsApplicantDto
    {
        private Additional _Additionals = new Additional();

        public const string _Id_Solicitante = "Id_Solicitante";
        public const string _Dni_Solic = "Dni_Solic";
        public const string _Codofin_Solic = "Codofin_Solic";
        public const string _Carnet_Solic = "Carnet_Solic";
        public const string _Paterno = "Paterno";
        public const string _Materno = "Materno";
        public const string _Nombres = "Nombres";
        public const string _Sexo = "Sexo";
        public const string _Situac = "Situac";
        public const string _Und_dscto = "Und_dscto";
        public const string _Grado = "Grado";
        public const string _GradoDesc = "GradoDesc";
        public const string _Fnace = "Fnace";
        public const string _Domicilio = "Domicilio";
        public const string _Dpto = "Dpto";
        public const string _Prov = "Prov";
        public const string _Dist = "Dist";
        public const string _Fijo = "Fijo";
        public const string _Movil = "Movil";
        public const string _Mail = "Mail";
        public const string _NroBen = "NroBen";
        public const string _IdBca = "IdBca";
        public const string _NumCta = "NumCta";
        public const string _CCI = "CCI";
        public const string _Grados = "Grados";

        public int Id_Solicitante { get; set; }
        public string Dni_Solic { get; set; }
        public string Codofin_Solic { get; set; }
        public string Carnet_Solic { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public int Sexo { get; set; }
        public int Situac { get; set; }
        public int Und_dscto { get; set; }
        public int Grado { get; set; }
        public string GradoDesc { get; set; }
        public DateTime Fnace { get; set; }
        public string Domicilio { get; set; }
        public int Dpto { get; set; }
        public int Prov { get; set; }
        public int Dist { get; set; }
        public string Fijo { get; set; }
        public string Movil { get; set; }
        public string Mail { get; set; }
        public int NroBen { get; set; }
        public string IdBca { get; set; }
        public string NumCta { get; set; }
        public string CCI { get; set; }
        public string Grados { get; set; }

        public Additional Additionals
        {
            get { return this._Additionals; }
            set { this._Additionals = value; }
        }
    }
}
