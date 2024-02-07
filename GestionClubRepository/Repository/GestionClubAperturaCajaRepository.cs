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
    public class GestionClubAperturaCajaRepository : IGestionClubAperturaCajaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubAperturaCajaDto xObj = new GestionClubAperturaCajaDto();
        private List<GestionClubAperturaCajaDto> xLista = new List<GestionClubAperturaCajaDto>();
        private GestionClubAperturaCajaDto Objeto(IDataReader iDr)
        {
            GestionClubAperturaCajaDto xObjEnc = new GestionClubAperturaCajaDto();
            xObjEnc.idAperturaCaja = Convert.ToInt32(iDr["idAperturaCaja"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.fecAperturaCaja = Convert.ToDateTime(iDr["fecAperturaCaja"]);
            xObjEnc.montoAperturaCaja = Convert.ToDecimal(iDr["montoAperturaCaja"]);
            xObjEnc.estadoAperturaCaja = Convert.ToString(iDr["estadoAperturaCaja"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubAperturaCajaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubAperturaCajaDto> ListarObjetos(string pScript)
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
        private List<GestionClubAperturaCajaDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubAperturaCajaDto> ListarAperturaCajas()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarAperturaCajas", lParameter);
        }
        public GestionClubAperturaCajaDto ListarAperturaCajasPorFecha(GestionClubAperturaCajaDto obj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@fecAperturaCaja", obj.fecAperturaCaja)
                };
            return this.BuscarObjeto("isp_ListarAperturaCajasPorFecha", lParameter);
        }
    }
}
