using GestionClubConnection.Connection;
using GestionClubModel.ModelDto;
using GestionClubRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClubRepository.Repository
{
    public class GestionClubEmpresaRepository : IGestionClubEmpresaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubEmpresaDto xObj = new GestionClubEmpresaDto();
        private List<GestionClubEmpresaDto> xLista = new List<GestionClubEmpresaDto>();
        private GestionClubEmpresaDto Objeto(IDataReader iDr)
        {
            GestionClubEmpresaDto xObjEnc = new GestionClubEmpresaDto();
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.codEmpresa = Convert.ToString(iDr["codEmpresa"]);
            xObjEnc.codSucursalEmpresa = Convert.ToInt32(iDr["codSucursalEmpresa"]);
            xObjEnc.desEmpresa = iDr["desEmpresa"].ToString();
            xObjEnc.rucEmpresa= Convert.ToString(iDr["rucEmpresa"]);
            xObjEnc.eMail = Convert.ToString(iDr["eMail"]);
            xObjEnc.direccionEmpresa = Convert.ToString(iDr["direccionEmpresa"]);
            xObjEnc.tlfFijoEmpresa = Convert.ToString(iDr["tlfFijoEmpresa"]);
            xObjEnc.tlfCelularEmpresa = Convert.ToString(iDr["tlfCelularEmpresa"]);
            xObjEnc.estadoEmpresa = Convert.ToString(iDr["estadoEmpresa"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubEmpresaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.Objeto(xIdr);
            }
            xObjCn.Disconnect();
            return xObj;
        }
        private List<GestionClubEmpresaDto> ListarObjetos(string pScript)
        {
            xObjCn.Connection();
            //xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
    }
}
