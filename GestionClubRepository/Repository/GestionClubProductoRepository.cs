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
            xObjEnc.estadoProducto = Convert.ToInt32(iDr[GestionClubProductoDto._estadoProducto]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr[GestionClubProductoDto._usuarioAgrega]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr[GestionClubProductoDto._fechaAgrega]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr[GestionClubProductoDto._usuarioModifica]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr[GestionClubProductoDto._fechaModifica]);

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
        public List<GestionClubProductoDto> ListarProductos()
        {
            return this.ListarObjetos("isp_ListarProductos");
        }
    }
}
