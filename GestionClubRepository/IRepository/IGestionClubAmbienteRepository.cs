using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAmbienteRepository
    {
        List<GestionClubAmbientesDto> ListarAmbientes();
        GestionClubAmbientesDto ListarAmbientesPorCodigoPorEmpresa(GestionClubAmbientesDto pObj);
        void AgregarAmbiente(GestionClubAmbientesDto pObj);
        GestionClubAmbientesDto ListarAmbientesPorId(GestionClubAmbientesDto pObj);
        void ModificarAmbiente(GestionClubAmbientesDto pObj);
        void EliminarAmbiente(GestionClubAmbientesDto pObj);
    }
}