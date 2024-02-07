﻿using Comun;
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
    public class GestionClubComprobanteRepository : IGestionClubComprobanteRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubComprobanteDto xObj = new GestionClubComprobanteDto();
        private List<GestionClubComprobanteDto> xLista = new List<GestionClubComprobanteDto>();
        private GestionClubDetalleComprobanteDto xObjDet = new GestionClubDetalleComprobanteDto();
        private List<GestionClubDetalleComprobanteDto> xListaDet = new List<GestionClubDetalleComprobanteDto>();
        private GestionClubComprobanteDto ObjetoCabecera(IDataReader iDr)
        {
            GestionClubComprobanteDto xObjEnc = new GestionClubComprobanteDto();
            xObjEnc.idComprobante = Convert.ToInt32(iDr[GestionClubComprobanteDto._idComprobante]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubComprobanteDto._idEmpresa]);
            xObjEnc.tipComprobante = iDr[GestionClubComprobanteDto._tipComprobante].ToString();
            xObjEnc.desTipComprobante = iDr[GestionClubComprobanteDto._desTipComprobante].ToString();
            xObjEnc.serNroComprobante = iDr[GestionClubComprobanteDto._serNroComprobante].ToString();
            xObjEnc.serComprobante = iDr[GestionClubComprobanteDto._serComprobante].ToString();
            xObjEnc.nroComprobante = iDr[GestionClubComprobanteDto._nroComprobante].ToString();
            xObjEnc.fecComprobante = Convert.ToDateTime(iDr[GestionClubComprobanteDto._fecComprobante]);
            xObjEnc.codMoneda = iDr[GestionClubComprobanteDto._codMoneda].ToString();
            xObjEnc.desMoneda = iDr[GestionClubComprobanteDto._desMoneda].ToString();
            xObjEnc.impCambio = Convert.ToDecimal(iDr[GestionClubComprobanteDto._impCambio]);
            xObjEnc.serGuiaComprobante = iDr[GestionClubComprobanteDto._serGuiaComprobante].ToString();
            xObjEnc.nroGuiaComprobante = iDr[GestionClubComprobanteDto._nroGuiaComprobante].ToString();
            xObjEnc.fecGuiaComprobante = Convert.ToDateTime(iDr[GestionClubComprobanteDto._fecGuiaComprobante]);
            xObjEnc.idAmbiente = Convert.ToInt32(iDr[GestionClubComprobanteDto._idAmbiente]);
            xObjEnc.idMesa = Convert.ToInt32(iDr[GestionClubComprobanteDto._idMesa]);
            xObjEnc.idMozo = Convert.ToInt32(iDr[GestionClubComprobanteDto._idMozo]);
            xObjEnc.turnoCaja = Convert.ToString(iDr[GestionClubComprobanteDto._turnoCaja]);
            xObjEnc.modPagoComprobante = iDr[GestionClubComprobanteDto._modPagoComprobante].ToString();
            xObjEnc.desPagoComprobante = iDr[GestionClubComprobanteDto._desPagoComprobante].ToString();
            xObjEnc.tipMovComprobante = iDr[GestionClubComprobanteDto._tipMovComprobante].ToString();
            xObjEnc.idCliente = Convert.ToInt32(iDr[GestionClubComprobanteDto._idCliente]);
            xObjEnc.nroIdentificacionCliente = Convert.ToString(iDr[GestionClubComprobanteDto._nroIdentificacionCliente]);
            xObjEnc.nombreRazSocialCliente = Convert.ToString(iDr[GestionClubComprobanteDto._nombreRazSocialCliente]);
            xObjEnc.obsComprobante = Convert.ToString(iDr[GestionClubComprobanteDto._obsComprobante]);
            xObjEnc.estadoComprobante = Convert.ToString(iDr[GestionClubComprobanteDto._estadoComprobante]);
            xObjEnc.desEstado = Convert.ToString(iDr[GestionClubComprobanteDto._desEstado]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubComprobanteDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubComprobanteDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubComprobanteDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubComprobanteDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idComprobante.ToString();
            return xObjEnc;
        }
        private GestionClubDetalleComprobanteDto ObjetoDetalle(IDataReader iDr)
        {
            GestionClubDetalleComprobanteDto xObjEnc = new GestionClubDetalleComprobanteDto();
            xObjEnc.idDetalleComprobante = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._idDetalleComprobante]);
            xObjEnc.idComprobante = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._idComprobante]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._idEmpresa]);
            xObjEnc.idProducto = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._idProducto]);
            xObjEnc.preVenta = Convert.ToDecimal(iDr[GestionClubDetalleComprobanteDto._preVenta]);
            xObjEnc.cantidad = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._cantidad]);
            xObjEnc.preTotal = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._preTotal]);
            xObjEnc.obsDetalleComprobante = Convert.ToString(iDr[GestionClubDetalleComprobanteDto._obsDetalleComprobante]);
            xObjEnc.estadoDetalleComprobante = Convert.ToString(iDr[GestionClubDetalleComprobanteDto._estadoDetalleComprobante]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubDetalleComprobanteDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubDetalleComprobanteDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubDetalleComprobanteDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idDetalleComprobante.ToString();
            return xObjEnc;
        }
        private GestionClubComprobanteDto BuscarObjetoCabecera(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubComprobanteDto> ListarObjetosCabecera(string pScript)
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
        private List<GestionClubComprobanteDto> BuscarObjetoPorParametroCabecera(string pScript, List<SqlParameter> lParameter)
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
        private GestionClubDetalleComprobanteDto BuscarObjetoDetalle(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubDetalleComprobanteDto> ListarObjetosDetalle(string pScript)
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
        private List<GestionClubDetalleComprobanteDto> BuscarObjetoPorParametroDetalle(string pScript, List<SqlParameter> lParameter)
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
        public int AgregarComprobante(GestionClubComprobanteDto pObj)
        {
            int xIdentity = 0;
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@tipComprobante", pObj.tipComprobante),
                    new SqlParameter("@serComprobante", pObj.serComprobante),
                    new SqlParameter("@nroComprobante", pObj.nroComprobante),
                    new SqlParameter("@fecComprobante", pObj.fecComprobante),
                    new SqlParameter("@codMoneda", pObj.codMoneda),
                    new SqlParameter("@impCambio", pObj.impCambio),
                    new SqlParameter("@serGuiaComprobante", pObj.serGuiaComprobante),
                    new SqlParameter("@nroGuiaComprobante", pObj.nroGuiaComprobante),
                    new SqlParameter("@fecGuiaComprobante", pObj.fecGuiaComprobante),
                    new SqlParameter("@idNroComanda", pObj.idNroComanda),
                    new SqlParameter("@idAmbiente", pObj.idAmbiente),
                    new SqlParameter("@idMesa", pObj.idMesa),
                    new SqlParameter("@idMozo", pObj.idMozo),
                    new SqlParameter("@turnoCaja", pObj.turnoCaja),
                    new SqlParameter("@modPagoComprobante", pObj.modPagoComprobante),
                    new SqlParameter("@tipMovComprobante", pObj.tipMovComprobante),
                    new SqlParameter("@impEfeComprobante", pObj.impEfeComprobante),
                    new SqlParameter("@impDepComprobante", pObj.impDepComprobante),
                    new SqlParameter("@impTarComprobante", pObj.impTarComprobante),
                    new SqlParameter("@impBruComprobante", pObj.impBruComprobante),
                    new SqlParameter("@impIgvComprobante", pObj.impIgvComprobante),
                    new SqlParameter("@impNetComprobante", pObj.impNetComprobante),
                    new SqlParameter("@impDtrComprobante", pObj.impDtrComprobante),
                    new SqlParameter("@idCliente", pObj.idCliente),
                    new SqlParameter("@estadoComprobante", pObj.estadoComprobante),
                    new SqlParameter("@obsComprobante", pObj.obsComprobante),
                    new SqlParameter("@usuarioAgrega", Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarComprobante");
            xIdentity = xObjCn.GetInt();
            xObjCn.Disconnect();
            return xIdentity;
        }
        public void AgregarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idComprobante", pObj.idComprobante),
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                new SqlParameter("@idProducto", pObj.idProducto),
                new SqlParameter("@preVenta", pObj.preVenta),
                new SqlParameter("@cantidad", pObj.cantidad),
                new SqlParameter("@preTotal", pObj.preTotal),
                new SqlParameter("@estadoDetalleComprobante", pObj.estadoDetalleComprobante),
                new SqlParameter("@obsDetalleComprobante", pObj.obsDetalleComprobante),
                new SqlParameter("@usuarioAgrega",  Universal.gIdAcceso),
                new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarDetalleComprobante");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarComprobante(GestionClubComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idComprobant", pObj.idComprobante),
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@tipComprobante", pObj.tipComprobante),
                    new SqlParameter("@serComprobante", pObj.serComprobante),
                    new SqlParameter("@nroComprobante", pObj.nroComprobante),
                    new SqlParameter("@fecComprobante", pObj.fecComprobante),
                    new SqlParameter("@codMoneda", pObj.codMoneda),
                    new SqlParameter("@impCambio", pObj.impCambio),
                    new SqlParameter("@serGuiaComprobante", pObj.serGuiaComprobante),
                    new SqlParameter("@nroGuiaComprobante", pObj.nroGuiaComprobante),
                    new SqlParameter("@fecGuiaComprobante", pObj.fecGuiaComprobante),
                    new SqlParameter("@idNroComanda", pObj.idNroComanda),
                    new SqlParameter("@idAmbiente", pObj.idAmbiente),
                    new SqlParameter("@idMesa", pObj.idMesa),
                    new SqlParameter("@idMozo", pObj.idMozo),
                    new SqlParameter("@turnoCaja", pObj.turnoCaja),
                    new SqlParameter("@modPagoComprobante", pObj.modPagoComprobante),
                    new SqlParameter("@tipMovComprobante", pObj.tipMovComprobante),
                    new SqlParameter("@impEfeComprobante", pObj.impEfeComprobante),
                    new SqlParameter("@impDepComprobante", pObj.impDepComprobante),
                    new SqlParameter("@impTarComprobante", pObj.impTarComprobante),
                    new SqlParameter("@impBruComprobante", pObj.impBruComprobante),
                    new SqlParameter("@impIgvComprobante", pObj.impIgvComprobante),
                    new SqlParameter("@impNetComprobante", pObj.impNetComprobante),
                    new SqlParameter("@impDtrComprobante", pObj.impDtrComprobante),
                    new SqlParameter("@idCliente", pObj.idCliente),
                    new SqlParameter("@estadoComprobante", pObj.estadoComprobante),
                    new SqlParameter("@obsComprobante", pObj.obsComprobante),
                    new SqlParameter("@usuarioAgrega", Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarComprobante");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idDetalleComprobante", pObj.idDetalleComprobante),
                new SqlParameter("@idComprobante", pObj.idComprobante),
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                new SqlParameter("@idProducto", pObj.idProducto),
                new SqlParameter("@preVenta", pObj.preVenta),
                new SqlParameter("@cantidad", pObj.cantidad),
                new SqlParameter("@preTotal", pObj.preTotal),
                new SqlParameter("@estadoDetalleComprobante", pObj.estadoDetalleComprobante),
                new SqlParameter("@obsDetalleComprobante", pObj.obsDetalleComprobante),
                new SqlParameter("@usuarioAgrega",  Universal.gIdAcceso),
                new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarDetalleComprobante");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarComprobante(GestionClubComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idComprobante", pObj.idComprobante),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarComprobante");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idDetalleComprobante", pObj.idDetalleComprobante),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarDetalleComprobante");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubComprobanteDto> ListarComprobantes(GestionClubComprobanteDto objEn)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@idNroComanda",objEn.idNroComanda)
                };
            return this.BuscarObjetoPorParametroCabecera("isp_ListarComprobantes", lParameter);
        }
    }
}