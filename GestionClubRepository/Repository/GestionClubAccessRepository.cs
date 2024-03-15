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
            xObjEnc.sitAcceso = Convert.ToString(iDr[GestionClubAccessDto.SitAcc]);
            xObjEnc.Estado = Convert.ToString(iDr[GestionClubAccessDto._Estado]);
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
            xObjEnc.ClaveAprobador = iDr[GestionClubAccessDto._ClaveAprobador].ToString();
            xObjEnc.claveObjeto = xObjEnc.idAcceso.ToString();
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
        public List<string> ListarSubPrivilegiosAcceso(int idAcceso)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdAcceso", idAcceso)
                };

            List<string> menu = new List<string>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarSubPrivilegiosAcceso");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                menu.Add((string)xIdr[0]);
                menu.Add((string)xIdr[1]);
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
        public void AdicionarAcceso(GestionClubAccessDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@codAcceso",pObj.codAcceso),
                    new SqlParameter("@nombreAcceso",pObj.nombreAcceso),
                    new SqlParameter("@dniAcceso",pObj.dniAcceso),
                    new SqlParameter("@passAcceso",pObj.passAcceso),
                    new SqlParameter("@paternoAcceso",pObj.paternoAcceso),
                    new SqlParameter("@maternoAcceso",pObj.maternoAcceso),
                    new SqlParameter("@nombresAcceso",pObj.nombresAcceso),
                    new SqlParameter("@mailAcceso",pObj.mailAcceso),
                    new SqlParameter("@domicilioAcceso",pObj.domicilioAcceso),
                    new SqlParameter("@dptoAcceso",pObj.dptoAcceso),
                    new SqlParameter("@provAcceso",pObj.provAcceso),
                    new SqlParameter("@distAcceso",pObj.distAcceso),
                    new SqlParameter("@fijoAcceso",pObj.fijoAcceso),
                    new SqlParameter("@movilAcceso",pObj.movilAcceso),
                    new SqlParameter("@levelAcceso",pObj.levelAcceso),
                    new SqlParameter("@sitAcceso",pObj.sitAcceso),
                    new SqlParameter("@fechaAcceso",pObj.fechaAcceso),
                    new SqlParameter("@ofc1",pObj.ofc1),
                    new SqlParameter("@ofc2",pObj.ofc2),
                    new SqlParameter("@ofc3",pObj.ofc3),
                    new SqlParameter("@ofc4",pObj.ofc4),
                    new SqlParameter("@cipAcceso",pObj.cipAcceso),
                    new SqlParameter("@codofinAcceso",pObj.codofinAcceso),
                    new SqlParameter("@gradoAcceso",pObj.gradoAcceso),
                    new SqlParameter("@pnp",pObj.pnp),
                    new SqlParameter("@cargoAcceso",pObj.cargoAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AdicionarAcceso");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarAcceso(GestionClubAccessDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idAcceso",pObj.idAcceso),
                    new SqlParameter("@codAcceso",pObj.codAcceso),
                    new SqlParameter("@nombreAcceso",pObj.nombreAcceso),
                    new SqlParameter("@dniAcceso",pObj.dniAcceso),
                    new SqlParameter("@passAcceso",pObj.passAcceso),
                    new SqlParameter("@paternoAcceso",pObj.paternoAcceso),
                    new SqlParameter("@maternoAcceso",pObj.maternoAcceso),
                    new SqlParameter("@nombresAcceso",pObj.nombresAcceso),
                    new SqlParameter("@mailAcceso",pObj.mailAcceso),
                    new SqlParameter("@domicilioAcceso",pObj.domicilioAcceso),
                    new SqlParameter("@dptoAcceso",pObj.dptoAcceso),
                    new SqlParameter("@provAcceso",pObj.provAcceso),
                    new SqlParameter("@distAcceso",pObj.distAcceso),
                    new SqlParameter("@fijoAcceso",pObj.fijoAcceso),
                    new SqlParameter("@movilAcceso",pObj.movilAcceso),
                    new SqlParameter("@levelAcceso",pObj.levelAcceso),
                    new SqlParameter("@sitAcceso",pObj.sitAcceso),
                    new SqlParameter("@fechaAcceso",pObj.fechaAcceso),
                    new SqlParameter("@ofc1",pObj.ofc1),
                    new SqlParameter("@ofc2",pObj.ofc2),
                    new SqlParameter("@ofc3",pObj.ofc3),
                    new SqlParameter("@ofc4",pObj.ofc4),
                    new SqlParameter("@cipAcceso",pObj.cipAcceso),
                    new SqlParameter("@codofinAcceso",pObj.codofinAcceso),
                    new SqlParameter("@gradoAcceso",pObj.gradoAcceso),
                    new SqlParameter("@pnp",pObj.pnp),
                    new SqlParameter("@cargoAcceso",pObj.cargoAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarAcceso");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ActualizarClaveAprobador(GestionClubAccessDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@dniAcceso",pObj.dniAcceso),
                    new SqlParameter("@claveAprobador",pObj.ClaveAprobador),

                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ActualizarClaveAprobador");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarAcceso(GestionClubAccessDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idAcceso",pObj.idAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarAcceso");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubAccessDto> ListarUsuarioMozos()
        {
            return this.ListarObjetos("isp_ListarUsuarioMozos");
        }
        public GestionClubAccessDto ListarUsuarioMozosPorId(GestionClubAccessDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idAcceso", pObj.idAcceso)
                };

            return this.BuscarObjeto("isp_ListarUsuarioMozosPorId", lParameter);
        }
    }
}
