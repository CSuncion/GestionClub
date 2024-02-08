using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GestionClubConnection.Connection;
using GestionClubRepository.IRepository;

namespace GestionClubRepository.Repository
{
    public class GestionClubCorrelativoComprobanteRepository : IGestionClubCorrelativoComprobanteRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubCorrelativoComprobanteDto xObj = new GestionClubCorrelativoComprobanteDto();
        private List<GestionClubCorrelativoComprobanteDto> xLista = new List<GestionClubCorrelativoComprobanteDto>();
        private GestionClubCorrelativoComprobanteDto Objeto(IDataReader iDr)
        {
            GestionClubCorrelativoComprobanteDto xObjEnc = new GestionClubCorrelativoComprobanteDto();
            xObjEnc.idCorrelativoComprobante = Convert.ToInt32(iDr[GestionClubCorrelativoComprobanteDto._idCorrelativoComprobante]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubCorrelativoComprobanteDto._idEmpresa]);
            xObjEnc.tipoDocumento = iDr[GestionClubCorrelativoComprobanteDto._tipoDocumento].ToString();
            xObjEnc.caja = iDr[GestionClubCorrelativoComprobanteDto._caja].ToString();
            xObjEnc.serCorrelativo = iDr[GestionClubCorrelativoComprobanteDto._serCorrelativo].ToString();
            xObjEnc.nroCorrelativo = iDr[GestionClubCorrelativoComprobanteDto._nroCorrelativo].ToString();
            xObjEnc.estado = Convert.ToString(iDr[GestionClubCorrelativoComprobanteDto._estado]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idCorrelativoComprobante.ToString();
            return xObjEnc;
        }
        private GestionClubCorrelativoComprobanteDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubCorrelativoComprobanteDto> ListarObjetos(string pScript)
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
        private List<GestionClubCorrelativoComprobanteDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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

        public GestionClubCorrelativoComprobanteDto GenerarCorrelativo(GestionClubCorrelativoComprobanteDto objEn)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@tipoDocumento",objEn.tipoDocumento),
                new SqlParameter("@caja",Universal.caja),
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_GenerarCorrelativo", lParameter);
        }
        public void ActualizarCorrelativo(GestionClubCorrelativoComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@tipoDocumento",pObj.tipoDocumento),
                    new SqlParameter("@caja",Universal.caja),
                    new SqlParameter("@serCorrelativo",pObj.serCorrelativo),
                    new SqlParameter("@nroCorrelativo",pObj.nroCorrelativo),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ActualizarCorrelativo");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
