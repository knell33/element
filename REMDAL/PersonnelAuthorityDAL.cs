﻿using Oracle.ManagedDataAccess.Client;
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
    }
}