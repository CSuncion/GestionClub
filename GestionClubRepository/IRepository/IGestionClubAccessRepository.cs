using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubAccessRepository
    {
        GestionClubAccessDto BuscarUsuarioXCodigo(GestionClubAccessDto pObj);
        List<int> ListarSubPrivilegiosAcceso(int idAcceso);
        List<GestionClubAccessDto> ListarUsuarioMeserosActivos(GestionClubAccessDto pObj);
        List<GestionClubAccessDto> ListarUsuarioMozos();
        void EliminarAcceso(GestionClubAccessDto pObj);
        void ModificarAcceso(GestionClubAccessDto pObj);
        void AdicionarAcceso(GestionClubAccessDto pObj);
        GestionClubAccessDto ListarUsuarioMozosPorId(GestionClubAccessDto pObj);
    }
}
