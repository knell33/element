using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    public class DRDAL
    {
        /// <summary>
        /// 获取v_要素资源值域
        /// </summary>
        /// <returns></returns>
        public List<DR> GetAllDR()
        {
            string sql = @"select 资源名称 Name,资源ID RID,类型 Type from V_要素资源值域 ";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<DR> dr = ModelConvert.DataTableToIList<DR>(dataTable).ToList();
            return dr;
        }

    }
}
