using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;
using Smart.Framework.Model;
using Smart.Framework.BLL;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class NewsTypeController : AdministratorController
    {
        //
        // GET: /Admin/NewsType/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
                ViewData["category"] = new NewsType().Find(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["category"] = null;
            }
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(string models)
        {
            JsonResult result = new JsonResult();
            if (models != null)
            {
                var t = JsonConvert.DeserializeObject<List<sd_newstype>>(models);
                var ety = new NewsType().Add(t);
                if (ety != null)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
                }
            }
            else
            {
                result.Data = false;
            }
            return result;
        }


        [HttpGet]
        public JsonResult Get()
        {
            JsonResult result = new JsonResult();
            List<sd_newstype> list = new NewsType().FindALL().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            sd_newstype model = new sd_newstype();
            List<sd_newstype> list = new List<sd_newstype>();
            if (models != null)
            {
                model = JsonConvert.DeserializeObject<sd_newstype>(models);
                var t = new NewsType().Update(model);
            }
            return Json(list);
        }

        [HttpPost]
        public JsonResult Delete(string models)
        {
            if (models != null)
            {
                var list = JsonConvert.DeserializeObject<List<sd_newstype>>(models);
                foreach (var item in list)
                {
                    new NewsType().Delete(list);
                }
            }
            return Json(true);
        }
    }
}
