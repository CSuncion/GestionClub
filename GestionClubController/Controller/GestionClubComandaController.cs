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

        public static void EliminarProducto(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            obj.EliminarProducto(pObj);
        }
        public static void ModificarProducto(GestionClubProductoDto pObj)
        {
            GestionClubProductoRepository obj = new GestionClubProductoRepository();
            obj.ModificarProducto(pObj);
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
        public static List<GestionClubDetalleComandaDto> ListarDetalleComandaPorMesaYPendienteCobrar(GestionClubDetalleComandaDto pObj)
        {
            GestionClubComandaRepository objCom = new GestionClubComandaRepository();
            return objCom.ListarDetalleComandaPorMesaYPendienteCobrar(pObj);
        }
    }
}
