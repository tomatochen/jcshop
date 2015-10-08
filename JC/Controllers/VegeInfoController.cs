using JC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JC.Common;
namespace JC.Controllers
{
    public class VegeInfoController : BaseController
    {
        //
        // GET: /VegeInfo/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List(string sidx, string sord, int page, int rows)
        {
            var query = from n in DbContext.VEGETABLESINFO select n;
            query = query.Where(m => m.ISDELETED == 0);

            ////单位名称
            //string BranchName = this.Get("BranchName");
            //if (!string.IsNullOrEmpty(BranchName))
            //{
            //    query = query.Where(m => m.BRANCHNAME.Contains(BranchName));
            //}
            //////姓名
            //string FullName = this.Get("FullName");
            //if (!string.IsNullOrEmpty(FullName))
            //{
            //    query = query.Where(m => m.FULLNAME.Contains(FullName));
            //}
            //////所在科室
            //string SuoZaiKeShi = this.Get("SuoZaiKeShi");
            //if (!string.IsNullOrEmpty(SuoZaiKeShi))
            //{
            //    query = query.Where(m => m.DEPARTMENT.Contains(SuoZaiKeShi));
            //}
            //////在岗状态
            //string zaigangzhuangtai = this.Get("zaigangzhuangtai");
            //if (!string.IsNullOrEmpty(zaigangzhuangtai))
            //{
            //    query = query.Where(m => m.JOBSTATE == zaigangzhuangtai);
            //}
            //////出生年月日
            //DateTime? ChuShengNianYue_s = Tool.StringToDate(this.Get("ChuShengNianYue_s"));
            //DateTime? ChuShengNianYue_end = Tool.StringToDate(this.Get("ChuShengNianYue_end"));
            //query = query.Where(m =>
            //    (ChuShengNianYue_s == null || m.BIRTHDAY >= ChuShengNianYue_s)
            //    && (ChuShengNianYue_end == null || m.BIRTHDAY <= ChuShengNianYue_end));
            ////籍贯
            //string JiGuan = this.Get("JiGuan");
            //if (!string.IsNullOrEmpty(JiGuan))
            //{
            //    query = query.Where(m => m.BIRTHPLACE.Contains(JiGuan));
            //}
            //////身份
            //string ShenFen = this.Get("ShenFen");
            //if (!string.IsNullOrEmpty(ShenFen))
            //{
            //    query = query.Where(m => m.PERSONALIDENTITY.Contains(ShenFen));
            //}
            ////聘干时间
            //DateTime? pianganshijian_s = Tool.StringToDate(this.Get("pianganshijian_s"));
            //DateTime? pianganshijian_end = Tool.StringToDate(this.Get("pianganshijian_end"));
            //query = query.Where(m =>
            //    (pianganshijian_s == null || m.EMPLOYDATE >= pianganshijian_s)
            //    && (pianganshijian_end == null || m.EMPLOYDATE <= pianganshijian_end));

            ////工作时间
            //DateTime? GongZuoShjian_s = Tool.StringToDate(this.Get("GongZuoShjian_s"));
            //DateTime? GongZuoShjian_end = Tool.StringToDate(this.Get("GongZuoShjian_end"));
            //query = query.Where(m =>
            //    (GongZuoShjian_s == null || m.WORDTIME >= GongZuoShjian_s)
            //    && (GongZuoShjian_end == null || m.WORDTIME <= GongZuoShjian_end));

            //////连续工龄时间
            //DateTime? LianXuGongLingShiJian_s = Tool.StringToDate(this.Get("LianXuGongLingShiJian_s"));
            //DateTime? LianXuGongLingShiJian_end = Tool.StringToDate(this.Get("LianXuGongLingShiJian_end"));
            //query = query.Where(m =>
            //    (LianXuGongLingShiJian_s == null || m.WORKAGE >= LianXuGongLingShiJian_s)
            //    && (LianXuGongLingShiJian_end == null || m.WORKAGE <= LianXuGongLingShiJian_end));

            //////政治面貌
            //string PoliticalStatus = this.Get("PoliticalStatus");
            //if (!string.IsNullOrEmpty(PoliticalStatus))
            //{
            //    query = query.Where(m => m.POLITICALSTATUS.Contains(PoliticalStatus));
            //}
            //////入党时间
            //DateTime? RuDangShiJian_s = Tool.StringToDate(this.Get("RuDangShiJian_s"));
            //DateTime? RuDangShiJian_end = Tool.StringToDate(this.Get("RuDangShiJian_end"));
            //query = query.Where(m =>
            //    (RuDangShiJian_s == null || m.WORKAGE >= RuDangShiJian_s)
            //    && (RuDangShiJian_end == null || m.WORKAGE <= RuDangShiJian_end));


            //////岗位名称
            //string gangweimingcheng = this.Get("gangweimingcheng");
            //if (!string.IsNullOrEmpty(SuoZaiKeShi))
            //{
            //    query = query.Where(m => m.JOBTITLE.Contains(gangweimingcheng));
            //}
            //////从事专业
            //string congshizhuanye = this.Get("congshizhuanye");
            //if (!string.IsNullOrEmpty(congshizhuanye))
            //{
            //    query = query.Where(m => m.MAJOR.Contains(congshizhuanye));
            //}



            //////入党时间
            //DateTime? canjiadangpaishijain_s = Tool.StringToDate(this.Get("canjiadangpaishijain_s"));
            //DateTime? canjiadangpaishijain_end = Tool.StringToDate(this.Get("canjiadangpaishijain_end"));
            //query = query.Where(m =>
            //    (canjiadangpaishijain_s == null || m.JOINPARTYTIME >= canjiadangpaishijain_s)
            //    && (canjiadangpaishijain_end == null || m.JOINPARTYTIME <= canjiadangpaishijain_end));


            //////转正时间
            //DateTime? zhuanzhengshijian_s = Tool.StringToDate(this.Get("zhuanzhengshijian_s"));
            //DateTime? zhuanzhengshijian_end = Tool.StringToDate(this.Get("zhuanzhengshijian_end"));
            //query = query.Where(m =>
            //    (zhuanzhengshijian_s == null || m.JOINPARTYTIME >= zhuanzhengshijian_s)
            //    && (zhuanzhengshijian_end == null || m.JOINPARTYTIME <= zhuanzhengshijian_end));

            //////现职称名称
            //string xianzhichengmingcheng = this.Get("xianzhichengmingcheng");
            //if (!string.IsNullOrEmpty(xianzhichengmingcheng))
            //{
            //    query = query.Where(m => m.NOWTITLE == xianzhichengmingcheng);
            //}
            ////现职称聘任时间
            //DateTime? xianzhichengmingcheng_s = Tool.StringToDate(this.Get("xianzhichengmingcheng_s"));
            //DateTime? xianzhichengmingcheng_end = Tool.StringToDate(this.Get("xianzhichengmingcheng_end"));
            //query = query.Where(m =>
            //    (xianzhichengmingcheng_s == null || m.JOINPARTYTIME >= xianzhichengmingcheng_s)
            //    && (xianzhichengmingcheng_end == null || m.JOINPARTYTIME <= xianzhichengmingcheng_end));
            ////执业资格证名称
            //string PractisingQualification = this.Get("PractisingQualification");

            //if (!string.IsNullOrEmpty(PractisingQualification))
            //{
            //    query = query.Where(m => m.PRACTISINGQUALIFICATION.Contains(PractisingQualification));
            //}




            var list = query.ToList();
            return list.GetJson<VEGETABLESINFO>(sidx, sord, page, rows, JsonRequestBehavior.AllowGet,
                new string[] { "GUID","GUID",  "BIGPRICE","VEGETABLESNAME", "VEGETABLESDES","BIGUNIT", "SMALLUNIT", 
                    "PACKRULE","TYPENAME", 
                    "SMALLIMAGEURL", "SEQUENCE" });
        }
        public JsonResult Delete(string id = "")
        {
            try
            {
                Guid guid = Guid.Parse(id);
                var model = DbContext.VEGETABLESINFO.First(m => m.GUID == guid);
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
        /// <summary>
        /// 修改菜品价格
        /// </summary>
        /// <param name="newbigprice"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ChangeSalePrice(decimal newbigprice, string id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                var model = DbContext.VEGETABLESINFO.First(m => m.GUID == guid);
                if (model.BIGPRICE == newbigprice)
                {
                    //价格相同时不需要修改
                    return new JsonM().ToJson(true, MsgHelper.NoSave, null, id);
                }
                else
                {
                    decimal oldbigprice=model.BIGPRICE;
                    decimal oldsmallpirce=model.SMALLPRICE;
                    model.BIGPRICE = newbigprice;
                    model.SMALLPRICE = model.BIGPRICE / (decimal)model.PACKRULE;
                    DbContext.Entry(model).State = System.Data.EntityState.Modified;
                    AddPriceChangeLog(model, oldbigprice, oldsmallpirce);//菜品价格修改日志
                    DbContext.SaveChanges();
                    return new JsonM().ToJson(true, MsgHelper.SaveSuccess, null, id);
                }
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail, null, id);
            }
        }
        /// <summary>
        /// 菜品价格修改日志
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oldbigprice"></param>
        /// <param name="oldsmallpirce"></param>
        private void AddPriceChangeLog(VEGETABLESINFO model,decimal oldbigprice,decimal oldsmallpirce)
        {
            if (model.BIGPRICE != 0)
            {
                DateTime nowdt= Convert.ToDateTime(DateTime.Now.ToShortDateString());
                var list = DbContext.VEGETABLESINFOCHANGELOG.Where(o => (o.VEGETABLESID == model.VEGETABLESID) && (o.PACKRULE == model.PACKRULE) && (o.STOREID == model.STOREID) && (o.CHANGEDATE == nowdt)).ToList();
                if (list.Count() > 0)
                {
                    foreach (var vimodel in list)
                    {
                        vimodel.NEWBIGPRICE = model.BIGPRICE;//最新大包装价格
                        vimodel.NEWSMALLPRICE = model.SMALLPRICE;//最新小包装价格
                        DbContext.Entry(vimodel).State = System.Data.EntityState.Modified;
                    }
                }
                else
                {
                    VEGETABLESINFOCHANGELOG vimodel = new VEGETABLESINFOCHANGELOG();
                    vimodel.GUID = Guid.NewGuid();
                    vimodel.BIGUNIT = model.BIGUNIT;
                    vimodel.CREATEDATETIME = DateTime.Now;
                    //vimodel.CREATEUSERID = C_UserID;
                    //vimodel.CREATEUSERNAME = C_FullName;
                    vimodel.PACKRULE = model.PACKRULE;
                    vimodel.SMALLUNIT = model.SMALLUNIT;
                    vimodel.STOREID = model.STOREID;
                    vimodel.STORENAME = model.STORENAME;
                    vimodel.TYPEID = model.TYPEID;
                    vimodel.TYPENAME = model.TYPENAME;
                    vimodel.VEGETABLESID = model.VEGETABLESID;
                    vimodel.VEGETABLESNAME = model.VEGETABLESNAME;
                    vimodel.CHANGEDATE = Convert.ToDateTime(DateTime.Now.ToShortDateString());//修改日期
                    vimodel.NEWBIGPRICE = model.BIGPRICE;//最新大包装价格
                    vimodel.NEWSMALLPRICE = model.SMALLPRICE;//最新小包装价格
                    vimodel.OLDBIGPRICE = oldbigprice;//上次大包装价格
                    vimodel.OLDSMALLPRICE = oldsmallpirce;//上次小包装价格
                    DbContext.VEGETABLESINFOCHANGELOG.Add(vimodel);
                }


            }
        }
    }
}
