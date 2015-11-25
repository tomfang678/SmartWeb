using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.Model;

namespace SmartWeb.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/

        public ActionResult Index()
        {
            ViewData["contactus"] = new Commondata().FindByKey("联系方式");
            return View();
        }
    }
}
