using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubTipoCambioRepository
    {
        List<GestionClubTipoCambioDto> ListarTipoCambio();
        GestionClubTipoCambioDto ListarTipoCambioPorFecha(GestionClubTipoCambioDto xObj);
        GestionClubTipoCambioDto ListarTipoCambioPorId(GestionClubTipoCambioDto xObj);
        void EliminarTipoCambio(GestionClubTipoCambioDto pObj);
        void ModificarTipoCambio(GestionClubTipoCambioDto pObj);
        void AdicionarTipoCambio(GestionClubTipoCambioDto pObj);
    }
}
