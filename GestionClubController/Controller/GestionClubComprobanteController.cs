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
    public class GestionClubComprobanteController
    {
        private readonly IGestionClubComprobanteRepository _iCreditComprobanteRepository;

        public GestionClubComprobanteController()
        {
            this._iCreditComprobanteRepository = new GestionClubComprobanteRepository();
        }

        public static void EliminarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.EliminarComprobante(pObj);
        }
        public static void ModificarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.ModificarComprobante(pObj);
        }
        public static int AgregarComprobante(GestionClubComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            return obj.AgregarComprobante(pObj);
        }
        public static void AgregarDetalleComprobante(GestionClubDetalleComprobanteDto pObj)
        {
            GestionClubComprobanteRepository obj = new GestionClubComprobanteRepository();
            obj.AgregarDetalleComprobante(pObj);
        }
    }
}
