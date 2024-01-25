using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubProductoRepository
    {
        List<GestionClubProductoDto> ListarProductos();
    }
}