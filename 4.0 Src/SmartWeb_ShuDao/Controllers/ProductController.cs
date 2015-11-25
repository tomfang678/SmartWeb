using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace ShuDaoWeb.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["product"] = new Product().FindALL();
            return View();
        }

        public ActionResult Detail()
        {
            var id = Request.QueryString["id"];
            int pid = 0;
            var i = int.TryParse(id, out pid);
            if (!string.IsNullOrEmpty(id) && i)
            {
                var model = new Product().Find(pid);
                ViewData["productDetail"] = model;
            }
            return View();
        }
    }
}