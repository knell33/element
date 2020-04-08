using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace REMCommon
{
    public class ModelConvert
    {
        /// <summary> 
        /// DataSet装换为泛型集合 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="p_DataSet">DataSet</param> 
        /// <param name="p_TableIndex">待转换数据表索引</param> 
        /// <returns></returns> 
        ///
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化 
            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.ToUpper().Equals(p_Data.Columns[i].ColumnName.ToUpper()))
                        {
                            // 数据库NULL值单独处理 
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_Data.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        /// <summary>
        /// DataTable装换为泛型集合 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> DataTableToIList<T>(DataTable dt)
        {
            IList<T> ts = new List<T>();// 定义集合
            
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = (T)Activator.CreateInstance(typeof(T)); 
                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    try
                    { 
                    if (dt.Columns.Contains(tempName.ToUpper())|| dt.Columns.Contains(tempName.ToLower()))
                    {
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName.ToUpper()];
                            if (value != DBNull.Value)
                            {
                                pi.SetValue(t, value, null);
                            } else {
                                pi.SetValue(t, null, null);
                            }
                    }
                    }catch(Exception ex)
                    {

                    }


                }
                ts.Add(t);
            }
            return ts;
        }
        /// <summary>
        /// DataTable装换为Dictionary集合 (字典)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<Dictionary<object, object>> DataTableToDic(DataTable dt)
        {
            IList<Dictionary<object, object>> keyValuePairs = new List<Dictionary<object, object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<object, object> temp = new Dictionary<object, object>();
                foreach (DataColumn item in dt.Columns)
                {
                    temp.Add(item.ColumnName, dr[item]);
                }
                keyValuePairs.Add(temp);
            }
            return keyValuePairs;

        }
    }
}
