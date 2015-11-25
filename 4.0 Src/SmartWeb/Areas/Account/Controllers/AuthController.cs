using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Account.BLL;
using Smart.Framework.Utility;
namespace SmartWeb.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Account/Auth/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            string pwd = Encrypt.Encode(password);
            var user = new AccountService().Login(username, pwd);
            return Json(user);
        }
    }
}
