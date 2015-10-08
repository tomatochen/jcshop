using JC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JC.Controllers
{
    public class HomeController : Controller
    {

        jincaiEntities db = new jincaiEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            try
            {
                jincaiEntities db2 = new jincaiEntities();
                ViewData["dd"] = db.STOREINFO.ToList().Count;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
