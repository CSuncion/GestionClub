using GestionClubModel.ModelDto;
using System.Collections.Generic;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubPermisoEmpresaRepository
    {
        GestionClubPermisoEmpresaDto ListarPermisoEmpresaPorCodigo(GestionClubPermisoEmpresaDto pObj);
        List<GestionClubPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(GestionClubPermisoEmpresaDto pObj);

    }
}