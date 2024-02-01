using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubProductoRepository
    {
        List<GestionClubProductoDto> ListarProductos();
        GestionClubProductoDto ListarProductoPorId(GestionClubProductoDto pObj);
        GestionClubProductoDto ListarProductoPorCodigoPorEmpresa(GestionClubProductoDto pObj);
        void AgregarProducto(GestionClubProductoDto pObj);
        void ModificarProducto(GestionClubProductoDto pObj);
        void EliminarProducto(GestionClubProductoDto pObj);
        List<GestionClubProductoDto> ListarProductosActivos();
        List<GestionClubProductoDto> ListarProductosActivosPorCategoria(GestionClubProductoDto pObj);
        GestionClubProductoDto ListarProductoPorNroDocumentoPorEmpresa(GestionClubProductoDto pObj);
    }
}