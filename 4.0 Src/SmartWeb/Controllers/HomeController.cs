using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System.Drawing;
using Smart.Framework.Contract;
using Smart.Framework.Web;

namespace SmartWeb.Controllers
{
    public class HomeController : SmartControllerBase
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //Response.Redirect("/index.html");
            return View("Index");
        }
        public ActionResult About()
        {
            var data = new Smart.Framework.BLL.About().FindALL();
            if (data.Count() > 0)
            {
                ViewBag.about = data.FirstOrDefault().content;
            }
            return View("About");
        }

        [HttpGet]
        public JsonResult GetQQOnline()
        {
            try
            {
                var list = Caching.Get("zg_qqonline");
                if (list != null)
                {
                    var data = list as PagedList<sd_online>;
                    return Json(data);
                }
                else
                {
                    var data = new Smart.Framework.BLL.Online().FindByPage(10, 1);
                    if (data.Count() > 0)
                    {
                        Caching.Set("zg_qqonline", data, 5);
                        return Json(data);
                    }
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult GetAbout()
        {
            var data = new Smart.Framework.BLL.About().FindByPage(1, 1);
            if (data.Count() > 0)
            {
                return Json(data);
            }
            return Json("");
        }

        [HttpGet]
        public JsonResult GetAboutUsList(int PageIndex, int PageSize)
        {
            var data = new Smart.Framework.BLL.Commondata().FindByPage(PageSize, PageIndex);
            if (data.Count() > 0)
            {
                return Json(data);
            }
            return Json("");
        }

        [HttpGet]
        public JsonResult Detail(string key)
        {
            var data = new Smart.Framework.BLL.Commondata().FindByKey(key);
            if (data != null)
            {
                return Json(data);
            }
            return Json("");
        }

        [HttpPost]
        public JsonResult SendMessage(string models)
        {
            try
            {
                var code = Request.QueryString["code"];
                var sesion = Session["ValidateCode"] != null ? Session["ValidateCode"].ToString().ToLower() : "";
                if (code != sesion)
                {
                    return Json(0);
                }
                if (!string.IsNullOrEmpty(models))
                {
                    var entity = SerializeHelper.JsonDeserialize<sd_message>(models);
                    entity.addtime = DateTime.Now;
                    entity.ip = Fetch.UserIp;
                    var check = new FeedBack().Check(entity.name, entity.email, entity.contact, entity.addtime);
                    if (!check)
                    {
                        var list = new FeedBack().Add(entity);
                        return Json(list);
                    }
                    else
                    {
                        return Json(1);
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult ValidateCode()
        {
            string str = "";
            var img = new ValidateCode_Style1().CreateImage(out str);
            Session["ValidateCode"] = str;
            return File(img, @"image/jpeg");
        }

        [HttpGet]
        public JsonResult GetStaffList(int PageIndex, int PageSize)
        {
            var data = new Smart.Framework.BLL.Staff().FindByPage(PageSize, PageIndex);
            if (data.Count() > 0)
            {
                return Json(data);
            }
            return Json("");
        }
    }
}
