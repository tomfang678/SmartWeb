using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class JobController : AdministratorController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JobAdd()
        {
            if (Request["id"] != null)
            {
                ViewData["job"] = new Recruitment().Find(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["job"] = null;
            }
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult JobRelease(string models)
        {
            sd_job jobmodel = new sd_job();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                jobmodel = JsonConvert.DeserializeObject<sd_job>(models);
                jobmodel.addtime = DateTime.Now;
                result.Data = new Recruitment().Add(jobmodel);
            }
            else
            {
                result.Data = false;
            }
            return result;
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult GetJobList(int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            Recruitment bll = new Recruitment();
            var t = bll.FindByPage(pageSize, page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateJob(string models)
        {
            sd_job info = new sd_job();
            if (models != null)
            {
                info = JsonConvert.DeserializeObject<sd_job>(models);
                info.addtime = DateTime.Now;
                var t = new Recruitment().Update(info);
                return Json(t);
            }
            return Json(false);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Destroy(string models)
        {
            if (!string.IsNullOrEmpty(models))
            {
                var info = JsonConvert.DeserializeObject<List<sd_job>>(models);
                var t = new Recruitment().Delete(info);
                return Json(t);
            }
            return Json(false);
        }

    }
}
