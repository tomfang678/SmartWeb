using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class AboutController : AdministratorController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCompanyAboutList()
        {
            return Json(new About().FindALL());
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateAbout(string models)
        {
            List<sd_about> list = new List<sd_about>();
            if (models != null)
            {
                sd_about about = JsonConvert.DeserializeObject<sd_about>(models);
                about.updatetime = DateTime.Now;
                var t = new About().Update(about);
                return Json(t, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AboutDestroy(string models)
        {
            List<Guid> list = new List<Guid>();
            var ts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sd_about>>(models);
            foreach (var item in ts)
            {
                var t = new About().Delete(item);
            }
            return Json(list);
        }

        [HttpPost]
        public ActionResult PublishAbout()
        {
            var address = Request["address"];
            var phone = Request["phone"];
            var fax = Request["fax"];
            var descript = Request["descript"];
            var content = Request["content"];
            sd_about About = new sd_about();
            if (address != null)
            {
                About.address = address.ToString();
            }
            if (phone != null)
            {
                About.phone = phone.ToString();
            }
            if (fax != null)
            {
                About.fax = fax.ToString();
            }
            if (descript != null)
            {
                About.shortDesc = descript.ToString().Replace("&lt;", "<").Replace("&gt;", ">"); ;
            }
            if (content != null)
            {
                About.content = content.ToString().Replace("&lt;", "<").Replace("&gt;", ">"); ;
            }
            About.id = Guid.NewGuid();
            JsonData data = new JsonData();
            About bll = new About();
            var model = bll.Add(About);
            data.Success = (model != null ? true : false);
            data.Message = "新闻添加成功";
            return Json(data);
        }
    }
}
