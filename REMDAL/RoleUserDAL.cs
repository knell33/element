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
    public class RoleUserDAL
    {
        /// <summary>
        /// 根据角色ID获取角色用户信息
        /// </summary>
        /// <param name="RID">角色ID</param>
        /// <returns></returns>
        public List<RoleUesr> GetAllRoleUserByRID(string RID)
        {
            string sql = @"select 角色用户ID RUID,
                                    角色ID RID,
                                    用户ID UserID,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    用户名 UserName,
                                    编码 Code,
                                    组织机构 Organization,
                                    邮箱地址 EmailAddress
                                    from 角色用户信息
                                    where 角色ID=:RID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":RID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<RoleUesr> roleUesrs = ModelConvert.DataTableToIList<RoleUesr>(dataTable).ToList();
            return roleUesrs;
        }
    }
}
