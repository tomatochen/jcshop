using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Models;
namespace JC.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        private jincaiEntities _context;

        protected jincaiEntities DbContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new jincaiEntities();

                }
                return _context;
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        protected string C_UserName
        {
            get
            {
                return Session["USERNAME"].ToString();
            }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        protected string C_FullName
        {
            get
            {
                return Session["FULLNAME"].ToString();
            }
        }
        protected Guid? C_UserID
        {
            get
            {
                if (Session["UserID"] == null)
                {
                    return null;
                }
                else
                {
                    return Guid.Parse(Session["UserID"].ToString());
                }

            }
        }
        
        private List<BUSINESSAREA> _areaList = new List<BUSINESSAREA>();

        
        public List<BUSINESSAREA> AreaList
        {
            get{
                if (_areaList == null || _areaList.Count == 0)
                {
                    _areaList = DbContext.BUSINESSAREA.Where(m => m.ISDELETED == 0).ToList();
                }

                return _areaList;
            } 
        }

        protected List<SelectOption>  AreaListOptions
        {
            get
            {
                List<SelectOption> l = new List<SelectOption>();
                if(AreaList == null || AreaList.Count ==0)
                {
                    return l;
                }

                foreach (var item in AreaList)
                {
                    SelectOption temp = new SelectOption(item.GUID.ToString(), item.AREANAME);
                    l.Add(temp);
                }

                return l;

            }
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (!this.C_UserID.HasValue)
            //{
            //    filterContext.Result = RedirectToAction("Login", "Account");
            //}
            //base.OnAuthorization(filterContext);
        }

        public string Get(string k)
        {
            var o = Request.QueryString[k].ToString();
            if (string.IsNullOrWhiteSpace(o))
            {
                return string.Empty;
            }

            return o.Trim();
        }

        
    }
}
