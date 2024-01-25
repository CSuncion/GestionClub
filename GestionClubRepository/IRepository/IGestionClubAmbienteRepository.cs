using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAmbienteRepository
    {
        List<GestionClubAmbientesDto> ListarAmbientes();
    }
}