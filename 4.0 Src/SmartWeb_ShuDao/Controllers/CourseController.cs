using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 课程
    /// </summary>
    public class CourseController : BaseController
    {
        //
        // GET: /Course/

        public ActionResult Index()
        {
            var list = new News().GetByNewsCategory((int)NewsTypeEnum.VedioNews);
            ViewData["vedio"] = list;
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
                ViewData["vedioDetail"] = model;
            }
            return View();
        }
    }
}
