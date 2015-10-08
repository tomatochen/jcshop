using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC.Common
{
    public static class Tool
    {
        public static DateTime? StringToDate(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            DateTime dt;
            if(DateTime.TryParse(s,out dt))
            {
                return dt;
            }
            else
            {
                throw new Exception();
                
            }
        }
        public static Guid String2Guid(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return Guid.Empty;
            }
            Guid r;
            if(Guid.TryParse(s,out r))
            {
                return r;
            }
            else
            {
                return Guid.Empty;
            }
        }
        public static Guid? String2Guid2(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            Guid r;
            if (Guid.TryParse(s, out r))
            {
                return r;
            }
            else
            {
                return null;
            }
        }
        public static decimal String2Decimal(string s)
        {
           if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            decimal r;
            if( Decimal.TryParse(s,out r))
            {
                return r;
            }
            else
            {
                return 0;
            }
        }
        public static int? String2Int32(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            int r;
            if (Int32.TryParse(s, out r))
            {
                return r;
            }
            else
            {
                return null;
            }
        }
        public static string ToJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static byte[] textToBytes(string text)
        {
            byte[] buf = new byte[0];
            if (!string.IsNullOrEmpty(text))
                buf = System.Text.Encoding.Default.GetBytes(text);
            return buf;
        }

        public static string GetMD5Hash(byte[] data)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;


            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                       new System.Security.Cryptography.MD5CryptoServiceProvider();

            try
            {

                arrbytHashValue = oMD5Hasher.ComputeHash(data);

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch
            {
            }

            return (strResult);
        }
    }
}
