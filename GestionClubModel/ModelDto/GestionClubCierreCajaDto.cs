﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubCierreCajaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idCierreCaja = "idCierreCaja";
        public const string _idEmpresa = "idEmpresa";
        public const string _fecCierreCaja = "fecCierreCaja";
        public const string _montoCierreCaja = "montoCierreCaja";
        public const string _caja = "caja";
        public const string _estadoCierreCaja = "estadoCierreCaja";
        public const string _Estado = "Estado";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idCierreCaja { get; set; } = 0;
        public int idEmpresa { get; set; }
        public DateTime fecCierreCaja { get; set; } = DateTime.Now;
        public decimal montoCierreCaja { get; set; }
        public string caja { get; set; }
        public string estadoCierreCaja { get; set; } = "01";
        public string Estado { get; set; } = string.Empty;
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; } = DateTime.Now;
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; } = DateTime.Now;

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
