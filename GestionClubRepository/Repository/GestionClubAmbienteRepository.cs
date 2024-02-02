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
    public class GestionClubAmbienteRepository : IGestionClubAmbienteRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubAmbientesDto xObj = new GestionClubAmbientesDto();
        private List<GestionClubAmbientesDto> xLista = new List<GestionClubAmbientesDto>();
        private GestionClubAmbientesDto Objeto(IDataReader iDr)
        {
            GestionClubAmbientesDto xObjEnc = new GestionClubAmbientesDto();
            xObjEnc.idAmbiente = Convert.ToInt32(iDr["idAmbiente"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.codAmbiente = iDr["codAmbiente"].ToString();
            xObjEnc.desAmbiente = iDr["desAmbiente"].ToString();
            xObjEnc.estadoAmbiente = Convert.ToString(iDr["estadoAmbiente"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idAmbiente.ToString();
            return xObjEnc;
        }
        private GestionClubAmbientesDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubAmbientesDto> ListarObjetos(string pScript)
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
        private List<GestionClubAmbientesDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubAmbientesDto> ListarAmbientes()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarAmbientes", lParameter);
        }
        public List<GestionClubAmbientesDto> ListarAmbientesActivos()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarAmbientesActivos", lParameter);
        }
        public GestionClubAmbientesDto ListarAmbientesPorCodigoPorEmpresa(GestionClubAmbientesDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codAmbiente),
                new SqlParameter("@empresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarAmbientesPorCodigoPorEmpresa", lParameter);
        }
        public void AgregarAmbiente(GestionClubAmbientesDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@codAmbiente",pObj.codAmbiente),
                        new SqlParameter("@desAmbiente",pObj.desAmbiente),
                        new SqlParameter("@estadoAmbiente",pObj.estadoAmbiente),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarAmbiente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public GestionClubAmbientesDto ListarAmbientesPorId(GestionClubAmbientesDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idAmbiente", pObj.idAmbiente),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarAmbientesPorId", lParameter);
        }
        public void ModificarAmbiente(GestionClubAmbientesDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idAmbiente", pObj.idAmbiente),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                        new SqlParameter("@codAmbiente", pObj.codAmbiente),
                        new SqlParameter("@desAmbiente", pObj.desAmbiente),
                        new SqlParameter("@estadoAmbiente", pObj.estadoAmbiente),
                        new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarAmbiente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarAmbiente(GestionClubAmbientesDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idAmbiente", pObj.idAmbiente),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarAmbiente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
