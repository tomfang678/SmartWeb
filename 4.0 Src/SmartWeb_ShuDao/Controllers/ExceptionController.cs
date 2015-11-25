using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    public class ExceptionController : BaseController
    {
        //
        // GET: /Exception/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult NotAccess()
        {
            return View();
        }
    }
}
