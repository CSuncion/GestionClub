using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubComprobanteAlmacenRepository
    {
        int AgregarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj);
        void AgregarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj);
        void ModificarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj);
        void ModificarDetalleComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj);
        void EliminarComprobanteAlmacen(GestionClubComprobanteAlmacenDto pObj);
        void EliminarComprobanteDetalleAlmacen(GestionClubComprobanteDetalleAlmacenDto pObj);
        List<GestionClubComprobanteAlmacenDto> ListarComprobanteAlmacen(GestionClubComprobanteAlmacenDto objEn);
        GestionClubComprobanteAlmacenDto ListarComprobanteAlmacenPorId(GestionClubComprobanteAlmacenDto objEn);
        List<GestionClubComprobanteDetalleAlmacenDto> ListarComprobanteDetalleAlmacenPorComprobanteAlmacen(GestionClubComprobanteDetalleAlmacenDto objEn);

    }
}