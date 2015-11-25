using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class StudentShareController : AdministratorController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var t = Request.QueryString["id"];
            if (t != null)
            {
                ViewData["studentshareinfo"] = new StudentShare().Find(int.Parse(t.ToString()));
            }
            return View();
        }

        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
                ViewData["studentshareinfo"] = new StudentShare().Find(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["studentshareinfo"] = null;
            }
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddStudentShare(string models)
        {
            sd_studentshare StudentShare = new sd_studentshare();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                StudentShare = JsonConvert.DeserializeObject<sd_studentshare>(models);
                result.Data = new StudentShare().Add(StudentShare);
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
            StudentShare bll = new StudentShare();
            var t = bll.FindByPage(page, pageSize);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            sd_studentshare model = new sd_studentshare();
            List<sd_studentshare> list = new List<sd_studentshare>();
            if (models != null)
            {
                model = JsonConvert.DeserializeObject<sd_studentshare>(models);
                var t = new StudentShare().Update(model);
            }
            return Json(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            sd_studentshare model = new sd_studentshare();
            List<sd_studentshare> list = new List<sd_studentshare>();
            if (models != null)
            {
                try
                {
                    list = JsonConvert.DeserializeObject<List<sd_studentshare>>(models);
                    foreach (sd_studentshare item in list)
                    {
                        var t = new StudentShare().Update(item);
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
                var list = JsonConvert.DeserializeObject<List<sd_studentshare>>(models);
                foreach (var item in list)
                {
                    new StudentShare().Delete(item);
                }
            }
            return Json(true);
        }
    }
}
