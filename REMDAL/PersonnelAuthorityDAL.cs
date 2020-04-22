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
    public class PersonnelAuthorityDAL
    {
        /// <summary>
        /// 根据用户ID获取人员权限
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        public List<PersonnelAuthority> GetAllPersonnelAuthorityByUID(string UserID)
        {
            string sql = @"select a.人员权限id PAID,
                                   a.主体权限id MAID,
                                   a.主体id MID,
                                   a.主体名称 MName,
                                   a.类型 Type,
                                   a.用户id UserID,
                                   a.权限类型 AuthorityType,
                                   a.最后修改人 LastModify,
                                   a.最后修改时间 LastDate
                                   from 人员权限 a
                                   where a.用户id = :UserID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":UserID",OracleDbType.Varchar2,UserID,ParameterDirection.Input)
            };
            DataTable dataTable = oracleDataAccess.ExecuteDataTable(sql, System.Data.CommandType.Text, oracleParameters);
            List<PersonnelAuthority> personnelAuthorities = ModelConvert.DataTableToIList<PersonnelAuthority>(dataTable).ToList();
            return personnelAuthorities;
        }

        /// <summary>
        /// 根据主体权限ID同步人员权限
        /// </summary>
        /// <param name="MAID">主体权限ID</param>
        public void CreatePersonnelAuthority(string MAID)
        {
            string sql = "p_人员权限同步_core";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter("主体权限id_In",OracleDbType.Varchar2,MAID,ParameterDirection.Input) 
            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
        }

        /// <summary>
        /// 删除角色权限同步人员权限
        /// </summary>
        /// <param name="MAID">主体权限ID</param>
        public void DeletePerPersonnelAuthority(string MAID)
        {
            string sql = "delete from 人员权限 where 主体权限ID = :MAID";
            OracleDataAccess oracleDataAccess = new OracleDataAccess(SiteConfig.OracleConn);
            OracleParameter[] oracleParameters =
            {
                new OracleParameter(":MAID",OracleDbType.Varchar2,MAID,ParameterDirection.Input)
            };
            oracleDataAccess.ExecuteProcdure(sql, oracleParameters);
        }
    }
}
