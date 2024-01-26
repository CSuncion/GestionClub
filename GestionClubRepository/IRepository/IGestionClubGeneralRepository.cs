using GestionClubModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.IRepository
{
    public interface IGestionClubGeneralRepository
    {
        void CrearBackupDbFbPol();
        List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTabla(string tabla);
    }
}
