using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsProcesoPagoRepository : ICreditsProcesoPagoRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public CreditsProcesoPagoDto SelProcesoPago(CreditsProcesoPagoDto creditsProcesoPagosDto)
        {
            CreditsProcesoPagoDto selProcesoPago = new CreditsProcesoPagoDto();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdUnidadDscto", creditsProcesoPagosDto.IdUnidadDscto),
                new SqlParameter("@strSituacion", creditsProcesoPagosDto.Situacion),
                new SqlParameter("@strIdBanca", creditsProcesoPagosDto.IdBanca),
                new SqlParameter("@strIdCheqOpe", creditsProcesoPagosDto.IdCheqOpe),
                new SqlParameter("@strNumCheqOpe", creditsProcesoPagosDto.NumCheqOpe),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_SelProcesoPago");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                selProcesoPago = new CreditsProcesoPagoDto()
                {
                    Id_ProcesoPagos = (decimal)xIdr[0],
                    F_Proces = (DateTime)xIdr[1],
                    IdUnidadDscto = (int)xIdr[2],
                    Situacion = (int)xIdr[3],
                    IdBanca = (string)xIdr[4],
                    IdCheqOpe = (int)xIdr[5],
                    NumCheqOpe = (string)xIdr[6],
                    ImporteCheqOpe = (decimal)xIdr[7],
                    Anotacion = (string)xIdr[8],
                    UserProces = (decimal)xIdr[9],
                };
            }
            xObjCn.Disconnect();
            return selProcesoPago;
        }

        public int ProcesoInsertarProcesoPago(CreditsProcesoPagoDto pObj)
        {
            int idProcesoPago = 0;
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strFProceso", pObj.F_Proces),
                new SqlParameter("@strIdUnidadDscto", pObj.IdUnidadDscto),
                new SqlParameter("@strSituacion", pObj.Situacion),
                new SqlParameter("@strIdBanca", pObj.IdBanca),
                new SqlParameter("@strIdCheqOpe", pObj.IdCheqOpe),
                new SqlParameter("@strNumCheqOpe", pObj.NumCheqOpe),
                new SqlParameter("@strImporteCheqOpe", pObj.ImporteCheqOpe),
                new SqlParameter("@strAnotacion", pObj.Anotacion),
                new SqlParameter("@strUserProces", Universal.gIdAcceso),
                new SqlParameter("@strImpBruto", pObj.impbruto),
                new SqlParameter("@strImpDscto", pObj.impdscto),
                new SqlParameter("@strImpNeto", pObj.impneto),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_InsertarProcesoPago");
            idProcesoPago = xObjCn.GetInt();
            xObjCn.Disconnect();
            return idProcesoPago;
        }
    }
}
