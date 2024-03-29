﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubClienteDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idCliente = "idCliente";
        public const string _idEmpresa = "idEmpresa";
        public const string _codCliente = "codCliente";
        public const string _tipSocioCliente = "tipSocioCliente";
        public const string _TipoSocio = "TipoSocio";
        public const string _tipCliente = "tipCliente";
        public const string _TipoCliente = "TipoCliente";
        public const string _nroIdentificacionCliente = "nroIdentificacionCliente";
        public const string _nombreRazSocialCliente = "nombreRazSocialCliente";
        public const string _razComercialCliente = "razComercialCliente";
        public const string _emailCliente = "emailCliente";
        public const string _nroCelularCliente = "nroCelularCliente";
        public const string _representanteCliente = "representanteCliente";
        public const string _estadoCliente = "estadoCliente";
        public const string _Estado = "Estado";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idCliente { get; set; }
        public int idEmpresa { get; set; }
        public string codCliente { get; set; } = string.Empty;
        public string tipSocioCliente { get; set; } = "01";
        public string TipoSocio { get; set; } = string.Empty;
        public string tipCliente { get; set; } = "01";
        public string TipoCliente { get; set; } = string.Empty;
        public string nroIdentificacionCliente { get; set; } = string.Empty;
        public string nombreRazSocialCliente { get; set; }
        public string razComercialCliente { get; set; }
        public string emailCliente { get; set; }
        public string nroCelularCliente { get; set; }
        public string representanteCliente { get; set; }
        public string estadoCliente { get; set; } = "01";
        public string Estado { get; set; } = string.Empty;
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
