using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
namespace ShuDaoWeb.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // sd_about sd = new sd_about();
            //  var model = new Curriculum().GetScheduleList(5);
            //    ViewBag.ScheduleList = model;
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
        public ActionResult ValidateCode()
        {
            string str = "";
            var img = new ValidateCode_Style1().CreateImage(out str);
            Session["ValidateCode"] = str;
            return File(img, @"image/jpeg");
        }
    }
}
