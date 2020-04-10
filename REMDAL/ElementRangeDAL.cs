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
    public class ElementRangeDAL
    {
        /// <summary>
        /// 根据要素ID获取文本值域选项
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public List<ElementRange> GetAllElementRangeByEID(string EID)
        {
            string sql = @"select   选项值域ID ID,
                                    选项名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    要素ID EID from 文本选项值域 where 要素ID = :要素ID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameter =
            {
                new OracleParameter(":要素ID",OracleDbType.Varchar2,EID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, CommandType.Text, oracleParameter);
            List<ElementRange> list = ModelConvert.DataTableToIList<ElementRange>(dataTable).ToList();
            return list;
        }

        /// <summary>
        /// 根据选项值域ID获取文本值域选项
        /// </summary>
        /// <param name="ID">选项值域ID</param>
        /// <returns></returns>
        public List<ElementRange> GetAllElementRangeByID(string ID)
        {
            string sql = @"select   选项值域ID ID,
                                    选项名称 Name,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    要素ID EID from 文本选项值域 where 选项值域ID = :选项值域ID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameter =
            {
                new OracleParameter(":选项值域ID",OracleDbType.Varchar2,ID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, CommandType.Text, oracleParameter);
            List<ElementRange> list = ModelConvert.DataTableToIList<ElementRange>(dataTable).ToList();
            return list;
        }

        /// <summary>
        /// 新增文本值域选项
        /// </summary>
        /// <param name="elementRange">ElementRange对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateElementRange(ElementRange elementRange, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 文本选项值域( 选项值域ID,
                                                     选项名称,
                                                     备注,
                                                     最后修改人,
                                                     最后修改时间,
                                                     要素ID
                                                ) 
                                        values(:选项值域ID,:选项名称,:备注,:最后修改人,:最后修改时间,:要素ID)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":选项值域ID",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":选项名称",OracleDbType.Varchar2,elementRange.Name==null?"":elementRange.Name,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2,elementRange.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2,elementRange.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date, dt,ParameterDirection.Input),
                    new OracleParameter(":要素ID",OracleDbType.Varchar2,elementRange.EID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID修改文本值域选项
        /// </summary>
        /// <param name="elementRange">ElementClassify对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutElementRangeByID(ElementRange elementRange, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 文本选项值域  set  选项名称=:选项名称,
                                                 备注=:备注,
                                                 最后修改人=:最后修改人,
                                                 最后修改时间=:最后修改时间,
                                                 要素ID=:要素ID
                                             where 选项值域ID=:选项值域ID";
            OracleParameter[] oracleParameters =
            {

                    
                    new OracleParameter(":选项名称",OracleDbType.Varchar2,elementRange.Name==null?"":elementRange.Name,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2,elementRange.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2,elementRange.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date, dt,ParameterDirection.Input),
                    new OracleParameter(":要素ID",OracleDbType.Varchar2,elementRange.EID,ParameterDirection.Input),
                    new OracleParameter(":选项值域ID",OracleDbType.Varchar2,elementRange.ID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID删除文本值域选项
        /// </summary>
        /// <param name="ID">选项值域ID</param>
        public void DeleteElementRangeByID(string ID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 文本选项值域 where 选项值域ID=:选项值域ID";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":选项值域ID",OracleDbType.Varchar2,ID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }




    }
}
