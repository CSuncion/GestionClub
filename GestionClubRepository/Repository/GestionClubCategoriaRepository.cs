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
            xObjEnc.archivoCategoria = iDr["archivoCategoria"].ToString();
            xObjEnc.estadoCategoria = Convert.ToString(iDr["estadoCategoria"]);
            xObjEnc.Estado = Convert.ToString(iDr[GestionClubCategoriaDto._Estado]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            xObjEnc.claveObjeto = xObjEnc.idCategoria.ToString();
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
        private List<GestionClubCategoriaDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
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
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarCategorias", lParameter);
        }
        public GestionClubCategoriaDto ListarCategoriaPorId(GestionClubCategoriaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idCategoria", pObj.idCategoria),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarCategoriaPorId", lParameter);
        }
        public GestionClubCategoriaDto ListarCategoriaPorCodigoPorEmpresa(GestionClubCategoriaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codCategoria),
                new SqlParameter("@empresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarCategoriaPorCodigoPorEmpresa", lParameter);
        }
        public void AgregarCategoria(GestionClubCategoriaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                        new SqlParameter("@codCategoria",pObj.codCategoria),
                        new SqlParameter("@desCategoria",pObj.desCategoria),
                        new SqlParameter("@archivoCategoria",pObj.archivoCategoria),
                        new SqlParameter("@estadoCategoria",pObj.estadoCategoria),
                        new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                        new SqlParameter("@usuarioModifica",Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarCategoria");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarCategoria(GestionClubCategoriaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idCategoria", pObj.idCategoria),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                        new SqlParameter("@codCategoria", pObj.codCategoria),
                        new SqlParameter("@desCategoria", pObj.desCategoria),
                        new SqlParameter("@archivoCategoria",pObj.archivoCategoria),
                        new SqlParameter("@estadoCategoria", pObj.estadoCategoria),
                        new SqlParameter("@usuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarCategoria");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarCategoria(GestionClubCategoriaDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idCategoria", pObj.idCategoria),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarCategoria");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<GestionClubCategoriaDto> ListarCategoriasActivos()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa", Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarCategoriasActivos", lParameter);
        }
    }
}
