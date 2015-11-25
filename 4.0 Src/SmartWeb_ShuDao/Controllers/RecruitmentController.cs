using Smart.Framework.BLL;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 招聘信息
    /// </summary>
    public class RecruitmentController : BaseController
    {
        //
        // GET: /Job/

        public ActionResult Index()
        {
            var list = new Recruitment().FindALL();
            ViewData["job"] = list;
            return View();
        }

        [HttpGet]
        public JsonResult Get()
        {
            var list = new Recruitment().FindALL();
            return Json(list);
        }

        [HttpGet]
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new Recruitment().Find(pid);
                ViewData["jobDetail"] = model;
            }
            return View();
        }
        public ActionResult SendResume()
        {
            return View();
        }
    }
}
