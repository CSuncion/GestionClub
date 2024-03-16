using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubModel.ModelDto
{
    public class GestionClubResumenAlmacenDto
    {
        public const string _claveObjeto = "ClaveObjeto";
        public const string _IdResumenAlmacen = "IdResumenAlmacen";
        public const string _IdEmpresa = "IdEmpresa";
        public const string _IdCodAlmacen = "IdCodAlmacen";
        public const string _AnoProceso = "AnoProceso";
        public const string _MesProceso = "MesProceso";
        public const string _Mes = "Mes";
        public const string _CodigoProducto = "CodigoProducto";
        public const string _desProducto = "desProducto";
        public const string _SaldoAnterior = "SaldoAnterior";
        public const string _PrecioCostoAnterior = "PrecioCostoAnterior";
        public const string _AcumulngresosMes = "AcumulngresosMes";
        public const string _AcumulSalidasMes = "AcumulSalidasMes";
        public const string _SaldoNuevo = "SaldoNuevo";
        public const string _PrecioCostoNuevo = "PrecioCostoNuevo";
        public const string _FlagProcesado = "FlagProcesado";
        public const string _desCategoria = "desCategoria";

        public string claveObjeto { get; set; }
        public int IdResumenAlmacen { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCodAlmacen { get; set; }
        public string AnoProceso { get; set; }
        public string MesProceso { get; set; }
        public string Mes { get; set; }
        public string CodigoProducto { get; set; }
        public string desProducto { get; set; }
        public int SaldoAnterior { get; set; }
        public decimal PrecioCostoAnterior { get; set; }
        public int AcumulngresosMes { get; set; }
        public int AcumulSalidasMes { get; set; }
        public int SaldoNuevo { get; set; }
        public decimal PrecioCostoNuevo { get; set; }
        public bool FlagProcesado { get; set; }
        public string desCategoria { get; set; }
    }
    public class CuadroAnualAlmacen
    {
        public const string _CodigoProducto = "CodigoProducto";
        public const string _DesProducto = "DesProducto";
        public const string _IngEnero = "IngEnero";
        public const string _SalEnero = "SalEnero";
        public const string _IngFebrero = "IngFebrero";
        public const string _SalFebrero = "SalFebrero";
        public const string _IngMarzo = "IngMarzo";
        public const string _SalMarzo = "SalMarzo";
        public const string _IngAbril = "IngAbril";
        public const string _SalAbril = "SalAbril";
        public const string _IngMayo = "IngMayo";
        public const string _SalMayo = "SalMayo";
        public const string _IngJunio = "IngJunio";
        public const string _SalJunio = "SalJunio";
        public const string _IngJulio = "IngJulio";
        public const string _SalJulio = "SalJulio";
        public const string _IngAgosto = "IngAgosto";
        public const string _SalAgosto = "SalAgosto";
        public const string _IngSetiembre = "IngSetiembre";
        public const string _SalSetiembre = "SalSetiembre";
        public const string _IngOctubre = "IngOctubre";
        public const string _SalOctubre = "SalOctubre";
        public const string _IngNoviembre = "IngNoviembre";
        public const string _SalNoviembre = "SalNoviembre";
        public const string _IngDiciembre = "IngDiciembre";
        public const string _SalDiciembre = "SalDiciembre";

        public string CodigoProducto { get; set; }
        public string DesProducto { get; set; }
        public int IngEnero { get; set; }
        public int SalEnero { get; set; }
        public int IngFebrero { get; set; }
        public int SalFebrero { get; set; }
        public int IngMarzo { get; set; }
        public int SalMarzo { get; set; }
        public int IngAbril { get; set; }
        public int SalAbril { get; set; }
        public int IngMayo { get; set; }
        public int SalMayo { get; set; }
        public int IngJunio { get; set; }
        public int SalJunio { get; set; }
        public int IngJulio { get; set; }
        public int SalJulio { get; set; }
        public int IngAgosto { get; set; }
        public int SalAgosto { get; set; }
        public int IngSetiembre { get; set; }
        public int SalSetiembre { get; set; }
        public int IngOctubre { get; set; }
        public int SalOctubre { get; set; }
        public int IngNoviembre { get; set; }
        public int SalNoviembre { get; set; }
        public int IngDiciembre { get; set; }
        public int SalDiciembre { get; set; }
    }
}
