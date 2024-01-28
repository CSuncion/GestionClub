using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubMesaRepository
    {
        List<GestionClubMesaDto> ListarMesas();
        GestionClubMesaDto ListarMesaPorId(GestionClubMesaDto pObj);
        GestionClubMesaDto ListarMesasPorCodigoPorEmpresa(GestionClubMesaDto pObj);
        void AgregarMesa(GestionClubMesaDto pObj);
        void ModificarMesa(GestionClubMesaDto pObj);
        void EliminarMesa(GestionClubMesaDto pObj);
        List<GestionClubMesaDto> ListarMesasPorAmbientePorEmpresa(GestionClubMesaDto pObj);
    }
}