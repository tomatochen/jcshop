using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;



namespace JC.Models
{
    public static class VTool
    {
        public static List<Menu> GetMenu(RequestContext _context)
        {
            UrlHelper Url = new UrlHelper(_context);
            List<Menu> menus = new List<Menu>();
            Menu m1 = new Menu("a10", null, "首页", "menu-icon fa fa-home", Url.Content("~/Home/Index"));
            Menu m2 = new Menu("a11", null, "人员列表", "menu-icon fa fa-list", Url.Content("~/Human/List"));

            Menu m4 = new Menu("a15", null, "人员信息统计", "menu-icon fa fa-bar-chart-o", "#");
            m4.AddChild("a1501", "按年龄段统计", string.Empty, Url.Action("NianLing", "TongJi"));
            m4.AddChild("a1502", "按学历统计", string.Empty, Url.Action("XueLi", "TongJi"));
            m4.AddChild("a1503", "按政治面貌统计", string.Empty, Url.Action("ZhengZhi", "TongJi"));
            m4.AddChild("a1504", "按入职时间统计", string.Empty, Url.Action("RuZhi", "TongJi"));
            m4.AddChild("a1505", "按岗位统计", string.Empty, Url.Action("GangWei", "TongJi"));
            m4.AddChild("a1506", "按职称统计", string.Empty, Url.Action("ZhiCheng", "TongJi"));
            Menu m3 = new Menu("a12", null, "系统设置", "menu-icon fa fa-pencil-square-o", "#");

            m3.AddChild("a13", "数据字典栏目", string.Empty, Url.Action("Index", "DicLan"));
            m3.AddChild("a14", "数据字典", string.Empty, Url.Action("Index", "DicLan"));

            menus.Add(m1);
            menus.Add(m2);
            menus.Add(m4);
            menus.Add(m3);

            return menus;
        }
    }
}