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

        /// <summary>
        /// 根据资源ID获取资源目录
        /// </summary>
        /// <param name="RID">资源ID</param>
        /// <returns></returns>
        public List<Resource> GetResourceByID(string RID)
        {
            string sql = @"select   上级资源ID PID,
                                    资源名称 Name,
                                    类型 Type,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    显示名称 ShowName,
                                    是否树形 TreeForm,
                                    关系资源ID RelationID from 资源目录 where 资源ID=:RID order by 资源名称";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":RID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<Resource> resources = ModelConvert.DataTableToIList<Resource>(dataTable).ToList();
            return resources;
        }

        /// <summary>
        /// 新增资源目录
        /// </summary>
        /// <param name="resource">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateResource(Resource resource, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 资源目录( 资源ID,
                                                 上级资源ID,
                                                 资源名称,
                                                 类型,
                                                 备注,
                                                 最后修改人,
                                                 最后修改时间,
                                                 显示名称,
                                                 是否树形,
                                                关系资源ID) 
                                        values(:资源ID,:上级资源ID,:资源名称,:类型,:备注,:最后修改人,:最后修改时间,:显示名称,:是否树形,:关系资源ID)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":资源ID",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":上级资源ID",OracleDbType.Varchar2,resource.PID==null?"":resource.PID,ParameterDirection.Input),
                    new OracleParameter(":资源名称",OracleDbType.Varchar2,resource.Name,ParameterDirection.Input),
                    new OracleParameter(":类型",OracleDbType.Varchar2,resource.Type,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2, resource.Note==null?"":resource.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, resource.LastModify==null?"":resource.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":显示名称",OracleDbType.Varchar2,resource.ShowName,ParameterDirection.Input),
                    new OracleParameter(":是否树形",OracleDbType.Long,resource.TreeForm,ParameterDirection.Input),
                    new OracleParameter(":关系资源ID",OracleDbType.Varchar2,resource.RelationID==null?"":resource.RelationID,ParameterDirection.Input),
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID修改资源目录
        /// </summary>
        /// <param name="resource">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutResourceByID(Resource resource, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 资源目录  set  上级资源ID=:上级资源ID,
                                                 资源名称=:资源名称,
                                                 类型=:类型,
                                                 备注=:备注,
                                                 最后修改人=:最后修改人,
                                                 最后修改时间=:最后修改时间,
                                                 显示名称=:显示名称,
                                                 是否树形=:是否树形,
                                                 关系资源ID=:关系资源ID 
                                             where 资源ID=:资源ID";
            OracleParameter[] oracleParameters =
            {
                    
                    new OracleParameter(":上级资源ID",OracleDbType.Varchar2,resource.PID==null?"":resource.PID,ParameterDirection.Input),
                    new OracleParameter(":资源名称",OracleDbType.Varchar2,resource.Name,ParameterDirection.Input),
                    new OracleParameter(":类型",OracleDbType.Varchar2,resource.Type,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2, resource.Note==null?"":resource.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, resource.LastModify==null?"":resource.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":显示名称",OracleDbType.Varchar2,resource.ShowName,ParameterDirection.Input),
                    new OracleParameter(":是否树形",OracleDbType.Long,resource.TreeForm,ParameterDirection.Input),
                    new OracleParameter(":关系资源ID",OracleDbType.Varchar2,resource.RelationID==null?"":resource.RelationID,ParameterDirection.Input),
                    new OracleParameter(":资源ID",OracleDbType.Varchar2,resource.ID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID删除资源目录
        /// </summary>
        /// <param name="ID">资源ID</param>
        public void DeleteResourceByID(string ResourceID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 资源目录 where 资源ID=:资源ID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":资源ID",OracleDbType.Varchar2,ResourceID,ParameterDirection.Input),
                    
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

    }
}

