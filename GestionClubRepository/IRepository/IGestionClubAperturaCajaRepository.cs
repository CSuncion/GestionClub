using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAperturaCajaRepository
    {
        List<GestionClubAperturaCajaDto> ListarAperturaCajas();
        GestionClubAperturaCajaDto ListarAperturaCajasPorFecha(GestionClubAperturaCajaDto obj);
    }
}