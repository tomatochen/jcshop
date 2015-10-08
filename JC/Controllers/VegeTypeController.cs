using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
using JC.Common;

namespace JC.Controllers
{
    public class VegeTypeController : BaseController
    {
        private jincaiEntities db = new jincaiEntities();

        //
        // GET: /VegeType/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            try
            {
                var list = DbContext.VEGETABLESPARENTTYPE.Where(m => m.ISDELETED != 1).OrderBy(o=>o.SEQUENCE).ToList();
                var childList = DbContext.VEGETABLESTYPE.Where(m => m.ISDELETED != 1).OrderBy(o => o.SEQUENCE).ToList();

                List<ZtreeData> z_list = new List<ZtreeData>();
                foreach (VEGETABLESPARENTTYPE item in list)
                {
                    var z = new ZtreeData();
                    z.id = item.GUID.ToString();
                    z.isParent = true;
                    var c_list = childList.Where(m => m.PARENTTYPEID.HasValue &&  m.PARENTTYPEID.Value == item.GUID).ToList();
                    z.name = item.VEGETABLESNAME + "  (" + c_list.Count + ")";
                    z.name2 = item.VEGETABLESNAME;
                    foreach (var j in c_list)
                    {
                        var c = new ZtreeData();
                        c.id = j.GUID.ToString();
                        c.name = j.VEGETABLESNAME;
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
        //
        // GET: /VegeType/Create

        public ActionResult List(string q_pid = "")
        {
            Guid pid = Tool.String2Guid(q_pid);
            var list = DbContext.VEGETABLESTYPE.Where(m => m.PARENTTYPEID == pid && m.ISDELETED !=1)
                .OrderBy(m=>m.SEQUENCE)
                .ToList();
            return PartialView(list);
        }

        [HttpPost]
        public JsonResult Create(FormCollection col)
        {

            try
            {
                Guid id = Tool.String2Guid(col["GUID"]);
                VEGETABLESTYPE model = new VEGETABLESTYPE();
                if(id == Guid.Empty)
                {
                    model.GUID = Guid.NewGuid();
                    model.CREATEDATETIME = DateTime.Now;
                    FillModel(ref model, col);
                    DbContext.VEGETABLESTYPE.Add(model);
                }else
                {
                    model = DbContext.VEGETABLESTYPE.FirstOrDefault(n => n.GUID == id);
                    FillModel(ref model, col);
                    DbContext.Entry(model).State = EntityState.Modified;
                }
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.SaveSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail, ex.Message);
            }
        }

        private void FillModel(ref VEGETABLESTYPE m,FormCollection col)
        {
            m.PARENTTYPEID = Tool.String2Guid(col["parentID"]);
            m.VEGETABLESNAME = col["VEGETABLESNAME"];
            m.SEQUENCE = Tool.String2Decimal(col["SEQUENCE"]);
            m.CREATEUSERID = null;
            m.CREATEUSERNAME = null;
            
            m.ISDELETED = 0;
        }

        public JsonResult Find(string q_id = "")
        {
            Guid id = Tool.String2Guid(q_id);
            VEGETABLESTYPE model = DbContext.VEGETABLESTYPE.FirstOrDefault(m => m.GUID == id);
            return new JsonM().ToJson(true, "'", model);
        }



        public ActionResult Delete(string q_id = "")
        {
            try
            {
                Guid id = Tool.String2Guid(q_id);
                VEGETABLESTYPE model = DbContext.VEGETABLESTYPE.FirstOrDefault(m => m.GUID == id);
                if (model == null)
                {
                    return new JsonM().ToJson(true, "当前数据已删除");
                }
                model.ISDELETED = 1;
                DbContext.Entry(model).State = EntityState.Modified;
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
            }
            catch (Exception ex )
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail, ex.Message);
            }
        }


        protected override void Dispose(bool disposing)
        {
            DbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}