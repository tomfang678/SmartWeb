using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class FeedBackController : AdministratorController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Get(int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            FeedBack bll = new FeedBack();
            var t = bll.FindByPage(pageSize, page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpGet]
        public JsonResult GetMsg(int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            FeedBack bll = new FeedBack();
            var t = bll.FindByPage(pageSize, page);
            return Json(t);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(string models)
        {
            try
            {
                if (models != null)
                {
                    var list = JsonConvert.DeserializeObject<List<sd_message>>(models);
                    foreach (var item in list)
                    {
                        new FeedBack().Delete(item);
                    }
                }
                return Json(true);
            }
            catch (System.Exception ex)
            {
                return Json(false);
            }
        }
    }
}
