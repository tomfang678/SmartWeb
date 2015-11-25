using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    public class BizExceptionController : Controller
    {
        //
        // GET: /BizException/

        public ActionResult Index()
        {
            if (Request["errorid"] != null)
            {
                var id = Request["errorid"].ToString();
                var data = Caching.Get(id);
                ViewBag.errors = data;
                Caching.Remove(id);
            }
            return View();
        }
    }
}
