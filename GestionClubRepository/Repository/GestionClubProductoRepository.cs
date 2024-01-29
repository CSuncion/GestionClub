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
    public class GestionClubProductoRepository : IGestionClubProductoRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubProductoDto xObj = new GestionClubProductoDto();
        private List<GestionClubProductoDto> xLista = new List<GestionClubProductoDto>();
        private GestionClubProductoDto Objeto(IDataReader iDr)
        {
            GestionClubProductoDto xObjEnc = new GestionClubProductoDto();
            xObjEnc.GestionClubCategoriaDto = new GestionClubCategoriaDto();
            xObjEnc.idProducto = Convert.ToInt32(iDr[GestionClubProductoDto._idProducto]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr[GestionClubProductoDto._idEmpresa]);
            xObjEnc.codProducto = iDr[GestionClubProductoDto._codProducto].ToString();
            xObjEnc.desProducto = iDr[GestionClubProductoDto._desProducto].ToString();
            xObjEnc.uniMedProducto = iDr[GestionClubProductoDto._uniMedProducto].ToString();
            xObjEnc.codMoneda = iDr[GestionClubProductoDto._codMoneda].ToString();
            xObjEnc.preCosProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._preCosProducto]);
            xObjEnc.preVtsProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._preVtsProducto]);
            xObjEnc.preVnsProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._preVnsProducto]);
            xObjEnc.afeIgvProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._afeIgvProducto]);
            xObjEnc.afeDtraProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._afeDtraProducto]);
            xObjEnc.porDtraProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._porDtraProducto]);
            xObjEnc.impDolProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._impDolProducto]);
            xObjEnc.impOtrProducto = Convert.ToDecimal(iDr[GestionClubProductoDto._impOtrProducto]);
            xObjEnc.obsProducto = iDr[GestionClubProductoDto._obsProducto].ToString();
            xObjEnc.idCategoria = Convert.ToInt32(iDr[GestionClubProductoDto._idCategoria]);
            xObjEnc.GestionClubCategoriaDto.desCategoria = Convert.ToString(iDr[GestionClubProductoDto._desCategoria]);
            xObjEnc.estadoProducto = Convert.ToString(iDr[GestionClubProductoDto._estadoProducto]);
            xObjEnc.stockProducto = Convert.ToInt32(iDr[GestionClubProductoDto._stockProducto]);
            xObjEnc.archivoProducto = Convert.ToString(iDr[GestionClubProductoDto._archivoProducto]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubProductoDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubProductoDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubProductoDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubProductoDto._fechaModifica]);
            xObjEnc.claveObjeto = xObjEnc.idProducto.ToString();
            return xObjEnc;
        }
        private GestionClubProductoDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubProductoDto> ListarObjetos(string pScript)
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
        private List<GestionClubProductoDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubProductoDto> ListarProductos()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarProductos", lParameter);
        }
        public List<GestionClubProductoDto> ListarProductosActivos()
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjetoPorParametro("isp_ListarProductosActivos", lParameter);
        }
        public List<GestionClubProductoDto> ListarProductosActivosPorCategoria(GestionClubProductoDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                new SqlParameter("@idCategoria",pObj.idCategoria)
                };
            return this.BuscarObjetoPorParametro("isp_ListarProductosActivosPorCategoria", lParameter);
        }
        public GestionClubProductoDto ListarProductoPorId(GestionClubProductoDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idProducto", pObj.idProducto),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa)
                };
            return this.BuscarObjeto("isp_ListarProductoPorId", lParameter);
        }
        public GestionClubProductoDto ListarProductoPorCodigoPorEmpresa(GestionClubProductoDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@codigo", pObj.codProducto),
                new SqlParameter("@empresa", pObj.idEmpresa)
                };
            return this.BuscarObjeto("isp_ListarProductoPorCodigoPorEmpresa", lParameter);
        }
        public void AgregarProducto(GestionClubProductoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codProducto",pObj.codProducto),
                    new SqlParameter("@desProducto",pObj.desProducto),
                    new SqlParameter("@uniMedProducto",pObj.uniMedProducto),
                    new SqlParameter("@codMoneda",pObj.codMoneda),
                    new SqlParameter("@preCosProducto",pObj.preCosProducto),
                    new SqlParameter("@preVtsProducto",pObj.preVtsProducto),
                    new SqlParameter("@preVnsProducto",pObj.preVnsProducto),
                    new SqlParameter("@afeIgvProducto",pObj.afeIgvProducto),
                    new SqlParameter("@afeDtraProducto",pObj.afeDtraProducto),
                    new SqlParameter("@porDtraProducto",pObj.porDtraProducto),
                    new SqlParameter("@impDolProducto",pObj.impDolProducto),
                    new SqlParameter("@impOtrProducto",pObj.impOtrProducto),
                    new SqlParameter("@stockProducto",pObj.stockProducto),
                    new SqlParameter("@archivoProducto",pObj.archivoProducto),
                    new SqlParameter("@obsProducto",pObj.obsProducto),
                    new SqlParameter("@idCategoria",pObj.idCategoria),
                    new SqlParameter("@estadoProducto",pObj.estadoProducto),
                    new SqlParameter("@usuarioAgrega",Universal.gIdAcceso),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_AgregarProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarProducto(GestionClubProductoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idProducto",pObj.idProducto),
                    new SqlParameter("@idEmpresa",Universal.gIdEmpresa),
                    new SqlParameter("@codProducto",pObj.codProducto),
                    new SqlParameter("@desProducto",pObj.desProducto),
                    new SqlParameter("@uniMedProducto",pObj.uniMedProducto),
                    new SqlParameter("@codMoneda",pObj.codMoneda),
                    new SqlParameter("@preCosProducto",pObj.preCosProducto),
                    new SqlParameter("@preVtsProducto",pObj.preVtsProducto),
                    new SqlParameter("@preVnsProducto",pObj.preVnsProducto),
                    new SqlParameter("@afeIgvProducto",pObj.afeIgvProducto),
                    new SqlParameter("@afeDtraProducto",pObj.afeDtraProducto),
                    new SqlParameter("@porDtraProducto",pObj.porDtraProducto),
                    new SqlParameter("@impDolProducto",pObj.impDolProducto),
                    new SqlParameter("@impOtrProducto",pObj.impOtrProducto),
                    new SqlParameter("@stockProducto", pObj.stockProducto),
                    new SqlParameter("@archivoProducto", pObj.archivoProducto),
                    new SqlParameter("@obsProducto",pObj.obsProducto),
                    new SqlParameter("@idCategoria",pObj.idCategoria),
                    new SqlParameter("@estadoProducto",pObj.estadoProducto),
                    new SqlParameter("@usuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarProducto(GestionClubProductoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                        new SqlParameter("@idProducto", pObj.idProducto),
                        new SqlParameter("@idEmpresa", Universal.gIdEmpresa),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminarProducto");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
