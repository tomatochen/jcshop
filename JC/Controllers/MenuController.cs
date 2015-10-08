using JC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JC.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public List<Menu> GetMenu()
        {
            List<Menu> menus = new List<Menu>();
            Menu m1 = new Menu("a10", null, "首页", "menu-icon fa fa-home", Url.Content("~/VegeParentType/Index"));
            
            //Menu m5 = new Menu("a16", null, "二级分类", "menu-icon fa fa-list", Url.Action("Index", "VegeType"));
            Menu m6 = new Menu("a17", null, "订单管理", "menu-icon fa fa-list", Url.Action("Index", "OrderList"));
         
            Menu m4 = new Menu("a15", null, "菜品管理", "menu-icon fa fa-bar-chart-o", "#");
            m4.AddChild("a1501", "一级品类", string.Empty, Url.Action("Index", "VegeParentType"));
            m4.AddChild("a1502", "二级品类", string.Empty, Url.Action("Index", "VegeType"));
            m4.AddChild("a1503", "菜品基础信息", string.Empty, Url.Action("Index", "VegeName"));
            m4.AddChild("a1504", "菜品价格维护", string.Empty, Url.Action("Index", "VegeInfo"));

            Menu m2 = new Menu("a11", null, "客户信息", "menu-icon fa fa-list", Url.Action("Index", "CustomerInfo"));

            Menu m3 = new Menu("a12", null, "系统设置", "menu-icon fa fa-pencil-square-o", "#");
            m3.AddChild("a12_00", "系统用户管理", string.Empty, Url.Action("Index", "AUser"));
            m3.AddChild("a12_02", "数据字典栏目", string.Empty, Url.Action("Index", "DicLan"));
            m3.AddChild("a12_03", "数据字典", string.Empty, Url.Action("Index", "Dic"));

            menus.Add(m1);
            menus.Add(m6);
            menus.Add(m4);
            menus.Add(m2);
            //menus.Add(m7);
            menus.Add(m3);

            return menus;
        }
        string formate = @"
<li id='{0}'  class='hover'>
    <a href='{1}'>
        <i class='{2}'></i>
        <span class='menu-text'>{3}</span>
    </a>
    <b class='arrow'></b>
</li>";
//        string formate_active = @"
//<li id='{0}' class='active'>
//    <a href='{1}'>
//        <i class='{2}'></i>
//        <span class='menu-text'>{3}</span>
//    </a>
//    <b class='arrow'></b>
//</li>";
        string pformate = @"
                <li id='{0}' class='hover'>
                    <a href='#' class='dropdown-toggle'>
                        <i class='{1}'></i>
                        <span class='menu-text'>{2}</span>
                        <b class='arrow fa fa-angle-down'></b>
                    </a>
                    <b class='arrow'></b>";
//        string pformate_active = @"
//                <li id='{0}' class='open active'>
//                    <a href='#' class='dropdown-toggle'>
//                        <i class='{1}'></i>
//                        <span class='menu-text'>{2}</span>
//                        <b class='arrow fa fa-angle-down'></b>
//                    </a>
//                    <b class='arrow'></b>";
        public ActionResult Index()
        {
            try
            {
                List<Menu> menus = this.GetMenu();
                StringBuilder ms = new StringBuilder();
                foreach (var item in menus)
                {
                    if (item.IsParent)
                    {
                        ms.AppendFormat(pformate, item.ID, item.Icon, item.Name);
                      
                        ms.AppendLine("<ul class='submenu'>");
                        foreach (var item2 in item.ChildMenu)
                        {
                            ms.AppendFormat(formate, item2.ID, item2.Url, "menu-icon fa fa-caret-right", item2.Name);
                        }
                        ms.AppendLine("</ul>");
                        ms.AppendLine("</li>");
                    }
                    else
                    {
                        ms.AppendFormat(formate, item.ID, item.Url, item.Icon, item.Name);

                    }
                }
                ViewData["h"] = ms.ToString();
                return PartialView();
            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }

    }
}
