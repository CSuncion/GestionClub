using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using CreditsConnection.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CreditsRepository.Repository
{
    public class CreditsApplicantRepository : ICreditsApplicantRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private CreditsApplicantDto xObj = new CreditsApplicantDto();
        private List<CreditsApplicantDto> xLista = new List<CreditsApplicantDto>();
        private CreditsApplicantDto Objeto(IDataReader iDr)
        {
            CreditsApplicantDto xObjEnc = new CreditsApplicantDto();
            xObjEnc.Id_Solicitante = Convert.ToInt32(iDr[CreditsApplicantDto._Id_Solicitante]);
            xObjEnc.Dni_Solic = iDr[CreditsApplicantDto._Dni_Solic].ToString();
            xObjEnc.Codofin_Solic = iDr[CreditsApplicantDto._Codofin_Solic].ToString();
            xObjEnc.Carnet_Solic = iDr[CreditsApplicantDto._Carnet_Solic].ToString();
            xObjEnc.Paterno = iDr[CreditsApplicantDto._Paterno].ToString();
            xObjEnc.Materno = iDr[CreditsApplicantDto._Materno].ToString();
            xObjEnc.Nombres = iDr[CreditsApplicantDto._Nombres].ToString();
            xObjEnc.Sexo = Convert.ToInt32(iDr[CreditsApplicantDto._Sexo]);
            xObjEnc.Situac = Convert.ToInt32(iDr[CreditsApplicantDto._Situac]);
            xObjEnc.Und_dscto = Convert.ToInt32(iDr[CreditsApplicantDto._Und_dscto]);
            xObjEnc.Grado = Convert.ToInt32(iDr[CreditsApplicantDto._Grado]);
            xObjEnc.GradoDesc = iDr[CreditsApplicantDto._GradoDesc].ToString();
            xObjEnc.Fnace = Convert.ToDateTime(iDr[CreditsApplicantDto._Fnace]);
            xObjEnc.Domicilio = iDr[CreditsApplicantDto._Domicilio].ToString();
            xObjEnc.Dpto = Convert.ToInt32(iDr[CreditsApplicantDto._Dpto]);
            xObjEnc.Prov = Convert.ToInt32(iDr[CreditsApplicantDto._Prov]);
            xObjEnc.Dist = Convert.ToInt32(iDr[CreditsApplicantDto._Dist]);
            xObjEnc.Fijo = iDr[CreditsApplicantDto._Fijo].ToString();
            xObjEnc.Movil = iDr[CreditsApplicantDto._Movil].ToString();
            xObjEnc.Mail = iDr[CreditsApplicantDto._Mail].ToString();
            xObjEnc.NroBen = Convert.ToInt32(iDr[CreditsApplicantDto._NroBen]);
            xObjEnc.IdBca = iDr[CreditsApplicantDto._IdBca].ToString();
            xObjEnc.NumCta = iDr[CreditsApplicantDto._NumCta].ToString();
            xObjEnc.CCI = iDr[CreditsApplicantDto._CCI].ToString();
            xObjEnc.Grados = iDr[CreditsApplicantDto._Grados].ToString();
            return xObjEnc;
        }
        private CreditsApplicantDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            if (lParameter != null)
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
        private List<CreditsApplicantDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            if (lParameter != null)
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

        public List<dynamic> ListarSolicitantes(string anio)
        {
            List<dynamic> solicitantes = new List<dynamic>();
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", anio),
                };
            xObjCn.CommandStoreProcedure("isp_ListarSolicitantes");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                solicitantes.Add(new
                {
                    Cantidad = (int)xIdr[0],
                    Grados = (string)xIdr[1]
                });
            }
            xObjCn.Disconnect();
            return solicitantes;
        }
    }
}
