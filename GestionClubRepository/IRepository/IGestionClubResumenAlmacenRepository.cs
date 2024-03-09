using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubResumenAlmacenRepository
    {
        List<GestionClubResumenAlmacenDto> ResumenAnioMesAlmacen(string anio, string mes);
        List<CuadroAnualAlmacen> CuadroAnualIngresoYSalida(string anio);
        void RecalcularStockProducto(string anio, string mes);
    }
}
