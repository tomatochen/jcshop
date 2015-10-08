using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JC.Models
{
    public class SelectOption
    {
        public string value { get; set; }
        public string text { get; set; }

        public bool isSelected { get; set; }

        public string data { get; set; }
        public SelectOption()
        {
            this.isSelected = false;
        }
        public SelectOption(string v ,string t):this()
        {
            this.value = v;
            this.text = t;
        }
        public SelectOption(string v, string t,string data)
            : this()
        {
            this.value = v;
            this.text = t;
            this.data = data;
        }
        public SelectOption(string v, string t,bool s):this()
        {
            this.value = v;
            this.text = t;
            this.isSelected = s;
        }
        public override string ToString()
        {
            if(isSelected)
            {
                return string.Format("<option value='{0}' selected='selected' data-data='{1}'>{2}</option>", value,data, text);
            }else
            {
                return string.Format("<option value='{0}' data-data='{1}'>{2}</option>", value,data, text);
            }
        }
        public string ToString(bool s)
        {
            if (s)
            {
                return string.Format("<option value='{0}' selected='selected'>{1}</option>", value, text);
            }
            else
            {
                return string.Format("<option value='{0}'>{1}</option>", value, text);
            }
        }
    }
}