using GestionClubRepository.Repository;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionClubModel.ModelDto;

namespace GestionClubController.Controller
{
    public class GestionClubGeneralController
    {
        private readonly IGestionClubGeneralRepository _iGestionClubGeneralRepository;
        public GestionClubGeneralController()
        {
            this._iGestionClubGeneralRepository = new GestionClubGeneralRepository();
        }
        public void CrearBackupDbFbPol()
        {
            this._iGestionClubGeneralRepository.CrearBackupDbFbPol();
        }
        public List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTabla(string tabla)
        {
            return this._iGestionClubGeneralRepository.ListarSistemaDetallePorTabla(tabla);
        }
    }
}
