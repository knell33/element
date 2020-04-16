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
    public class DetailDAL
    {
        /// <summary>
        /// 根据资源ID获取资源明细数据
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Detail> GetAllDetailByResourceID(string RID)
        {
            string sql = @"select a.资源明细id DID ,
                                    a.明细名称 DetailName ,
                                    a.资源id RID ,
                                    a.明细要素信息 DetailInfo ,
                                    a.备注 Note ,
                                    a.最后修改人 LastModify ,
                                    a.最后修改时间 LastDate ,
                                    a.明细关系id DetailRelationID ,
                                    a.上级资源id PID ,
                                    a.上级资源明细id PDID ,
                                    a.上级明细名称 PDetailName ,
                                    a.事务时间 TransactionDate 
                         from(select a.资源明细id, 
                                    a.明细名称, 
                                    a.资源id, 
                                    a.明细要素信息, 
                                    a.备注, 
                                    a.最后修改人, 
                                    a.最后修改时间, 
                                    b.明细关系id,                              
                                    b.上级资源id, 
                                    b.上级资源明细id, 
                                    c.明细名称 上级明细名称, 
                                    a.事务时间
                               from 资源明细 a, 资源明细关系 b, 资源明细 c
                               where a.资源明细id = b.资源明细id(+)
                                    and b.上级资源明细id = c.资源明细id(+)
                                    and a.资源id = '{0}') a";
            sql = string.Format(sql, RID);
            //数据库连接
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);

            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Detail> Details = ModelConvert.DataTableToIList<Detail>(dataTable).ToList();
            return Details;
        }

    }
}
