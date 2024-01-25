using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsReportRepository : ICreditsReportRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private dynamic xObj;
        private List<dynamic> xLista = new List<dynamic>();
        private List<CreditsDecomicroDto> xListaDeco = new List<CreditsDecomicroDto>();
        private List<CreditsSaldosFormatoDto> xListaSalFor = new List<CreditsSaldosFormatoDto>();
        private CreditsDecomicroDto Objeto(IDataReader iDr)
        {
            CreditsDecomicroDto xObjEnc = new CreditsDecomicroDto();
            xObjEnc.Id_Operacion = (decimal)iDr[CreditsDecomicroDto.xId_Operacion];
            xObjEnc.Numero = iDr[CreditsDecomicroDto.xNumero].ToString();
            xObjEnc.TipDocId = (int)iDr[CreditsDecomicroDto.xTipDocId];
            xObjEnc.Dni_Solicitante = iDr[CreditsDecomicroDto.xDni_Solicitante].ToString();
            xObjEnc.Paterno = iDr[CreditsDecomicroDto.xPaterno].ToString();
            xObjEnc.Materno = iDr[CreditsDecomicroDto.xMaterno].ToString();
            xObjEnc.Nombres = iDr[CreditsDecomicroDto.xNombres].ToString();
            xObjEnc.Tipo_Persona = (int)iDr[CreditsDecomicroDto.xTipo_Persona];
            xObjEnc.Mod_Cred = (int)iDr[CreditsDecomicroDto.xMod_Cred];
            xObjEnc.Movil = iDr[CreditsDecomicroDto.xMovil].ToString();
            xObjEnc.Domicilio = iDr[CreditsDecomicroDto.xDomicilio].ToString();
            xObjEnc.Departamento = iDr[CreditsDecomicroDto.xDepartamento].ToString();
            xObjEnc.Provincia = iDr[CreditsDecomicroDto.xProvincia].ToString();
            xObjEnc.Distrito = iDr[CreditsDecomicroDto.xDistrito].ToString();
            xObjEnc.Vencimiento = iDr[CreditsDecomicroDto.xVencimiento].ToString();
            xObjEnc.Estado = iDr[CreditsDecomicroDto.xEstado].ToString();
            xObjEnc.Credito = (decimal)iDr[CreditsDecomicroDto.xCredito];
            xObjEnc.Pagos = (decimal)iDr[CreditsDecomicroDto.xPagos];
            xObjEnc.Pendiente = (decimal)iDr[CreditsDecomicroDto.xPendiente];
            xObjEnc.Dias_Atrasos = (int)iDr[CreditsDecomicroDto.xDias_Atrasos];
            xObjEnc.Ret_Fecha = (DateTime)iDr[CreditsDecomicroDto.xRet_Fecha];
            return xObjEnc;
        }
        private CreditsSaldosFormatoDto ObjetoSaldoFormato(IDataReader iDr)
        {
            CreditsSaldosFormatoDto xObjEnc = new CreditsSaldosFormatoDto();
            xObjEnc.Id_Operacion = (decimal)iDr[CreditsSaldosFormatoDto.xId_Operacion];
            xObjEnc.Concatenado = iDr[CreditsSaldosFormatoDto.xConcatenado].ToString();
            xObjEnc.Cod = iDr[CreditsSaldosFormatoDto.xCod].ToString();
            xObjEnc.Producto = iDr[CreditsSaldosFormatoDto.xProducto].ToString();
            xObjEnc.Solicitante = iDr[CreditsSaldosFormatoDto.xSolicitante].ToString();
            xObjEnc.DNI = iDr[CreditsSaldosFormatoDto.xDNI].ToString();
            xObjEnc.Ser = iDr[CreditsSaldosFormatoDto.xSer].ToString();
            xObjEnc.Numero = iDr[CreditsSaldosFormatoDto.xNumero].ToString();
            xObjEnc.Aprobado = (decimal)iDr[CreditsSaldosFormatoDto.xAprobado];
            xObjEnc.Inicia = (decimal)iDr[CreditsSaldosFormatoDto.xInicia];
            xObjEnc.Amortiza = (decimal)iDr[CreditsSaldosFormatoDto.xAmortiza];
            xObjEnc.Dec__ = (decimal)iDr[CreditsSaldosFormatoDto.xDec__];
            xObjEnc.Jan_ = (decimal)iDr[CreditsSaldosFormatoDto.xJan_];
            xObjEnc.Feb_ = (decimal)iDr[CreditsSaldosFormatoDto.xFeb_];
            xObjEnc.Mar_ = (decimal)iDr[CreditsSaldosFormatoDto.xMar_];
            xObjEnc.Apr_ = (decimal)iDr[CreditsSaldosFormatoDto.xApr_];
            xObjEnc.May_ = (decimal)iDr[CreditsSaldosFormatoDto.xMay_];
            xObjEnc.Jun_ = (decimal)iDr[CreditsSaldosFormatoDto.xJun_];
            xObjEnc.Jul_ = (decimal)iDr[CreditsSaldosFormatoDto.xJul_];
            xObjEnc.Aug_ = (decimal)iDr[CreditsSaldosFormatoDto.xAug_];
            xObjEnc.Sep_ = (decimal)iDr[CreditsSaldosFormatoDto.xSep_];
            xObjEnc.Oct_ = (decimal)iDr[CreditsSaldosFormatoDto.xOct_];
            xObjEnc.Nov_ = (decimal)iDr[CreditsSaldosFormatoDto.xNov_];
            xObjEnc.Dec_ = (decimal)iDr[CreditsSaldosFormatoDto.xDec_];
            xObjEnc.NvoSaldo = (decimal)iDr[CreditsSaldosFormatoDto.xNvoSaldo];
            xObjEnc.X = (int)iDr[CreditsSaldosFormatoDto.xX];
            return xObjEnc;
        }
        private CreditsDecomicroDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<CreditsDecomicroDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
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
            return xListaDeco;
        }

        public List<dynamic> ListarCreditosOtorgados(int anio)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", anio)
                };

            List<dynamic> creditoOtorgados = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarCreditosOtorgados");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                creditoOtorgados.Add(new
                {
                    Id_Mes = (int)xIdr[0],
                    Des_Mes = (string)xIdr[1],
                    CreditosAprobados = (int)xIdr[2],
                    MontosAprobados = (decimal)xIdr[3]
                });
            }
            xObjCn.Disconnect();
            return creditoOtorgados;
        }
        public List<dynamic> ListarTipoCreditos(int anio)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", anio)
                };

            List<dynamic> tipoCreditos = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarTipoCreditos");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tipoCreditos.Add(new
                {
                    Productos = (string)xIdr[0],
                    CreditosAprobados = (int)xIdr[1],
                    MontosAprobados = (decimal)xIdr[2]
                });
            }
            xObjCn.Disconnect();
            return tipoCreditos;
        }
        public List<dynamic> ListarTipoCreditoPorAnio(int anio, int codCentroCosto)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strAnio", anio),
                new SqlParameter("@strCodCentroCosto", codCentroCosto),
                };

            List<dynamic> tipoCreditos = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarTipoCreditoPorAnio");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                tipoCreditos.Add(new
                {
                    Id_Mes = (int)xIdr[0],
                    Des_Mes = (string)xIdr[1],
                    CreditosAprobados = (int)xIdr[2],
                    MontosAprobados = (decimal)xIdr[3]
                });
            }
            xObjCn.Disconnect();
            return tipoCreditos;
        }

        public List<dynamic> ListarSaldoFavorSolicitantes(string desde, string hasta)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strFechaIni", desde),
                new SqlParameter("@strFechaFin", hasta),
                };

            List<dynamic> saldoFavor = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_SaldoFavorSolicitantes");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                saldoFavor.Add(new
                {
                    Id_Operacion = (decimal)xIdr[0],
                    Dni_Solicitante = (string)xIdr[1],
                    Ser = (string)xIdr[2],
                    Numero = (string)xIdr[3],
                    Apellidos_Nombres = (string)xIdr[4],
                    Fijo = (string)xIdr[5],
                    Movil = (string)xIdr[6],
                    Mail = (string)xIdr[7],
                    Domicilio = (string)xIdr[8],
                    Fecha = (DateTime)xIdr[9],
                    NameProducto = (string)xIdr[10],
                    Corta_TpOperac = (string)xIdr[11],
                    Des_TpOperac = (string)xIdr[12],
                    Aprobado = (decimal)xIdr[13],
                    Plazo = (int)xIdr[14],
                    NumCta = (string)xIdr[15],
                    CCI = (string)xIdr[16],
                    CREDITO = (decimal)xIdr[17],
                    PAGOS = (decimal)xIdr[18],
                    SALDO = (decimal)xIdr[19],
                });
            }
            xObjCn.Disconnect();
            return saldoFavor;
        }

        public List<dynamic> ListarTipoCreditoGeneradoDesembolsado(string desde, string hasta)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strFechaIni", desde),
                new SqlParameter("@strFechaFin", hasta),
                };

            List<dynamic> generadoDesembolsado = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TipoCreditoGeneradoDesembolsado");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                generadoDesembolsado.Add(new
                {
                    Id_Operacion = (decimal)xIdr[0],
                    Dni_Solicitante = (string)xIdr[1],
                    Ser = (string)xIdr[2],
                    Numero = (string)xIdr[3],
                    Apellidos_Nombres = (string)xIdr[4],
                    Fijo = (string)xIdr[5],
                    Movil = (string)xIdr[6],
                    Mail = (string)xIdr[7],
                    Domicilio = (string)xIdr[8],
                    Fecha = (DateTime)xIdr[9],
                    NameProducto = (string)xIdr[10],
                    Corta_TpOperac = (string)xIdr[11],
                    Des_TpOperac = (string)xIdr[12],
                    Aprobado = (decimal)xIdr[13],
                    Plazo = (int)xIdr[14],
                    NumCta = (string)xIdr[15],
                    CCI = (string)xIdr[16],
                    Dpto = (int)xIdr[17],
                    DesDpto = (string)xIdr[18],
                    Prov = (int)xIdr[19],
                    DesProv = (string)xIdr[20],
                    Dist = (int)xIdr[21],
                    DesDist = (string)xIdr[22],
                });
            }
            xObjCn.Disconnect();
            return generadoDesembolsado;
        }

        public List<dynamic> ListarCreditoEnProceso(string desde, string hasta)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strFechaIni", desde),
                new SqlParameter("@strFechaFin", hasta),
                };

            List<dynamic> creditoEnProceso = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_TipoCreditoEnProceso");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                creditoEnProceso.Add(new
                {
                    Id_Operacion = (decimal)xIdr[0],
                    Dni_Solicitante = (string)xIdr[1],
                    Ser = (string)xIdr[2],
                    Numero = (string)xIdr[3],
                    Apellidos_Nombres = (string)xIdr[4],
                    Fijo = (string)xIdr[5],
                    Movil = (string)xIdr[6],
                    Mail = (string)xIdr[7],
                    Domicilio = (string)xIdr[8],
                    Fecha = (DateTime)xIdr[9],
                    NameProducto = (string)xIdr[10],
                    Corta_TpOperac = (string)xIdr[11],
                    Des_TpOperac = (string)xIdr[12],
                    Aprobado = (decimal)xIdr[13],
                    Plazo = (int)xIdr[14],
                    NumCta = (string)xIdr[15],
                    CCI = (string)xIdr[16],
                    Dpto = (int)xIdr[17],
                    DesDpto = (string)xIdr[18],
                    Prov = (int)xIdr[19],
                    DesProv = (string)xIdr[20],
                    Dist = (int)xIdr[21],
                    DesDist = (string)xIdr[22],
                });
            }
            xObjCn.Disconnect();
            return creditoEnProceso;
        }
        public List<dynamic> ListarCreditoMorosos(string hasta)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strFechaFin", hasta),
                };

            List<dynamic> creditoMorosos = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_CreditoMorosos");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                creditoMorosos.Add(new
                {
                    Id_Operacion = (decimal)xIdr[0],
                    Dni_Solicitante = (string)xIdr[1],
                    Ser = (string)xIdr[2],
                    Numero = (string)xIdr[3],
                    Apellidos_Nombres = (string)xIdr[4],
                    Fijo = (string)xIdr[5],
                    Movil = (string)xIdr[6],
                    Mail = (string)xIdr[7],
                    Domicilio = (string)xIdr[8],
                    Fecha = (DateTime)xIdr[9],
                    NameProducto = (string)xIdr[10],
                    Corta_TpOperac = (string)xIdr[11],
                    Des_TpOperac = (string)xIdr[12],
                    Aprobado = (decimal)xIdr[13],
                    Plazo = (int)xIdr[14],
                    CREDITO = (decimal)xIdr[15],
                    PAGOS = (decimal)xIdr[16],
                    Ret_Fecha = (DateTime)xIdr[17],
                    Dias_Atrasos = (int)xIdr[18],
                    Cuota = (int)xIdr[19],
                    Pendiente = (decimal)xIdr[20],
                });
            }
            xObjCn.Disconnect();
            return creditoMorosos;
        }
        public List<dynamic> ListarOperacionesRefinanciamientoAmpliacion(CreditsOperationsDto oCreOpe)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", oCreOpe.Dni_Solicitante.Trim()),
                new SqlParameter("@strIdOperacion", oCreOpe.Id_Operacion),
                };

            List<dynamic> creditoRefAmp = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListarOperacionesRefinanciamientoAmpliacion");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                creditoRefAmp.Add(new
                {
                    Operacion = (string)xIdr[0],
                    NameProducto = (string)xIdr[1],
                    Fecha = (DateTime)xIdr[2],
                    Aprobado = (decimal)xIdr[3],
                    Importe = (decimal)xIdr[4],
                    Amortizacion = (decimal)xIdr[5],
                    Interes = (decimal)xIdr[6],
                    Seguro = (decimal)xIdr[7],
                    Gastos = (decimal)xIdr[8],
                    Igv = (decimal)xIdr[9],
                    Comision1 = (decimal)xIdr[10],
                    Comision2 = (decimal)xIdr[11],
                    Total = (decimal)xIdr[12],
                    Ret_Fecha = (DateTime)xIdr[13],
                    DesSubEstado = (string)xIdr[14],
                    Operacion2 = (string)xIdr[15],
                });
            }
            xObjCn.Disconnect();
            return creditoRefAmp;
        }

        public List<dynamic> ListarComparativoCreditoOtorgados()
        {
            List<dynamic> comparativoCreditosOtorgados = new List<dynamic>();
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ComparativoCreditoOtorgados");
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                comparativoCreditosOtorgados.Add(new
                {
                    ANIOCinco = (int)xIdr[0],
                    MESCinco = (int)xIdr[1],
                    DESMESCinco = (string)xIdr[2],
                    CANTIDCinco = (int)xIdr[3],
                    MONTOCinco = (decimal)xIdr[4],
                    ANIOCuatro = (int)xIdr[5],
                    MESCuatro = (int)xIdr[6],
                    DESMESCuatro = (string)xIdr[7],
                    CANTIDCuatro = (int)xIdr[8],
                    MONTOCuatro = (decimal)xIdr[9],
                    ANIOTres = (int)xIdr[10],
                    MESTres = (int)xIdr[11],
                    DESMESTres = (string)xIdr[12],
                    CANTIDTres = (int)xIdr[13],
                    MONTOTres = (decimal)xIdr[14],
                    ANIODos = (int)xIdr[15],
                    MESDos = (int)xIdr[16],
                    DESMESDos = (string)xIdr[17],
                    CANTIDDos = (int)xIdr[18],
                    MONTODos = (decimal)xIdr[19],
                    ANIOUno = (int)xIdr[20],
                    MESUno = (int)xIdr[21],
                    DESMESUno = (string)xIdr[22],
                    CANTIDUno = (int)xIdr[23],
                    MONTOUno = (decimal)xIdr[24]
                });
            }
            xObjCn.Disconnect();
            return comparativoCreditosOtorgados;
        }
        public decimal ListarConsultaNoAdeudo(string dni)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", dni),
                };

            decimal saldo = 0;
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ConsultaNoAdeudo");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                saldo = (decimal)xIdr[0];
            }
            xObjCn.Disconnect();
            return saldo;
        }

        public string GenerarCorrelativoConstanciaNoAdeudo(string periodo)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strPeriodo", periodo),
                };

            string Correlativo = "";
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_GenerarCorrelativoConstanciaNoAdeudo");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                Correlativo = (string)xIdr[0];
            }
            xObjCn.Disconnect();
            return Correlativo;
        }

        public int ValidaImpresionCorrelativoConstanciaNoAdeudo(string dni)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strDniSolicitante", dni),
                };

            int Result = 0;
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ValidaImpresionCorrelativoConstanciaNoAdeudo");
            xObjCn.AssignParameters(lParameter);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                Result = (int)xIdr[0];
            }
            xObjCn.Disconnect();
            return Result;
        }
        public string ListaNameAnio()
        {

            string nameAnio = string.Empty;
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_ListaNameAnio");
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                nameAnio = (string)xIdr[0];
            }
            xObjCn.Disconnect();
            return nameAnio;
        }
        public List<string> ListaFirmaGerenteFinanza()
        {

            List<string> firmaFinanza = new List<string>();
            ;
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_FirmaGerenteFinanza");
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                string[] firma = { (string)xIdr[0], (string)xIdr[1] };
                firmaFinanza.AddRange(firma);
            }

            xObjCn.Disconnect();
            return firmaFinanza;
        }
        public List<CreditsDecomicroDto> ListarDecomicro()
        {
            try
            {
                xObjCn.Connection();
                xObjCn.CommandStoreProcedure("isp_ListarDecomicro");
                IDataReader xIdr = xObjCn.GetIdr();
                while (xIdr.Read())
                {
                    this.xListaDeco.Add(this.Objeto(xIdr));
                }
                xObjCn.Disconnect();
            }
            catch (Exception)
            {
                xObjCn.Disconnect();
            }
            return this.xListaDeco;
        }
        public List<CreditsSaldosFormatoDto> ListaSaldosFormato(string mes, string anio, string producto)
        {
            try
            {
                xObjCn.Connection();
                List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strMes", mes),
                new SqlParameter("@strAnio", anio),
                new SqlParameter("@strProducto", producto),
                };
                xObjCn.CommandStoreProcedure("isp_SaldosFormato");
                xObjCn.AssignParameters(lParameter);
                IDataReader xIdr = xObjCn.GetIdr();
                while (xIdr.Read())
                {
                    this.xListaSalFor.Add(this.ObjetoSaldoFormato(xIdr));
                }
                xObjCn.Disconnect();
            }
            catch (Exception)
            {
                xObjCn.Disconnect();
            }
            return this.xListaSalFor;
        }
    }
}
