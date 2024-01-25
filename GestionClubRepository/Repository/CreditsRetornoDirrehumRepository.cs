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
    public class CreditsRetornoDirrehumRepository : ICreditsRetornoDirrehumRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public void BuscarProcesoRetornoDirrehum(CreditsRetornoDirrehumDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strCodoFin", pObj.Codofin),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strSituacion", pObj.Situacion),
                new SqlParameter("@strImporte", pObj.Importe),
                new SqlParameter("@strCom", pObj.Com),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_BuscarProcesoRetornoDirrehum");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public List<CreditsRetornoDirrehumDto> SelRetDirrehumAnioMesTrabajado(CreditsRetornoDirrehumDto creditsRetornoDirrehumDto)
        {
            List<CreditsRetornoDirrehumDto> selRetornoDirrehum = new List<CreditsRetornoDirrehumDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", creditsRetornoDirrehumDto.Anio),
                new SqlParameter("@strMes", creditsRetornoDirrehumDto.Mes),
                new SqlParameter("@strFico", creditsRetornoDirrehumDto.Fico),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_RetDirrehum_AnioMes_Trabajado");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                selRetornoDirrehum.Add(new CreditsRetornoDirrehumDto()
                {
                    CodofinRetorno = (string)xIdr[0],
                    Descontado = (decimal)xIdr[1],
                    Envio = (decimal)xIdr[2],
                    Tipo = (string)xIdr[3],
                    Fi = (decimal)xIdr[4],
                    Queda = (decimal)xIdr[5],
                    Co = (decimal)xIdr[6],
                    Resta = (decimal)xIdr[7],
                });
            }
            xObjCn.Disconnect();
            return selRetornoDirrehum;
        }
    }
}
