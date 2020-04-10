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
    public class ElementClassifyDAL
    {
        /// <summary>
        /// 根据资源ID获取要素分类
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<ElementClassify> GetElementClassifyByRID(string RID)
        {
            string sql = @"select   资源分类ID ID,
                                    资源ID RID,
                                    分类名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate from 资源分类 where 资源ID = :RID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":RID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, CommandType.Text, oracleParameters);
            List<ElementClassify> elementClassifies = ModelConvert.DataTableToIList<ElementClassify>(dataTable).ToList();
            return elementClassifies;
        }


        /// <summary>
        /// 根据资源分类ID获取要素分类
        /// </summary>
        /// <param name="ClassifyID">资源分类ID</param>
        /// <returns></returns>
        public List<ElementClassify> GetElementClassifyByID(string CID)
        {
            string sql = @"select   资源分类ID ID,
                                    资源ID RID,
                                    分类名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate from 资源分类 where 资源分类ID = :ID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":ID",OracleDbType.Varchar2,CID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<ElementClassify> elementClassifies  = ModelConvert.DataTableToIList<ElementClassify>(dataTable).ToList();
            return elementClassifies;
        }

        /// <summary>
        /// 新增要素分类
        /// </summary>
        /// <param name="elementClassify">ElementClassify对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateElementClassify(ElementClassify elementClassify, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 资源分类( 资源分类ID,
                                                 资源ID,
                                                 分类名称,
                                                 备注,
                                                 最后修改人,
                                                 最后修改时间
                                                ) 
                                        values(:资源分类ID,:资源ID,:分类名称,:备注,:最后修改人,:最后修改时间)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":资源分类ID",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":资源ID",OracleDbType.Varchar2,elementClassify.RID==null?"":elementClassify.RID,ParameterDirection.Input),
                    new OracleParameter(":分类名称",OracleDbType.Varchar2,elementClassify.Name,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2,elementClassify.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, elementClassify.LastModify==null?"":elementClassify.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID修改要素分类
        /// </summary>
        /// <param name="resource">ElementClassify对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutElementClassifyByID(ElementClassify elementClassify, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 资源分类  set  资源ID=:资源ID,
                                                 分类名称=:分类名称,
                                                 备注=:备注,
                                                 最后修改人=:最后修改人,
                                                 最后修改时间=:最后修改时间
                                             where 资源分类ID=:资源分类ID";
            OracleParameter[] oracleParameters =
            {

                    new OracleParameter(":资源ID",OracleDbType.Varchar2,elementClassify.RID==null?"":elementClassify.RID,ParameterDirection.Input),
                    new OracleParameter(":分类名称",OracleDbType.Varchar2,elementClassify.Name,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2,elementClassify.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, elementClassify.LastModify==null?"":elementClassify.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":资源分类ID",OracleDbType.Varchar2,elementClassify.ID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID删除要素分类
        /// </summary>
        /// <param name="ClassifyID">资源分类ID</param>
        public void DeleteElementClassifyByID(string CID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 资源分类 where 资源分类ID=:资源分类ID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":资源分类ID",OracleDbType.Varchar2,CID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }
    }
}
