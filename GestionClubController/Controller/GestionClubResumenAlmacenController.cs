using GestionClubModel.ModelDto;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubResumenAlmacenController
    {
        public static List<GestionClubResumenAlmacenDto> ResumenAnioMesAlmacen(string anio, string mes)
        {
            GestionClubResumenAlmacenRepository objRepo = new GestionClubResumenAlmacenRepository();
            return objRepo.ResumenAnioMesAlmacen(anio, mes);
        }
        public static List<CuadroAnualAlmacen> CuadroAnualIngresoYSalida(string anio)
        {
            GestionClubResumenAlmacenRepository objRepo = new GestionClubResumenAlmacenRepository();
            return objRepo.CuadroAnualIngresoYSalida(anio);
        }
        public static void RecalcularStockProducto(string anio, string mes)
        {
            GestionClubResumenAlmacenRepository obj = new GestionClubResumenAlmacenRepository();
            obj.RecalcularStockProducto(anio, mes);
        }
    }
}
