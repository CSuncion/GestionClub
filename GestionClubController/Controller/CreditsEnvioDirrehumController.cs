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
    public class CreditsEnvioDirrehumController
    {
        private readonly ICreditsEnvioDirrehumRepository _iCreditsEnvioDirrehumRepository;
        public CreditsEnvioDirrehumController()
        {
            this._iCreditsEnvioDirrehumRepository = new CreditsEnvioDirrehumRepository();
        }
        public void EliminaEnvioDirrehum(CreditsEnvioDirrehumDto pObj)
        {
            this._iCreditsEnvioDirrehumRepository.EliminaEnvioDirrehum(pObj);
        }
        public void InsertarTbEnvioDirrehum(string strQuery)
        {
            this._iCreditsEnvioDirrehumRepository.InsertarTbEnvioDirrehum(strQuery);
        }
    }
}
