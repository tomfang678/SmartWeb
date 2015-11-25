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
    public class CategoryController : AdministratorController
    {

        //GET: /Admin/Category/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
                ViewData["category"] = new Category().Find(int.Parse(Request["id"].ToString()));
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
            sd_category model = new sd_category();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                var list = JsonConvert.DeserializeObject<List<sd_category>>(models);
                result.Data = new Category().Add(list);
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
            var t = new Category().FindALL();
            return Json(t, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            sd_category model = new sd_category();
            //List<sd_category> list = new List<sd_category>();
            if (models != null)
            {
                model = JsonConvert.DeserializeObject<sd_category>(models);
                var t = new Category().Update(model);
                return Json(t);
            }
            return null;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            List<sd_category> list = new List<sd_category>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<sd_category>>(models);
                foreach (var model in list)
                {
                    var t = new Category().Update(model);
                }
            }
            return Json(list);

        }


        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                if (models != null)
                {
                    var list = JsonConvert.DeserializeObject<List<sd_category>>(models);
                    foreach (var item in list)
                    {
                        new Category().Delete(item);
                    }
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}
