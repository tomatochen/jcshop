using JC.Common;
using JC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JC.Controllers
{
    public class DicLanController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            try
            {
                var list = DbContext.SYS_DATADICLIST.ToList();

                return new JsonM().ToJson(true, "", list);
            }
            catch (Exception ex)
            {

                return new JsonM().ToJson(false, ex.Message);
            }
        }

        public ActionResult ValidateUniqueFlag(FormCollection col)
        {
            string username = col["name"];
            int c = DbContext.SYS_DATADICLIST.Count(m => m.UNIQUEFLAG == username);
            return Json(c > 0 ? new { Success = true } : new { Success = false });
        }

        public ActionResult Details(string id = null)
        {
            SYS_DATADICLIST hr_sys_datadiclist = DbContext.SYS_DATADICLIST.Find(id);
            if (hr_sys_datadiclist == null)
            {
                return HttpNotFound();
            }
            return View(hr_sys_datadiclist);
        }


        [HttpPost]
        public JsonResult Create(FormCollection collection)
        {
            try
            {
                SYS_DATADICLIST model = new SYS_DATADICLIST();
                model.GUID = Guid.NewGuid();
                model.UNIQUEFLAG = collection["UniqueFlag"].ToString();
                model.DATANAME = collection["DataName"].ToString();
                model.PARENTCODE = "0";
                model.SEQUENCE = 0;
                model.ISTREE = "0";
                DbContext.SYS_DATADICLIST.Add(model);
                DbContext.SaveChanges();

                return new JsonM().ToJson(true, MsgHelper.SaveSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail, ex.Message);
            }

        }

        public ActionResult Delete(string UniqueFlag = "")
        {
            try
            {
                SYS_DATADICLIST model =
                    DbContext.SYS_DATADICLIST
                    .First(m => m.UNIQUEFLAG == UniqueFlag);
                if (model == null)
                {
                    return new JsonM().ToJson(true, "记录已删除！");
                }
                else
                {
                    DbContext.SYS_DATADICLIST.Remove(model);
                    
                    DbContext.SaveChanges();
                    return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
                }
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail, ex.Message);
            }



        }

        //
        // POST: /DicLan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SYS_DATADICLIST hr_sys_datadiclist = DbContext.SYS_DATADICLIST.Find(id);
            DbContext.SYS_DATADICLIST.Remove(hr_sys_datadiclist);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            DbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}