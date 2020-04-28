using Oracle.ManagedDataAccess.Client;
using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    public class TestDAL
    {
        public object FunctionTest(string type)
        {
            string sql = "p_test_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("Type_in",OracleDbType.Varchar2,type,ParameterDirection.Input),
                new OracleParameter("Numbera_out",OracleDbType.Varchar2,"",ParameterDirection.Output)
            };
            /*object numbera =  oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
            return numbera;*/
            Dictionary<string, object> dic = oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
            if (dic.ContainsKey("Numbera_out"))
                return ModelConvert.DataTableToIList<Test>(dic["Numbera_out"] as DataTable).ToList();
            else
                return null;
        }
    }
}
