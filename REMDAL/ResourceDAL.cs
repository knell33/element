using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    /// <summary>
    /// 资源目录管理
    /// </summary>
    public class ResourceDAL
    {
        /// <summary>
        /// 获取资源目录
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetAll()
        {
            string sql = @"select   资源ID ID,
                                    上级资源ID PID,
                                    资源名称 Name,
                                    类型 Type,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    显示名称 ShowName,
                                    是否树形 TreeForm,
                                    关系资源ID RelationID from 资源目录 order by 资源名称";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Resource> resources = ModelConvert.DataTableToIList<Resource>(dataTable).ToList();
            return resources;
        }
    }
}
