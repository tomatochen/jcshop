using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace JC.Common
{
    public class JsonM
    {
        private bool _success;

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public JsonM()
        {
            _success = false;
            _message = string.Empty;
        }
        public JsonM(bool s, string m)
        {
            _success = s;
            _message = m;
        }
        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private object _obj;

        public object Obj
        {
            get { return _obj; }
            set { _obj = value; }
        }
        
        /// <summary>
        /// 返回成功时，返回的提示
        /// </summary>
        /// <param name="m"></param>
        public JsonM(string m)
        {
            _success = true;
            _message = m;
        } 
    }

    public static class ExtensionH
    {
        public static JsonResult ToJson(this JsonM datas)
        {
            return ToJson(datas, datas.Success, datas.Message);
        }
        public static JsonResult ToJson(this JsonM datas,string msg)
        {
            return ToJson(datas, datas.Success, msg);
        }
        public static JsonResult ToJson(this JsonM datas, bool suc,string msg)
        {
            datas.Success = suc;
            datas.Message = msg;
            var json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = datas;
            return json;
        }
        public static JsonResult ToJson(this JsonM datas, bool suc, string msg,object o)
        {
            return ToJson(datas, suc, msg, o, null);
        }
        public static JsonResult ToJson(this JsonM datas, bool suc, string msg, object o,string id)
        {
            datas.Success = suc;
            datas.Message = msg;

            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            datas.Obj = JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented, timeFormat);
            datas.ID = id;
            var json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = datas;

            return json;
        }
    }
}
