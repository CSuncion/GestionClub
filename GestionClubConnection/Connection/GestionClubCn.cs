using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GestionClubConnection.Connection
{
    public class GestionClubCn
    {
        SqlConnection sqlCn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        SqlTransaction sqlTrc;
        public void Connection()
        {
            StringBuilder xStringConnection = new StringBuilder();
            xStringConnection.Append(" Data Source=" + ConfigurationManager.AppSettings["DataSource"].ToString() + ";");
            xStringConnection.Append(" Initial Catalog=" + ConfigurationManager.AppSettings["InitialCatalog"].ToString() + ";");
            xStringConnection.Append(" User Id=" + ConfigurationManager.AppSettings["UserId"].ToString() + ";");
            xStringConnection.Append(" Password=" + ConfigurationManager.AppSettings["Password"].ToString() + ";");
            this.sqlCn.ConnectionString = xStringConnection.ToString();
            this.sqlCn.Open();
        }
        public void CommandStoreProcedure(string pPa)
        {
            this.sqlCmd.Connection = this.sqlCn;
            this.sqlCmd.CommandTimeout = 2000;
            this.sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmd.CommandText = pPa;
        }

        public void CommandText(string pTexto)
        {
            this.sqlCmd.Connection = this.sqlCn;
            this.sqlCmd.CommandTimeout = 550;
            this.sqlCmd.CommandType = System.Data.CommandType.Text;
            this.sqlCmd.CommandText = pTexto;
        }

        public void AssignParameters(List<SqlParameter> lPar)
        {
            this.sqlCmd.Parameters.Clear();
            foreach (var pPar in lPar)
            {
                this.sqlCmd.Parameters.Add(pPar);
            }
        }

        public DataTable GetTableRegister()
        {
            DataTable xDt = new DataTable();
            xDt.Load(this.sqlCmd.ExecuteReader());
            return xDt;
        }

        public void ExecuteNotResult()
        {
            this.sqlCmd.ExecuteNonQuery();
        }

        public IDataReader GetIdr()
        {
            IDataReader xDr;
            xDr = this.sqlCmd.ExecuteReader();
            return xDr;
        }

        public string GetString()
        {
            string xValor;
            if (this.sqlCmd.ExecuteScalar() == null)
            {
                xValor = string.Empty;
            }
            else
            {
                xValor = this.sqlCmd.ExecuteScalar().ToString();
            }
            return xValor;
        }
        public int GetInt()
        {
            int xValor;
            if (this.sqlCmd.ExecuteScalar() == null)
            {
                xValor = 0;
            }
            else
            {
                xValor = Convert.ToInt32(this.sqlCmd.ExecuteScalar());
            }
            return xValor;
        }

        public void Disconnect()
        {
            this.sqlCn.Dispose();
            this.sqlCn.Close();
            this.sqlCmd.Dispose();
        }

        public void InitTransaction()
        {
            this.sqlTrc = this.sqlCn.BeginTransaction();
            this.sqlTrc = this.sqlCn.BeginTransaction();
        }

        public void CommandTextTransaction(string pTexto)
        {
            this.sqlCmd.Connection = this.sqlCn;
            this.sqlCmd.CommandType = System.Data.CommandType.Text;
            this.sqlCmd.CommandText = pTexto;
            this.sqlCmd.Transaction = this.sqlTrc;
        }

        public void ClosedTransaction()
        {
            this.sqlTrc.Commit();
        }
    }
}
