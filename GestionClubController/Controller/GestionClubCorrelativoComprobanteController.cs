using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using GestionClubRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubController.Controller
{
    public class GestionClubCorrelativoComprobanteController
    {
        private readonly IGestionClubCorrelativoComprobanteRepository _iGestionClubCorrelativoComprobanteRepository;

        public GestionClubCorrelativoComprobanteController()
        {
            this._iGestionClubCorrelativoComprobanteRepository = new GestionClubCorrelativoComprobanteRepository();
        }
        public static GestionClubCorrelativoComprobanteDto GenerarCorrelativo(GestionClubCorrelativoComprobanteDto obj)
        {
            GestionClubCorrelativoComprobanteRepository oRepo = new GestionClubCorrelativoComprobanteRepository();
            return oRepo.GenerarCorrelativo(obj);
        }
        public static void ActualizarCorrelativo(GestionClubCorrelativoComprobanteDto pObj)
        {
            GestionClubCorrelativoComprobanteRepository xObj = new GestionClubCorrelativoComprobanteRepository();
            xObj.ActualizarCorrelativo(pObj);
        }
    }
}
