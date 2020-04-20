using REMCommon;
using REMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace REMDAL
{
    public class RoleInformationDAL
    {
        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns></returns>
        public List<RoleInformation> GetAllRoleInformation()
        {
            string sql = @"select 角色ID ID,
                                    角色名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate
                                    from 角色信息";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<RoleInformation> roleInformation = ModelConvert.DataTableToIList<RoleInformation>(dataTable).ToList();
            return roleInformation;
        }
    }
}
