using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubCategoriaRepository
    {
        List<GestionClubCategoriaDto> ListarCategorias();
        GestionClubCategoriaDto ListarCategoriaPorId(GestionClubCategoriaDto pObj);
        GestionClubCategoriaDto ListarCategoriaPorCodigoPorEmpresa(GestionClubCategoriaDto pObj);
        void ModificarCategoria(GestionClubCategoriaDto pObj);
        void EliminarCategoria(GestionClubCategoriaDto pObj);
        void AgregarCategoria(GestionClubCategoriaDto pObj);
        List<GestionClubCategoriaDto> ListarCategoriasActivos();

    }
}