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
        public static List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTabla(string tabla)
        {
            GestionClubGeneralRepository objRepo = new GestionClubGeneralRepository();
            return objRepo.ListarSistemaDetallePorTabla(tabla);
        }
        public static List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTablaPorObs(string tabla, string obs)
        {
            GestionClubGeneralRepository objRepo = new GestionClubGeneralRepository();
            return objRepo.ListarSistemaDetallePorTablaPorObs(tabla, obs);
        }
    }
}
