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
    public class StaffStarController : AdministratorController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
                ViewData["staff"] = new Staff().Find(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["staff"] = null;
            }
            return View();
        }
        public ActionResult Add()
        {
            var t = Request.QueryString["id"];
            if (t != null)
            {
                ViewData["stafflist"] = new Staff().Find(int.Parse(t.ToString()));
            }
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddStaff(string models)
        {
            sd_staff staff = new sd_staff();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                staff = JsonConvert.DeserializeObject<sd_staff>(models);
                staff.addTime = DateTime.Now;
                result.Data = new Staff().Add(staff);
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
            Staff bll = new Staff();
            var t = bll.FindByPage(pageSize, page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            sd_staff model = new sd_staff();
            List<sd_staff> list = new List<sd_staff>();
            if (models != null)
            {
                model = JsonConvert.DeserializeObject<sd_staff>(models);
                model.updateTime = DateTime.Now;
                var t = new Staff().Update(model);
            }
            return Json(list);
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateByList(string models)
        {
            List<sd_staff> list = new List<sd_staff>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<sd_staff>>(models);
                foreach (var model in list)
                {
                    model.updateTime = DateTime.Now;
                    var t = new Staff().Update(model);
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
                var list = JsonConvert.DeserializeObject<List<sd_staff>>(models);
                new Staff().Delete(list);
            }
            return Json(true);
        }
    }
}
