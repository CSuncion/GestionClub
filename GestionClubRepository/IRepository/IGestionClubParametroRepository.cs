using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubParametroRepository
    {
        List<GestionClubParametroDto> ListarParametro();
        void ModificarParametro(GestionClubParametroDto pObj);
    }
}
