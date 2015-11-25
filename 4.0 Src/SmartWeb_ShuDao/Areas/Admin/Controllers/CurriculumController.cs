using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.Model;
using Smart.Framework.BLL;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    //<summary>
    //课程表
    //</summary>
    public class CurriculumController : AdministratorController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
                ViewData["curriculum"] = new Curriculum().Find(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["curriculum"] = null;
            }
            return View();
        }
        public ActionResult Add()
        {
            var t = Request.QueryString["id"];
            if (t != null)
            {
                ViewData["curriculum"] = new Curriculum().Find(int.Parse(t.ToString()));
            }
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddCurriculum(string models)
        {
            sd_curriculum curriculum = new sd_curriculum();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                curriculum = JsonConvert.DeserializeObject<sd_curriculum>(models);
                TimeSpan? day = curriculum.enddate - curriculum.startdate;
                if (string.IsNullOrEmpty(curriculum.daterange))
                {
                    curriculum.daterange = (day.Value.TotalDays + 1).ToString();
                }
                result.Data = new Curriculum().Add(curriculum);
                result.Data = true;
            }
            else
            {
                result.Data = false;
            }
            return result;
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Get(int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            Curriculum bll = new Curriculum();
            var t = bll.FindByPage(page, pageSize);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            sd_curriculum model = new sd_curriculum();
            List<sd_curriculum> list = new List<sd_curriculum>();
            if (models != null)
            {
                model = JsonConvert.DeserializeObject<sd_curriculum>(models);
                var t = new Curriculum().Update(model);
            }
            return Json(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            sd_curriculum model = new sd_curriculum();
            List<sd_curriculum> list = new List<sd_curriculum>();
            if (models != null)
            {
                try
                {
                    list = JsonConvert.DeserializeObject<List<sd_curriculum>>(models);
                    foreach (sd_curriculum item in list)
                    {
                        var t = new Curriculum().Update(item);
                    }
                    return Json(true);
                }
                catch (Exception ex)
                {
                    return Json(false);
                }
            }
            return Json(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(string models)
        {
            if (models != null)
            {
                var list = JsonConvert.DeserializeObject<List<sd_curriculum>>(models);
                foreach (var item in list)
                {
                    new Curriculum().Delete(item);
                }
            }
            return Json(true);
        }
    }
}
