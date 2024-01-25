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
    public class CreditsProcesoEnvioController
    {
        private readonly ICreditsProcesoEnvioRepository _iCreditsProcesoEnvioRepository;
        public CreditsProcesoEnvioController()
        {
            this._iCreditsProcesoEnvioRepository = new CreditsProcesoEnvioRepository();
        }
        public void InsertarProcesoEnvio(CreditsProcesoEnvioDto pObj)
        {
            this._iCreditsProcesoEnvioRepository.InsertarProcesoEnvio(pObj);
        }
    }
}
