using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace REMDAL
{
    /// <summary>
    /// 数据访问基础类(基于Oracle)
    /// 可以用户可以修改满足自己项目的需要。
    /// </summary>
    public class OracleDataAccess
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.    
        private string connectionString;

        #region 数据库连接
        /// <summary>
        /// 数据库连接（仅传配置）
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="inf"></param>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public OracleDataAccess(string ip, string port, string inf, string name, string pwd)
        {
            connectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};;Pooling =true;Connection Lifetime=0;Max Pool Size=10;Min Pool Size=1;Incr Pool Size=1",
    ip, port, inf, name, pwd);

        }
    //    /// <summary>
    //    /// 数据库连接-连接对象
    //    /// </summary>
    //    /// <param name="connects">数据库连接配置JSON对象</param>
    //    /// <param name="connname">数据库连接的名称</param>
    //    public OracleDataAccess(List<DataConnect> connects, string connname)
    //    {
    //        DataConnect conn = connects.Where(o => o.name == connname).FirstOrDefault();
    //        connectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};;Pooling =true;Connection Lifetime=0;Max Pool Size=10;Min Pool Size=1;Incr Pool Size=1",
    //conn.HOST, conn.Port, conn.Service, conn.User, conn.Password);

    //    }




      

        /// <summary>
        /// 数据库连接-自动检查库（传入连接串）
        /// </summary>
        /// <param name="configString"></param>
        /// <param name="tableSchemas"></param>
        public OracleDataAccess(string configString, Dictionary<string, string> tableSchemas)
        {
            connectionString = configString;
            CheckDatabase(tableSchemas);
        }

        /// <summary>
        /// 数据库连接（传入连接串）
        /// </summary>
        /// <param name="configString"></param>
        public OracleDataAccess(string configString)
        {
            connectionString = configString;
        }

        internal DataTable ExecuteDataTable()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 数据库初始化

        /// <summary>
        /// 检查数据库（会创建尚不存在的表结构）
        /// </summary>
        public void CheckDatabase(Dictionary<string, string> tableSchemas)
        {
            if (tableSchemas == null || tableSchemas.Count == 0)
                return;

            foreach (KeyValuePair<string, string> var in tableSchemas)
            {
                if (!IsTableExist(var.Key))
                {
                    ExecuteNonQuery(var.Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsTableExist(string tableName)
        {
            object objVal = ExecuteScalar("SELECT 1 FROM USER_TABLES WHERE TABLE_NAME=:p1", tableName);
            if (objVal == null)
                return false;
            else
                return true;
        }

        #endregion

        #region 执行数据库操作

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public OracleConnection GetConnection()
        {
            OracleConnection conn = new OracleConnection(connectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();
            return conn;

        }


        /// <summary>
        /// Reader方式获取数据，使用完后务必关闭Reader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public OracleDataReader ExcuteDataReader(string sql, CommandType commandType, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.CommandType = commandType;
                OracleParameter[] cmdParms = ConvertParameter(sqlParams);
                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// Reader方式获取数据，使用完后务必关闭Reader
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public OracleDataReader ExcuteDataReader(string sql, CommandType commandType, bool isParameterByName, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.CommandType = commandType;
                cmd.BindByName = isParameterByName;
                OracleParameter[] cmdParms = ConvertParameter(sqlParams);
                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }


        /// <summary>
        /// DataTable方式获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.CommandType = commandType;//cmdType;

                OracleParameter[] cmdParms = (OracleParameter[])sqlParams;
                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    //da.Fill(ds, "ds");
                    cmd.Parameters.Clear();

                    return dt;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally

            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// DataTable方式获取数据
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, bool isParameterByName, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.CommandType = commandType;//cmdType;
                cmd.BindByName = isParameterByName;
                OracleParameter[] cmdParms = (OracleParameter[])sqlParams;
                if (cmdParms != null)
                {
                    foreach (OracleParameter parm in cmdParms)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    //da.Fill(ds, "ds");
                    cmd.Parameters.Clear();

                    return dt;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally

            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，不需要返回值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        public void ExecuteNonQuery(string sql, CommandType commandType, params OracleParameter[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, connection, sql, commandType, sqlParams);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，不需要返回值
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        public void ExecuteNonQuery(string sql, CommandType commandType, bool isParameterByName, params OracleParameter[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = isParameterByName;
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, connection, sql, commandType, sqlParams);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行存储过程或者函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteProcdure(string sql, params OracleParameter[] parameters)
        {
            OracleConnection conn = GetConnection();
            IList<OracleParameter> oracleParameters = new List<OracleParameter>();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    oracleParameters = PrepareCommand(cmd, conn, sql, CommandType.StoredProcedure, parameters);
                    cmd.ExecuteNonQuery();
                }
                if (oracleParameters != null && oracleParameters.Count >= 0)
                {
                    foreach (var item in oracleParameters)
                    {
                        keyValuePairs.Add(item.ParameterName, GetOraParamVal(item));

                    }
                }
            }
            catch (Exception oraEx)
            {
                throw oraEx;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return keyValuePairs;
        }

        /// <summary>
        /// 执行存储过程或者函数
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteProcdure(string sql, bool isParameterByName, params OracleParameter[] parameters)
        {
            OracleConnection conn = GetConnection();
            IList<OracleParameter> oracleParameters = new List<OracleParameter>();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = isParameterByName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oracleParameters = PrepareCommand(cmd, conn, sql, CommandType.StoredProcedure, parameters);
                    cmd.ExecuteNonQuery();
                }
                if (oracleParameters != null && oracleParameters.Count >= 0)
                {
                    foreach (var item in oracleParameters)
                    {
                        keyValuePairs.Add(item.ParameterName, GetOraParamVal(item));

                    }
                }
            }
            catch (Exception oraEx)
            {
                throw oraEx;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return keyValuePairs;
        }

        /// <summary>
        /// 获取Oracle参数的值
        /// </summary>
        /// <param name="oraParam"></param>
        /// <returns></returns>
        protected virtual object GetOraParamVal(OracleParameter oraParam)
        {
            if (oraParam.Value == null || (oraParam.Value is INullable && (oraParam.Value as INullable).IsNull))
                return DBNull.Value;

            object val = DBNull.Value;
            if (oraParam.Value is OracleXmlType)
            {
                OracleXmlType xmltype = (OracleXmlType)oraParam.Value;
                if (!xmltype.IsEmpty) val = xmltype.Value;
            }
            else if (oraParam.Value is OracleBlob)
            {
                OracleBlob blobVal = (OracleBlob)oraParam.Value;
                if (!blobVal.IsNull) val = (oraParam.Value as OracleBlob).Value;
            }
            else if (oraParam.Value is OracleClob)
            {
                OracleClob clobVal = (OracleClob)oraParam.Value;
                if (!clobVal.IsNull) val = clobVal.Value;
            }
            else if (oraParam.Value is OracleDecimal)
            {
                OracleDecimal decimalVal = (OracleDecimal)oraParam.Value;
                if (!decimalVal.IsNull) val = decimalVal.Value;
            }
            else if (oraParam.Value is OracleDate)
            {
                OracleDate dateVal = (OracleDate)oraParam.Value;
                if (!dateVal.IsNull) val = dateVal.Value;
            }
            else if (oraParam.Value is OracleString)
            {
                OracleString stringVal = (OracleString)oraParam.Value;
                if (!stringVal.IsNull) val = stringVal.Value;
            }
            else if (oraParam.Value is OracleBFile)
            {
                OracleBFile fileVal = oraParam.Value as OracleBFile;
                if (!fileVal.IsNull) val = fileVal.Value;
            }
            else if (oraParam.Value is OracleBinary)
            {
                OracleBinary binaryVal = (OracleBinary)oraParam.Value;
                if (!binaryVal.IsNull) val = binaryVal.Value;
            }
            else if (oraParam.Value is OracleTimeStamp)
            {
                OracleTimeStamp timeStampVal = (OracleTimeStamp)oraParam.Value;
                if (!timeStampVal.IsNull) val = timeStampVal.Value;
            }
            else if (oraParam.Value is OracleRefCursor)
            {
                using (OracleRefCursor timeStampVal = (OracleRefCursor)oraParam.Value)
                {
                    if (timeStampVal.IsNull)
                        return null;
                    OracleDataReader dataReader = timeStampVal.GetDataReader();
                    DataTable datatable = new DataTable();
                    datatable.Load(dataReader);
                    return datatable;
                }
            }
            else
            {
                val = oraParam.Value;
            }
            return val;
        }


        /// <summary>
        /// 执行数据库操作，无返回值(执行sql语句)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        public void ExecuteNonQuery(string sql, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    PrepareCommand(cmd, connection, sql, CommandType.Text, sqlParams);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，无返回值(执行sql语句)
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        public void ExecuteNonQuery(string sql, bool isParameterByName, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = isParameterByName;
                    cmd.CommandType = CommandType.Text;
                    PrepareCommand(cmd, connection, sql, CommandType.Text, sqlParams);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，返回对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, CommandType commandType, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, connection, sql, commandType, sqlParams);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，返回对象
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, CommandType commandType, bool isParameterByName, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = isParameterByName;
                    cmd.CommandType = commandType;
                    PrepareCommand(cmd, connection, sql, commandType, sqlParams);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，返回对象(执行sql语句)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    PrepareCommand(cmd, connection, sql, CommandType.Text, sqlParams);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行数据库操作，返回对象(执行sql语句)
        /// 按OracleParameter参数名称执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, bool isParameterByName, params object[] sqlParams)
        {
            OracleConnection connection = GetConnection();
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.BindByName = isParameterByName;
                    cmd.CommandType = CommandType.Text;
                    PrepareCommand(cmd, connection, sql, CommandType.Text, sqlParams);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        #endregion

        #region OracleParameter配置
        private IList<OracleParameter> PrepareCommand(OracleCommand cmd, OracleConnection conn, string cmdText, CommandType commandType, object[] sqlParams)
        {
            OracleParameter[] cmdParms = ConvertParameter(sqlParams);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            IList<OracleParameter> parameters = new List<OracleParameter>();
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                    if (parm.Direction != ParameterDirection.Input)
                    {
                        parameters.Add(parm);
                    }
                }
            }
            return parameters;
        }



        OracleParameter[] ConvertParameter(object[] cmdParms)
        {
            if (cmdParms == null)
                return null;
            return cmdParms as OracleParameter[];
            //OracleParameter[] ps = CreateOracleParameter(cmdParms.Length);
            //for (int i = 0; i < cmdParms.Length; i++)
            //{
            //    ps[i].Value = cmdParms[i];
            //}
            //return ps;
        }


        OracleParameter[] CreateOracleParameter(int parameterCount)
        {
            OracleParameter[] ps = new OracleParameter[parameterCount];
            for (int i = 0; i < parameterCount; i++)
            {
                ps[i] = new OracleParameter();
            }
            return ps;
        }

        public bool ValidateConnection()
        {
            try
            {
                OracleConnection connection = GetConnection();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}