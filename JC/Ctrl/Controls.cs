using JC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace System.Web.Mvc.Html
{
    public static class Controls
    {
        public static MvcHtmlString DropDownList2(this HtmlHelper htmlHelper, string uniqueFlag, string name)
        {
            jincaiEntities aa = new jincaiEntities();
            List<SYS_DATADIC> list =
                aa.SYS_DATADIC.Where(m => m.UNIQUEFLAG == uniqueFlag &&m.ISDELETED !="1").OrderBy(m => m.SEQUENCE).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select id='{0}' name='{0}' class='form-control'>", name);
            sb.AppendFormat("<option value=''></option>");
            foreach (SYS_DATADIC item in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", item.DICNAME, item.DICNAME);
            }
            sb.Append("</select>");
            var btn = MvcHtmlString.Create(sb.ToString());

            return btn;
        }
        public static MvcHtmlString DropDownList2(this HtmlHelper htmlHelper, string uniqueFlag, string name, string svalue)
        {
            jincaiEntities aa = new jincaiEntities();
            List<SYS_DATADIC> list =
                aa.SYS_DATADIC.Where(m => m.UNIQUEFLAG == uniqueFlag).OrderBy(m => m.SEQUENCE).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select id='{0}' name='{0}' class='form-control'>", name);
            sb.AppendFormat("<option value=''></option>");
            foreach (SYS_DATADIC item in list)
            {
                if (svalue == item.DICNAME)
                {
                    sb.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", item.DICNAME, item.DICNAME);
                }
                else
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", item.DICNAME, item.DICNAME);

                }
            }
            sb.Append("</select>");
            var btn = MvcHtmlString.Create(sb.ToString());

            return btn;
        }
        //public static MvcHtmlString DropDownListSearch(this HtmlHelper htmlHelper, string uniqueFlag, string name, string svalue, string msg)
        //{
        //    jincaiEntities aa = new jincaiEntities();
        //    List<HR_SYS_DATADIC> list =
        //        aa.HR_SYS_DATADIC.Where(m => m.UNIQUEFLAG == uniqueFlag).OrderBy(m => m.SEQUENCE).ToList();

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<select id='{0}' name='{0}' class='chosen-select form-control' data-placeholder='{1}'>", name, msg);
        //    sb.AppendFormat("<option value=''></option>");
        //    foreach (HR_SYS_DATADIC item in list)
        //    {
        //        if (svalue == item.DICNAME)
        //        {
        //            sb.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", item.DICNAME, item.DICNAME);

        //        }
        //        else
        //        {
        //            sb.AppendFormat("<option value='{0}'>{1}</option>", item.DICNAME, item.DICNAME);

        //        }
        //    }
        //    sb.Append("</select>");
        //    var btn = MvcHtmlString.Create(sb.ToString());

        //    return btn;
        //}
        //public static void BindSub(ZtreeData parentTreeNode, int parentID, ref List<SYS_DEPARTMENT> allTowns, ref List<SelectOption> so_list)
        //{
        //    var p = from c in allTowns
        //            where c.PARENTID == parentID
        //            orderby c.SEQUENCE
        //            select new { c.DEPTID, c.DEPTNAME };
        //    foreach (var towninfo in p)
        //    {
        //        ZtreeData subTreeNode = new ZtreeData();
        //        int deptID = towninfo.DEPTID;
        //        subTreeNode.id = deptID.ToString();
        //        subTreeNode.name = towninfo.DEPTNAME;
        //        parentTreeNode.addChild(subTreeNode);

        //        so_list.Add(new SelectOption(subTreeNode.id, subTreeNode.name));
        //        BindSub(subTreeNode, deptID, ref allTowns, ref so_list);
        //    }
        //}
        //public static MvcHtmlString DropDownListDept(this HtmlHelper htmlHelper, string name, string svalue, string msg)
        //{
        //    List<SelectOption> so_list = new List<SelectOption>();

        //    jincaiEntities aa = new jincaiEntities();
        //    List<SYS_DEPARTMENT> list2 = aa.SYS_DEPARTMENT.OrderBy(m => m.SEQUENCE).ToList();
        //    SYS_DEPARTMENT root = list2.Find(m => m.PARENTID == 0);
        //    if(root == null)
        //    {
        //        return MvcHtmlString.Create("异常");
        //    }
        //    ZtreeData rootData = new ZtreeData();
        //    rootData.id = root.DEPTID.ToString();
        //    rootData.name = root.DEPTNAME;
        //    so_list.Add(new SelectOption(rootData.id, rootData.name));
        //    BindSub(rootData, root.DEPTID, ref list2, ref so_list);
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<select id='{0}' name='{0}' class='chosen-select form-control' data-placeholder='{1}'>", name, msg);
        //    sb.AppendFormat("<option value=''></option>");
        //    foreach (SelectOption item in so_list)
        //    {
        //        if (svalue == item.value)
        //        {
        //            sb.AppendFormat(item.ToString(true));

        //        }
        //        else
        //        {
        //            sb.AppendFormat(item.ToString(false));

        //        }
        //    }
        //    sb.Append("</select>");
        //    var btn = MvcHtmlString.Create(sb.ToString());

        //    return btn;
        //}
        public static MvcHtmlString DropDownListDept(this HtmlHelper htmlHelper, string name, string svalue, string msg, List<SelectOption> so_list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select id='{0}' name='{0}' class='multiselect form-control'>", name);
            sb.AppendFormat("<option value=''>请选择</option>");
            foreach (SelectOption item in so_list)
            {
                if (svalue == item.value)
                {
                    sb.AppendFormat(item.ToString(true));
                }
                else
                {
                    sb.AppendFormat(item.ToString(false));
                }
            }
            sb.Append("</select>");
            var btn = MvcHtmlString.Create(sb.ToString());

            return btn;
        }

        public static MvcHtmlString DropDownList4(this HtmlHelper htmlHelper, string name, string svalue, List<SelectOption> so_list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select id='{0}' name='{0}' class='multiselect form-control'>", name);
            sb.AppendFormat("<option value=''></option>");
            foreach (SelectOption item in so_list)
            {
                if (svalue == item.value)
                {
                    sb.AppendFormat(item.ToString(true));
                }
                else
                {
                    sb.AppendFormat(item.ToString(false));
                }
            }
            sb.Append("</select>");
            var btn = MvcHtmlString.Create(sb.ToString());

            return btn;
        }
        public static MvcHtmlString Date(this HtmlHelper htmlHelper, string name)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control date_time");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBox(name, null, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Date(this HtmlHelper htmlHelper, string name, string value, object htmlAttr)
        {
            var dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttr);
            dic.Add("class", "form-control date_time");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBox(name, value, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Date(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> dic)
        {
            dic.Add("class", "form-control date_time");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBox(name, value, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Date(this HtmlHelper htmlHelper, string name, string value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control date_time");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";
            string input_html = htmlHelper.TextBox(name, value, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Date(this HtmlHelper htmlHelper, string name, DateTime? value)
        {
            string v = "";
            if (value.HasValue)
            {
                v = value.Value.ToString("yyyy-MM-dd");
            }

            return Date(htmlHelper, name, v);
        }
        public static MvcHtmlString DateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control date_time");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBoxFor(expression, "{0:yyyy-MM-dd}", dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString MonthView(this HtmlHelper htmlHelper, DateTime? v)
        {
            string d = v.HasValue ? v.Value.ToString("yyyy-MM") : string.Empty;
            string formate = "<span>{0}</span>";
            string html = string.Format(formate, d);
            return MvcHtmlString.Create(html);

        }
        public static MvcHtmlString DateTimeView(this HtmlHelper htmlHelper, DateTime? v)
        {
            string d = v.HasValue ? v.Value.ToString("yyyy-MM-dd hh:MM:ss") : string.Empty;
            string formate = "<span>{0}</span>";
            string html = string.Format(formate, d);
            return MvcHtmlString.Create(html);

        }
        public static MvcHtmlString CTextView(this HtmlHelper htmlHelper, string text)
        {
            string d = text;
            string formate = "<span>{0}</span>";
            string html = string.Format(formate, d);
            return MvcHtmlString.Create(html);

        }
        public static MvcHtmlString CTextView(this HtmlHelper htmlHelper, decimal? dec)
        {
            string d = dec.HasValue ? string.Format("{0:N2}",dec.Value): string.Empty;
            string formate = "<span>{0}</span>";
            string html = string.Format(formate, d);
            return MvcHtmlString.Create(html);

        }
        public static string CValue(this HtmlHelper htmlHelper, decimal? dec)
        {
            string d = dec.HasValue ? string.Format("{0:N2}", dec.Value) : string.Empty;
            return d;

        }
        public static string CValue(this HtmlHelper htmlHelper, DateTime? dt,string formate)
        {
            string d = dt.HasValue ? dt.Value.ToString(formate) : string.Empty;
            return d;

        } 
        public static MvcHtmlString DateView(this HtmlHelper htmlHelper, DateTime? v)
        {
            string d = v.HasValue ? v.Value.ToString("yyyy-MM-dd") : string.Empty;
            string formate = "<span>{0}</span>";
            string html = string.Format(formate, d);
            return MvcHtmlString.Create(html);

        }
        public static MvcHtmlString Month(this HtmlHelper htmlHelper, string name, string value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control date_month");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBox(name, value, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Month(this HtmlHelper htmlHelper, string name, string value, object htmlAttr)
        {
            var dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttr);
            return Month(htmlHelper, name, value, dic);
        }
        public static MvcHtmlString Month(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> dic)
        {
            dic.Add("class", "form-control date_month");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";

            string input_html = htmlHelper.TextBox(name, value, dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString Month(this HtmlHelper htmlHelper, string name, DateTime? value)
        {
            string v = "";
            if (value.HasValue)
            {
                v = value.Value.ToString("yyyy-MM");
            }
            return Month(htmlHelper, name, v);
        }
        public static MvcHtmlString MonthFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control date_month");

            string formate = @"<div class='input-group'>{0}
                    <span class='input-group-addon'>
                        <i class='fa fa-calendar bigger-110'></i>
                    </span>
                </div>";
            string input_html = htmlHelper.TextBoxFor(expression, "{0:yyyy-MM}", dic).ToHtmlString();

            string html = string.Format(formate, input_html);
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString CTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            string format = null;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "form-control");
            return htmlHelper.TextBoxFor(expression, format, dic);
        }
        public static MvcHtmlString CTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttr)
        {
            var dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttr);
            string format = null;
            dic.Add("class", "form-control");
            return htmlHelper.TextBoxFor(expression, format, dic);
        }
        public static MvcHtmlString CTextBoxNotNullFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool required, string msg)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string format = null;
            dic.Add("class", "form-control");
            if (required)
            {
                dic.Add("validate", "{required:true,messages: { required: '" + msg + "'}}");
            }
            return htmlHelper.TextBoxFor(expression, format, dic);
        }
        public static MvcHtmlString CTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {

            string format = null;
            htmlAttributes.Add("class", "form-control");
            return htmlHelper.TextBoxFor(expression, format, htmlAttributes);
        }


        public static MvcHtmlString EditButton(this HtmlHelper htmlHelper, string id, string function, string value)
        {
            string formate = "<div id='{0}' onclick=\"{1}('{2}');\" class=\"btn btn-xs btn-primary no-padding no-margin\">修改</div>";

            return MvcHtmlString.Create(string.Format(formate, id, function, value));
        }

        public static MvcHtmlString DelelteButton(this HtmlHelper htmlHelper, string id, string function, string value)
        {
            string formate = "<div id='{0}' onclick=\"{1}('{2}');\" class=\"btn btn-xs btn-danger no-padding no-margin\">删除</div>";

            return MvcHtmlString.Create(string.Format(formate, id, function, value));
        }

        public static MvcHtmlString AddButton(this HtmlHelper htmlHelper, string id, string function)
        {
            string f = function + "();";
            string formate = "<a  id={0} class=\"btn btn-success btn-sm\" href=\"#\" onclick='{1}return false;'><i class=\"ace-icon fa fa-plus-circle bigger-125\"></i>新增</a>";

            return MvcHtmlString.Create(string.Format(formate, id, f));
        }
        public static MvcHtmlString AddButton(this HtmlHelper htmlHelper, string id)
        {
            string formate = "<a  id={0} class=\"btn btn-success btn-sm\" href=\"#\" onclick='{1}return false;'><i class=\"ace-icon fa fa-plus-circle bigger-125\"></i>新增</a>";

            return MvcHtmlString.Create(string.Format(formate, id, ""));
        }

        public static MvcHtmlString CRadioButton(this HtmlHelper htmlHelper, string name, string value, string checkValue,bool isDefault)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("class", "ace");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<label>");
            string h = string.Empty;
            if(!string.IsNullOrEmpty(checkValue))
            {
                h = htmlHelper.RadioButton(name, value, checkValue == value, dic).ToHtmlString();
            }else
            {
                h = htmlHelper.RadioButton(name, value, isDefault, dic).ToHtmlString();
            }
            sb.AppendLine(h);
            sb.AppendLine("<span class='lbl'>" + value + "</span></label>");

            return MvcHtmlString.Create(sb.ToString());
        }
        public static MvcHtmlString CString(this HtmlHelper htmlHelper, bool b, string yes, string no)
        {
            string b1 = b ? yes : no;
            return MvcHtmlString.Create(b1);
        }
    }
}