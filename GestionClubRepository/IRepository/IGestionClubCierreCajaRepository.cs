using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubCierreCajaRepository
    {
        List<GestionClubCierreCajaDto> ListarCierreCajas();
    }
}