using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.Model;
using Smart.Framework.BLL;
using Smart.Framework.Utility;
namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class SystemInfoController : AdministratorController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Module()
        {
            return View();
        }
        #region 基本设置
        public ActionResult BasicEdit()
        {
            sd_commondata commondata = new sd_commondata();
            if (Request["id"] != null)
            {
                commondata = new Commondata().Find(Converter.ToInt(Request["id"].ToString()));
            }
            ViewData["commondata"] = commondata;
            return View();
        }

        public ActionResult BasicAdd()
        {
            sd_commondata data = new sd_commondata();
            if (Request["id"] != null)
            {
                ViewData["id"] = Request["id"].ToString();
                ViewData["datainfo"] = new Commondata().Find(Converter.ToInt(Request["id"].ToString()));
            }
            else
            {
                ViewData["id"] = null;
            }
            ViewData["module"] = new Module().GetModuleByParentId();
            return View();
        }
        #endregion

        [HttpGet]
        [ValidateInput(false)]
        public JsonResult GetModule(string models)
        {
            JsonResult result = new JsonResult();
            result.Data = new Commondata().FindALL();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [HttpGet]
        [ValidateInput(false)]
        public JsonResult GetModuleByParentId(int id)
        {
            //JsonResult result = new JsonResult();
            var data = new Commondata().FindByModuleId(id);
            // result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //return result;
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string models)
        {

            if (models != null)
            {
                sd_commondata info = new sd_commondata();
                info = JsonConvert.DeserializeObject<sd_commondata>(models);
                info.newstime = DateTime.Now;
                info.addTime = DateTime.Now;
                new Commondata().Add(info);
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(string models)
        {
            if (models != null)
            {
                sd_commondata info = new sd_commondata();
                info = JsonConvert.DeserializeObject<sd_commondata>(models);
                info.newstime = DateTime.Now;
                info.updateTime = DateTime.Now;
                bool result = new Commondata().Update(info);
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BasicSetting()
        {
            Commondata bll = new Commondata();
            ViewData["commondata"] = bll.FindALL();
            return View();
        }

        [HttpPost]
        public JsonResult Destroy()
        {
            if (Request["id"] != null)
            {
                var t = new Commondata().Delete(Converter.ToInt(Request["id"].ToString()));
                return Json(t);
            }
            return Json(false);
        }
    }
}
