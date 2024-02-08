using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAperturaCajaRepository
    {
        List<GestionClubAperturaCajaDto> ListarAperturaCajas();
        GestionClubAperturaCajaDto ListarAperturaCajasPorFechaPorCaja(GestionClubAperturaCajaDto obj);
        void AgregarAperturaCaja(GestionClubAperturaCajaDto pObj);
        void ModificarAperturaCaja(GestionClubAperturaCajaDto pObj);
        void EliminarAperturaCaja(GestionClubAperturaCajaDto pObj);
        GestionClubAperturaCajaDto ListarAperturaCajaPorId(GestionClubAperturaCajaDto pObj);

    }
}