using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    public class GCodedirDAL
    {
        /// <summary>
        /// 获取通用编码目录
        /// </summary>
        /// <returns></returns>
        public List<GCodedir> GetAllGCodedir()
        {
            string sql = @"select 目录ID ID,
                                    目录名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    是否树形 TreeForm
                                    from 通用编码目录";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<GCodedir> gCodedir = ModelConvert.DataTableToIList<GCodedir>(dataTable).ToList();
            return gCodedir;
        }
    }
}
