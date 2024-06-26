﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubCategoriaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idCategoria = "idCategoria";
        public const string _idEmpresa = "idEmpresa";
        public const string _codCategoria = "codCategoria";
        public const string _desCategoria = "desCategoria";
        public const string _archivoCategoria = "archivoCategoria";
        public const string _estadoCategoria = "estadoCategoria";
        public const string _Estado = "Estado";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";

        public string claveObjeto { get; set; }
        public int idCategoria { get; set; }
        public int idEmpresa { get; set; }
        public string codCategoria { get; set; } = string.Empty;
        public string desCategoria { get; set; }
        public string archivoCategoria { get; set; }
        public string estadoCategoria { get; set; } = "01";
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
