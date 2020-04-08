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
        public List<ElementClassify> GetAllByResourceID(string RID)
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
    }
}
