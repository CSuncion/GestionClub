using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubGeneralRepository : IGestionClubGeneralRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();

        public void CrearBackupDbFbPol()
        {
            xObjCn.Connection();
            xObjCn.CommandStoreProcedure("isp_CrearBackupDbFbPol");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
