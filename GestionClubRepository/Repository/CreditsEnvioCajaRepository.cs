using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsEnvioCajaRepository : ICreditsEnvioCajaRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public void EliminaEnvioCaja(CreditsEnvioCajaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminaEnvioCaja");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
