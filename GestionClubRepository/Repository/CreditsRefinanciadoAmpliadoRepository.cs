using CreditsConnection.Connection;
using CreditsModel.ModelDto;
using CreditsRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditsRepository.Repository
{
    public class CreditsRefinanciadoAmpliadoRepository : ICreditsRefinanciadoAmpliadoRepository
    {
        private CreditsCn xObjCn = new CreditsCn();
        private CreditsRefinanciadoAmpliadoDto xObj = new CreditsRefinanciadoAmpliadoDto();
        private List<CreditsRefinanciadoAmpliadoDto> xLista = new List<CreditsRefinanciadoAmpliadoDto>();
        private CreditsRefinanciadoAmpliadoDto Objeto(IDataReader iDr)
        {
            CreditsRefinanciadoAmpliadoDto xObjEnc = new CreditsRefinanciadoAmpliadoDto();
            xObjEnc.IdRefinanciadoAmpliado = Convert.ToInt32(iDr[CreditsRefinanciadoAmpliadoDto.xIdRefinanciadoAmpliado]);
            xObjEnc.IdOperacion = Convert.ToInt32(iDr[CreditsRefinanciadoAmpliadoDto.xIdOperacion]);
            xObjEnc.Estado = Convert.ToInt32(iDr[CreditsRefinanciadoAmpliadoDto.xEstado]);
            xObjEnc.DesEstado = iDr[CreditsRefinanciadoAmpliadoDto.xDesEstado].ToString();
            xObjEnc.UsuarioAgrega = Convert.ToInt32(iDr[CreditsRefinanciadoAmpliadoDto.xUsuarioAgrega]);
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CreditsRefinanciadoAmpliadoDto.xFechaAgrega]);
            xObjEnc.UsuarioModifica = Convert.ToInt32(iDr[CreditsRefinanciadoAmpliadoDto.xUsuarioModifica]);
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CreditsRefinanciadoAmpliadoDto.xFechaModifica]);
            return xObjEnc;
        }
        private CreditsRefinanciadoAmpliadoDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<CreditsRefinanciadoAmpliadoDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
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
        public void CrearRefinanciadoAmpliado(CreditsRefinanciadoAmpliadoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@IdOperacion", pObj.IdOperacion),
                new SqlParameter("@Estado", pObj.Estado),
                new SqlParameter("@UsuarioAgrega", Universal.gIdAcceso),
                new SqlParameter("@UsuarioModifica", Universal.gIdAcceso),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_CrearRefinanciadoAmpliado");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public void EliminarRefinanciadoAmpliado(CreditsRefinanciadoAmpliadoDto pObj)
        {
            xObjCn.Connection();
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@IdOperacion", pObj.IdOperacion),
                };
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure("isp_EliminaRefinanciadoAmpliado");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public CreditsRefinanciadoAmpliadoDto ListarRefinanciadoAmpliadoPorOperacion(CreditsRefinanciadoAmpliadoDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@IdOperacion", pObj.IdOperacion)
                };

            return this.BuscarObjeto("isp_ListarRefinanciadoAmpliadoPorOperacion", lParameter);
        }
    }
}
