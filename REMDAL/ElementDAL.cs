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
    public class ElementDAL
    {
        /// <summary>
        /// 获取 要素目录/资源目录/资源分类/统计指标定义/计算要素条件 联合查询
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Element> GetAllByResourceID(string RID)
        {
            string sql = @"select   a.要素id EID,
                                    a.资源id RID,
                                    a.要素名称 Name,
                                    a.要素类型 Type,
                                    a.单位 Unit,
                                    a.备注 Note,
                                    a.最后修改人 LastModify,
                                    a.最后修改时间 LastDate,
                                    a.长度 Length,
                                    a.精度 Precision,
                                    a.默认值 Defaulta,
                                    a.选项类型 OptionType,
                                    a.序号 Numbera,
                                    a.要素分类 ElementClassify,
                                    b.资源名称 ResourceName,                                
                                    c.分类名称 ClassifyName,                                                       
                                    count(d.指标定义id) DYZBGS,
                                    e.表达式文本 Text FROM 要素目录 a,资源目录 b,资源分类 c,统计指标定义 d,计算要素条件 e 
                                    where a.资源id= '{0}' and a.资源id=b.资源id(+)
                                    and a.分类id=c.资源分类id(+)
                                    and a.要素id=d.关联id(+) 
                                    and a.要素id=e.要素id(+) 
                                    group by a.要素id,
                                            a.资源id,
                                            b.资源名称,
                                            c.分类名称,
                                            a.要素名称,
                                            a.要素类型,
                                            a.单位,
                                            a.备注,
                                            a.最后修改人,
                                            a.最后修改时间,
                                            a.长度,
                                            a.精度,
                                            a.选项类型,
                                            a.序号,
                                            e.表达式文本,
                                            a.要素分类,
                                            a.默认值";
            sql = string.Format(sql, RID);
            //数据库连接
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);

            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Element> elements = ModelConvert.DataTableToIList<Element>(dataTable).ToList();
            return elements;
        }
    }
}
