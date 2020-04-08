using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace REMCommon
{
    /// <summary>
    /// XML操作
    /// </summary>
    public class DataTableToXML
    {
        public static string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {

                
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.TableName = "PATIENT";
                xmlDS.WriteXml(writer);



                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim() ;
                //return "<OUTPUT>"+utf.GetString(arr).Trim()+ "</OUTPUT>";
                /*
                StringBuilder strXml = new StringBuilder();
                strXml.AppendLine("<MonitorData>");
                for (int i = 0; i < xmlDS.Rows.Count; i++)
                {
                    strXml.AppendLine("<rows>");
                    for (int j = 0; j < xmlDS.Columns.Count; j++)
                    {
                        strXml.AppendLine("<" + xmlDS.Columns[j].ColumnName + ">" + xmlDS.Rows[i][j] + "</" + xmlDS.Columns[j].ColumnName + ">");
                    }
                    strXml.AppendLine("</rows>");
                }
                strXml.AppendLine("</MonitorData>");

                return strXml.ToString();*/

            }
            catch (System.Exception ex)
            {
                //return String.Empty;
                throw ex;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        private DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
