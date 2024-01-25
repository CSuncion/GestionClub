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
    public class CreditsEnvioDirrehumRepository : ICreditsEnvioDirrehumRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public void EliminaEnvioDirrehum(CreditsEnvioDirrehumDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminaEnvioDirrehum");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void InsertarTbEnvioDirrehum(string strQuery)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strInsert", strQuery),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_InsertarTbEnvioDirrehum");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
