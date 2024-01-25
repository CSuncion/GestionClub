using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsOperationsRepository : ICreditsOperationsRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private CreditsOperationsDto xObj = new CreditsOperationsDto();
        private List<CreditsOperationsDto> xLista = new List<CreditsOperationsDto>();

        private CreditsOperationsDto Objeto(IDataReader iDr)
        {
            CreditsOperationsDto xObjEnc = new CreditsOperationsDto();
            xObjEnc.Id_Operacion = Convert.ToInt32(iDr[CreditsOperationsDto.IdOper]);
            xObjEnc.Tipo = Convert.ToInt32(iDr[CreditsOperationsDto.Tip]);
            xObjEnc.Ser = iDr[CreditsOperationsDto.xSer].ToString();
            xObjEnc.Numero = iDr[CreditsOperationsDto.Nro].ToString();
            xObjEnc.Producto = Convert.ToInt32(iDr[CreditsOperationsDto.Product]);
            xObjEnc.NameProducto = iDr[CreditsOperationsDto.NameProduct].ToString();
            xObjEnc.Num = iDr[CreditsOperationsDto.Numro].ToString();
            xObjEnc.Fecha = Convert.ToDateTime(iDr[CreditsOperationsDto.Fec]);
            xObjEnc.UnidDscto = Convert.ToInt32(iDr[CreditsOperationsDto.UnDscto]);
            xObjEnc.Dni_Solicitante = iDr[CreditsOperationsDto.DniSolic].ToString();
            xObjEnc.Proveedor = iDr[CreditsOperationsDto.Prove].ToString();
            xObjEnc.Moneda = Convert.ToInt32(iDr[CreditsOperationsDto.Mon]);
            xObjEnc.TpCambio = Convert.ToDecimal(iDr[CreditsOperationsDto.TpCamb]);
            xObjEnc.Aprobado = Convert.ToDecimal(iDr[CreditsOperationsDto.Aproba]);
            xObjEnc.Plazo = Convert.ToInt32(iDr[CreditsOperationsDto.Pla]);
            xObjEnc.Interes = Convert.ToDecimal(iDr[CreditsOperationsDto.Inter]);
            xObjEnc.Seguro = Convert.ToDecimal(iDr[CreditsOperationsDto.Seg]);
            xObjEnc.GastosAdm = Convert.ToDecimal(iDr[CreditsOperationsDto.GastosAd]);
            xObjEnc.IGV = Convert.ToDecimal(iDr[CreditsOperationsDto.xIgv]);
            xObjEnc.Obs = iDr[CreditsOperationsDto.xObs].ToString();
            xObjEnc.Provedor = Convert.ToInt32(iDr[CreditsOperationsDto.xProvedor]);
            xObjEnc.PeGracia = Convert.ToInt32(iDr[CreditsOperationsDto.xPeGracia]);
            xObjEnc.Fg = Convert.ToInt32(iDr[CreditsOperationsDto.xFg]);
            xObjEnc.Vencimiento = Convert.ToDateTime(iDr[CreditsOperationsDto.xVencimiento]);
            xObjEnc.IdAcceso = Convert.ToInt32(iDr[CreditsOperationsDto.xIdAcceso]);
            xObjEnc.Cuota = Convert.ToInt32(iDr[CreditsOperationsDto.xCuota]);
            xObjEnc.LoteId = Convert.ToInt32(iDr[CreditsOperationsDto.xLoteId]);
            xObjEnc.IdTpOperac = Convert.ToInt32(iDr[CreditsOperationsDto.xIdTpOperac]);
            xObjEnc.DesTpOperac = iDr[CreditsOperationsDto.xDesTpOperac].ToString();
            xObjEnc.Corta_TpOperac = iDr[CreditsOperationsDto.xCortaTpOperac].ToString();
            xObjEnc.F1 = iDr[CreditsOperationsDto.xF1].ToString();
            xObjEnc.IdProveedor = Convert.ToInt32(iDr[CreditsOperationsDto.xIdProveedor]);
            xObjEnc.Des_Proveedor = iDr[CreditsOperationsDto.xDesProveedor].ToString();
            xObjEnc.RUC = iDr[CreditsOperationsDto.xRuc].ToString();
            xObjEnc.Representante = iDr[CreditsOperationsDto.xRepresentante].ToString();
            xObjEnc.DNI = iDr[CreditsOperationsDto.xDni].ToString();
            xObjEnc.Direccion = iDr[CreditsOperationsDto.xDireccion].ToString();
            xObjEnc.Dpto = Convert.ToInt32(iDr[CreditsOperationsDto.xDpto]);
            xObjEnc.Prov = Convert.ToInt32(iDr[CreditsOperationsDto.xProv]);
            xObjEnc.Dist = Convert.ToInt32(iDr[CreditsOperationsDto.xDist]);
            xObjEnc.Fijo = iDr[CreditsOperationsDto.xFijo].ToString();
            xObjEnc.Movil = iDr[CreditsOperationsDto.xMovil].ToString();
            xObjEnc.Mail = iDr[CreditsOperationsDto.xMail].ToString();
            xObjEnc.Condicion = Convert.ToInt32(iDr[CreditsOperationsDto.xCondicion]);
            xObjEnc.IdUnidDscto = Convert.ToInt32(iDr[CreditsOperationsDto.xIdUnidDscto]);
            xObjEnc.DesUnidDscto = iDr[CreditsOperationsDto.xDesUnidDscto].ToString();
            xObjEnc.DesCortaUDscto = iDr[CreditsOperationsDto.xDesCortaUDscto].ToString();
            xObjEnc.Credito = Convert.ToInt32(iDr[CreditsOperationsDto.xCredito]);
            xObjEnc.Pagos = Convert.ToInt32(iDr[CreditsOperationsDto.xPagos]);
            xObjEnc.IdOrden = Convert.ToInt32(iDr[CreditsOperationsDto.xIdOrden]);
            xObjEnc.Aprobacion = Convert.ToInt32(iDr[CreditsOperationsDto.xAprobacion]);
            xObjEnc.VFecha = Convert.ToDateTime(iDr[CreditsOperationsDto.xVFecha]);
            xObjEnc.Orden = Convert.ToInt32(iDr[CreditsOperationsDto.xOrden]);
            xObjEnc.Informe = Convert.ToInt32(iDr[CreditsOperationsDto.xInforme]);
            xObjEnc.Anio = Convert.ToInt32(iDr[CreditsOperationsDto.xAnio]);
            xObjEnc.Voucher = Convert.ToDateTime(iDr[CreditsOperationsDto.xVoucher]);
            xObjEnc.FeDesembolso = Convert.ToDateTime(iDr[CreditsOperationsDto.xFeDesembolso]);
            xObjEnc.IdCriterio = Convert.ToInt32(iDr[CreditsOperationsDto.xIdCriterio]);
            xObjEnc.Estado = Convert.ToInt32(iDr[CreditsOperationsDto.xEstado]);
            xObjEnc.DesEstado = iDr[CreditsOperationsDto.xDesEstado].ToString();
            xObjEnc.DesSubEstado = iDr[CreditsOperationsDto.xDesSubEstado].ToString();
            return xObjEnc;
        }
        private CreditsOperationsDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<CreditsOperationsDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
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

        public List<CreditsOperationsDto> TablaOperacDni(CreditsOperationsDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", pObj.Dni_Solicitante)
                };

            return this.ListarObjetos("isp_TablaOperacDni", lParameter);
        }
        public List<CreditsOperationsDto> ListarRefinanciadoAmpliadoPorDni(CreditsOperationsDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", pObj.Dni_Solicitante)
                };

            return this.ListarObjetos("isp_ListarRefinanciadoAmpliadoPorDni", lParameter);
        }
        public List<decimal> ValidarEstadoDeCuenta(CreditsOperationsDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdOperacion", pObj.Id_Operacion)
                };

            List<decimal> estadoCuenta = new List<decimal>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ValidarEstadoDeCuenta");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                decimal[] estado = { (decimal)xIdr[0], (decimal)xIdr[1], (decimal)xIdr[2] };
                estadoCuenta.AddRange(estado);
            };

            xObjCn.Disconnect();
            return estadoCuenta;
        }
    }
}
