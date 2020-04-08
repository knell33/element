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
        public List<CountNorm> GetAll(string RID)
        {
            string sql = @"select   指标定义ID ID,
                                    指标名称 Name,
                                    计算类型 CalculateType,
                                    运算符 Operator,
                                    运算值 Ovalue,
                                    关联类型 AssociationType,
                                    关联ID GLID,
                                    备注 Note,
                                    最后修改人 LastModify,
                                    最后修改时间 LastDate,
                                    资源ID RID from 统计指标定义 where 资源ID = :RID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":RID",OracleDbType.Varchar2,RID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<CountNorm> countNorms = ModelConvert.DataTableToIList<CountNorm>(dataTable).ToList();
            return countNorms;
        }
    }
}
