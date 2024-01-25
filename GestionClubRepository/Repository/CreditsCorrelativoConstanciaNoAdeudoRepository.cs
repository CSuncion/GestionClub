using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsCorrelativoConstanciaNoAdeudoRepository : ICreditsCorrelativoConstanciaNoAdeudoRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private CreditsCorrelativoConstanciaNoAdeudoDto xObj = new CreditsCorrelativoConstanciaNoAdeudoDto();
        private List<CreditsCorrelativoConstanciaNoAdeudoDto> xLista = new List<CreditsCorrelativoConstanciaNoAdeudoDto>();
        private CreditsCorrelativoConstanciaNoAdeudoDto Objeto(IDataReader iDr)
        {
            CreditsCorrelativoConstanciaNoAdeudoDto xObjEnc = new CreditsCorrelativoConstanciaNoAdeudoDto();
            xObjEnc.IdCorrelativoConstanciaNoAdeudo = (int)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xIdCorrelativoConstanciaNoAdeudo];
            xObjEnc.Periodo = (string)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xPeriodo];
            xObjEnc.Correlativo = (string)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xCorrelativo];
            xObjEnc.FechaCorrelativo = (DateTime)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xFechaCorrelativo];
            xObjEnc.DniSolicitante = (string)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xDniSolicitante];
            xObjEnc.UsuarioAgrega = (int)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xUsuarioAgrega];
            xObjEnc.FechaAgrega = (DateTime)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xFechaAgrega];
            xObjEnc.UsuarioModifica = (int)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xUsuarioModifica];
            xObjEnc.FechaModifica = (DateTime)iDr[CreditsCorrelativoConstanciaNoAdeudoDto.xFechaModifica];
            return xObjEnc;
        }
        private CreditsCorrelativoConstanciaNoAdeudoDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<CreditsCorrelativoConstanciaNoAdeudoDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
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

        public string CrearCorrelativoConstanciaNoAdeudo(CreditsCorrelativoConstanciaNoAdeudoDto pObj)
        {
            string correlativo = string.Empty;
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@strPeriodo",pObj.Periodo),
                    new SqlParameter("@strCorrelativo",pObj.Correlativo),
                    new SqlParameter("@strFechaCorrelativo",pObj.FechaCorrelativo),
                    new SqlParameter("@strDniSolicitante",pObj.DniSolicitante),
                    new SqlParameter("@strUsuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@strUsuarioModifica",Universal.gIdAcceso)
                };

            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_CrearCorrelativoConstanciaNoAdeudo");
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                correlativo = (string)xIdr[0];
            }
            xObjCn.Disconnect();
            return correlativo;
        }
    }
}
