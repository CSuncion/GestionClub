using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubComandaRepository
    {
        int AgregarComanda(GestionClubComandaDto pObj);
        void AgregarDetalleComanda(GestionClubDetalleComandaDto pObj);
        List<GestionClubDetalleComandaDto> ListarDetalleComandaPorMesaYPendienteCobrar(GestionClubDetalleComandaDto pObj);
        void ModificarComanda(GestionClubComandaDto pObj);
        void ModificarDetalleComanda(GestionClubDetalleComandaDto pObj);
        void EliminarComanda(GestionClubComandaDto pObj);
        void EliminarProducto(GestionClubDetalleComandaDto pObj);

    }
}