using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.Utility;
using Smart.Framework.BLL;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class JsonData
    {
        public JsonData()
        {
            Success = false;
            Message = "失败";
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string pwd, string validcode, bool record)
        {
            if (Session["ValidateCode"] == null || validcode.ToLower() != Session["ValidateCode"].ToString().ToLower())
            {
                return Json(new JsonData
                {
                    Message = "验证码错误",
                    Success = false
                });
            }
            JsonData _jdata = new JsonData();
            name = Server.HtmlEncode(name);
            int _code = new AuthenticationBLL().Login(name, pwd);
            if (_code == 1)
            {
                Cookie.Save("jlgl_user", name, 1);
                _jdata.Success = true;
                _jdata.Message = "登录成功！";
            }
            else
            {
                _jdata.Success = false;
                _jdata.Message = "登录失败！";
            }
            return Json(_jdata);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            if (Cookie.Get("jlgl_user") != null)
            {
                Cookie.Remove(Cookie.Get("jlgl_user"));
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ChangePassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePwd()
        {
            //  AppointInfo model = new AppointInfo();
            JsonResult result = new JsonResult();
            var username = Request["username"].ToString();
            var newpwd = Request["newpwd"].ToString();
            var oldpwd = Request["oldpwd"].ToString();
            try
            {
                AuthenticationBLL bll = new AuthenticationBLL();
                var t = bll.ChangePwd(username, oldpwd, newpwd);
                if (t == true)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
                }
                HttpCookie cookie = Cookie.Get("jlgl_user");
                if (cookie != null)
                {
                    Cookie.Remove("jlgl_user");
                }
            }
            catch (Exception ex)
            {
                result.Data = false;
            }
            return result;
        }
    }
}
