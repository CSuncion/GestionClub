using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubClienteRepository : IGestionClubClienteRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubClienteDto xObj = new GestionClubClienteDto();
        private List<GestionClubClienteDto> xLista = new List<GestionClubClienteDto>();
        private GestionClubClienteDto Objeto(IDataReader iDr)
        {
            GestionClubClienteDto xObjEnc = new GestionClubClienteDto();
            xObjEnc.idCliente = Convert.ToInt32(iDr["idCliente"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.codCliente = iDr["codCliente"].ToString();
            xObjEnc.tipSocioCliente = iDr["tipSocioCliente"].ToString();
            xObjEnc.tipCliente= Convert.ToString(iDr["tipCliente"]);
            xObjEnc.nroIdentificacionCliente = Convert.ToString(iDr["nroIdentificacionCliente"]);
            xObjEnc.nombreRazSocialCliente = Convert.ToString(iDr["nombreRazSocialCliente"]);
            xObjEnc.razComercialCliente = Convert.ToString(iDr["razComercialCliente"]);
            xObjEnc.emailCliente = Convert.ToString(iDr["emailCliente"]);
            xObjEnc.nroCelularCliente = Convert.ToString(iDr["nroCelularCliente"]);
            xObjEnc.representanteCliente = Convert.ToString(iDr["representanteCliente"]);
            xObjEnc.estadoCliente = Convert.ToInt32(iDr["estadoCliente"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubClienteDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubClienteDto> ListarObjetos(string pScript)
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
        public List<GestionClubClienteDto> ListarClientes()
        {
            return this.ListarObjetos("isp_ListarClientes");
        }
    }
}
