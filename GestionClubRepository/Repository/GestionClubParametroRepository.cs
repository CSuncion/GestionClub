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
    public class GestionClubParametroRepository : IGestionClubParametroRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubParametroDto xObj = new GestionClubParametroDto();
        private List<GestionClubParametroDto> xLista = new List<GestionClubParametroDto>();
        private GestionClubParametroDto Objeto(IDataReader iDr)
        {
            GestionClubParametroDto xObjEnc = new GestionClubParametroDto();
            xObjEnc.RutaLogoEmpresa = iDr[GestionClubParametroDto._RutaLogoEmpresa].ToString();
            xObjEnc.PorcentajeIgv = Convert.ToDecimal(iDr[GestionClubParametroDto._PorcentajeIgv]);
            xObjEnc.PorcentajeDetra = Convert.ToDecimal(iDr[GestionClubParametroDto._PorcentajeDetra]);
            xObjEnc.NombreSoles = iDr[GestionClubParametroDto._NombreSoles].ToString();
            xObjEnc.NombreDolares = iDr[GestionClubParametroDto._NombreDolares].ToString();
            xObjEnc.RutaImagenCategoria = iDr[GestionClubParametroDto._RutaImagenCategoria].ToString();
            xObjEnc.RutaImagenProducto = iDr[GestionClubParametroDto._RutaImagenProducto].ToString();
            xObjEnc.RutaImagenMesa = iDr[GestionClubParametroDto._RutaImagenMesa].ToString();
            xObjEnc.RutaImagenQR = iDr[GestionClubParametroDto._RutaImagenQR].ToString();
            xObjEnc.CtaBcoNacion = iDr[GestionClubParametroDto._CtaBcoNacion].ToString();
            xObjEnc.UsuarioAgrega = iDr[GestionClubParametroDto._UsuarioAgrega].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[GestionClubParametroDto._FechaAgrega]);
            xObjEnc.UsuarioModifica = iDr[GestionClubParametroDto._UsuarioModifica].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[GestionClubParametroDto._FechaModifica]);

            return xObjEnc;
        }
        private GestionClubParametroDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubParametroDto> ListarObjetos(string pScript)
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
        private List<GestionClubParametroDto> BuscarObjetoPorParametro(string pScript, List<SqlParameter> lParameter)
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
        public List<GestionClubParametroDto> ListarParametro()
        {
            return this.ListarObjetos("isp_ListarParametro");
        }
        public void ModificarParametro(GestionClubParametroDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@RutaLogoEmpresa",pObj.RutaLogoEmpresa),
                    new SqlParameter("@PorcentajeIgv",pObj.PorcentajeIgv),
                    new SqlParameter("@PorcentajeDetra",pObj.PorcentajeDetra),
                    new SqlParameter("@NombreSoles",pObj.NombreSoles),
                    new SqlParameter("@NombreDolares",pObj.NombreDolares),
                    new SqlParameter("@RutaImagenCategoria ",pObj.RutaImagenCategoria ),
                    new SqlParameter("@RutaImagenProducto",pObj.RutaImagenProducto),
                    new SqlParameter("@RutaImagenMesa",pObj.RutaImagenMesa),
                    new SqlParameter("@RutaImagenQR",pObj.RutaImagenQR),
                    new SqlParameter("@CtaBcoNacion",pObj.RutaImagenQR),
                    new SqlParameter("@UsuarioModifica",Universal.gIdAcceso)
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_ModificarParametro");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
