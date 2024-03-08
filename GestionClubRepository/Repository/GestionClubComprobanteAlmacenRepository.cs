using Comun;
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
    public class GestionClubComprobanteAlmacenRepository : IGestionClubComprobanteAlmacenRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubComprobanteAlmacenDto xObj = new GestionClubComprobanteAlmacenDto();
        private List<GestionClubComprobanteAlmacenDto> xLista = new List<GestionClubComprobanteAlmacenDto>();
        private GestionClubComprobanteDetalleAlmacenDto xObjDet = new GestionClubComprobanteDetalleAlmacenDto();
        private List<GestionClubComprobanteDetalleAlmacenDto> xListaDet = new List<GestionClubComprobanteDetalleAlmacenDto>();
        private GestionClubComprobanteAlmacenDto ObjetoCabecera(IDataReader iDr)
        {
            GestionClubComprobanteAlmacenDto xObjEnc = new GestionClubComprobanteAlmacenDto();
            xObjEnc.idComprobanteAlmacen = Convert.ToInt32(iDr[GestionClubComprobanteAlmacenDto._idComprobanteAlmacen]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubComprobanteAlmacenDto._idEmpresa]);
            xObjEnc.codAlmacen = iDr[GestionClubComprobanteAlmacenDto._codAlmacen].ToString();
            xObjEnc.anoProceso = iDr[GestionClubComprobanteAlmacenDto._anoProceso].ToString();
            xObjEnc.mesProceso = iDr[GestionClubComprobanteAlmacenDto._mesProceso].ToString();
            xObjEnc.tipoMovimiento = iDr[GestionClubComprobanteAlmacenDto._tipoMovimiento].ToString();
            xObjEnc.nroDocumento = iDr[GestionClubComprobanteAlmacenDto._nroDocumento].ToString();
            xObjEnc.fecAlmacen = Convert.ToDateTime(iDr[GestionClubComprobanteAlmacenDto._fecAlmacen]);
            xObjEnc.tipCliente = iDr[GestionClubComprobanteAlmacenDto._tipCliente].ToString();
            xObjEnc.nroRuc = iDr[GestionClubComprobanteAlmacenDto._nroRuc].ToString();
            xObjEnc.razSocial = iDr[GestionClubComprobanteAlmacenDto._razSocial].ToString();
            xObjEnc.tipFactura = iDr[GestionClubComprobanteAlmacenDto._tipFactura].ToString();
            xObjEnc.desTipFactura = iDr[GestionClubComprobanteAlmacenDto._desTipFactura].ToString();
            xObjEnc.serNroFactura = iDr[GestionClubComprobanteAlmacenDto._serNroFactura].ToString();
            xObjEnc.serFactura = iDr[GestionClubComprobanteAlmacenDto._serFactura].ToString();
            xObjEnc.nroFactura = iDr[GestionClubComprobanteAlmacenDto._nroFactura].ToString();
            xObjEnc.fecFactura = Convert.ToDateTime(iDr[GestionClubComprobanteAlmacenDto._fecFactura]);
            xObjEnc.guiaRe = iDr[GestionClubComprobanteAlmacenDto._guiaRe].ToString();
            xObjEnc.fecGui = Convert.ToDateTime(iDr[GestionClubComprobanteAlmacenDto._fecGui]);
            xObjEnc.totVta = Convert.ToDecimal(iDr[GestionClubComprobanteAlmacenDto._totVta]);
            xObjEnc.totIgv = Convert.ToDecimal(iDr[GestionClubComprobanteAlmacenDto._totIgv]);
            xObjEnc.totBru = Convert.ToDecimal(iDr[GestionClubComprobanteAlmacenDto._totBru]);
            xObjEnc.estAlmacen = iDr[GestionClubComprobanteAlmacenDto._estAlmacen].ToString();
            xObjEnc.Estado = Convert.ToString(iDr[GestionClubComprobanteAlmacenDto._Estado]);
            xObjEnc.Obsope = iDr[GestionClubComprobanteAlmacenDto._Obsope].ToString();
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubComprobanteAlmacenDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubComprobanteAlmacenDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubComprobanteAlmacenDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubComprobanteAlmacenDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idComprobanteAlmacen.ToString();
            return xObjEnc;
        }
        private GestionClubComprobanteDetalleAlmacenDto ObjetoDetalle(IDataReader iDr)
        {
            GestionClubComprobanteDetalleAlmacenDto xObjEnc = new GestionClubComprobanteDetalleAlmacenDto();

            xObjEnc.idComprobanteDetalleAlmacen = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._idComprobanteDetalleAlmacen]);
            xObjEnc.idComprobanteAlmacen = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._idComprobanteAlmacen]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._idEmpresa]);
            xObjEnc.codAlmacen = iDr[GestionClubComprobanteDetalleAlmacenDto._codAlmacen].ToString();
            xObjEnc.anoProceso = iDr[GestionClubComprobanteDetalleAlmacenDto._anoProceso].ToString();
            xObjEnc.mesProceso = iDr[GestionClubComprobanteDetalleAlmacenDto._mesProceso].ToString();
            xObjEnc.tipoMovimiento = iDr[GestionClubComprobanteDetalleAlmacenDto._tipoMovimiento].ToString();
            xObjEnc.nroDocumento = iDr[GestionClubComprobanteDetalleAlmacenDto._nroDocumento].ToString();
            xObjEnc.nroDocCorrelativo = iDr[GestionClubComprobanteDetalleAlmacenDto._nroDocCorrelativo].ToString();
            xObjEnc.fechaAlmacen = Convert.ToDateTime(iDr[GestionClubComprobanteDetalleAlmacenDto._fechaAlmacen]);
            xObjEnc.tipoFactura = iDr[GestionClubComprobanteDetalleAlmacenDto._tipoFactura].ToString();
            xObjEnc.serFactura = iDr[GestionClubComprobanteDetalleAlmacenDto._serFactura].ToString();
            xObjEnc.nroFactura = iDr[GestionClubComprobanteDetalleAlmacenDto._nroFactura].ToString();
            xObjEnc.fecFactura = Convert.ToDateTime(iDr[GestionClubComprobanteDetalleAlmacenDto._fecFactura]);
            xObjEnc.codProducto = Convert.ToString(iDr[GestionClubComprobanteDetalleAlmacenDto._codProducto]);
            xObjEnc.idProducto = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._idProducto]);
            xObjEnc.desProducto = iDr[GestionClubComprobanteDetalleAlmacenDto._desProducto].ToString();
            xObjEnc.uniMedida = iDr[GestionClubComprobanteDetalleAlmacenDto._uniMedida].ToString();
            xObjEnc.precioCosto = Convert.ToDecimal(iDr[GestionClubComprobanteDetalleAlmacenDto._precioCosto]);
            xObjEnc.cantidad = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._cantidad]);
            xObjEnc.totCosto = Convert.ToDecimal(iDr[GestionClubComprobanteDetalleAlmacenDto._totCosto]);
            xObjEnc.estAlmacen = iDr[GestionClubComprobanteDetalleAlmacenDto._estAlmacen].ToString();
            xObjEnc.Estado = Convert.ToString(iDr[GestionClubComprobanteAlmacenDto._Estado]);
            xObjEnc.obsOperacion = iDr[GestionClubComprobanteDetalleAlmacenDto._obsOperacion].ToString();
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubComprobanteDetalleAlmacenDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubComprobanteDetalleAlmacenDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubComprobanteDetalleAlmacenDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idComprobanteDetalleAlmacen.ToString();

            return xObjEnc;
        }
        private GestionClubComprobanteAlmacenDto BuscarObjetoCabecera(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubComprobanteAlmacenDto> ListarObjetosCabecera(string pScript)
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
        private List<GestionClubComprobanteAlmacenDto> BuscarObjetoPorParametroCabecera(string pScript, List<SqlParameter> lParameter)
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
        private GestionClubComprobanteDetalleAlmacenDto BuscarObjetoDetalle(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubComprobanteDetalleAlmacenDto> ListarObjetosDetalle(string pScript)
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
        private List<GestionClubComprobanteDetalleAlmacenDto> BuscarObjetoPorParametroDetalle(string pScript, List<SqlParameter> lParameter)
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
        public int AgregarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            int xIdentity = 0;
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codAlmacen",pObj.codAlmacen),
                    new SqlParameter("@anoProceso",pObj.anoProceso),
                    new SqlParameter("@mesProceso",pObj.mesProceso),
                    new SqlParameter("@tipoMovimiento",pObj.tipoMovimiento),
                    new SqlParameter("@nroDocumento",pObj.nroDocumento),
                    new SqlParameter("@fecAlmacen",pObj.fecAlmacen),
                    new SqlParameter("@tipCliente",pObj.tipCliente),
                    new SqlParameter("@nroRuc",pObj.nroRuc),
                    new SqlParameter("@razSocial",pObj.razSocial),
                    new SqlParameter("@tipFactura",pObj.tipFactura),
                    new SqlParameter("@serFactura",pObj.serFactura),
                    new SqlParameter("@nroFactura",pObj.nroFactura),
                    new SqlParameter("@fecFactura",pObj.fecFactura),
                    new SqlParameter("@guiaRe",pObj.guiaRe),
                    new SqlParameter("@fecGui",pObj.fecGui),
                    new SqlParameter("@totVta",pObj.totVta),
                    new SqlParameter("@totIgv",pObj.totIgv),
                    new SqlParameter("@totBru",pObj.totBru),
                    new SqlParameter("@estAlmacen",pObj.estAlmacen),
                    new SqlParameter("@Obsope",pObj.Obsope),
                    new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarComprobanteAlmacen");
            xIdentity = xObjCn.GetInt();
            xObjCn.Disconnect();
            return xIdentity;
        }
        public void AgregarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idComprobanteAlmacen", pObj.idComprobanteAlmacen),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@codAlmacen", pObj.codAlmacen),
                    new SqlParameter("@anoProceso", pObj.anoProceso),
                    new SqlParameter("@mesProceso", pObj.mesProceso),
                    new SqlParameter("@tipoMovimiento", pObj.tipoMovimiento),
                    new SqlParameter("@nroDocumento", pObj.nroDocumento),
                    new SqlParameter("@nroDocCorrelativo", pObj.nroDocCorrelativo),
                    new SqlParameter("@fechaAlmacen", pObj.fechaAlmacen),
                    new SqlParameter("@tipoFactura", pObj.tipoFactura),
                    new SqlParameter("@serFactura", pObj.serFactura),
                    new SqlParameter("@nroFactura", pObj.nroFactura),
                    new SqlParameter("@fecFactura", pObj.fecFactura),
                    new SqlParameter("@idProducto", pObj.idProducto),
                    new SqlParameter("@desProducto", pObj.desProducto),
                    new SqlParameter("@uniMedida", pObj.uniMedida),
                    new SqlParameter("@precioCosto", pObj.precioCosto),
                    new SqlParameter("@cantidad", pObj.cantidad),
                    new SqlParameter("@totCosto", pObj.totCosto),
                    new SqlParameter("@estAlmacen", pObj.estAlmacen),
                    new SqlParameter("@obsOperacion", pObj.obsOperacion),
                    new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarComprobanteDetalleAlmacen");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idComprobanteAlmacen",pObj.idComprobanteAlmacen),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codAlmacen",pObj.codAlmacen),
                    new SqlParameter("@anoProceso",pObj.anoProceso),
                    new SqlParameter("@mesProceso",pObj.mesProceso),
                    new SqlParameter("@tipoMovimiento",pObj.tipoMovimiento),
                    new SqlParameter("@nroDocumento",pObj.nroDocumento),
                    new SqlParameter("@fecAlmacen",pObj.fecAlmacen),
                    new SqlParameter("@tipCliente",pObj.tipCliente),
                    new SqlParameter("@nroRuc",pObj.nroRuc),
                    new SqlParameter("@razSocial",pObj.razSocial),
                    new SqlParameter("@tipFactura",pObj.tipFactura),
                    new SqlParameter("@serFactura",pObj.serFactura),
                    new SqlParameter("@nroFactura",pObj.nroFactura),
                    new SqlParameter("@fecFactura",pObj.fecFactura),
                    new SqlParameter("@guiaRe",pObj.guiaRe),
                    new SqlParameter("@fecGui",pObj.fecGui),
                    new SqlParameter("@totVta",pObj.totVta),
                    new SqlParameter("@totIgv",pObj.totIgv),
                    new SqlParameter("@totBru",pObj.totBru),
                    new SqlParameter("@estAlmacen",pObj.estAlmacen),
                    new SqlParameter("@Obsope",pObj.Obsope),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarComprobanteAlmacen");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarDetalleComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idComprobanteDetalleAlmacen", pObj.idComprobanteDetalleAlmacen),
                    new SqlParameter("@idComprobanteAlmacen", pObj.idComprobanteAlmacen),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@codAlmacen", pObj.codAlmacen),
                    new SqlParameter("@anoProceso", pObj.anoProceso),
                    new SqlParameter("@mesProceso", pObj.mesProceso),
                    new SqlParameter("@tipoMovimiento", pObj.tipoMovimiento),
                    new SqlParameter("@nroDocumento", pObj.nroDocumento),
                    new SqlParameter("@nroDocCorrelativo", pObj.nroDocCorrelativo),
                    new SqlParameter("@fechaAlmacen", pObj.fechaAlmacen),
                    new SqlParameter("@tipoFactura", pObj.tipoFactura),
                    new SqlParameter("@serFactura", pObj.serFactura),
                    new SqlParameter("@nroFactura", pObj.nroFactura),
                    new SqlParameter("@fecFactura", pObj.fecFactura),
                    new SqlParameter("@idProducto", pObj.idProducto),
                    new SqlParameter("@desProducto", pObj.desProducto),
                    new SqlParameter("@uniMedida", pObj.uniMedida),
                    new SqlParameter("@precioCosto", pObj.precioCosto),
                    new SqlParameter("@cantidad", pObj.cantidad),
                    new SqlParameter("@totCosto", pObj.totCosto),
                    new SqlParameter("@estAlmacen", pObj.estAlmacen),
                    new SqlParameter("@obsOperacion", pObj.obsOperacion),
                    new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarComprobanteDetalleAlmacen");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idComprobanteAlmacen", pObj.idComprobanteAlmacen),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarComprobanteAlmacen");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idComprobanteAlmacen", pObj.idComprobanteAlmacen),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarComprobanteDetalleAlmacen");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubComprobanteAlmacenDto> ListarComprobanteAlmacen(GestionClubComprobanteAlmacenDto objEn)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametroCabecera("isp_ListarComprobanteAlmacen", lParameter);
        }
        public GestionClubComprobanteAlmacenDto ListarComprobanteAlmacenPorId(GestionClubComprobanteAlmacenDto objEn)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@idComprobanteAlmacen",objEn.idComprobanteAlmacen)
                };
            return this.BuscarObjetoCabecera("isp_ListarComprobanteAlmacenPorId", lParameter);
        }
        public List<GestionClubComprobanteDetalleAlmacenDto> ListarComprobanteDetalleAlmacenPorComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto objEn)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@idComprobanteAlmacen",objEn.idComprobanteAlmacen)
                };
            return this.BuscarObjetoPorParametroDetalle("isp_ListarComprobanteDetalleAlmacenPorComprobanteAlmacen", lParameter);
        }
        public List<GestionClubComprobanteAlmacenDto> ResumenAnioMesAlmacen(string anio, string mes)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@anio",anio),
                new SqlParameter("@mes",mes)
                };
            return this.BuscarObjetoPorParametroCabecera("isp_ResumenAnioMesAlmacen", lParameter);
        }
        public List<GestionClubComprobanteAlmacenDto> CuadroAnualIngresoYSalida(string anio, string mes)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@anio",anio),
                new SqlParameter("@mes",mes)
                };
            return this.BuscarObjetoPorParametroCabecera("isp_CuadroAnualIngresoYSalida", lParameter);
        }
    }
}
