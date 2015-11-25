using Smart.Framework.Utility;
using Smart.Framework.Web;
using SmartWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class AdministratorController : Controller
    {
        protected string hostUrl = "";
        //
        // GET: /Admin/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.hostUrl = "http://" + this.Request.Url.Host;
            this.hostUrl += this.Request.Url.Port.ToString() == "80" ? "" : ":" + this.Request.Url.Port.ToString();
            this.hostUrl += this.Request.ApplicationPath;
            if (!CheckLogin())
            {
                filterContext.Result = RedirectToRoute("Admin_default", new { Controller = "Account", Action = "Login" });
            }
            base.OnActionExecuting(filterContext);
        }
        protected bool CheckLogin()
        {
            HttpCookie cookie = Cookie.Get("jlgl_user");
            if (cookie == null)
            {
                return false;
            }
            else
            {
                if (cookie.Value != "")
                {
                    return true;
                }
                return false;
            }
        }
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }

        public new JsonResult Json(object data, JsonRequestBehavior jsonRequest)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = jsonRequest };
        }

        public new JsonResult Json(object data)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
