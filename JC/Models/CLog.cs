using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JC.Models
{
    public static class CLog
    {
        /// <summary>
        /// 将相关错误日志信息保存到txt文件中
        /// </summary>
        /// <param name="strData">错误信息</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="pageInfo">页面</param>
        public static void SaveTextToFile(string strData, string pageInfo)
        {
            try
            {
                string filePath = HttpContext.Current.Request.PhysicalApplicationPath + "ErrorLog";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                System.IO.StreamWriter stream_writer = new System.IO.StreamWriter(filePath + "\\ErrorLog.txt", true);
                stream_writer.Write(DateTime.Now.ToString() + " 页面 " + pageInfo + " 发生错误信息： " + strData + " \r\n");
                stream_writer.Write(Environment.NewLine);
                stream_writer.Close();
            }
            catch
            {
            }
        }

    }
}