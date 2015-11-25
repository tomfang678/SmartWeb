using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    public class CurriculumController : Controller
    {
        public ActionResult Index()
        {
            var list = new Curriculum().FindByPage(1, 20);
            ViewBag.curriculumlist = list;
            return View();
        }
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new Curriculum().Find(pid);
                ViewBag.curriculumDetail = model;
                //ViewData["vedioDetail"] = model;
            }
            return View();
        }
    }
}
