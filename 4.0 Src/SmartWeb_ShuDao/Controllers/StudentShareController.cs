using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.Model;

namespace SmartWeb.Controllers
{
    public class StudentShareController : Controller
    {
        //
        // GET: /StudentShare/

        public ActionResult Index()
        {
            ViewBag.studentShare = new StudentShare().FindByPage(1, 20);
            return View();
        }
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new StudentShare().Find(pid);
                if (model == null)
                {
                    model = new sd_studentshare();
                }
                ViewBag.studentShareDetail = model;
            }
            return View();
        }
    }
}
