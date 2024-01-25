using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubClienteRepository
    {
        List<GestionClubClienteDto> ListarClientes();
    }
}