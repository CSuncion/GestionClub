using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubPermisoEmpresaDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _idPermisoEmpresa = "idPermisoEmpresa";
        public const string _codPermisoEmpresa = "codPermisoEmpresa";
        public const string _idEmpresa = "idEmpresa";
        public const string _codEmpresa = "codEmpresa";
        public const string _desEmpresa = "desEmpresa";
        public const string _idAcceso = "idAcceso";
        public const string _codAcceso = "codAcceso";
        public const string _nombresAcceso = "nombresAcceso";
        public const string _cPermitir = "cPermitir";
        public const string _usuarioAgrega = "usuarioAgrega";
        public const string _fechaAgrega = "fechaAgrega";
        public const string _usuarioModifica = "usuarioModifica";
        public const string _fechaModifica = "fechaModifica";


        public string claveObjeto { get; set; }
        public int idPermisoEmpresa { get; set; }
        public string codPermisoEmpresa { get; set; }
        public int idEmpresa { get; set; }
        public int idAcceso { get; set; }
        public string codEmpresa { get; set; }
        public string codAcceso { get; set; }
        public int cPermitir { get; set; }
        public int usuarioAgrega { get; set; }
        public DateTime fechaAgrega { get; set; }
        public int usuarioModifica { get; set; }
        public DateTime fechaModifica { get; set; }
        public GestionClubEmpresaDto gestionClubEmpresaDto { get; set; }
        public GestionClubAccessDto gestionClubAccesoDto { get; set; }

        private Adicional _Adicionales = new Adicional();
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
