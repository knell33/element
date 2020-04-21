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
    public class MainAuthorityDAL
    {
        /// <summary>
        /// 根据资源明细ID获取主体权限数据
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<MainAuthority> GetAllMainAuthorityByDetailID(string DID)
        {
            string sql = @"select a.主体权限id AID ,
                                    a.角色id RoleID , 
                                    a.角色名称 RoleName ,              
                                    a.主体id MID ,
                                    a.主体名称 MainName ,
                                    a.类型 Type ,
                                    a.权限类型 AuthorityType ,
                                    a.关联资源ID RID ,
                                    a.关联资源明细ID DID ,
                                    a.最后修改人 LastModify ,
                                    a.最后修改时间 LastDate 
                             from ( select a.主体权限id, 
                                    a.角色id,
                                    b.角色名称,
                                    a.主体id,
                                    a.主体名称,
                                    a.类型,
                                    a.权限类型,
                                    a.关联资源ID,                  
                                    a.关联资源明细ID,
                                    a.最后修改人,
                                    a.最后修改时间 
                                    from 主体权限 a , 角色信息 b
                                    where a.关联资源明细ID = '{0}'
                                    and a.角色id = b.角色id(+) ) a";
            sql = string.Format(sql, DID);
            //数据库连接
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);

            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<MainAuthority> mainAuthority = ModelConvert.DataTableToIList<MainAuthority>(dataTable).ToList();
            return mainAuthority;
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<MainAuthority> GetAllRoleInfo()
        {
            string sql = @"Select a.角色ID RoleID,a.角色名称 RoleName
                            From 角色信息 a";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<MainAuthority> mainAuthority = ModelConvert.DataTableToIList<MainAuthority>(dataTable).ToList();
            return mainAuthority;
        }

        /// <summary>
        /// 新增主体权限
        /// </summary>
        /// <param name="mainAuthority">主体权限对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateMainAuthority(MainAuthority mainAuthority, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 主体权限( 主体权限ID,
                                                 主体名称,
                                                 类型,
                                                 角色ID,
                                                 权限类型,
                                                 最后修改人,
                                                 最后修改时间,
                                                 关联资源ID,                                                 
                                                关联资源明细ID) 
                                        values(:主体权限ID,:主体名称,:类型,:角色ID,:权限类型,:最后修改人,:最后修改时间,:关联资源ID,:关联资源明细ID)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":主体权限ID",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":主体名称",OracleDbType.Varchar2,mainAuthority.MainName==null?"":mainAuthority.MainName,ParameterDirection.Input),
                    new OracleParameter(":类型",OracleDbType.Varchar2,mainAuthority.Type==null?"":mainAuthority.Type,ParameterDirection.Input),
                    new OracleParameter(":角色ID",OracleDbType.Varchar2, mainAuthority.RoleID==null?"":mainAuthority.RoleID,ParameterDirection.Input),
                    new OracleParameter(":权限类型",OracleDbType.Varchar2, mainAuthority.AuthorityType==null?"":mainAuthority.AuthorityType,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, mainAuthority.LastModify==null?"":mainAuthority.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":关联资源ID",OracleDbType.Varchar2, mainAuthority.RID==null?"":mainAuthority.RID,ParameterDirection.Input),
                    new OracleParameter(":关联资源明细ID",OracleDbType.Varchar2, mainAuthority.DID==null?"":mainAuthority.DID,ParameterDirection.Input)
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据AID修改主体权限
        /// </summary>
        /// <param name="MainAuthority">主体权限对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutMainAuthorityByAID(MainAuthority mainAuthority, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 主体权限
                            set 主体名称=:主体名称,
                                类型= :类型,
                                角色ID=:角色ID,
                                权限类型=:权限类型,
                                最后修改人=:最后修改人,
                                最后修改时间=:最后修改时间
                            where 主体权限ID=:主体权限ID";
            OracleParameter[] oracleParameters =
            {

                    new OracleParameter(":主体名称",OracleDbType.Varchar2,mainAuthority.MainName==null?"":mainAuthority.MainName,ParameterDirection.Input),
                    new OracleParameter(":类型",OracleDbType.Varchar2,mainAuthority.Type,ParameterDirection.Input),
                    new OracleParameter(":角色ID",OracleDbType.Varchar2,mainAuthority.RoleID,ParameterDirection.Input),
                    new OracleParameter(":权限类型",OracleDbType.Varchar2, mainAuthority.AuthorityType==null?"":mainAuthority.AuthorityType,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, mainAuthority.LastModify==null?"":mainAuthority.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":主体权限ID",OracleDbType.Varchar2,mainAuthority.AID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据AID删除主体权限
        /// </summary>
        /// <param name="AID">主体权限ID</param>
        public void DeleteMainAuthorityByAID(string AID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 主体权限 where 主体权限ID=:AID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":AID",OracleDbType.Varchar2,AID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据角色ID获取主体权限
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<MainAuthority> GetAllMainAuthoritiesByRID(string RID)
        {
            string sql = @"select a.主体权限id AID ,
                                    a.角色id RoleID ,         
                                    a.主体id MID ,
                                    a.主体名称 MainName ,
                                    a.类型 Type ,
                                    a.权限类型 AuthorityType ,
                                    a.关联资源ID RID ,
                                    a.关联资源明细ID DID ,
                                    a.最后修改人 LastModify ,
                                    a.最后修改时间 LastDate 
                                    from 主体权限 a
                                    where a.角色ID = :RID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":RID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<MainAuthority> mainAuthorities = ModelConvert.DataTableToIList<MainAuthority>(dataTable).ToList();
            return mainAuthorities;
        }

        /// <summary>
        /// 角色权限管理页面新增主体权限
        /// </summary>
        /// <param name="mainAuthority">主体权限实体类</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="uid">主体权限ID</param>
        public void CreateMainAuthorities(MainAuthority mainAuthority, DateTime dt, string uid)
        {
            string sql = "p_主体权限_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("主体权限id_In",OracleDbType.Varchar2,uid,ParameterDirection.Input),
                new OracleParameter("角色id_In",OracleDbType.Varchar2,mainAuthority.RoleID,ParameterDirection.Input),
                new OracleParameter("主体id_In",OracleDbType.Varchar2,mainAuthority.MID,ParameterDirection.Input),
                new OracleParameter("主体名称_In",OracleDbType.Varchar2,mainAuthority.MainName,ParameterDirection.Input),
                new OracleParameter("权限类型_In",OracleDbType.Varchar2,mainAuthority.AuthorityType,ParameterDirection.Input),
                new OracleParameter("最后修改人_In",OracleDbType.Varchar2,mainAuthority.LastModify,ParameterDirection.Input),
                new OracleParameter("最后修改时间_In",OracleDbType.Varchar2,dt,ParameterDirection.Input)
            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
        }

    }
}
