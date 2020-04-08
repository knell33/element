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
    public class ElementRangeDAL
    {
        /// <summary>
        /// 根据要素ID获取文本值域选项
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public List<ElementRange> GetAll(string EID)
        {
            string sql = @"select   选项值域ID ID,
                                    选项名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    要素ID EID from 文本选项值域 where 要素ID = :EID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameter =
            {
                new OracleParameter(":EID",OracleDbType.Varchar2,EID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, CommandType.Text, oracleParameter);
            List<ElementRange> list = ModelConvert.DataTableToIList<ElementRange>(dataTable).ToList();
            return list;
        }
    }
}
