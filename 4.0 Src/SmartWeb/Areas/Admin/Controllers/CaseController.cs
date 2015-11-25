using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class CaseController : AdministratorController
    {
        //
        // GET: /Admin/Case/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            if (Request["id"] != null)
            {
                ViewData["Case"] = new Case().Find(Converter.ToInt(Request["id"].ToString()));
            }
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetList(int pageSize, int page)
        {
            JsonResult result = new JsonResult();
            var t = new Case().FindByPage(pageSize, page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            try
            {
                List<sd_case> list = new List<sd_case>();
                if (models != null)
                {
                    sd_case about = JsonConvert.DeserializeObject<sd_case>(models);
                    about.updatetime = DateTime.Now;
                    list.Add(about);
                    foreach (var item in list)
                    {
                        var t = new Case().Update(item);
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(string models)
        {
            bool result = false;
            if (models != null)
            {
                List<sd_case> list = JsonConvert.DeserializeObject<List<sd_case>>(models);
                result = new Case().Delete(list);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(string models)
        {
            sd_case entity = new sd_case();
            JsonResult result = new JsonResult();
            Case bll = new Case();
            if (models != null)
            {
                {
                    entity = JsonConvert.DeserializeObject<sd_case>(models);
                    entity.addtime = DateTime.Now;
                }
                result.Data = bll.Add(entity);
            }
            return result;
        }
    }
}
