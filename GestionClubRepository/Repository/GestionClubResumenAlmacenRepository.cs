using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubResumenAlmacenRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubResumenAlmacenDto xObj = new GestionClubResumenAlmacenDto();
        private List<GestionClubResumenAlmacenDto> xLista = new List<GestionClubResumenAlmacenDto>();
        private List<CuadroAnualAlmacen> xListaCuadro = new List<CuadroAnualAlmacen>();
        private GestionClubResumenAlmacenDto Objeto(IDataReader iDr)
        {
            GestionClubResumenAlmacenDto xObjEnc = new GestionClubResumenAlmacenDto();
            xObjEnc.IdResumenAlmacen = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._IdResumenAlmacen]);
            xObjEnc.IdEmpresa = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._IdEmpresa]);
            xObjEnc.IdCodAlmacen = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._IdCodAlmacen]);
            xObjEnc.AnoProceso = iDr[GestionClubResumenAlmacenDto._AnoProceso].ToString();
            xObjEnc.MesProceso = iDr[GestionClubResumenAlmacenDto._MesProceso].ToString();
            xObjEnc.Mes = iDr[GestionClubResumenAlmacenDto._Mes].ToString();
            xObjEnc.CodigoProducto = iDr[GestionClubResumenAlmacenDto._CodigoProducto].ToString();
            xObjEnc.desProducto = iDr[GestionClubResumenAlmacenDto._desProducto].ToString();
            xObjEnc.SaldoAnterior = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._SaldoAnterior]);
            xObjEnc.PrecioCostoAnterior = Convert.ToDecimal(iDr[GestionClubResumenAlmacenDto._PrecioCostoAnterior]);
            xObjEnc.AcumulngresosMes = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._AcumulngresosMes]);
            xObjEnc.AcumulSalidasMes = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._AcumulSalidasMes]);
            xObjEnc.SaldoNuevo = Convert.ToInt32(iDr[GestionClubResumenAlmacenDto._SaldoNuevo]);
            xObjEnc.PrecioCostoNuevo = Convert.ToDecimal(iDr[GestionClubResumenAlmacenDto._PrecioCostoNuevo]);
            xObjEnc.FlagProcesado = Convert.ToBoolean(iDr[GestionClubResumenAlmacenDto._FlagProcesado]);
            xObjEnc.desCategoria = Convert.ToString(iDr[GestionClubResumenAlmacenDto._desCategoria]);
            xObjEnc.claveObjeto = xObjEnc.IdResumenAlmacen.ToString();
            return xObjEnc;
        }

        private CuadroAnualAlmacen ObjetoCuadro(IDataReader iDr)
        {
            CuadroAnualAlmacen xObjEnc = new CuadroAnualAlmacen();
            xObjEnc.CodigoProducto = Convert.ToString(iDr[CuadroAnualAlmacen._CodigoProducto]);
            xObjEnc.DesProducto = Convert.ToString(iDr[CuadroAnualAlmacen._DesProducto]);
            xObjEnc.IngEnero = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngEnero]);
            xObjEnc.SalEnero = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalEnero]);
            xObjEnc.IngFebrero = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngFebrero]);
            xObjEnc.SalFebrero = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalFebrero]);
            xObjEnc.IngMarzo = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngMarzo]);
            xObjEnc.SalMarzo = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalMarzo]);
            xObjEnc.IngAbril = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngAbril]);
            xObjEnc.SalAbril = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalAbril]);
            xObjEnc.IngMayo = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngMayo]);
            xObjEnc.SalMayo = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalMayo]);
            xObjEnc.IngJunio = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngJunio]);
            xObjEnc.SalJunio = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalJunio]);
            xObjEnc.IngJulio = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngJulio]);
            xObjEnc.SalJulio = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalJulio]);
            xObjEnc.IngAgosto = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngAgosto]);
            xObjEnc.SalAgosto = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalAgosto]);
            xObjEnc.IngSetiembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngSetiembre]);
            xObjEnc.SalSetiembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalSetiembre]);
            xObjEnc.IngOctubre = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngOctubre]);
            xObjEnc.SalOctubre = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalOctubre]);
            xObjEnc.IngNoviembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngNoviembre]);
            xObjEnc.SalNoviembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalNoviembre]);
            xObjEnc.IngDiciembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._IngDiciembre]);
            xObjEnc.SalDiciembre = Convert.ToInt32(iDr[CuadroAnualAlmacen._SalDiciembre]);
            return xObjEnc;

        }

        private GestionClubResumenAlmacenDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubResumenAlmacenDto> ListarObjetos(string pScript)
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
        private List<GestionClubResumenAlmacenDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        private List<CuadroAnualAlmacen> BuscarObjetoCuadroPorParametro(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xListaCuadro.Add(this.ObjetoCuadro(xIdr));
            }
            xObjCn.Disconnect();
            return xListaCuadro;
        }
        public List<GestionClubResumenAlmacenDto> ResumenAnioMesAlmacen(string anio, string mes)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@anio",anio),
                new SqlParameter("@mes",mes)
                };
            return this.BuscarObjetoPorParametro("isp_ResumenAnioMesAlmacen", lParameter);
        }
        public List<CuadroAnualAlmacen> CuadroAnualIngresoYSalida(string anio)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@anio",anio)
                };
            return this.BuscarObjetoCuadroPorParametro("isp_CuadroAnualIngresoYSalida", lParameter);
        }
        public void RecalcularStockProducto(string anio, string mes)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                    new SqlParameter("@IdCodAlmacen", 1),
                    new SqlParameter("@Anio", Convert.ToInt32(anio)),
                    new SqlParameter("@Mes", Convert.ToInt32(mes))
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_RecalcularStockProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
