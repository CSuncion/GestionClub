using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestionClubRepository.Repository
{
    public class GestionClubAccessRepository : IGestionClubAccessRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubAccessDto xObj = new GestionClubAccessDto();
        private List<GestionClubAccessDto> xLista = new List<GestionClubAccessDto>();
        private GestionClubAccessDto Objeto(IDataReader iDr)
        {
            GestionClubAccessDto xObjEnc = new GestionClubAccessDto();
            xObjEnc.idAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.IdAcc]);
            xObjEnc.codAcceso = iDr[GestionClubAccessDto.codAcc].ToString();
            xObjEnc.nombreAcceso = iDr[GestionClubAccessDto.nombreAcc].ToString();
            xObjEnc.dniAcceso = iDr[GestionClubAccessDto.DniAcc].ToString();
            xObjEnc.passAcceso = iDr[GestionClubAccessDto.PassAcc].ToString();
            xObjEnc.paternoAcceso = iDr[GestionClubAccessDto.PatAcc].ToString();
            xObjEnc.maternoAcceso = iDr[GestionClubAccessDto.MatAcc].ToString();
            xObjEnc.nombresAcceso = iDr[GestionClubAccessDto.nombresAcc].ToString();
            xObjEnc.mailAcceso = iDr[GestionClubAccessDto.MailAcc].ToString();
            xObjEnc.domicilioAcceso = iDr[GestionClubAccessDto.DomAcc].ToString();
            xObjEnc.dptoAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.DptoAcc]);
            xObjEnc.provAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.ProvAcc]);
            xObjEnc.distAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.DistAcc]);
            xObjEnc.fijoAcceso = iDr[GestionClubAccessDto.FijAcc].ToString();
            xObjEnc.movilAcceso = iDr[GestionClubAccessDto.MovAcc].ToString();
            xObjEnc.levelAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.LevAcc]);
            xObjEnc.sitAcceso = Convert.ToInt32(iDr[GestionClubAccessDto.SitAcc]);
            xObjEnc.fechaAcceso = Convert.ToDateTime(iDr[GestionClubAccessDto.FecAcc]);
            xObjEnc.ofc1 = Convert.ToInt32(iDr[GestionClubAccessDto.Of1]);
            xObjEnc.ofc2 = Convert.ToInt32(iDr[GestionClubAccessDto.Of2]);
            xObjEnc.ofc3 = Convert.ToInt32(iDr[GestionClubAccessDto.Of3]);
            xObjEnc.ofc4 = Convert.ToInt32(iDr[GestionClubAccessDto.Of4]);
            xObjEnc.cipAcceso = iDr[GestionClubAccessDto.CipAcc].ToString();
            xObjEnc.codofinAcceso = iDr[GestionClubAccessDto.CodfinAcc].ToString();
            xObjEnc.gradoAcceso = Convert.ToDecimal(iDr[GestionClubAccessDto.GradAcc]);
            xObjEnc.pnp = Convert.ToInt32(iDr[GestionClubAccessDto.xPnp]);
            xObjEnc.cargoAcceso = iDr[GestionClubAccessDto.CargAcc].ToString();
            return xObjEnc;
        }
        private GestionClubAccessDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubAccessDto> ListarObjetos(string pScript)
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
        private List<GestionClubAccessDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public GestionClubAccessDto BuscarUsuarioXCodigo(GestionClubAccessDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniAccess", pObj.dniAcceso)
                };

            return this.BuscarObjeto("isp_BuscarUsuarioXCodigo", lParameter);
        }
        public List<int> ListarSubPrivilegiosAcceso(int idAcceso)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdAcceso", idAcceso)
                };

            List<int> menu = new List<int>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarSubPrivilegiosAcceso");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                menu.Add((int)xIdr[0]);
            }
            xObjCn.Disconnect();
            return menu;
        }
        public List<GestionClubAccessDto> ListarUsuarioMeserosActivos(GestionClubAccessDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@gradoAcceso", pObj.gradoAcceso)
                };

            return this.BuscarObjetoPorParametro("isp_ListarUsuarioMeserosActivos", lParameter);
        }
    }
}
