using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
using JC.Common;

namespace JC.Controllers
{
    public class CustomerInfoController : BaseController
    {


        public ActionResult Index()
        {
            ViewData["Salesman"] = YeWuYuanOptions;
            return View();
        }

        private List<SYS_USER> YeWuYuan
        {
            get
            {
                return DbContext.SYS_USER.Where(m => m.ISDELETED == 0).ToList();
            }
        }
        private List<SelectOption> YeWuYuanOptions
        {
            get
            {
                var men = new List<SelectOption>();
                var list_user = YeWuYuan;
                if(list_user == null || list_user.Count ==0)
                {
                    return men;
                }
                foreach (var item in list_user)
                {
                    SelectOption temp = new SelectOption();
                    temp.value = item.USERID.ToString();
                    temp.text = item.FULLNAME;
                    men.Add(temp);
                }
                return men;
            }
        }
        public ActionResult Create(string q_guid = "")
        {
            ViewData["city"] = base.AreaListOptions;

            ViewData["Salesman"] = YeWuYuanOptions;

            CUSTOMERINFO model;
            if (string.IsNullOrEmpty(q_guid))
            {
                model = new CUSTOMERINFO();
            }
            else
            {
                Guid g = Tool.String2Guid(q_guid);
                model = DbContext.CUSTOMERINFO.FirstOrDefault(m => m.GUID == g);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Create(FormCollection col)
        {
            try
            {
                Guid gid = Tool.String2Guid(col["GUID"]);
                CUSTOMERINFO model = new CUSTOMERINFO();
                if (gid == Guid.Empty)
                {
                    model.GUID = Guid.NewGuid();
                    model.CREATETIME = DateTime.Now;
                    model.ISDELETED = 0;
                    FillModel(ref model, col);
                    string pwd = Tool.GetMD5Hash(Tool.textToBytes(col["CUSTOMERPWD"]));
                    model.CUSTOMERPWD = pwd;
                    DbContext.CUSTOMERINFO.Add(model);
                }
                else
                {
                    model = DbContext.CUSTOMERINFO.FirstOrDefault(m => m.GUID == gid);
                    FillModel(ref model, col);
                    DbContext.Entry(model).State = System.Data.EntityState.Modified;
                }
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.SaveSuccess);

            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail, ex.Message);

            }

        }
        private void FillModel(ref CUSTOMERINFO model, FormCollection col)
        {
            model.ADDR = col["ADDR"];
            model.BUSINESSLICENSE = col["BUSINESSLICENSE"];
            model.CITY = col["CITY"];
            model.CITYID = Tool.String2Guid2(col["CITYID"]);
            model.CUSTOMERPHONE = col["CUSTOMERPHONE"];


            model.INVITECODE = col["INVITECODE"];
            model.SALESMANID = Tool.String2Guid2(col["SALESMANID"]);
            model.SALESMANNAME = col["SALESMANNAME"];
            model.SHOPLEADERNAME = col["SHOPLEADERNAME"];
            model.SHOPNAME = col["SHOPNAME"];
        }

        public JsonResult Delete(string q_id = "")
        {
            try
            {
                Guid gid = Tool.String2Guid(q_id);


                var model = DbContext.CUSTOMERINFO.FirstOrDefault(m => m.GUID == gid);
                model.ISDELETED = 1;
                model.DELETETIME = DateTime.Now;
                model.DELETEUSER = C_UserName;

                DbContext.Entry(model).State = System.Data.EntityState.Modified;

                DbContext.SaveChanges();

                return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail, ex.Message);
            }

        }
        public JsonResult List(string sidx, string sord, int page, int rows)
        {

            var queryList = from m in DbContext.CUSTOMERINFO
                            where m.ISDELETED == 0
                            select m;
            string Shopname = this.Get("Shopname");
            if(!string.IsNullOrEmpty(Shopname))
            {
                queryList = queryList.Where(m => m.SHOPNAME.Contains(Shopname));

            }
            string ShopLeaderName = this.Get("ShopLeaderName");
            if (!string.IsNullOrEmpty(ShopLeaderName))
            {
                queryList = queryList.Where(m => m.SHOPLEADERNAME.Contains(ShopLeaderName));

            }
            Guid salemanID = Tool.String2Guid(this.Get("saleman"));

            if (salemanID != Guid.Empty)
            {
                queryList = queryList.Where(m => m.SALESMANID.HasValue &&m.SALESMANID.Value == salemanID);

            }
            return queryList.GetJson<CUSTOMERINFO>(sidx, sord, page, rows, JsonRequestBehavior.AllowGet,
                new string[] { "GUID", "SHOPNAME", "SHOPLEADERNAME", "CITY", "ADDR", 
                    "INVITECODE","BUSINESSLICENSE", 
                    "SALESMANNAME", "CUSTOMERPHONE" });
        }
    }
}
