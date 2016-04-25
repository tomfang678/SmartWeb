using Smart.Framework.Utility;
using Smart.Framework.Web;
using SmartWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Controllers
{
    public class BaseController : Controller
    {
        private static Dictionary<string, string> Visit = new Dictionary<string, string>();
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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        //protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        //{
        //    Response.Redirect("/BizException/NotFound");
        //    return base.HttpNotFound(statusDescription);
        //}
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    //当系统出现异常-自动告知系统管理员，跳转至默认静态页面
        //    string id = DateTime.Now.ToFileTime().ToString();
        //    var errormsg = filterContext.Exception.Message;
        //    Caching.Set(id, errormsg);
        //    Response.Redirect("/BizException?errorid=" + id);
        //}
    }
}