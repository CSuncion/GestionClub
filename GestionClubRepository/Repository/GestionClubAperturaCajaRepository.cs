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
            xObjEnc.caja = Convert.ToString(iDr["caja"]);
            xObjEnc.estadoAperturaCaja = Convert.ToString(iDr["estadoAperturaCaja"]);
            xObjEnc.Estado = Convert.ToString(iDr[GestionClubAperturaCajaDto._Estado]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idAperturaCaja.ToString();
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
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@caja", Universal.caja)
                };
            return this.BuscarObjetoPorParametro("isp_ListarAperturaCajas", lParameter);
        }
        public GestionClubAperturaCajaDto ListarAperturaCajasPorFechaPorCaja(GestionClubAperturaCajaDto obj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@fecAperturaCaja", obj.fecAperturaCaja.ToShortDateString()),
                    new SqlParameter("@caja", Universal.caja)
                };
            return this.BuscarObjeto("isp_ListarAperturaCajasPorFechaPorCaja", lParameter);
        }
        public void AgregarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@fecAperturaCaja",pObj.fecAperturaCaja),
                        new SqlParameter("@montoAperturaCaja",pObj.montoAperturaCaja),
                        new SqlParameter("@caja",Universal.caja),
                        new SqlParameter("@estadoAperturaCaja",pObj.estadoAperturaCaja),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarAperturaCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public GestionClubAperturaCajaDto ListarAperturaCajaPorId(GestionClubAperturaCajaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idAperturaCaja", pObj.idAperturaCaja),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarAperturaCajasPorId", lParameter);
        }
        public void ModificarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idAperturaCaja",pObj.idAperturaCaja),
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@fecAperturaCaja",pObj.fecAperturaCaja),
                        new SqlParameter("@montoAperturaCaja",pObj.montoAperturaCaja),
                        new SqlParameter("@caja",Universal.caja),
                        new SqlParameter("@estadoAperturaCaja",pObj.estadoAperturaCaja),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarAperturaCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarAperturaCaja(GestionClubAperturaCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idAperturaCaja", pObj.idAperturaCaja),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarAperturaCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
