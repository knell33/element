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

        /// <summary>
        /// 新增角色用户
        /// </summary>
        /// <param name="roleUesr">角色用户实体</param>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public string CreateRoleUser(RoleUesr roleUesr,DateTime dt)
        {
            string sql = "p_角色用户_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("角色用户id_In",OracleDbType.Varchar2,roleUesr.RUID,ParameterDirection.Input),
                new OracleParameter("角色id_In",OracleDbType.Varchar2,roleUesr.RID,ParameterDirection.Input),
                new OracleParameter("用户id_In",OracleDbType.Varchar2,roleUesr.UserID,ParameterDirection.Input),
                new OracleParameter("最后修改人_In",OracleDbType.Varchar2,roleUesr.LastModify,ParameterDirection.Input),
                new OracleParameter("最后修改时间_In",OracleDbType.Date,dt,ParameterDirection.Input),
                new OracleParameter("用户名_In",OracleDbType.Varchar2,roleUesr.UserName,ParameterDirection.Input),
                new OracleParameter("编码_In",OracleDbType.Varchar2,roleUesr.Code,ParameterDirection.Input),
                new OracleParameter("组织机构_In",OracleDbType.Varchar2,roleUesr.Organization,ParameterDirection.Input),
                new OracleParameter("邮箱地址_In",OracleDbType.Varchar2,roleUesr.EmailAddress,ParameterDirection.Input)
            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
            return "OK";
        }

        /// <summary>
        /// 删除角色用户信息
        /// </summary>
        /// <param name="RUID">角色用户ID</param>
        public void DeleteMainAuthorityByRUID(string RUID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 角色用户信息 where 角色用户ID = :RUID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":RUID",OracleDbType.Varchar2,RUID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }
    }
}
