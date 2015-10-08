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
    public class DicController : BaseController
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult List(string uniqueFlag = "")
        {
            var list = this.FindByUniqueflag(uniqueFlag);

            return PartialView(list);
        }

        private List<SYS_DATADIC> FindByUniqueflag(string uniqueflag)
        {
            return DbContext.SYS_DATADIC.Where(m => m.UNIQUEFLAG == uniqueflag && m.ISDELETED != "1").ToList();
        }
        public ActionResult GetAll()
        {
            try
            {
                var list = DbContext.SYS_DATADICLIST.ToList();

                List<ZtreeData> z_list = new List<ZtreeData>();
                foreach (SYS_DATADICLIST item in list)
                {
                    var z = new ZtreeData();
                    z.id = item.UNIQUEFLAG;
                    z.name = item.DATANAME;
                    z.isParent = true;
                    var c_list = this.FindByUniqueflag(z.id);
                    foreach (var j in c_list)
                    {
                        var c = new ZtreeData();
                        c.id = j.GUID.ToString();
                        c.name = j.DICNAME;
                        z.addChild(c);
                    }
                    z_list.Add(z);
                }

                return new JsonM().ToJson(true, "", z_list);
            }
            catch (Exception ex)
            {

                return new JsonM().ToJson(false, ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Create(FormCollection col)
        {
            try
            {
                SYS_DATADIC model = new SYS_DATADIC();
                model.GUID = Guid.NewGuid();
                string dicname = col["Dicname"].Trim();
                model.DICNAME = dicname;
                model.DICLISTNAME = col["Diclistname"];
                model.UNIQUEFLAG = col["UniqueFlag"];
                string unique = model.UNIQUEFLAG;
                model.ABBRE = col["Abbre"];
                model.DICID = 1;
                model.ISDELETED = "0";
                int c = DbContext.SYS_DATADIC.Count(m => m.DICNAME == dicname && m.UNIQUEFLAG == unique);
                if (c > 0)
                {
                    return new JsonM().ToJson(false, "当前栏目存在相同标识！");
                }
                else
                {
                    DbContext.SYS_DATADIC.Add(model);
                    DbContext.SaveChanges();
                    return new JsonM().ToJson(true, MsgHelper.SaveSuccess);
                }

            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(true, MsgHelper.SaveFail, ex.Message);
            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SYS_DATADIC sys_datadic)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(sys_datadic).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_datadic);
        }

        //
        // GET: /Dic/Delete/5

        public ActionResult Delete(string q_id = "")
        {
            try
            {
                Guid gid = Tool.String2Guid(q_id);
                SYS_DATADIC model = DbContext.SYS_DATADIC.FirstOrDefault(m => m.GUID == gid);

                if (model == null)
                {
                    return new JsonM().ToJson(true, "记录已删除！");
                }
                else
                {
                    model.ISDELETED = "1";
                    DbContext.Entry(model).State = EntityState.Modified;
                    DbContext.SaveChanges();
                    return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
                }
            }
            catch (Exception ex )
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail,ex.Message);
            }


        }

        //
        // POST: /Dic/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SYS_DATADIC sys_datadic = DbContext.SYS_DATADIC.Find(id);
            DbContext.SYS_DATADIC.Remove(sys_datadic);
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