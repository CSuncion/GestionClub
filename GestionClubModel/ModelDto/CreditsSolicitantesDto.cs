using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsModel.ModelDto
{
    public class CreditsSolicitantesDto
    {
        public const string xId_Solicitante = "Id_Solicitante";
        public const string xDni_Solic = "Dni_Solic";
        public const string xCodofin_Solic = "Codofin_Solic";
        public const string xCarnet_Solic = "Carnet_Solic";
        public const string xPaterno = "Paterno";
        public const string xMaterno = "Materno";
        public const string xNombres = "Nombres";
        public const string xSexo = "Sexo";
        public const string xSituac = "Situac";
        public const string xUnd_dscto = "Und_dscto";
        public const string xGrado = "Grado";
        public const string xFnace = "Fnace";
        public const string xDomicilio = "Domicilio";
        public const string xDpto = "Dpto";
        public const string xProv = "Prov";
        public const string xDist = "Dist";
        public const string xFijo = "Fijo";
        public const string xMovil = "Movil";
        public const string xMail = "Mail";
        public const string xNroBen = "NroBen";
        public const string xIdBca = "IdBca";
        public const string xNumCta = "NumCta";
        public const string xCCI = "CCI";
        public const string xDesDpto = "DesDpto";
        public const string xDesProv = "DesProv";
        public const string xDesDist = "DesDist";
        public const string xDesGrado = "DesGrado";


        public int Id_Solicitante { get; set; } = 0;
        public string Dni_Solic { get; set; } = string.Empty;
        public string Codofin_Solic { get; set; } = string.Empty;
        public string Carnet_Solic { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public int Sexo { get; set; } = 0;
        public int Situac { get; set; } = 0;
        public int Und_dscto { get; set; } = 0;
        public int Grado { get; set; } = 0;
        public string DesGrado { get; set; } = string.Empty;
        public DateTime Fnace { get; set; }
        public string Domicilio { get; set; } = string.Empty;
        public int Dpto { get; set; } = 0;
        public int Prov { get; set; } = 0;
        public int Dist { get; set; } = 0;
        public string DesDpto { get; set; } = string.Empty;
        public string DesProv { get; set; } = string.Empty;
        public string DesDist { get; set; } = string.Empty;
        public string Fijo { get; set; } = string.Empty;
        public string Movil { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string NroBen { get; set; } = string.Empty;
        public string IdBca { get; set; } = string.Empty;
        public string NumCta { get; set; } = string.Empty;
        public string CCI { get; set; } = string.Empty;

    }
}
