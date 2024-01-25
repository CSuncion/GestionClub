﻿using GestionClubConnection.Connection;
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
    public class GestionClubCierreCajaRepository : IGestionClubCierreCajaRepository
    {
        private GestionClubCn xObjCn = new GestionClubCn();
        private GestionClubCierreCajaDto xObj = new GestionClubCierreCajaDto();
        private List<GestionClubCierreCajaDto> xLista = new List<GestionClubCierreCajaDto>();
        private GestionClubCierreCajaDto Objeto(IDataReader iDr)
        {
            GestionClubCierreCajaDto xObjEnc = new GestionClubCierreCajaDto();
            xObjEnc.idCierreCaja = Convert.ToInt32(iDr["idCierreCaja"]);
            xObjEnc.idEmpresa = Convert.ToInt32(iDr["idEmpresa"]);
            xObjEnc.fecCierreCaja = Convert.ToDateTime(iDr["fecCierreCaja"]);
            xObjEnc.montoCierreCaja = Convert.ToDecimal(iDr["montoCierreCaja"]);
            xObjEnc.estadoCierreCaja = Convert.ToInt32(iDr["estadoCierreCaja"]);
            xObjEnc.usuarioAgrega = Convert.ToInt32(iDr["usuarioAgrega"]);
            xObjEnc.fechaAgrega = Convert.ToDateTime(iDr["fechaAgrega"]);
            xObjEnc.usuarioModifica = Convert.ToInt32(iDr["usuarioModifica"]);
            xObjEnc.fechaModifica = Convert.ToDateTime(iDr["fechaModifica"]);
            return xObjEnc;
        }
        private GestionClubCierreCajaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
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
        private List<GestionClubCierreCajaDto> ListarObjetos(string pScript)
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
        public List<GestionClubCierreCajaDto> ListarCierreCajas()
        {
            return this.ListarObjetos("isp_ListarCierreCajas");
        }
    }
}