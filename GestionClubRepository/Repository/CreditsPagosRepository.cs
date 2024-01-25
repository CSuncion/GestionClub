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
using System.Xml.Linq;

namespace CreditsRepository.Repository
{
    public class CreditsPagosRepository : ICreditsPagosRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        public void ActualizaMesAnioImpago(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strUnidDscto", pObj.CreditsOperationsDto.UnidDscto),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ActualizaMesAnioImpago");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public List<CreditsPagosDto> RastreaDeudasImpagas(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> rastredeudasimpagas = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strInteres", creditsPagosDto.Interes),
                new SqlParameter("@strIgv", creditsPagosDto.Igv),
                new SqlParameter("@strPeriodo", creditsPagosDto.Periodo),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_RastreaDeudasImpagas");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                rastredeudasimpagas.Add(new CreditsPagosDto()
                {
                    IdOperacion = (decimal)xIdr[0],
                    Ant_Amortizacion = (decimal)xIdr[1],
                    Ant_Interes = (decimal)xIdr[2],
                    Ant_Seguro = (decimal)xIdr[3],
                    Ant_Gastos = (decimal)xIdr[4],
                    Ant_Igv = (decimal)xIdr[5],
                    Ant_Comision1 = (decimal)xIdr[6],
                    Ant_Comision2 = (decimal)xIdr[7],
                    Interes = (decimal)xIdr[8],
                    MasIgv = (decimal)xIdr[9],
                    Queda = (decimal)xIdr[10],
                });
            }
            xObjCn.Disconnect();
            return rastredeudasimpagas;
        }

        public void ProcesoReprogramaPagosMesAnioImpago(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strIdOperacion", pObj.IdOperacion),
                new SqlParameter("@strAmortizacion", pObj.Ant_Amortizacion),
                new SqlParameter("@strInteres", pObj.Ant_Interes),
                new SqlParameter("@strSeguro", pObj.Ant_Seguro),
                new SqlParameter("@strGastos", pObj.Ant_Gastos),
                new SqlParameter("@strIgv", pObj.Ant_Igv),
                new SqlParameter("@strComision1", pObj.Interes),
                new SqlParameter("@strComision2", pObj.MasIgv),
                   };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ProcesoReprogramaPagosMesAnioImpago");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public List<CreditsPagosDto> EnvioMesAnioIdOperacion(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> envioMesAnio = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strTope", creditsPagosDto.selTope),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_PonerCuotaPlanillaEnvio");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                envioMesAnio.Add(new CreditsPagosDto()
                {
                    Tipo = (int)xIdr[0],
                    IdOperacion = (int)xIdr[1],
                    Fecha = (DateTime)xIdr[2],
                    CodoFin = (string)xIdr[3],
                    Dni = (string)xIdr[4],
                    Dni_Ser_Numero = (string)xIdr[5],
                    Grado = (string)xIdr[6],
                    Nombre = (string)xIdr[7],
                    Resultado = (decimal)xIdr[8],
                    Tope = (decimal)xIdr[9],
                    Envio = (decimal)xIdr[10],
                    Inicia = (decimal)xIdr[11],
                });
            }
            xObjCn.Disconnect();
            return envioMesAnio;
        }

        public List<CreditsPagosDto> EnvioMesAnioIdOperacionCaja(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> envioMesAnio = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strTope", creditsPagosDto.selTope),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_PonerCuotaCajaEnvio");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                envioMesAnio.Add(new CreditsPagosDto()
                {
                    Tipo = (int)xIdr[0],
                    IdOperacion = (int)xIdr[1],
                    Fecha = (DateTime)xIdr[2],
                    Cip = (string)xIdr[3],
                    NroBen = (string)xIdr[4],
                    NroDni = (string)xIdr[5],
                    Dni_Ser_Numero = (string)xIdr[6],
                    ApeNom = (string)xIdr[7],
                    Resultado = (decimal)xIdr[8],
                    Inicia = (decimal)xIdr[9],
                    Tope = (decimal)xIdr[10],
                    Envio = (decimal)xIdr[11],
                });
            }
            xObjCn.Disconnect();
            return envioMesAnio;
        }

        public List<CreditsPagosDto> TablaPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> tablaPagos = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strCodofin", creditsPagosDto.CodoFin),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TablaPagosMesAnioCodofin");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaPagos.Add(new CreditsPagosDto()
                {
                    IdOperacion = (decimal)xIdr[0],
                    Interes = (decimal)xIdr[1],
                    Seguro = (decimal)xIdr[2],
                    Igv = (decimal)xIdr[3],
                    Cuota = (int)xIdr[4],
                    Id_Pago = (decimal)xIdr[5],
                    Mes = (int)xIdr[6],
                    Anio = (int)xIdr[7],
                    Amortizacion = (decimal)xIdr[8],
                    Gastos = (decimal)xIdr[9],
                    Comision1 = (decimal)xIdr[10],
                    Comision2 = (decimal)xIdr[11],
                    Ret_Amortizacion = (decimal)xIdr[12],
                    Ret_Interes = (decimal)xIdr[13],
                    Ret_Seguro = (decimal)xIdr[14],
                    Ret_Gastos = (decimal)xIdr[15],
                    Ret_Igv = (decimal)xIdr[16],
                    Ret_Comision1 = (decimal)xIdr[17],
                    Ret_Comision2 = (decimal)xIdr[18],
                    Ant_Amortizacion = (decimal)xIdr[19],
                    Ant_Interes = (decimal)xIdr[20],
                    Ant_Seguro = (decimal)xIdr[21],
                    Ant_Gastos = (decimal)xIdr[22],
                    Ant_Igv = (decimal)xIdr[23],
                    Ant_Comision1 = (decimal)xIdr[24],
                    Ant_Comision2 = (decimal)xIdr[25],
                    Parcial = (decimal)xIdr[26]
                });
            }
            xObjCn.Disconnect();
            return tablaPagos;
        }

        public CreditsPagosDto TotalPagosMesAnioCodofin(CreditsPagosDto creditsPagosDto)
        {
            CreditsPagosDto tablaPagos = new CreditsPagosDto();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strCodofin", creditsPagosDto.CodoFin),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TotalPagosMesAnioCodofin");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaPagos = new CreditsPagosDto()
                {
                    Total = (decimal)xIdr[0],
                };
            }
            xObjCn.Disconnect();
            return tablaPagos;
        }

        public int InsertTbPagos(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdOperacion", pObj.IdOperacion),
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strCuota", pObj.Cuota),
                new SqlParameter("@strAmortizacion", pObj.Amortizacion),
                new SqlParameter("@strInteres", pObj.Interes),
                new SqlParameter("@strSeguro", pObj.Seguro),
                new SqlParameter("@strGastos", pObj.Gastos),
                new SqlParameter("@strIgv", pObj.Igv),
                new SqlParameter("@strComision1", pObj.Comision1),
                new SqlParameter("@strComision2", pObj.Comision2),
                new SqlParameter("@strPorcentaje", pObj.Porcentaje),
                new SqlParameter("@strRet_Fecha", pObj.Ret_Fecha),
                new SqlParameter("@strRet_Amortiza", pObj.Ret_Amortizacion),
                new SqlParameter("@strRet_Interes", pObj.Ret_Interes),
                new SqlParameter("@strRet_Seguro", pObj.Ret_Seguro),
                new SqlParameter("@strRet_Gastos", pObj.Ret_Gastos),
                new SqlParameter("@strRet_Igv", pObj.Ret_Igv),
                new SqlParameter("@strRet_Comision1", pObj.Ret_Comision1),
                new SqlParameter("@strRet_Comision2", pObj.Ret_Comision2),
                new SqlParameter("@strFg", pObj.Fg),
                new SqlParameter("@strIdAcceso", Universal.gIdAcceso),
                new SqlParameter("@strAnt_Amortizacion", pObj.Ant_Amortizacion),
                new SqlParameter("@strAnt_Interes", pObj.Ant_Interes),
                new SqlParameter("@strAnt_Seguro", pObj.Ant_Seguro),
                new SqlParameter("@strAnt_Gastos", pObj.Ant_Gastos),
                new SqlParameter("@strAnt_Igv", pObj.Ant_Igv),
                new SqlParameter("@strAnt_Comision1", pObj.Ant_Comision1),
                new SqlParameter("@strAnt_Comision2", pObj.Ant_Comision2),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_InsertTbPagos");
            int idPago = xObjCn.GetInt();
            xObjCn.Disconnect();
            return idPago;
        }
        public void ActualizaTbPagos(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdPago", pObj.Id_Pago),
                new SqlParameter("@strRet_Amortiza", pObj.Ret_Amortizacion),
                new SqlParameter("@strRet_Interes", pObj.Ret_Interes),
                new SqlParameter("@strRet_Seguro", pObj.Ret_Seguro),
                new SqlParameter("@strRet_Gastos", pObj.Ret_Gastos),
                new SqlParameter("@strRet_Igv", pObj.Ret_Igv),
                new SqlParameter("@strRet_Comision1", pObj.Ret_Comision1),
                new SqlParameter("@strRet_Comision2", pObj.Ret_Comision2),
                new SqlParameter("@strRet_Fecha", pObj.Ret_Fecha),
                new SqlParameter("@strIdProcesoPago", pObj.Id_ProcesoPagos),
                new SqlParameter("@strIdAcceso", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ActualizaTbPagos");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public List<CreditsPagosDto> TablaPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> tablaCodofinCo = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strCodofin", creditsPagosDto.CodoFin),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TablaPagosMesAnioCodofinCO");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaCodofinCo.Add(new CreditsPagosDto()
                {
                    Id_Pago = (int)xIdr[0],
                    IdOperacion = (int)xIdr[1],
                    Cuota = (int)xIdr[3],
                    Amortizacion = (decimal)xIdr[3],
                    Ant_Amortizacion = (decimal)xIdr[4],
                    Ret_Amortizacion = (decimal)xIdr[5],
                });
            }
            xObjCn.Disconnect();
            return tablaCodofinCo;
        }

        public CreditsPagosDto TotalPagosMesAnioCodofinCO(CreditsPagosDto creditsPagosDto)
        {
            CreditsPagosDto tablaPagos = new CreditsPagosDto();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUnidDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                new SqlParameter("@strCodofin", creditsPagosDto.CodoFin),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TotalPagosMesAnioCodofinCO");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaPagos = new CreditsPagosDto()
                {
                    Total = (decimal)xIdr[0],
                };
            }
            xObjCn.Disconnect();
            return tablaPagos;
        }

        public int InsertEnvioPagoCO(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdOperacion", pObj.IdOperacion),
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strCuota", pObj.Cuota),
                new SqlParameter("@strAmortizacion", pObj.Amortizacion),
                new SqlParameter("@strPorcentaje", pObj.Porcentaje),
                new SqlParameter("@strEnvFecha", pObj.Env_Fecha),
                new SqlParameter("@strRet_Fecha", pObj.Ret_Fecha),
                new SqlParameter("@strRetAmortizacion", pObj.Ret_Amortizacion),
                new SqlParameter("@strFg", pObj.Fg),
                new SqlParameter("@strIdAcceso", Universal.gIdAcceso),
                new SqlParameter("@strAntAmortizacion", pObj.Ant_Amortizacion),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_InsertEnvioPagoCO");
            int idPago = xObjCn.GetInt();
            xObjCn.Disconnect();
            return idPago;
        }

        public void ActualizaPagosCobranza(CreditsPagosDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strIdOperacion", pObj.IdOperacion),
                new SqlParameter("@strMes", pObj.Mes),
                new SqlParameter("@strAnio", pObj.Anio),
                new SqlParameter("@strCuota", pObj.Cuota),
                new SqlParameter("@strAmortizacion", pObj.Amortizacion),
                new SqlParameter("@strPorcentaje", pObj.Porcentaje),
                new SqlParameter("@strEnvFecha", pObj.Env_Fecha),
                new SqlParameter("@strRet_Fecha", pObj.Ret_Fecha),
                new SqlParameter("@strRetAmortizacion", pObj.Ret_Amortizacion),
                new SqlParameter("@strFg", pObj.Fg),
                new SqlParameter("@strIdAcceso", Universal.gIdAcceso),
                new SqlParameter("@strAntAmortizacion", pObj.Ant_Amortizacion),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ActualizaPagosCobranza");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public List<CreditsPagosDto> TablaPagosMesAnio(CreditsPagosDto creditsPagosDto)
        {
            List<CreditsPagosDto> tablaPagos = new List<CreditsPagosDto>();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                new SqlParameter("@strUniDscto", creditsPagosDto.CreditsOperationsDto.UnidDscto),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TablaPagosMesAnio");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaPagos.Add(new CreditsPagosDto()
                {
                    IdOperacion = (decimal)xIdr[0],
                    Interes = (decimal)xIdr[1],
                    Seguro = (decimal)xIdr[2],
                    Igv = (decimal)xIdr[3],
                    Cuota = (int)xIdr[4],
                    Id_Pago = (decimal)xIdr[5],
                    Mes = (int)xIdr[6],
                    Anio = (int)xIdr[7],
                    Amortizacion = (decimal)xIdr[8],
                    Gastos = (decimal)xIdr[9],
                    Comision1 = (decimal)xIdr[10],
                    Comision2 = (decimal)xIdr[11],
                    Ret_Amortizacion = (decimal)xIdr[12],
                    Ret_Interes = (decimal)xIdr[13],
                    Ret_Seguro = (decimal)xIdr[14],
                    Ret_Gastos = (decimal)xIdr[15],
                    Ret_Igv = (decimal)xIdr[16],
                    Ret_Comision1 = (decimal)xIdr[17],
                    Ret_Comision2 = (decimal)xIdr[18],
                    Ant_Amortizacion = (decimal)xIdr[19],
                    Ant_Interes = (decimal)xIdr[20],
                    Ant_Seguro = (decimal)xIdr[21],
                    Ant_Gastos = (decimal)xIdr[22],
                    Ant_Igv = (decimal)xIdr[23],
                    Ant_Comision1 = (decimal)xIdr[24],
                    Ant_Comision2 = (decimal)xIdr[25],
                    Dni_Solicitante = (string)xIdr[26],
                    Env_Fecha = (DateTime)xIdr[27],
                    Ret_Fecha = (DateTime)xIdr[28],
                });
            }
            xObjCn.Disconnect();
            return tablaPagos;
        }

        public CreditsPagosDto TraeDescuentoDirrehum(CreditsPagosDto creditsPagosDto)
        {
            CreditsPagosDto tablaPagos = new CreditsPagosDto();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", creditsPagosDto.Mes),
                new SqlParameter("@strAnio", creditsPagosDto.Anio),
                };
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TraeDescuentoDirrehum");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tablaPagos = new CreditsPagosDto()
                {
                    Descuenta = (decimal)xIdr[0],
                };
            }
            xObjCn.Disconnect();
            return tablaPagos;
        }
    }
}
