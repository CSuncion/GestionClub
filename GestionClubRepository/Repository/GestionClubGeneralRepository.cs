using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubGeneralRepository : IGestionClubGeneralRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubSistemaDetalleDto xObj = new GestionClubSistemaDetalleDto();
        private List<GestionClubSistemaDetalleDto> xLista = new List<GestionClubSistemaDetalleDto>();
        private GestionClubSistemaDetalleDto Objeto(IDataReader iDr)
        {
            GestionClubSistemaDetalleDto xObjEnc = new GestionClubSistemaDetalleDto();
            xObjEnc.gestionClubSistemaDto = new GestionClubSistemaDto();
            xObjEnc.idTabSistemaDetalle = Convert.ToInt32(iDr["idTabSistemaDetalle"]);
            xObjEnc.idTabSistema = Convert.ToInt32(iDr["idTabSistema"]);
            xObjEnc.gestionClubSistemaDto.titSistema = Convert.ToString(iDr["titSistema"]);
            xObjEnc.codigo = iDr["codigo"].ToString();
            xObjEnc.descri = iDr["descri"].ToString();
            xObjEnc.desbrv = iDr["desbrv"].ToString();
            xObjEnc.monIni = Convert.ToDecimal(iDr["monIni"]);
            xObjEnc.monFin = Convert.ToDecimal(iDr["monFin"]);
            xObjEnc.monBas = Convert.ToDecimal(iDr["monBas"]);
            xObjEnc.valMes = Convert.ToInt32(iDr["valMes"]);
            xObjEnc.valDia = Convert.ToInt32(iDr["valDia"]);
            xObjEnc.obsSistemaDetalle = Convert.ToString(iDr["obsSistemaDetalle"]);
            xObjEnc.estado = Convert.ToInt32(iDr["estado"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubSistemaDetalleDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubSistemaDetalleDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubSistemaDetalleDto> ListarObjetos(string pScript)
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
        public void CrearBackupDbFbPol()
        {
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_CrearBackupDbFbPol");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTabla(string tabla)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@tabla", tabla)
                };
            return this.BuscarObjetoPorParametro("isp_ListarSistemaDetallePorTabla", lParameter);
        }

    }
}
