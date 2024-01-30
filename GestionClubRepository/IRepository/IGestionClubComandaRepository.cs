using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubComandaRepository
    {
        int AgregarComanda(GestionClubComandaDto pObj);
        void AgregarDetalleComanda(GestionClubDetalleComandaDto pObj);
        void ModificarProducto(GestionClubProductoDto pObj);
        void EliminarProducto(GestionClubProductoDto pObj);
        List<GestionClubDetalleComandaDto> ListarDetalleComandaPorMesaYPendienteCobrar(GestionClubDetalleComandaDto pObj);
    }
}