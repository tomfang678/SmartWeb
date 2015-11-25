using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.Model;
using Smart.Framework.BLL;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class ResumeController : AdministratorController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Get(int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            result.Data = new Resume().FindByPage(pageSize, page);
            return result;
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult GetResume(int page, int pageSize)
        {
            return Json(new Resume().FindByPage(pageSize, page));
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            List<sd_resume> list = new List<sd_resume>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<sd_resume>>(models);
                foreach (var item in list)
                {
                    var t = new Resume().Update(item);
                }
            }
            return Json(list);
        }
        public ActionResult Detail()
        {
            if (Request["id"] != null)
            {
                ViewData["model"] = new Resume().Find(int.Parse(Request["id"].ToString()));
            }
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(string models)
        {
            List<sd_resume> resumlelist = new List<sd_resume>();
            if (models != null)
            {
                resumlelist = JsonConvert.DeserializeObject<List<sd_resume>>(models);
                var t = new Resume().Delete(resumlelist);
                return Json(t);
            }
            return Json(false);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(string models)
        {
            JsonResult result = new JsonResult();
            if (models != null)
            {
                var model = JsonConvert.DeserializeObject<sd_resume>(models);
                var t = new Resume().Add(model);
                try
                {
                    result.Data = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}
