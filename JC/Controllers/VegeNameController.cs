using JC.Common;
using JC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JC.Controllers
{
    public class VegeNameController : BaseController
    {
        //
        // GET: /VegeName/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public JsonResult List(string sidx, string sord, int page, int rows)
        {
            var query = from n in DbContext.VEGETABLESNAMEBASE select n;
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
            return list.GetJson<VEGETABLESNAMEBASE>(sidx, sord, page, rows, JsonRequestBehavior.AllowGet,
                new string[] { "GUID", "VEGETABLESNAME", "VEGETABLESDES", "BIGUNIT", "SMALLUNIT", 
                    "PACKRULE","TYPENAME", 
                    "SMALLIMAGEURL", "SEQUENCE" });
        }
        public ActionResult Create(string id = "")
        {
            VEGETABLESNAMEBASE model = new VEGETABLESNAMEBASE();
            if (id != "")
            {
                Guid guid = Tool.String2Guid(id);
                model = DbContext.VEGETABLESNAMEBASE.FirstOrDefault(o => o.GUID == guid);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                VEGETABLESNAMEBASE model = FillModel(collection);
                if (model.GUID == Guid.Empty)
                {
                    model.GUID = Guid.NewGuid();
                    DbContext.VEGETABLESNAMEBASE.Add(model);
                    AddVegeInfo(model);
                }
                else
                {
                    DbContext.Entry(model).State = System.Data.EntityState.Modified;
                    UpdateVegeInfo(model);
                }
                if (DbContext.SaveChanges() >= 0)
                {
                    return new JsonM().ToJson(true, MsgHelper.SaveSuccess, null, model.GUID.ToString());
                }
                else
                {
                    return new JsonM().ToJson(false, MsgHelper.SaveFail);
                }
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.SaveFail);
            }
        }
        /// <summary>
        /// 添加菜品名称时，根据选择的区域自动生成VEGETABLESINFO表中的数据
        /// </summary>
        /// <param name="model"></param>
        private void AddVegeInfo(VEGETABLESNAMEBASE model)
        {
            if (model.BUSINESSAREAIDS != "")
            {
                string[] arrArea = model.BUSINESSAREAIDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] arrAreaName = model.BUSINESSAREANAMES.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrArea.Length; i++)
                {
                    VEGETABLESINFO vimodel = new VEGETABLESINFO();
                    vimodel.GUID = Guid.NewGuid();
                    vimodel.BIGIMAGEURL = model.BIGIMAGEURL;
                    vimodel.BIGUNIT = model.BIGUNIT;
                    vimodel.CREATEDATETIME = model.CREATEDATETIME;
                    vimodel.CREATEUSERID = model.CREATEUSERID;
                    vimodel.CREATEUSERNAME = model.CREATEUSERNAME;
                    vimodel.ISDELETED = 0;
                    vimodel.PACKRULE = model.PACKRULE;
                    vimodel.SMALLIMAGEURL = model.SMALLIMAGEURL;
                    vimodel.SMALLUNIT = model.SMALLUNIT;
                    vimodel.STOREID = Tool.String2Guid(arrArea[i]);
                    vimodel.STORENAME = arrAreaName[i].ToString();
                    vimodel.TYPEID = model.TYPEID;
                    vimodel.TYPENAME = model.TYPENAME;
                    vimodel.VEGETABLESDES = model.VEGETABLESDES;
                    vimodel.VEGETABLESID = model.GUID;
                    vimodel.VEGETABLESNAME = model.VEGETABLESNAME;
                    DbContext.VEGETABLESINFO.Add(vimodel);
                }

            }

        }
        /// <summary>
        /// 修改菜品名称时，根据选择的区域自动更新VEGETABLESINFO表中的数据
        /// </summary>
        /// <param name="model"></param>
        private void UpdateVegeInfo(VEGETABLESNAMEBASE model)
        {
            var list = DbContext.VEGETABLESINFO.Where(o => o.VEGETABLESID == model.GUID).ToList();
            string[] arrArea = model.BUSINESSAREAIDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] arrAreaName = model.BUSINESSAREANAMES.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var vimodel in list)
            {
                vimodel.BIGIMAGEURL = model.BIGIMAGEURL;
                vimodel.BIGUNIT = model.BIGUNIT;
                vimodel.CREATEDATETIME = model.CREATEDATETIME;
                vimodel.CREATEUSERID = model.CREATEUSERID;
                vimodel.CREATEUSERNAME = model.CREATEUSERNAME;
                vimodel.PACKRULE = model.PACKRULE;
                vimodel.SMALLIMAGEURL = model.SMALLIMAGEURL;
                vimodel.SMALLUNIT = model.SMALLUNIT;
                vimodel.TYPEID = model.TYPEID;
                vimodel.TYPENAME = model.TYPENAME;
                vimodel.VEGETABLESDES = model.VEGETABLESDES;
                vimodel.VEGETABLESNAME = model.VEGETABLESNAME;
                if (arrArea.Contains(vimodel.STOREID.ToString().ToUpper()))
                {
                    vimodel.ISDELETED = 0;
                }
                else
                {
                    vimodel.ISDELETED = 1;
                }
                DbContext.Entry(vimodel).State = System.Data.EntityState.Modified;
            }
            for (int i = 0; i < arrArea.Length; i++)
            {
                if (list.Where(o => o.STOREID == Tool.String2Guid(arrArea[i])).ToList().Count() == 0)
                {
                    VEGETABLESINFO vimodel = new VEGETABLESINFO();
                    vimodel.GUID = Guid.NewGuid();
                    vimodel.BIGIMAGEURL = model.BIGIMAGEURL;
                    vimodel.BIGUNIT = model.BIGUNIT;
                    vimodel.CREATEDATETIME = model.CREATEDATETIME;
                    vimodel.CREATEUSERID = model.CREATEUSERID;
                    vimodel.CREATEUSERNAME = model.CREATEUSERNAME;
                    vimodel.ISDELETED = 0;
                    vimodel.PACKRULE = model.PACKRULE;
                    vimodel.SMALLIMAGEURL = model.SMALLIMAGEURL;
                    vimodel.SMALLUNIT = model.SMALLUNIT;
                    vimodel.STOREID = Tool.String2Guid(arrArea[i]);
                    vimodel.STORENAME = arrAreaName[i].ToString();
                    vimodel.TYPEID = model.TYPEID;
                    vimodel.TYPENAME = model.TYPENAME;
                    vimodel.VEGETABLESDES = model.VEGETABLESDES;
                    vimodel.VEGETABLESID = model.GUID;
                    vimodel.VEGETABLESNAME = model.VEGETABLESNAME;
                    DbContext.VEGETABLESINFO.Add(vimodel);
                }
            }
        }
        /// <summary>
        /// 修改菜品名称时，根据选择的区域自动更新VEGETABLESINFO表中的数据
        /// </summary>
        /// <param name="model"></param>
        private void DelVegeInfo(VEGETABLESNAMEBASE model)
        {
            var list = DbContext.VEGETABLESINFO.Where(o => o.VEGETABLESID == model.GUID).ToList();
            foreach (var vimodel in list)
            {
                vimodel.ISDELETED = 1;
                vimodel.DELETEDATE = model.DELETEDATE;
                vimodel.DELETEUSER = model.DELETEUSER;
                DbContext.Entry(vimodel).State = System.Data.EntityState.Modified;
            }
        }
        private VEGETABLESNAMEBASE FillModel(FormCollection collection)
        {
            VEGETABLESNAMEBASE model = new VEGETABLESNAMEBASE();
            model.GUID = Tool.String2Guid(collection["GUID"].ToString());
            model.SEQUENCE = Convert.ToDecimal(collection["SEQUENCE"] == null ? "0" : collection["SEQUENCE"].ToString());
            model.CREATEDATETIME = DateTime.Now;
            model.CREATEUSERID = Guid.NewGuid();
            model.CREATEUSERNAME = "管理员";
            model.BIGIMAGEURL = "../Upload/" + collection["hid_path"];
            model.SMALLIMAGEURL = "../Upload/" + collection["hid_path"];
            model.BIGUNIT = collection["BIGUNIT"];
            model.PACKRULE = Convert.ToInt32(collection["PACKRULE"]);
            model.REMARK = collection["REMARK"];
            model.SEQUENCE = Convert.ToDecimal(collection["SEQUENCE"]);
            model.SMALLUNIT = collection["SMALLUNIT"];
            model.VEGETABLESDES = collection["VEGETABLESDES"];
            model.VEGETABLESNAME = collection["VEGETABLESNAME"];
            model.ISDELETED = 0;
            //model.TYPEID = "";
            //model.TYPENAME = "";
            model.BUSINESSAREAIDS = collection["BUSINESSAREAIDS"];
            model.BUSINESSAREANAMES = collection["BUSINESSAREANAMES"];
            return model;
        }
        public JsonResult Delete(string id = "")
        {
            try
            {
                Guid guid = Guid.Parse(id);
                var model = DbContext.VEGETABLESNAMEBASE.First(m => m.GUID == guid);
                model.ISDELETED = 1;
                model.DELETEUSER = "管理员";
                model.DELETEDATE = DateTime.Now;
                DbContext.Entry(model).State = System.Data.EntityState.Modified;
                DelVegeInfo(model);
                DbContext.SaveChanges();
                return new JsonM().ToJson(true, MsgHelper.DeleteSuccess);
            }
            catch (Exception ex)
            {
                return new JsonM().ToJson(false, MsgHelper.DeleteFail);
            }
        }
    }
}
