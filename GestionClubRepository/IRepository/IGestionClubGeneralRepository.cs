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
        List<GestionClubSistemaDetalleDto> ListarSistemaDetallePorTablaPorObs(string tabla, string obs);
        List<GestionClubSistemaDto> ListarSistema();
        GestionClubSistemaDetalleDto ListarSistemaDetallePorId(GestionClubSistemaDetalleDto pObj);
        void AdicionarSistemaDetalle(GestionClubSistemaDetalleDto pObj);
        void ModificarSistemaDetalle(GestionClubSistemaDetalleDto pObj);
        void EliminarSistemaDetalle(GestionClubSistemaDetalleDto pObj);
        GestionClubSistemaDetalleDto ListarSistemaDetallePorCodigo(GestionClubSistemaDetalleDto pObj);
        List<GestionClubSistemaDetalleDto> ListarSistemaDetalle();
    }
}
