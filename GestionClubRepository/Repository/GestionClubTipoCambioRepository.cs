using Comun;
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
    public class GestionClubTipoCambioRepository : IGestionClubTipoCambioRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubTipoCambioDto xObj = new GestionClubTipoCambioDto();
        private List<GestionClubTipoCambioDto> xLista = new List<GestionClubTipoCambioDto>();
        private GestionClubTipoCambioDto Objeto(IDataReader iDr)
        {
            GestionClubTipoCambioDto xObjEnc = new GestionClubTipoCambioDto();
            xObjEnc.idTipoCambio = Convert.ToInt32(iDr[GestionClubTipoCambioDto._idTipoCambio]);
            xObjEnc.FechaTipoCambio = Convert.ToString(iDr[GestionClubTipoCambioDto._FechaTipoCambio]);
            xObjEnc.CompraTipoCambio = Convert.ToDecimal(iDr[GestionClubTipoCambioDto._CompraTipoCambio]);
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[GestionClubTipoCambioDto._VentaTipoCambio]);
            xObjEnc.CEstadoTipoCambio = Convert.ToString(iDr[GestionClubTipoCambioDto._CEstadoTipoCambio]);
            xObjEnc.UsuarioAgrega = Convert.ToString(iDr[GestionClubTipoCambioDto._UsuarioAgrega]);
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[GestionClubTipoCambioDto._FechaAgrega]);
            xObjEnc.UsuarioModifica = Convert.ToString(iDr[GestionClubTipoCambioDto._UsuarioModifica]);
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[GestionClubTipoCambioDto._FechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idTipoCambio.ToString();
            return xObjEnc;
        }
        private GestionClubTipoCambioDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubTipoCambioDto> ListarObjetos(string pScript)
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
        private List<GestionClubTipoCambioDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubTipoCambioDto> ListarTipoCambio()
        {
            return this.ListarObjetos("isp_ListarTipoCambio");
        }
        public GestionClubTipoCambioDto ListarTipoCambioPorFecha(GestionClubTipoCambioDto xObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@fechaTipoCambio", Fecha.ObtenerDiaMesAno(xObj.FechaTipoCambio))
                };
            return this.BuscarObjeto("isp_ListarTipoCambioPorFecha", lParameter);
        }
        public GestionClubTipoCambioDto ListarTipoCambioPorId(GestionClubTipoCambioDto xObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idTipoCambio", xObj.idTipoCambio)
                };
            return this.BuscarObjeto("isp_ListarTipoCambioPorId", lParameter);
        }
        public void AdicionarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@FechaTipoCambio",pObj.FechaTipoCambio),
                    new SqlParameter("@CompraTipoCambio",pObj.CompraTipoCambio),
                    new SqlParameter("@VentaTipoCambio",pObj.VentaTipoCambio),
                    new SqlParameter("@CEstadoTipoCambio",pObj.CEstadoTipoCambio),
                    new SqlParameter("@UsuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@UsuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AdicionarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTipoCambio",pObj.idTipoCambio),
                    new SqlParameter("@FechaTipoCambio",pObj.FechaTipoCambio),
                    new SqlParameter("@CompraTipoCambio",pObj.CompraTipoCambio),
                    new SqlParameter("@VentaTipoCambio",pObj.VentaTipoCambio),
                    new SqlParameter("@CEstadoTipoCambio",pObj.CEstadoTipoCambio),
                    new SqlParameter("@UsuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarTipoCambio(GestionClubTipoCambioDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTipoCambio", pObj.idTipoCambio)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
