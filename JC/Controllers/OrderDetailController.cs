using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
using JC.Common;

namespace JC.Controllers
{
    public class OrderDetailController : BaseController
    {
        //
        // GET: /OrderDetail/

        public ActionResult List(string q_orderid = "")
        {
            Guid orderid = Tool.String2Guid(q_orderid);
            List<ORDERDETAIL> list = DbContext.ORDERDETAIL.Where(m => m.ORDERID == orderid).ToList();

            return PartialView(list);
        }

    }
}
