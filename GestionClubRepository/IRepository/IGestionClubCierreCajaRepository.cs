using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubCierreCajaRepository
    {
        List<GestionClubCierreCajaDto> ListarCierreCajas();
        GestionClubCierreCajaDto ListarCierreCajaPorFechaPorCaja(GestionClubCierreCajaDto obj);
        void AgregarCierreCaja(GestionClubCierreCajaDto pObj);
        void ModificarCierreCaja(GestionClubCierreCajaDto pObj);
        void EliminarCierreCaja(GestionClubCierreCajaDto pObj);
        GestionClubCierreCajaDto ListarCierreCajaPorId(GestionClubCierreCajaDto pObj);
    }
}