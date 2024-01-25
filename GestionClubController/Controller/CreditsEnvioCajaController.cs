using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using CreditsRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsController.Controller
{
    public class CreditsEnvioCajaController
    {
        private readonly ICreditsEnvioCajaRepository _iCreditsEnvioCajaRepository;
        public CreditsEnvioCajaController()
        {
            this._iCreditsEnvioCajaRepository = new CreditsEnvioCajaRepository();
        }
        public void EliminaEnvioCaja(CreditsEnvioCajaDto pObj)
        {
            this._iCreditsEnvioCajaRepository.EliminaEnvioCaja(pObj);
        }
    }
}
