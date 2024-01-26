using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubPermisoEmpresaRepository : IGestionClubPermisoEmpresaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubPermisoEmpresaDto xObj = new GestionClubPermisoEmpresaDto();
        private List<GestionClubPermisoEmpresaDto> xLista = new List<GestionClubPermisoEmpresaDto>();
        private GestionClubPermisoEmpresaDto Objeto(IDataReader iDr)
        {
            GestionClubPermisoEmpresaDto xObjEnc = new GestionClubPermisoEmpresaDto();
            xObjEnc.gestionClubEmpresaDto = new GestionClubEmpresaDto();
            xObjEnc.gestionClubAccesoDto = new GestionClubAccessDto();
            xObjEnc.idPermisoEmpresa = Convert.ToInt32(iDr["idPermisoEmpresa"]);
            xObjEnc.codPermisoEmpresa = Convert.ToString(iDr["codPermisoEmpresa"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.gestionClubEmpresaDto.codEmpresa = Convert.ToString(iDr["codEmpresa"]);
            xObjEnc.gestionClubEmpresaDto.desEmpresa = Convert.ToString(iDr["desEmpresa"]);
            xObjEnc.gestionClubEmpresaDto.estadoEmpresa = Convert.ToString(iDr["estadoEmpresa"]);
            xObjEnc.idAcceso = Convert.ToInt32(iDr["idAcceso"].ToString());
            xObjEnc.gestionClubAccesoDto.codAcceso = Convert.ToString(iDr["codAcceso"]);
            xObjEnc.gestionClubAccesoDto.nombresAcceso = Convert.ToString(iDr["nombresAcceso"]);
            xObjEnc.cPermitir = Convert.ToInt32(iDr["cPermitir"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubPermisoEmpresaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.Objeto(xIdr);
            }
            xObjCn.Disconnect();
            return xObj;
        }
        private List<GestionClubPermisoEmpresaDto> ListarObjetos(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private List<GestionClubPermisoEmpresaDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }

        public GestionClubPermisoEmpresaDto ListarPermisoEmpresaPorCodigo(GestionClubPermisoEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codPermisoEmpresa)
                };
            return this.BuscarObjeto("isp_ListarPermisoEmpresaPorCodigo", lParameter);
        }
        public List<GestionClubPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(GestionClubPermisoEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@codigo", pObj.codAcceso),
                    new SqlParameter("@estado", "1")
                };
            return this.BuscarObjetoPorParametro("isp_ListarPermisosEmpresaActivasXUsuarioYAutorizadas", lParameter);
        }

    }
}
