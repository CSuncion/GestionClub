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
        private GestionClubSistemaDetalleDto xObjDetalle = new GestionClubSistemaDetalleDto();
        private List<GestionClubSistemaDetalleDto> xListaDetalle = new List<GestionClubSistemaDetalleDto>();

        private GestionClubSistemaDto xObjCabecera = new GestionClubSistemaDto();
        private List<GestionClubSistemaDto> xListaCabecera = new List<GestionClubSistemaDto>();

        private GestionClubSistemaDto ObjetoCabecera(IDataReader iDr)
        {
            GestionClubSistemaDto xObjEnc = new GestionClubSistemaDto();
            xObjEnc.idTabSistema = Convert.ToInt32(iDr[GestionClubSistemaDto._idTabSistema]);
            xObjEnc.nroSistema = iDr[GestionClubSistemaDto._nroSistema].ToString();
            xObjEnc.titSistema = iDr[GestionClubSistemaDto._titSistema].ToString();
            xObjEnc.titBrvSistema = iDr[GestionClubSistemaDto._titBrvSistema].ToString();
            xObjEnc.estSistema = iDr[GestionClubSistemaDto._estSistema].ToString();
            xObjEnc.obsSistema = iDr[GestionClubSistemaDto._obsSistema].ToString();
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.nroSistema.ToString();
            return xObjEnc;
        }

        private GestionClubSistemaDetalleDto ObjetoDetalle(IDataReader iDr)
        {
            GestionClubSistemaDetalleDto xObjEnc = new GestionClubSistemaDetalleDto();
            xObjEnc.idTabSistemaDetalle = Convert.ToInt32(iDr["idTabSistemaDetalle"]);
            xObjEnc.idTabSistema = Convert.ToInt32(iDr["idTabSistema"]);
            xObjEnc.titSistema = Convert.ToString(iDr["titSistema"]);
            xObjEnc.nroSistema = Convert.ToString(iDr["nroSistema"]);
            xObjEnc.codigo = iDr["codigo"].ToString();
            xObjEnc.descri = iDr["descri"].ToString();
            xObjEnc.desbrv = iDr["desbrv"].ToString();
            xObjEnc.monIni = Convert.ToDecimal(iDr["monIni"]);
            xObjEnc.monFin = Convert.ToDecimal(iDr["monFin"]);
            xObjEnc.monBas = Convert.ToDecimal(iDr["monBas"]);
            xObjEnc.valMes = Convert.ToInt32(iDr["valMes"]);
            xObjEnc.valDia = Convert.ToInt32(iDr["valDia"]);
            xObjEnc.obsSistemaDetalle = Convert.ToString(iDr["obsSistemaDetalle"]);
            xObjEnc.estado = iDr["estado"].ToString();
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idTabSistemaDetalle.ToString();
            return xObjEnc;
        }

        private GestionClubSistemaDto BuscarObjetoCabecera(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObjCabecera = this.ObjetoCabecera(xIdr);
            }
            xObjCn.Disconnect();
            return xObjCabecera;
        }
        private List<GestionClubSistemaDto> BuscarObjetoPorParametroCabecera(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaCabecera.Add(this.ObjetoCabecera(xIdr));
            }
            xObjCn.Disconnect();
            return xListaCabecera;
        }
        private List<GestionClubSistemaDto> ListarObjetosCabecera(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaCabecera.Add(this.ObjetoCabecera(xIdr));
            }
            xObjCn.Disconnect();
            return xListaCabecera;
        }


        private GestionClubSistemaDetalleDto BuscarObjetoDetalle(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObjDetalle = this.ObjetoDetalle(xIdr);
            }
            xObjCn.Disconnect();
            return xObjDetalle;
        }
        private List<GestionClubSistemaDetalleDto> BuscarObjetoPorParametroDetalle(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaDetalle.Add(this.ObjetoDetalle(xIdr));
            }
            xObjCn.Disconnect();
            return xListaDetalle;
        }
        private List<GestionClubSistemaDetalleDto> ListarObjetosDetalle(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaDetalle.Add(this.ObjetoDetalle(xIdr));
            }
            xObjCn.Disconnect();
            return xListaDetalle;
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
            return this.BuscarObjetoPorParametroDetalle("isp_ListarSistemaDetallePorTabla", lParameter);
        }
        public List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTablaPorObs(string tabla, string obs)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@tabla", tabla),
                new SqlParameter("@obs", obs)
                };
            return this.BuscarObjetoPorParametroDetalle("isp_ListarSistemaDetallePorTablaPorObs", lParameter);
        }
        public List<GestionClubSistemaDto> ListarSistema()
        {
            return this.ListarObjetosCabecera("isp_ListarSistema");
        }
        public GestionClubSistemaDetalleDto ListarSistemaDetallePorId(GestionClubSistemaDetalleDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idTabSistemaDetalle", pObj.idTabSistemaDetalle)
                };
            return this.BuscarObjetoDetalle("isp_ListarSistemaDetallePorId", lParameter);
        }
        public void AdicionarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTabSistema" ,pObj.idTabSistema.ToString()),
                    new SqlParameter("@nroSistema" ,pObj.nroSistema.ToString()),
                    new SqlParameter("@codigo" ,pObj.codigo.ToString()),
                    new SqlParameter("@descri" ,pObj.descri.ToString()),
                    new SqlParameter("@desbrv" ,pObj.desbrv.ToString()),
                    new SqlParameter("@monIni" ,pObj.monIni.ToString()),
                    new SqlParameter("@monFin" ,pObj.monFin.ToString()),
                    new SqlParameter("@monBas" ,pObj.monBas.ToString()),
                    new SqlParameter("@valMes" ,pObj.valMes.ToString()),
                    new SqlParameter("@valDia" ,pObj.valDia.ToString()),
                    new SqlParameter("@estado" ,pObj.estado.ToString()),
                    new SqlParameter("@obsSistemaDetalle" ,pObj.obsSistemaDetalle.ToString()),
                    new SqlParameter("@usuarioAgrega" ,Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica" ,Universal.gIdAcceso),

                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AdicionarSistemaDetalle");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTabSistemaDetalle" ,pObj.idTabSistemaDetalle.ToString()),
                    new SqlParameter("@idTabSistema" ,pObj.idTabSistema.ToString()),
                    new SqlParameter("@nroSistema" ,pObj.nroSistema.ToString()),
                    new SqlParameter("@codigo" ,pObj.codigo.ToString()),
                    new SqlParameter("@descri" ,pObj.descri.ToString()),
                    new SqlParameter("@desbrv" ,pObj.desbrv.ToString()),
                    new SqlParameter("@monIni" ,pObj.monIni.ToString()),
                    new SqlParameter("@monFin" ,pObj.monFin.ToString()),
                    new SqlParameter("@monBas" ,pObj.monBas.ToString()),
                    new SqlParameter("@valMes" ,pObj.valMes.ToString()),
                    new SqlParameter("@valDia" ,pObj.valDia.ToString()),
                    new SqlParameter("@estado" ,pObj.estado.ToString()),
                    new SqlParameter("@obsSistemaDetalle" ,pObj.obsSistemaDetalle.ToString()),
                    new SqlParameter("@usuarioModifica" ,pObj.usuarioModifica.ToString()),

                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarSistemaDetalle");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarSistemaDetalle(GestionClubSistemaDetalleDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTabSistemaDetalle" ,pObj.idTabSistemaDetalle.ToString()),

                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarSistemaDetalle");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public GestionClubSistemaDetalleDto ListarSistemaDetallePorCodigo(GestionClubSistemaDetalleDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idTabSistema", pObj.idTabSistema),
                new SqlParameter("@Codigo", pObj.codigo)
                };
            return this.BuscarObjetoDetalle("isp_ListarSistemaDetallePorCodigo", lParameter);
        }
        public List<GestionClubSistemaDetalleDto> ListarSistemaDetalle()
        {
            return this.ListarObjetosDetalle("isp_ListarSistemaDetalle");
        }
    }
}
