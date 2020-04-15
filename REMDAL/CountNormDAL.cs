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
    public class CountNormDAL
    {
        /// <summary>
        /// 根据资源ID获取统计指标定义
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<CountNorm> GetAllCountNormByRID(string RID)
        {
            string sql = @"select   指标定义ID ID,
                                    指标名称 NormName,
                                    计算类型 CalculateType,
                                    运算符 Operator,
                                    运算值 Ovalue,
                                    关联类型 AssociationType,
                                    关联ID GLID,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    资源ID RID from 统计指标定义 where 资源ID = :资源ID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":资源ID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<CountNorm> countNorms = ModelConvert.DataTableToIList<CountNorm>(dataTable).ToList();
            return countNorms;
        }

        /// <summary>
        /// 根据指标定义ID获取统计指标定义
        /// </summary>
        /// <param name="指标定义ID"></param>
        /// <returns></returns>
        public List<CountNorm> GetAllCountNormByID(string ID)
        {
            string sql = @"select   指标定义ID ID,
                                    指标名称 NormName,
                                    计算类型 CalculateType,
                                    运算符 Operator,
                                    运算值 Ovalue,
                                    关联类型 AssociationType,
                                    关联ID GLID,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    资源ID RID from 统计指标定义 where 指标定义ID = :指标定义ID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":指标定义ID",OracleDbType.Varchar2,ID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<CountNorm> countNorms = ModelConvert.DataTableToIList<CountNorm>(dataTable).ToList();
            return countNorms;
        }

        /// <summary>
        /// 新增资源目录
        /// </summary>
        /// <param name="CountNorm">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateCountNorm(CountNorm countNorm, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 统计指标定义( 指标定义id, 指标名称, 计算类型, 运算符, 运算值, 关联类型, 关联id, 备注, 最后修改人, 最后修改时间, 资源id) 
                                        values(:指标定义id, :指标名称, :计算类型, :运算符, :运算值, :关联类型, :关联id, :备注, :最后修改人, ：最后修改时间, ：资源id)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":指标定义id",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":指标名称",OracleDbType.Varchar2,countNorm.NormName,ParameterDirection.Input),
                    new OracleParameter(":计算类型",OracleDbType.Varchar2,countNorm.CalculateType,ParameterDirection.Input),
                    new OracleParameter(":运算符",OracleDbType.Varchar2,countNorm.Operator,ParameterDirection.Input),
                    new OracleParameter(":运算值",OracleDbType.Varchar2, countNorm.Ovalue,ParameterDirection.Input),
                    new OracleParameter(":关联类型",OracleDbType.Varchar2, countNorm.AssociationType==null?"":countNorm.AssociationType,ParameterDirection.Input),
                    new OracleParameter(":关联id",OracleDbType.Varchar2,countNorm.GLID==null?"":countNorm.GLID,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2,countNorm.Note==null?"":countNorm.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2,countNorm.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":资源id",OracleDbType.Varchar2,countNorm.RID==null?"":countNorm.RID,ParameterDirection.Input),
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID修改统计指标
        /// </summary>
        /// <param name="CountNorm">统计指标对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutCountNormByID(CountNorm countNorm, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 统计指标定义  
                                set 指标名称 = :指标名称, 
                                    计算类型 = :计算类型, 
                                    运算符 = :运算符, 
                                    运算值 = :运算值, 
                                    关联类型 = :关联类型, 
                                    关联ID = :关联ID, 
                                    备注 = :备注, 
                                    最后修改人 = :最后修改人,
                                    最后修改时间 = :最后修改时间, 
                                    资源ID = :资源ID 
                                where 指标定义ID=:指标定义ID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":指标名称",OracleDbType.Varchar2,countNorm.NormName==null?"":countNorm.NormName,ParameterDirection.Input),
                    new OracleParameter(":计算类型",OracleDbType.Varchar2,countNorm.CalculateType==null?"":countNorm.CalculateType,ParameterDirection.Input),
                    new OracleParameter(":运算符",OracleDbType.Varchar2,countNorm.Operator==null?"":countNorm.Operator,ParameterDirection.Input),
                    new OracleParameter(":运算值",OracleDbType.Varchar2, countNorm.Ovalue==null?"":countNorm.Ovalue,ParameterDirection.Input),
                    new OracleParameter(":关联类型",OracleDbType.Varchar2, countNorm.AssociationType==null?"":countNorm.AssociationType,ParameterDirection.Input),
                    new OracleParameter(":关联ID",OracleDbType.Varchar2, countNorm.GLID==null?"":countNorm.GLID,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2, countNorm.Note==null?"":countNorm.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2, countNorm.LastModify==null?"":countNorm.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":资源ID",OracleDbType.Varchar2,countNorm.RID==null?"":countNorm.RID,ParameterDirection.Input),
                    new OracleParameter(":指标定义ID",OracleDbType.Varchar2,countNorm.ID==null?"":countNorm.ID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID删除统计指标
        /// </summary>
        /// <param name="countNormID">指标定义ID</param>
        public void DeleteCountNormByID(string countNormID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 统计指标定义 where 指标定义ID=:指标定义ID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":指标定义ID",OracleDbType.Varchar2,countNormID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }


    }
}
