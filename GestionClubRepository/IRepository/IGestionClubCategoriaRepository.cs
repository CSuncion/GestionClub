using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubCategoriaRepository
    {
        List<GestionClubCategoriaDto> ListarCategorias();
    }
}