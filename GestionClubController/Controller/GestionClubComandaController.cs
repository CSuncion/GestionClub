using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubComandaController
    {
        private readonly IGestionClubComandaRepository _iCreditComandaRepository;

        public GestionClubComandaController()
        {
            this._iCreditComandaRepository = new GestionClubComandaRepository();
        }

        public static void EliminarComanda(GestionClubComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.EliminarComanda(pObj);
        }
        public static void ModificarComanda(GestionClubComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.ModificarComanda(pObj);
        }
        public static int AgregarComanda(GestionClubComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            return obj.AgregarComanda(pObj);
        }
        public static void AgregarDetalleComanda(GestionClubDetalleComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.AgregarDetalleComanda(pObj);
        }
        public static void ModificarDetalleComanda(GestionClubDetalleComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.ModificarDetalleComanda(pObj);
        }
        public static void EliminarDetalleComanda(GestionClubDetalleComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.EliminarDetalleComanda(pObj);
        }
        public static List<GestionClubDetalleComandaDto> ListarDetalleComandaPorMesaYPendienteCobrar(GestionClubDetalleComandaDto pObj)
        {
            GestionClubComandaRepository objCom = new GestionClubComandaRepository();
            return objCom.ListarDetalleComandaPorMesaYPendienteCobrar(pObj);
        }
        public static void ModificarSituacionComanda(GestionClubComandaDto pObj)
        {
            GestionClubComandaRepository obj = new GestionClubComandaRepository();
            obj.ModificarSituacionComanda(pObj);
        }
    }
}
