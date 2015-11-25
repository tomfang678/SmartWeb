using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    public class CaseController : BaseController
    {
        //
        // GET: /Case/

        public ActionResult Index()
        {
            ViewData["case"] = new Case().FindALL();
            return View();
        }
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new Case().Find(pid);
                ViewData["caseDetail"] = model;
            }
            return View();
        }
    }
}
