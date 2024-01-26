using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAmbienteRepository
    {
        List<GestionClubAmbientesDto> ListarAmbientes();
        GestionClubAmbientesDto ListarAmbientesPorCodigo(GestionClubAmbientesDto pObj);
        void AgregarAmbiente(GestionClubAmbientesDto pObj);
    }
}