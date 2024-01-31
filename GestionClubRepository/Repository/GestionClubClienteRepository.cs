using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
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
            xObjEnc.tipCliente = Convert.ToString(iDr["tipCliente"]);
            xObjEnc.nroIdentificacionCliente = Convert.ToString(iDr["nroIdentificacionCliente"]);
            xObjEnc.nombreRazSocialCliente = Convert.ToString(iDr["nombreRazSocialCliente"]);
            xObjEnc.razComercialCliente = Convert.ToString(iDr["razComercialCliente"]);
            xObjEnc.emailCliente = Convert.ToString(iDr["emailCliente"]);
            xObjEnc.nroCelularCliente = Convert.ToString(iDr["nroCelularCliente"]);
            xObjEnc.representanteCliente = Convert.ToString(iDr["representanteCliente"]);
            xObjEnc.estadoCliente = Convert.ToString(iDr["estadoCliente"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idCliente.ToString();
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
        private List<GestionClubClienteDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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

        public List<GestionClubClienteDto> ListarClientes()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarClientes", lParameter);
        }
        public List<GestionClubClienteDto> ListarClientesActivos()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarClientesActivos", lParameter);
        }

        public GestionClubClienteDto ListarClientePorId(GestionClubClienteDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idCliente", pObj.idCliente),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarClientePorId", lParameter);
        }
        public GestionClubClienteDto ListarClientePorCodigoPorEmpresa(GestionClubClienteDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codCliente),
                new SqlParameter("@empresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarClientePorCodigoPorEmpresa", lParameter);
        }
        public void AgregarCliente(GestionClubClienteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codCliente",pObj.codCliente),
                    new SqlParameter("@tipSocioCliente",pObj.tipSocioCliente),
                    new SqlParameter("@tipCliente",pObj.tipCliente),
                    new SqlParameter("@nroIdentificacionCliente",pObj.nroIdentificacionCliente),
                    new SqlParameter("@nombreRazSocialCliente",pObj.nombreRazSocialCliente),
                    new SqlParameter("@razComercialCliente",pObj.razComercialCliente),
                    new SqlParameter("@emailCliente",pObj.emailCliente),
                    new SqlParameter("@nroCelularCliente",pObj.nroCelularCliente),
                    new SqlParameter("@representanteCliente",pObj.representanteCliente),
                    new SqlParameter("@estadoCliente",pObj.estadoCliente),
                    new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarCliente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarCliente(GestionClubClienteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idCliente",pObj.idCliente),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codCliente",pObj.codCliente),
                    new SqlParameter("@tipSocioCliente",pObj.tipSocioCliente),
                    new SqlParameter("@tipCliente",pObj.tipCliente),
                    new SqlParameter("@nroIdentificacionCliente",pObj.nroIdentificacionCliente),
                    new SqlParameter("@nombreRazSocialCliente",pObj.nombreRazSocialCliente),
                    new SqlParameter("@razComercialCliente",pObj.razComercialCliente),
                    new SqlParameter("@emailCliente",pObj.emailCliente),
                    new SqlParameter("@nroCelularCliente",pObj.nroCelularCliente),
                    new SqlParameter("@representanteCliente",pObj.representanteCliente),
                    new SqlParameter("@estadoCliente",pObj.estadoCliente),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarCliente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarCliente(GestionClubClienteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idCliente", pObj.idCliente),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarCliente");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public GestionClubClienteDto ListarClientePorNroDocumentoPorEmpresa(GestionClubClienteDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@empresa", Universal.gIdEmpresa),
                new SqlParameter("@nroIdentificacionCliente", pObj.nroIdentificacionCliente),                
                };
            return this.BuscarObjeto("isp_ListarClientePorNroDocumentoPorEmpresa", lParameter);
        }
    }
}
