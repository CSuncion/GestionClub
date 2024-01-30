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
    public class GestionClubMesaRepository : IGestionClubMesaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubMesaDto xObj = new GestionClubMesaDto();
        private List<GestionClubMesaDto> xLista = new List<GestionClubMesaDto>();
        private GestionClubMesaDto Objeto(IDataReader iDr)
        {
            GestionClubMesaDto xObjEnc = new GestionClubMesaDto();
            xObjEnc.GestionClubAmbientesDto = new GestionClubAmbientesDto();
            xObjEnc.idAmbiente = Convert.ToInt32(iDr["idAmbiente"]);
            xObjEnc.idMesa = Convert.ToInt32(iDr["idMesa"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.codMesas = iDr["codMesas"].ToString();
            xObjEnc.desMesas = iDr["desMesas"].ToString();
            xObjEnc.desAmbiente = iDr["desAmbiente"].ToString();
            xObjEnc.sitMesa = Convert.ToString(iDr["sitMesa"]);
            xObjEnc.estadoMesa = Convert.ToString(iDr["estadoMesa"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = Convert.ToString(iDr["idMesa"]);
            return xObjEnc;
        }
        private GestionClubMesaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubMesaDto> ListarObjetos(string pScript)
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
        private List<GestionClubMesaDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubMesaDto> ListarMesas()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarMesas", lParameter);
        }
        public GestionClubMesaDto ListarMesaPorId(GestionClubMesaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                new SqlParameter("@idMesa", pObj.idMesa)
                };
            return this.BuscarObjeto("isp_ListarMesaPorId", lParameter);
        }
        public GestionClubMesaDto ListarMesasPorCodigoPorEmpresa(GestionClubMesaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codMesas),
                new SqlParameter("@empresa", pObj.idEmpresa)
                };
            return this.BuscarObjeto("isp_ListarMesasPorCodigoPorEmpresa", lParameter);
        }
        public void AgregarMesa(GestionClubMesaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idAmbiente",pObj.idAmbiente),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codMesas",pObj.codMesas),
                    new SqlParameter("@desMesas",pObj.desMesas),
                    new SqlParameter("@sitMesa", pObj.sitMesa),
                    new SqlParameter("@estadoMesa",pObj.estadoMesa),
                    new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarMesa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarMesa(GestionClubMesaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idMesa", pObj.idMesa),
                    new SqlParameter("@idAmbiente", pObj.idAmbiente),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@codMesas", pObj.codMesas),
                    new SqlParameter("@desMesas", pObj.desMesas),
                    new SqlParameter("@sitMesa", pObj.sitMesa),
                    new SqlParameter("@estadoMesa", pObj.estadoMesa),
                    new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarMesa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarMesa(GestionClubMesaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idMesa", pObj.idAmbiente),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarMesa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubMesaDto> ListarMesasPorAmbientePorEmpresa(GestionClubMesaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@empresa", Universal.gIdEmpresa),
                    new SqlParameter("@idAmbiente", pObj.idAmbiente),
                };
            return this.BuscarObjetoPorParametro("isp_ListarMesasPorAmbientePorEmpresa", lParameter);
        }
    }
}
