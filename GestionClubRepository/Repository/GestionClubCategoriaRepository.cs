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
    public class GestionClubCategoriaRepository : IGestionClubCategoriaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubCategoriaDto xObj = new GestionClubCategoriaDto();
        private List<GestionClubCategoriaDto> xLista = new List<GestionClubCategoriaDto>();
        private GestionClubCategoriaDto Objeto(IDataReader iDr)
        {
            GestionClubCategoriaDto xObjEnc = new GestionClubCategoriaDto();
            xObjEnc.idCategoria = Convert.ToInt32(iDr["idCategoria"]);
            xObjEnc.codCategoria = iDr["codCategoria"].ToString();
            xObjEnc.desCategoria = iDr["desCategoria"].ToString();
            xObjEnc.estadoCategoria = Convert.ToInt32(iDr["estadoCategoria"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubCategoriaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubCategoriaDto> ListarObjetos(string pScript)
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
        public List<GestionClubCategoriaDto> ListarCategorias()
        {
            return this.ListarObjetos("isp_ListarCategorias");
        }
    }
}
