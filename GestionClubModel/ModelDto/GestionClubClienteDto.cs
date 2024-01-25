using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubClienteDto
    {
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
        public string represtanteCliente { get; set; }
        public int estadoCliente { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }

    }
}
