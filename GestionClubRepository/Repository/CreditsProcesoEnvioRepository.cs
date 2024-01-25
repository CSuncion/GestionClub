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
    public class CreditsProcesoEnvioRepository : ICreditsProcesoEnvioRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public void InsertarProcesoEnvio(CreditsProcesoEnvioDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strUser", Universal.gIdAcceso),
                new SqlParameter("@strUnidDscto", pObj.UnidDscto),
                new SqlParameter("@strFecha", pObj.Fecha),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_InsertarProcesoEnvio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
