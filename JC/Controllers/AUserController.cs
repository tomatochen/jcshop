using JC.Models;
using JC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JC.Controllers
{
    //AUser
    public class AUserController : BaseController
    {


        public ActionResult Index()
        {
            ViewData["Area"] = base.AreaListOptions;
            return View();
        }
        public ActionResult Create(string q_userid = "")
        {

            ViewData["Area"] = base.AreaListOptions;
            SYS_USER model;
            if (string.IsNullOrEmpty(q_userid))
            {
                model = new SYS_USER();
            }
            else
            {
                Guid g = Tool.String2Guid(q_userid);
                model = DbContext.SYS_USER.FirstOrDefault(m => m.USERID == g);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Create(FormCollection col)
        {
            try
            {
                Guid userid = Tool.String2Guid(col["userid"]);
                SYS_USER model = new SYS_USER();
                if (userid == Guid.Empty)
                {
                    model.USERID = Guid.NewGuid();
                    model.OPERATEDATE = DateTime.Now;
                    model.ISDELETED = 0;
                    FillModel(ref model, col);
                    string pwd = Tool.GetMD5Hash(Tool.textToBytes(col["PASSWORD"]));
                    model.PASSWORD = pwd;
                    DbContext.SYS_USER.Add(model);
                }
                else
                {
                    model = DbContext.SYS_USER.FirstOrDefault(m => m.USERID == userid);
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
        private void FillModel(ref SYS_USER model, FormCollection col)
        {
            model.USERNAME = col["USERNAME"];
            model.FULLNAME = col["FULLNAME"];
            model.SHORTNAME = col["SHORTNAME"];
            model.DEPTNAME = col["DEPTNAME"];
            model.ALLOWLOGIN = col["ALLOWLOGIN"];
            model.SEQUENCE = Tool.String2Int32(col["SEQUENCE"]);
            model.QQ = col["QQ"];
            model.MOBILE = col["MOBILE"];
            model.AREAID = Tool.String2Guid2(col["AREAID"]);
            model.AREANAME = col["AREANAME"];
            model.REMARK = col["REMARK"];
        }
        public JsonResult Delete(string q_id = "")
        {
            try
            {
                Guid gid = Tool.String2Guid(q_id);


                var model = DbContext.SYS_USER.FirstOrDefault(m => m.USERID == gid);
                model.ISDELETED = 1;
                model.DELETEDATE = DateTime.Now;
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
            var queryList = from m in DbContext.SYS_USER
                        where m.ISDELETED == 0
                        select m;
            var q_username = this.Get("username");
            if (!string.IsNullOrEmpty(q_username))
            {
                queryList = queryList.Where(u => u.USERNAME.Contains(q_username));
            }

            var q_fullname = this.Get("fullname");
            if (!string.IsNullOrEmpty(q_fullname))
            {
                queryList = queryList.Where(u => u.FULLNAME.Contains(q_fullname));
            }
            var areaID = Tool.String2Guid( this.Get("ddl_area"));
            if (areaID != Guid.Empty)
            {
                queryList = queryList.Where(u => u.AREAID == areaID);
            }
            return queryList.GetJson<SYS_USER>(sidx, sord, page, rows, JsonRequestBehavior.AllowGet,
                new string[] { "USERID", "USERNAME", "FULLNAME", "QQ", "EMAIL",
                    "MOBILE", "LASTTIME","ALLOWLOGIN", "SEQUENCE","AREANAME" });
        }

    }
}
