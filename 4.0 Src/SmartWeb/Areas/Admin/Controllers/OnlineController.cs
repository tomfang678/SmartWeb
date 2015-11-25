using Newtonsoft.Json.Linq;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class OnlineController : AdministratorController
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddOnline(string models)
        {
            JsonResult result = new JsonResult();
            if (models != null)
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sd_online>>(models.ToString());
                if (list.Count > 0)
                {
                    result.Data = new Online().Add(list);
                }
            }
            else
            {
                result.Data = false;
            }
            return result;
        }
        public JsonResult GetOnlineList()
        {
            Online bll = new Online();
            return Json(bll.FindALL(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DeleteOnline(string models)
        {
            JsonResult result = new JsonResult();
            sd_online info = new sd_online();
            if (models != null)
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sd_online>>(models.ToString());
                result.Data = new Online().Delete(list);
            }
            else
            {
                result.Data = false;
            }
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateOnline(string models)
        {

            JsonResult result = new JsonResult();
            if (models != null)
            {
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sd_online>>(models.ToString());
                if (list.Count > 0)
                {
                    result.Data = new Online().Update(list);
                }
            }
            else
            {
                result.Data = false;
            }
            return result;
        }
    }
}
