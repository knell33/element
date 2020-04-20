using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    public class DesignpageDAL
    {
        /// <summary>
        /// 获取设计页面信息
        /// </summary>
        /// <returns></returns>
        public List<Designpage> GetAllDesignpage()
        {
            string sql = @"select 编码 Code,
                                    名称 Name,
                                    描述 Description,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate
                                    from 设计页面";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Designpage> designpages = ModelConvert.DataTableToIList<Designpage>(dataTable).ToList();
            return designpages;
        }
    }
}
