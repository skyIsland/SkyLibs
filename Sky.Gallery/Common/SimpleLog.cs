using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sky.Common
{
    public static class SimpleLog
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">写入内容</param>
        public static void WriteLogs(string content, string filePath = "Log")
        {
;           string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + filePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "-->" + content);
                    //  sw.WriteLine("----------------------------------------");
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 写入日志(扩展方法)
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void WriteLogsExtension(this string filePath)
        {
            WriteLogs(filePath);
        }
    }
}
