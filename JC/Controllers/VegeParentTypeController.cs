using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
using JC.Common;
namespace JC.Controllers
{
    public class VegeParentTypeController : BaseController
    {
        //
        // GET: /VegeParentType/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = DbContext.VEGETABLESPARENTTYPE.Where(o => o.ISDELETED != 1).OrderBy(o => o.SEQUENCE).ToList();
            return PartialView(list);
        }

        //
        // GET: /VegeParentType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VegeParentType/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                VEGETABLESPARENTTYPE model = FillModel(collection); ;
                if (string.IsNullOrEmpty(collection["GUID"]))
                {
                    model.GUID = Guid.NewGuid();
                    DbContext.VEGETABLESPARENTTYPE.Add(model);
                }
                else
                {
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

        public JsonResult Edit(string id = "")
        {
            Guid guid = Guid.Parse(id);
            var model = DbContext.VEGETABLESPARENTTYPE.First(m => m.GUID == guid);
            return new JsonM().ToJson(true, "", model);
        }

        public JsonResult Delete(string id = "")
        {
            try
            {
                Guid guid = Guid.Parse(id);
                var model = DbContext.VEGETABLESPARENTTYPE.First(m => m.GUID == guid);
                model.ISDELETED = 1;
                model.DELETEUSER = "管理员";
                model.DELETEDATE = DateTime.Now;
                DbContext.Entry(model).State = System.Data.EntityState.Modified;
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail);
            }
        }
        public VEGETABLESPARENTTYPE FillModel(FormCollection collection)
        {
            VEGETABLESPARENTTYPE model = new VEGETABLESPARENTTYPE();
            model.GUID = collection["GUID"].ToString() == "" ? Guid.Empty : Guid.Parse(collection["GUID"].ToString());
            model.VEGETABLESNAME = collection["VEGETABLESNAME"].ToString();
            model.SEQUENCE = Convert.ToDecimal(collection["SEQUENCE"].ToString());
            model.CREATEDATETIME = DateTime.Now;
            model.CREATEUSERID = Guid.NewGuid();
            model.CREATEUSERNAME = "1";
            model.ISDELETED = 0;
            return model;
        }
    }
}
