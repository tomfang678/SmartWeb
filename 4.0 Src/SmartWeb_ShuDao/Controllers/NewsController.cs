using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class NewsController : BaseController
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            ViewData["news"] = new News().GetTop();
            return View();
        }
        public ActionResult Vedio()
        {
            return View();
        }
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new News().Find(pid);
                ViewData["newDetail"] = model;
            }
            return View();
        }

        [HttpPost]
        public JsonResult GetTopNews()
        {
            var list = new News().GetTop();
            return Json(list);
        }
    }
}
