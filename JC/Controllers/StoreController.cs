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
    public class StoreController : Controller
    {
        private jincaiEntities db = new jincaiEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View(db.STOREINFO.ToList());
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(string id = "")
        {
            Guid guid = Tool.String2Guid(id);
            STOREINFO storeinfo = db.STOREINFO.Find(guid);
            if (storeinfo == null)
            {
                return HttpNotFound();
            }
            return View(storeinfo);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(STOREINFO storeinfo)
        {
            if (ModelState.IsValid)
            {
                storeinfo.GUID = Guid.NewGuid();
                db.STOREINFO.Add(storeinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeinfo);
        }

        //
        // GET: /Store/Edit/5

        public ActionResult Edit(string id = "")
        {
            Guid guid = Tool.String2Guid(id);
            STOREINFO storeinfo = db.STOREINFO.Find(guid);
            if (storeinfo == null)
            {
                return HttpNotFound();
            }
            return View(storeinfo);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(STOREINFO storeinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeinfo);
        }

        //
        // GET: /Store/Delete/5

        public ActionResult Delete(string id = "")
        {
            Guid guid = Tool.String2Guid(id);
            STOREINFO storeinfo = db.STOREINFO.Find(guid);
            if (storeinfo == null)
            {
                return HttpNotFound();
            }
            return View(storeinfo);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            STOREINFO storeinfo = db.STOREINFO.Find(id);
            db.STOREINFO.Remove(storeinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}