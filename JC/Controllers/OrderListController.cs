//订单管理信息
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
using JC.Common;

namespace JC.Controllers
{

    //OrderList
    public class OrderListController : BaseController
    {
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
            DateTime startMonth = dt.AddDays(1 - dt.Day);
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
            ViewData["mStart"] = startMonth.ToString("yyyy-MM-dd");
            ViewData["mEnd"] = endMonth.ToString("yyyy-MM-dd");

            List<SelectOption> cc_list = new List<SelectOption>();
            var slist = DbContext.STOREINFO.ToList();
            foreach (var item in slist)
            {
                SelectOption temp = new SelectOption(item.GUID.ToString(), item.STORENAME);
                cc_list.Add(temp);
            }

            ViewData["StoreInfo"] = cc_list;
            return View();
        }

        public ActionResult Edit(string q_id="'")
        {
            Guid gid = Tool.String2Guid(q_id);
            ORDERLIST model = DbContext.ORDERLIST.FirstOrDefault(m => m.GUID == gid);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult ChangeStatus(string q_id="",string q_value="",string q_text="")
        {
            try
            {
                Guid gid = Tool.String2Guid(q_id);
                ORDERLIST model = DbContext.ORDERLIST.FirstOrDefault(m => m.GUID == gid);
                model.ORDERSTATUS = q_value;
                model.ORDERSTATUSNAME = q_text;
                DbContext.Entry(model).State = System.Data.EntityState.Modified;
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.SaveSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail,ex.Message);
            }

        }


        public JsonResult List(string sidx, string sord, int page, int rows)
        {
            var dbset_list = from n in DbContext.ORDERLIST select n;

            //订单号
            string q_OrderCode = this.Get("OrderCode");
            if (!string.IsNullOrEmpty(q_OrderCode))
            {
                dbset_list = dbset_list.Where(m => m.ORDERCODE.Contains(q_OrderCode));
            }

            //客户商铺名称
            string q_CustomerShopName = this.Get("CustomerShopName");
            if (!string.IsNullOrEmpty(q_CustomerShopName))
            {
                dbset_list = dbset_list.Where(m => m.CUSTOMERSHOPNAME.Contains(q_CustomerShopName));
            }

            //订单状态
            string q_OrderStatus = this.Get("OrderStatus");
            if (!string.IsNullOrEmpty(q_OrderStatus))
            {
                dbset_list = dbset_list.Where(m => m.ORDERSTATUSNAME == q_OrderStatus);
            }
            DateTime? s = Tool.StringToDate(this.Get("xdrq_s"));
            DateTime? e = Tool.StringToDate(this.Get("xdrq_end"));

            dbset_list = dbset_list.Where(m => m.ORDERTIME >=s && m.ORDERTIME<=e);

            //所属仓储名称
            string q_storeInfo = this.Get("storeInfo");
            if (!string.IsNullOrEmpty(q_storeInfo))
            {
                Guid storeInfo_guid = Tool.String2Guid(q_storeInfo);
                dbset_list = dbset_list.Where(m => m.STOREID == storeInfo_guid);
            }

            return dbset_list.GetJson<ORDERLIST>(sidx, sord, page, rows, JsonRequestBehavior.AllowGet,
                new string[] { "GUID", "ORDERCODE", "CUSTOMERSHOPNAME", "ORDERTOTALMONEY", "ORDERSTATUSNAME", 
                    "ORDERTIME","STORENAME"});
        }
    }
}
