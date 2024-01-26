using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubClienteDto
    {
        public const string _idCliente = "idCliente";
        public const string _idEmpresa = "idEmpresa";
        public const string _codCliente = "codCliente";
        public const string _tipSocioCliente = "tipSocioCliente";
        public const string _tipCliente = "tipCliente";
        public const string _nroIdentificacionCliente = "nroIdentificacionCliente";
        public const string _nombreRazSocialCliente = "nombreRazSocialCliente";
        public const string _razComercialCliente = "razComercialCliente";
        public const string _emailCliente = "emailCliente";
        public const string _nroCelularCliente = "nroCelularCliente";
        public const string _representanteCliente = "representanteCliente";
        public const string _estadoCliente = "estadoCliente";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public int idCliente { get; set; }
        public int idEmpresa { get; set; }
        public string codCliente { get; set; }
        public string tipSocioCliente { get; set; }
        public string tipCliente { get; set; }
        public string nroIdentificacionCliente { get; set; }
        public string nombreRazSocialCliente { get; set; }
        public string razComercialCliente { get; set; }
        public string emailCliente { get; set; }
        public string nroCelularCliente { get; set; }
        public string representanteCliente { get; set; }
        public string estadoCliente { get; set; }
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
