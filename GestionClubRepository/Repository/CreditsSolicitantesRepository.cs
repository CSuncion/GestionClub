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
    public class CreditsSolicitantesRepository : ICreditsSolicitantesRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private CreditsSolicitantesDto xObj = new CreditsSolicitantesDto();
        private List<CreditsSolicitantesDto> xLista = new List<CreditsSolicitantesDto>();
        private CreditsSolicitantesDto Objeto(IDataReader iDr)
        {
            CreditsSolicitantesDto xObjEnc = new CreditsSolicitantesDto();

            xObjEnc.Id_Solicitante = Convert.ToInt32(iDr[CreditsSolicitantesDto.xId_Solicitante]);
            xObjEnc.Dni_Solic = iDr[CreditsSolicitantesDto.xDni_Solic].ToString();
            xObjEnc.Codofin_Solic = iDr[CreditsSolicitantesDto.xCodofin_Solic].ToString();
            xObjEnc.Carnet_Solic = iDr[CreditsSolicitantesDto.xCarnet_Solic].ToString();
            xObjEnc.Paterno = iDr[CreditsSolicitantesDto.xPaterno].ToString();
            xObjEnc.Materno = iDr[CreditsSolicitantesDto.xMaterno].ToString();
            xObjEnc.Nombres = iDr[CreditsSolicitantesDto.xNombres].ToString();
            xObjEnc.Sexo = Convert.ToInt32(iDr[CreditsSolicitantesDto.xSexo]);
            xObjEnc.Situac = Convert.ToInt32(iDr[CreditsSolicitantesDto.xSituac]);
            xObjEnc.Und_dscto = Convert.ToInt32(iDr[CreditsSolicitantesDto.xUnd_dscto]);
            xObjEnc.Grado = Convert.ToInt32(iDr[CreditsSolicitantesDto.xGrado]);
            xObjEnc.DesGrado = iDr[CreditsSolicitantesDto.xDesGrado].ToString();
            xObjEnc.Fnace = Convert.ToDateTime(iDr[CreditsSolicitantesDto.xFnace]);
            xObjEnc.Domicilio = iDr[CreditsSolicitantesDto.xDomicilio].ToString();
            xObjEnc.Dpto = Convert.ToInt32(iDr[CreditsSolicitantesDto.xDpto]);
            xObjEnc.Prov = Convert.ToInt32(iDr[CreditsSolicitantesDto.xProv]);
            xObjEnc.Dist = Convert.ToInt32(iDr[CreditsSolicitantesDto.xDist]);
            xObjEnc.DesDpto = iDr[CreditsSolicitantesDto.xDesDpto].ToString();
            xObjEnc.DesProv = iDr[CreditsSolicitantesDto.xDesProv].ToString();
            xObjEnc.DesDist = iDr[CreditsSolicitantesDto.xDesDist].ToString();
            xObjEnc.Fijo = iDr[CreditsSolicitantesDto.xFijo].ToString();
            xObjEnc.Movil = iDr[CreditsSolicitantesDto.xMovil].ToString();
            xObjEnc.Mail = iDr[CreditsSolicitantesDto.xMail].ToString();
            xObjEnc.NroBen = iDr[CreditsSolicitantesDto.xNroBen].ToString();
            xObjEnc.IdBca = iDr[CreditsSolicitantesDto.xIdBca].ToString();
            xObjEnc.NumCta = iDr[CreditsSolicitantesDto.xNumCta].ToString();
            xObjEnc.CCI = iDr[CreditsSolicitantesDto.xCCI].ToString();
            return xObjEnc;
        }
        private CreditsSolicitantesDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<CreditsSolicitantesDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
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

        public CreditsSolicitantesDto ListarSolicitantesPorDni(CreditsSolicitantesDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", pObj.Dni_Solic)
                };

            return this.BuscarObjeto("isp_ListarSolicitantesPorDni", lParameter);
        }
    }
}
