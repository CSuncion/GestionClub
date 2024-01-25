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
            xObjEnc.codMesa = iDr["codMesa"].ToString();
            xObjEnc.desMesa = iDr["desMesa"].ToString();
            xObjEnc.GestionClubAmbientesDto.desAmbiente = iDr["desAmbiente"].ToString();
            xObjEnc.estadoMesa = Convert.ToInt32(iDr["estadoMesa"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
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
        public List<GestionClubMesaDto> ListarMesas()
        {
            return this.ListarObjetos("isp_ListarMesas");
        }
    }
}
