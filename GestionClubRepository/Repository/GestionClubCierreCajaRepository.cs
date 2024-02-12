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
    public class GestionClubCierreCajaRepository : IGestionClubCierreCajaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubCierreCajaDto xObj = new GestionClubCierreCajaDto();
        private List<GestionClubCierreCajaDto> xLista = new List<GestionClubCierreCajaDto>();
        private GestionClubCierreCajaDto Objeto(IDataReader iDr)
        {
            GestionClubCierreCajaDto xObjEnc = new GestionClubCierreCajaDto();
            xObjEnc.idCierreCaja = Convert.ToInt32(iDr["idCierreCaja"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.fecCierreCaja = Convert.ToDateTime(iDr["fecCierreCaja"]);
            xObjEnc.montoCierreCaja = Convert.ToDecimal(iDr["montoCierreCaja"]);
            xObjEnc.caja = Convert.ToString(iDr["caja"]);
            xObjEnc.estadoCierreCaja = Convert.ToString(iDr["estadoCierreCaja"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idCierreCaja.ToString();
            return xObjEnc;
        }
        private GestionClubCierreCajaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubCierreCajaDto> ListarObjetos(string pScript)
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
        private List<GestionClubCierreCajaDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubCierreCajaDto> ListarCierreCajas()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarCierreCajas", lParameter);
        }
        public GestionClubCierreCajaDto ListarCierreCajaPorFechaPorCaja(GestionClubCierreCajaDto obj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@fecCierreCaja", obj.fecCierreCaja.ToShortDateString()),
                    new SqlParameter("@caja", obj.caja)
                };
            return this.BuscarObjeto("isp_ListarCierreCajaPorFechaPorCaja", lParameter);
        }
        public void AgregarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@fecCierreCaja",pObj.fecCierreCaja),
                        new SqlParameter("@montoCierreCaja",pObj.montoCierreCaja),
                        new SqlParameter("@caja",pObj.caja),
                        new SqlParameter("@estadoCierreCaja",pObj.estadoCierreCaja),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarCierreCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public GestionClubCierreCajaDto ListarCierreCajaPorId(GestionClubCierreCajaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idCierreCaja", pObj.idCierreCaja),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarCierreCajaPorId", lParameter);
        }
        public void ModificarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idCierreCaja",pObj.idCierreCaja),
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@fecCierreCaja",pObj.fecCierreCaja),
                        new SqlParameter("@montoCierreCaja",pObj.montoCierreCaja),
                        new SqlParameter("@caja",pObj.caja),
                        new SqlParameter("@estadoCierreCaja",pObj.estadoCierreCaja),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarCierreCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarCierreCaja(GestionClubCierreCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idCierreCaja", pObj.idCierreCaja),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarCierreCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

    }
}
