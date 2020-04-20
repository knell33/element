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
        public List<Element> GetAllElementByResourceID(string RID)
        {
            string sql = @"select   a.要素id EID,
                                    a.资源id RID,
                                    a.要素名称 Name,
                                    a.要素类型 Type,
                                    a.单位 Unit,
                                    a.备注 Note,
                                    a.最后修改人 LastModify,
                                    a.最后修改时间 LastDate,
                                    a.默认值 Defaulta,
                                    a.选项类型 OptionType,
                                    a.序号 Numbera,
                                    a.长度 Length,
                                    a.精度 Precision,
                                    a.是否必填 IFRequired，
                                    a.是否展示主目录 IFZSZML,
                                    a.名称是否展示 IFZSMC,
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
                                    a.要素名称,
                                    a.要素类型,
                                    a.单位,
                                    a.备注,
                                    a.最后修改人,
                                    a.最后修改时间,
                                    a.默认值,
                                    a.选项类型,
                                    a.序号,
                                    a.长度,
                                    a.精度,
                                    a.是否必填，
                                    a.是否展示主目录,
                                    a.名称是否展示,
                                    a.要素分类,
                                    b.资源名称,                                
                                    c.分类名称,                                                       
                                    e.表达式文本";
            sql = string.Format(sql, RID);
            //数据库连接
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);

            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Element> elements = ModelConvert.DataTableToIList<Element>(dataTable).ToList();
            return elements;
        }

        /// <summary>
        /// 获取 根据要素ID获取要素信息
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public List<Element> GetAllElementByEID(string EID)
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
                                    a.分类id CID,
                                    a.是否必填 IFRequired,
                                    a.选项类型 OptionType,
                                    a.序号 Numbera,
                                    a.值域资源id DRID,
                                    a.是否展示主目录 IFZSZML,
                                    a.名称是否展示 IFZSMC,
                                    a.编码目录id  CDID,
                                    a.要素分类 ElementClassify,
                                    b.资源名称 ResourceName,                                
                                    c.分类名称 ClassifyName,                                                       
                                    count(d.指标定义id) DYZBGS,
                                    e.表达式文本 Text FROM 要素目录 a,资源目录 b,资源分类 c,统计指标定义 d,计算要素条件 e,通用编码目录 f,要素值域 g
                                    where a.要素id= '{0}' and a.资源id=b.资源id(+)
                                    and a.分类id=c.资源分类id(+)
                                    and a.要素id=d.关联id(+) 
                                    and a.要素id=e.要素id(+)
                                    and a.编码目录id=f.目录id(+)
                                    and a.值域资源id=g.值域id(+)
                                    group by a.要素id,
                                            a.资源id,
                                            a.分类id,
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
                                            a.是否必填,
                                            a.选项类型,
                                            a.序号,
                                            a.值域资源id,
                                            a.是否展示主目录,
                                            a.名称是否展示,
                                            e.表达式文本,
                                            a.要素分类,
                                            a.编码目录id,
                                            a.默认值";
            sql = string.Format(sql, EID);
            //数据库连接
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);

            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, null);
            List<Element> elements = ModelConvert.DataTableToIList<Element>(dataTable).ToList();
            return elements;
        }


        /// <summary>
        /// 要素目录新增
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dt"></param>
        /// <param name="uid"></param>
        public void CreateElement(Element element, DateTime dt, string uid)
        {
            string sql = "p_要素目录新增_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("v_要素ID",OracleDbType.Varchar2,uid,ParameterDirection.Input),
                new OracleParameter("v_资源ID",OracleDbType.Varchar2,element.RID==null?"":element.RID,ParameterDirection.Input),
                new OracleParameter("v_要素名称",OracleDbType.Varchar2,element.Name,ParameterDirection.Input),
                new OracleParameter("v_要素类型",OracleDbType.Varchar2,element.Type,ParameterDirection.Input),
                new OracleParameter("v_单位",OracleDbType.Varchar2,element.Unit,ParameterDirection.Input),
                new OracleParameter("v_备注",OracleDbType.Varchar2,element.Note,ParameterDirection.Input),
                new OracleParameter("v_最后修改人",OracleDbType.Varchar2,element.LastModify,ParameterDirection.Input),
                new OracleParameter("v_最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                new OracleParameter("v_长度",OracleDbType.Long,element.Length,ParameterDirection.Input),
                new OracleParameter("v_精度",OracleDbType.Long,element.Precision,ParameterDirection.Input),
                new OracleParameter("v_默认值",OracleDbType.Varchar2,element.Defaulta,ParameterDirection.Input),
                new OracleParameter("v_分类ID",OracleDbType.Varchar2,element.CID,ParameterDirection.Input),
                new OracleParameter("v_是否必填",OracleDbType.Int32,element.IFRequired,ParameterDirection.Input),
                new OracleParameter("v_选项类型",OracleDbType.Varchar2,element.OptionType,ParameterDirection.Input),
                new OracleParameter("v_序号",OracleDbType.Varchar2,element.Numbera,ParameterDirection.Input),
                new OracleParameter("v_值域资源id",OracleDbType.Varchar2,element.DRID,ParameterDirection.Input),
                new OracleParameter("v_是否展示主目录",OracleDbType.Int32,element.IFZSZML,ParameterDirection.Input),
                new OracleParameter("v_名称是否展示",OracleDbType.Int32,element.IFZSMC,ParameterDirection.Input),
                new OracleParameter("v_编码目录id",OracleDbType.Varchar2,element.CDID,ParameterDirection.Input),
                new OracleParameter("v_要素分类",OracleDbType.Varchar2,element.ElementClassify==null?"":element.ElementClassify,ParameterDirection.Input),
                new OracleParameter("v_资源名称",OracleDbType.Varchar2,"-",ParameterDirection.Input),
                new OracleParameter("v_分类名称",OracleDbType.Varchar2,"-",ParameterDirection.Input),
                new OracleParameter("v_定义指标个数",OracleDbType.Int32,0,ParameterDirection.Input),
                new OracleParameter("v_资源名称",OracleDbType.Varchar2,"-",ParameterDirection.Input)
            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
        }

        /// <summary>
        /// 根据要素ID修改要素信息
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dt">最后修改时间</param>
        public void UpdateElementByEID(Element element,DateTime dt)
        {
            string sql = "p_要素目录修改_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("v_要素id",OracleDbType.Varchar2,element.EID,ParameterDirection.Input),
                new OracleParameter("v_资源id",OracleDbType.Varchar2,element.RID,ParameterDirection.Input),
                new OracleParameter("v_要素名称",OracleDbType.Varchar2,element.Name,ParameterDirection.Input),
                new OracleParameter("v_要素类型",OracleDbType.Varchar2,element.Type,ParameterDirection.Input),
                new OracleParameter("v_单位",OracleDbType.Varchar2,element.Unit,ParameterDirection.Input),
                new OracleParameter("v_备注",OracleDbType.Varchar2,element.Note,ParameterDirection.Input),
                new OracleParameter("v_最后修改人",OracleDbType.Varchar2,element.LastModify,ParameterDirection.Input),
                new OracleParameter("v_最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                new OracleParameter("v_长度",OracleDbType.Long,element.Length,ParameterDirection.Input),
                new OracleParameter("v_精度",OracleDbType.Long,element.Precision,ParameterDirection.Input),
                new OracleParameter("v_默认值",OracleDbType.Varchar2,element.Defaulta,ParameterDirection.Input),
                new OracleParameter("v_分类id",OracleDbType.Varchar2,element.CID,ParameterDirection.Input),
                new OracleParameter("v_是否必填",OracleDbType.Int32,element.IFRequired,ParameterDirection.Input),
                new OracleParameter("v_选项类型",OracleDbType.Varchar2,element.OptionType,ParameterDirection.Input),
                new OracleParameter("v_序号",OracleDbType.Varchar2,element.Numbera,ParameterDirection.Input),
                new OracleParameter("v_值域资源id",OracleDbType.Varchar2,element.DRID,ParameterDirection.Input),
                new OracleParameter("v_是否展示主目录",OracleDbType.Int32,element.IFZSZML,ParameterDirection.Input),
                new OracleParameter("v_名称是否展示",OracleDbType.Int32,element.IFZSMC,ParameterDirection.Input),
                new OracleParameter("v_编码目录id",OracleDbType.Varchar2,element.CDID,ParameterDirection.Input),
                new OracleParameter("v_要素分类",OracleDbType.Varchar2,element.ElementClassify==null?"":element.ElementClassify,ParameterDirection.Input)

            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
        }

        /// <summary>
        /// 根据要素ID删除要素信息
        /// </summary>
        /// <param name="EID">要素ID</param>
        public void DeleteElementByEID(string EID)
        {
            string sql = @"delete 要素目录 where 要素ID = :EID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":EID",OracleDbType.Varchar2,EID,ParameterDirection.Input)
            };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }
    }
}
