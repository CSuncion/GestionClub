using Comun;
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
    public class GestionClubComandaRepository : IGestionClubComandaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubComandaDto xObj = new GestionClubComandaDto();
        private List<GestionClubComandaDto> xLista = new List<GestionClubComandaDto>();
        private GestionClubDetalleComandaDto xObjDet = new GestionClubDetalleComandaDto();
        private List<GestionClubDetalleComandaDto> xListaDet = new List<GestionClubDetalleComandaDto>();
        private GestionClubComandaDto ObjetoCabecera(IDataReader iDr)
        {
            GestionClubComandaDto xObjEnc = new GestionClubComandaDto();
            xObjEnc.idComanda = Convert.ToInt32(iDr[GestionClubComandaDto._idComanda]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubComandaDto._idEmpresa]);
            xObjEnc.tipDocumentoComanda = iDr[GestionClubComandaDto._tipDocumentoComanda].ToString();
            xObjEnc.nroComanda = iDr[GestionClubComandaDto._nroComanda].ToString();
            xObjEnc.idAmbiente = Convert.ToInt32(iDr[GestionClubComandaDto._idAmbiente]);
            xObjEnc.idMesa = Convert.ToInt32(iDr[GestionClubComandaDto._idMesa]);
            xObjEnc.fecComanda = Convert.ToDateTime(iDr[GestionClubComandaDto._fecComanda]);
            xObjEnc.idMozo = Convert.ToInt32(iDr[GestionClubComandaDto._idMozo]);
            xObjEnc.turnoCaja = Convert.ToString(iDr[GestionClubComandaDto._turnoCaja]);
            xObjEnc.idCliente = Convert.ToInt32(iDr[GestionClubComandaDto._idCliente]);
            xObjEnc.idComprobante = Convert.ToInt32(iDr[GestionClubComandaDto._idComprobante]);
            xObjEnc.nroAtencion = Convert.ToString(iDr[GestionClubComandaDto._nroAtencion]);
            xObjEnc.obsComprobante = Convert.ToString(iDr[GestionClubComandaDto._obsComprobante]);
            xObjEnc.estadoComanda = Convert.ToString(iDr[GestionClubComandaDto._estadoComanda]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubComandaDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubComandaDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubComandaDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubComandaDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idComanda.ToString();
            return xObjEnc;
        }
        private GestionClubDetalleComandaDto ObjetoDetalle(IDataReader iDr)
        {
            GestionClubDetalleComandaDto xObjEnc = new GestionClubDetalleComandaDto();
            xObjEnc.idDetalleComanda = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idDetalleComanda]);
            xObjEnc.idComanda = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idComanda]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idEmpresa]);
            xObjEnc.idAmbiente = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idAmbiente]);
            xObjEnc.desAmbiente = Convert.ToString(iDr[GestionClubDetalleComandaDto._desAmbiente]);
            xObjEnc.idMesa = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idMesa]);
            xObjEnc.desMesas = Convert.ToString(iDr[GestionClubDetalleComandaDto._desMesas]);
            xObjEnc.idMozo = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idMozo]);
            xObjEnc.fecDetalleComanda = Convert.ToDateTime(iDr[GestionClubDetalleComandaDto._fecDetalleComanda]);
            xObjEnc.idProducto = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._idProducto]);
            xObjEnc.desProducto = Convert.ToString(iDr[GestionClubDetalleComandaDto._desProducto]);
            xObjEnc.archivoProducto = Convert.ToString(iDr[GestionClubDetalleComandaDto._archivoProducto]);
            xObjEnc.preVenta = Convert.ToDecimal(iDr[GestionClubDetalleComandaDto._preVenta]);
            xObjEnc.cantidad = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._cantidad]);
            xObjEnc.preTotal = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._preTotal]);
            xObjEnc.nroAtencion = Convert.ToString(iDr[GestionClubDetalleComandaDto._nroAtencion]);
            xObjEnc.obsComprobante = Convert.ToString(iDr[GestionClubDetalleComandaDto._obsComprobante]);
            xObjEnc.estadoComanda = Convert.ToString(iDr[GestionClubDetalleComandaDto._estadoComanda]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubDetalleComandaDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubDetalleComandaDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubDetalleComandaDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idDetalleComanda.ToString();
            return xObjEnc;
        }
        private GestionClubComandaDto BuscarObjetoCabecera(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.ObjetoCabecera(xIdr);
            }
            xObjCn.Disconnect();
            return xObj;
        }
        private List<GestionClubComandaDto> ListarObjetosCabecera(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.ObjetoCabecera(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private List<GestionClubComandaDto> BuscarObjetoPorParametroCabecera(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.ObjetoCabecera(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private GestionClubDetalleComandaDto BuscarObjetoDetalle(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObjDet = this.ObjetoDetalle(xIdr);
            }
            xObjCn.Disconnect();
            return xObjDet;
        }
        private List<GestionClubDetalleComandaDto> ListarObjetosDetalle(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaDet.Add(this.ObjetoDetalle(xIdr));
            }
            xObjCn.Disconnect();
            return xListaDet;
        }
        private List<GestionClubDetalleComandaDto> BuscarObjetoPorParametroDetalle(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaDet.Add(this.ObjetoDetalle(xIdr));
            }
            xObjCn.Disconnect();
            return xListaDet;
        }
        public int AgregarComanda(GestionClubComandaDto pObj)
        {
            int xIdentity = 0;
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@tipDocumentoComanda",pObj.tipDocumentoComanda),
                new SqlParameter("@nroComanda",pObj.nroComanda),
                new SqlParameter("@idAmbiente",pObj.idAmbiente),
                new SqlParameter("@idMesa",pObj.idMesa),
                new SqlParameter("@fecComanda",pObj.fecComanda),
                new SqlParameter("@idMozo",pObj.idMozo),
                new SqlParameter("@turnoCaja",pObj.turnoCaja),
                new SqlParameter("@idCliente",pObj.idCliente),
                new SqlParameter("@idComprobante",pObj.idComprobante),
                new SqlParameter("@nroAtencion",pObj.nroAtencion),
                new SqlParameter("@obsComprobante",pObj.obsComprobante),
                new SqlParameter("@estadoComanda",pObj.estadoComanda),
                new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                new SqlParameter("@usuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarComanda");
            xIdentity = xObjCn.GetInt();
            xObjCn.Disconnect();
            return xIdentity;
        }
        public void AgregarDetalleComanda(GestionClubDetalleComandaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idComanda",pObj.idComanda),
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@idAmbiente",pObj.idAmbiente),
                new SqlParameter("@idMesa",pObj.idMesa),
                new SqlParameter("@idMozo",pObj.idMozo),
                new SqlParameter("@fecDetalleComanda",pObj.fecDetalleComanda),
                new SqlParameter("@idProducto",pObj.idProducto),
                new SqlParameter("@preVenta",pObj.preVenta),
                new SqlParameter("@cantidad",pObj.cantidad),
                new SqlParameter("@preTotal",pObj.preTotal),
                new SqlParameter("@nroAtencion",pObj.nroAtencion),
                new SqlParameter("@obsComprobante",pObj.obsComprobante),
                new SqlParameter("@estadoComanda",pObj.estadoComanda),
                new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                new SqlParameter("@usuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarDetalleComanda");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarProducto(GestionClubProductoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idProducto",pObj.idProducto),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codProducto",pObj.codProducto),
                    new SqlParameter("@desProducto",pObj.desProducto),
                    new SqlParameter("@uniMedProducto",pObj.uniMedProducto),
                    new SqlParameter("@codMoneda",pObj.codMoneda),
                    new SqlParameter("@preCosProducto",pObj.preCosProducto),
                    new SqlParameter("@preVtsProducto",pObj.preVtsProducto),
                    new SqlParameter("@preVnsProducto",pObj.preVnsProducto),
                    new SqlParameter("@afeIgvProducto",pObj.afeIgvProducto),
                    new SqlParameter("@afeDtraProducto",pObj.afeDtraProducto),
                    new SqlParameter("@porDtraProducto",pObj.porDtraProducto),
                    new SqlParameter("@impDolProducto",pObj.impDolProducto),
                    new SqlParameter("@impOtrProducto",pObj.impOtrProducto),
                    new SqlParameter("@stockProducto", pObj.stockProducto),
                    new SqlParameter("@archivoProducto", pObj.archivoProducto),
                    new SqlParameter("@obsProducto",pObj.obsProducto),
                    new SqlParameter("@idCategoria",pObj.idCategoria),
                    new SqlParameter("@estadoProducto",pObj.estadoProducto),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarProducto(GestionClubProductoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idProducto", pObj.idProducto),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubDetalleComandaDto> ListarDetalleComandaPorMesaYPendienteCobrar(GestionClubDetalleComandaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                new SqlParameter("@idMesa", pObj.idMesa)
                };
            return this.BuscarObjetoPorParametroDetalle("isp_ListarDetalleComandaPorMesaYPendienteCobrar", lParameter);
        }


    }
}
