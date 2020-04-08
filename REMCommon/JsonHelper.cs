
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace REMCommon
{
    /// <summary>
    ///JsonTableHelper 的摘要说明
    /// </summary>
    public static class JsonHelper
    {

        public static string ToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                    if (j < dt.Columns.Count - 1)
                    {
                        Json.Append(",");
                    }
                }

                Json.Append("}");
                if (i < dt.Rows.Count - 1)
                {
                    Json.Append(",");
                }
            }

            Json.Append("]}");

            return Json.ToString();

        }


        public static string ToJson(string jsonName, DataView dv)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");

            for (int i = 0; i < dv.Count; i++)
            {
                Json.Append("{");
                for (int j = 0; j < dv.Table.Columns.Count; j++)
                {
                    Json.Append("\"" + dv.Table.Columns[j].ToString() + "\":\"" + dv[i].Row[j].ToString() + "\"");
                    if (j < dv.Table.Columns.Count - 1)
                    {
                        Json.Append(",");
                    }
                }

                Json.Append("}");
                if (i < dv.Count - 1)
                {
                    Json.Append(",");
                }
            }

            Json.Append("]}");

            return Json.ToString();

        }



        public static string ObjectToJson<T>(string jsonName, IList<T> IL)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (IL.Count > 0)
            {
                for (int i = 0; i < IL.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }

                    Json.Append("}");
                    if (i < IL.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }

            Json.Append("]}");
            return Json.ToString();

        }

        /// <summary>
        /// 将字符串转换成json格式:
        /// </summary>
        /// <param name="input">要处理的字符串：多行之间用{,}隔开，每个单元格之间用{|}隔开,每个值之间用{:}隔开</param>
        /// <param name="jsonName">json名称</param>
        /// <returns></returns>
        public static string StringToJson(string input, string jsonName)
        {
            System.Text.StringBuilder json = new System.Text.StringBuilder();
            json.Append("{\"" + jsonName + "\":[");

            string[] rows = input.Split(new string[] { "{,}" }, StringSplitOptions.RemoveEmptyEntries);
            if (rows != null)
            {
                string[] cloumns;
                string[] cellV;
                for (int i = 0; i < rows.Length; i++)
                {
                    json.Append("{");

                    cloumns = rows[i].Split(new string[] { "{|}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (cloumns == null) continue;
                    for (int j = 0; j < cloumns.Length; j++)
                    {
                        cellV = cloumns[j].Split(new string[] { "{:}" }, StringSplitOptions.None);
                        if (cellV == null || cellV.Length != 2) continue;
                        json.Append("\"" + cellV[0] + "\":\"" + cellV[1] + "\"");
                        if (j < cloumns.Length - 1)
                        {
                            json.Append(",");
                        }
                    }

                    json.Append("}");
                    if (i < rows.Length - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]}");
            return json.ToString();
        }



    }
}