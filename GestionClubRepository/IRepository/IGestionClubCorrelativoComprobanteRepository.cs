using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubCorrelativoComprobanteRepository
    {
        void ActualizarCorrelativo(GestionClubCorrelativoComprobanteDto pObj);
        GestionClubCorrelativoComprobanteDto GenerarCorrelativo(GestionClubCorrelativoComprobanteDto objEn);
    }
}
