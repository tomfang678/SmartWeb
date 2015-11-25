using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class MenuController : AdministratorController
    {
        //
        // GET: /Admin/Menu/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMenu(string level)
        {
            if (level != null)
            {

            }
            return View();
        }
    }
}
