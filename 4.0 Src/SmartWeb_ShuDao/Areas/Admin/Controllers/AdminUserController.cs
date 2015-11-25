using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class AdminUserController : AdministratorController
    {
        //
        // GET: /Admin/AdminUser/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            // AdminUserBLL bll = new AdminUserBLL();
            //  return Json(bll.GetList(), JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
