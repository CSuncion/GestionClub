using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubResultadoNubeFactRepository
    {
        void AdicionarResultadoNubeFact(GestionClubResultadoNubeFactDto pObj);
        void AdicionarErrorNubeFact(GestionClubErrorNubeFactDto pObj);
        List<GestionClubErrorNubeFactDto> ListadoErrorsNubeFact();
        List<GestionClubResultadoNubeFactDto> ListadoResultadoNubeFact();
    }
}
