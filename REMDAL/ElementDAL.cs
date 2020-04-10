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
        public List<Element> GetAllElementByRID(string RID)
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

        /// <summary>
        /// 获取 要素目录/资源目录/资源分类/统计指标定义/计算要素条件/通用编码目录/要素值域 联合查询
        /// </summary>
        /// <param name="RID"></param>
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
        /// 新增要素目录
        /// </summary>
        /// <param name="element">要素目录对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateElement(Element element, DateTime dt, string nid)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"insert into 要素目录( 要素id,
                                                资源id,
                                                要素名称,
                                                要素类型,
                                                单位,
                                                备注,
                                                最后修改人,
                                                最后修改时间,
                                                长度,
                                                精度,
                                                默认值,
                                                分类id,
                                                是否必填,
                                                选项类型,
                                                序号,
                                                值域资源id,
                                                是否展示主目录,
                                                名称是否展示,
                                                编码目录id,
                                                要素分类) 
                                        values(:要素id,:资源id,:要素名称,:要素类型,:单位,:备注,:最后修改人,:最后修改时间,:长度,:精度,:默认值,:分类id,:是否必填,:选项类型,:序号,:值域资源id,:是否展示主目录,:名称是否展示,:编码目录id,:要素分类)";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":要素id",OracleDbType.Varchar2,nid,ParameterDirection.Input),
                    new OracleParameter(":资源id",OracleDbType.Varchar2,element.RID==null?"":element.RID,ParameterDirection.Input),
                    new OracleParameter(":要素名称",OracleDbType.Varchar2,element.Name,ParameterDirection.Input),
                    new OracleParameter(":要素类型",OracleDbType.Varchar2,element.Type,ParameterDirection.Input),
                    new OracleParameter(":单位",OracleDbType.Varchar2, element.Unit==null?"":element.Unit,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2, element.Note==null?"":element.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2,element.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":长度",OracleDbType.Decimal,element.Length,ParameterDirection.Input),
                    new OracleParameter(":精度",OracleDbType.Decimal,element.Precision,ParameterDirection.Input),
                    new OracleParameter(":默认值",OracleDbType.Varchar2,element.Defaulta,ParameterDirection.Input),
                    new OracleParameter(":分类id",OracleDbType.Varchar2,element.CID==null?"":element.CID,ParameterDirection.Input),
                    new OracleParameter(":是否必填",OracleDbType.Decimal,element.IFRequired,ParameterDirection.Input),
                    new OracleParameter(":选项类型",OracleDbType.Varchar2,element.OptionType,ParameterDirection.Input),
                    new OracleParameter(":序号",OracleDbType.Varchar2, element.Numbera==null?"":element.Numbera,ParameterDirection.Input),
                    new OracleParameter(":值域资源id",OracleDbType.Varchar2,element.DRID==null?"":element.DRID,ParameterDirection.Input),
                    new OracleParameter(":是否展示主目录",OracleDbType.Decimal,element.IFZSZML,ParameterDirection.Input),
                    new OracleParameter(":名称是否展示",OracleDbType.Decimal,element.IFZSMC,ParameterDirection.Input),
                    new OracleParameter(":编码目录id",OracleDbType.Varchar2,element.CDID,ParameterDirection.Input),
                    new OracleParameter(":要素分类",OracleDbType.Varchar2,element.ElementClassify==null?"":element.ElementClassify,ParameterDirection.Input),
             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID修改要素目录
        /// </summary>
        /// <param name="element">要素目录对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutElementByID(Element element, DateTime dt)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"update 要素目录  set  资源id=:资源id,
                                                 要素名称=:要素名称,
                                                 要素类型=:要素类型,
                                                 单位=:单位,
                                                 备注=:备注,
                                                 最后修改人=:最后修改人,
                                                 最后修改时间=:最后修改时间,
                                                 长度=:长度,
                                                 精度=:精度,
                                                 默认值=:默认值,
                                                 分类id=:分类id,
                                                 是否必填=:是否必填,
                                                 选项类型=:选项类型,
                                                 序号=:序号,
                                                 值域资源id=:值域资源id,
                                                 是否展示主目录=:是否展示主目录,
                                                 名称是否展示=:名称是否展示,
                                                 编码目录id=:编码目录id,
                                                 要素分类=:要素分类
                                             where 要素id=:要素id";
            OracleParameter[] oracleParameters =
            {

                    new OracleParameter(":资源id",OracleDbType.Varchar2,element.RID==null?"":element.RID,ParameterDirection.Input),
                    new OracleParameter(":要素名称",OracleDbType.Varchar2,element.Name,ParameterDirection.Input),
                    new OracleParameter(":要素类型",OracleDbType.Varchar2,element.Type,ParameterDirection.Input),
                    new OracleParameter(":单位",OracleDbType.Varchar2, element.Unit==null?"":element.Unit,ParameterDirection.Input),
                    new OracleParameter(":备注",OracleDbType.Varchar2, element.Note==null?"":element.Note,ParameterDirection.Input),
                    new OracleParameter(":最后修改人",OracleDbType.Varchar2,element.LastModify,ParameterDirection.Input),
                    new OracleParameter(":最后修改时间",OracleDbType.Date,dt,ParameterDirection.Input),
                    new OracleParameter(":长度",OracleDbType.Decimal,element.Length,ParameterDirection.Input),
                    new OracleParameter(":精度",OracleDbType.Decimal,element.Precision,ParameterDirection.Input),
                    new OracleParameter(":默认值",OracleDbType.Varchar2,element.Defaulta,ParameterDirection.Input),
                    new OracleParameter(":分类id",OracleDbType.Varchar2,element.CID==null?"":element.CID,ParameterDirection.Input),
                    new OracleParameter(":是否必填",OracleDbType.Decimal,element.IFRequired,ParameterDirection.Input),
                    new OracleParameter(":选项类型",OracleDbType.Varchar2,element.OptionType,ParameterDirection.Input),
                    new OracleParameter(":序号",OracleDbType.Varchar2, element.Numbera==null?"":element.Numbera,ParameterDirection.Input),
                    new OracleParameter(":值域资源id",OracleDbType.Varchar2,element.DRID==null?"":element.DRID,ParameterDirection.Input),
                    new OracleParameter(":是否展示主目录",OracleDbType.Decimal,element.IFZSZML,ParameterDirection.Input),
                    new OracleParameter(":名称是否展示",OracleDbType.Decimal,element.IFZSMC,ParameterDirection.Input),
                    new OracleParameter(":编码目录id",OracleDbType.Varchar2,element.CDID,ParameterDirection.Input),
                    new OracleParameter(":要素分类",OracleDbType.Varchar2,element.ElementClassify==null?"":element.ElementClassify,ParameterDirection.Input),
                    new OracleParameter(":要素id",OracleDbType.Varchar2,element.EID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }

        /// <summary>
        /// 根据ID删除要素目录
        /// </summary>
        /// <param name="EID">要素ID</param>
        public void DeleteElementByID(string EID)
        {
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            string sql = @"delete from 要素目录 where 要素id=:要素id";
            OracleParameter[] oracleParameters =
            {
                    new OracleParameter(":要素id",OracleDbType.Varchar2,EID,ParameterDirection.Input),

             };
            oracleDataAccess.ExecuteNonQuery(sql, System.Data.CommandType.Text, oracleParameters);
        }
    }
}
