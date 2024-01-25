﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubComandaDto
    {
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public string tipoDocumentoComanda { get; set; }
        public string nroComanda { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public DateTime fecMesa { get; set; }
        public int idMozo { get; set; }
        public string turnoCaja { get; set; }
        public int idCliente { get; set; }
        public int idComprobante { get; set; }
        public string nroAtencion { get; set; }
        public string obsComprobante { get; set; }
        public int estadoComanda { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
    public class GestionClubDetalleComandaDto
    {
        public int idDetalleComanda { get; set; }
        public int idComanda { get; set; }
        public int idEmpresa { get; set; }
        public int idAmbiente { get; set; }
        public int idMesa { get; set; }
        public int idMozo { get; set; }
        public DateTime fecDetallaComanda { get; set; }
        public int idProducto { get; set; }
        public decimal preVenta { get; set; }
        public int cantidad { get; set; }
        public decimal preTotal { get; set; }
        public string nroAtencion { get; set; }
        public string obsComprobante { get; set; }
        public int estadoComanda { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
    }
}