using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;


namespace REMCommon
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public class FileOperate
    {
        #region 读写
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="contents">保存内容</param>
        /// <param name="filePath">保存路径</param>
        /// <param name="replaceFile">是否替换原文件</param>
        /// <param name="addDatetime">保存路径</param>
        public static void SaveStringToFile(string contents, string filePath, bool replaceFile = false, bool addDatetime = true)
        {
            string dirName = Path.GetDirectoryName(filePath);
            if (Directory.Exists(dirName) == false)
                Directory.CreateDirectory(dirName);
            StreamWriter rw = null;
            try
            {
                if (replaceFile)
                {
                    rw = File.CreateText(filePath);
                }
                else
                {
                    if (File.Exists(filePath)) rw = File.AppendText(filePath);
                    else rw = File.CreateText(filePath);
                }

                rw.WriteLine(addDatetime ? string.Format("[{0}] {1}", DateTime.Now, contents) : contents);
                rw.Flush();
            }
            finally
            {
                rw.Close();
            }
        }



        /// <summary>
        /// 读取文件。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            StringBuilder arrText = new StringBuilder();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.UTF8Encoding.UTF8))
                {
                    string sLine = "";
                    while (sLine != null)
                    {
                        sLine = sr.ReadLine();
                        if (sLine != null)
                            arrText.Append(sLine);
                    }
                    sr.Close();
                }
            }
            return arrText.ToString();
        }
        #endregion

        #region 文件转二进制互操作
        /// <summary>
        /// 二进制转文件
        /// </summary>
        /// <param name="c"></param>
        public static void ByteToFile(object c)
        {
            try
            {
                byte[] Files = (Byte[])c;
                using (BinaryWriter bw = new BinaryWriter(File.Open(@"D:\111.pdf", FileMode.OpenOrCreate)))
                {
                    bw.Write(Files);
                    bw.Close();
                }
            }
            catch
            {
                throw new Exception("二进制转文件出错！");
            }

        }
        /// <summary>
        /// 文件转二进制
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] FileToStream(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                BinaryReader br = new BinaryReader(fs);
                byte[] byData = br.ReadBytes((int)fs.Length);
                fs.Close();
                return byData;
            }
        }


        #endregion

    }
}
