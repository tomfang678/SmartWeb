using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class ModuleController : AdministratorController
    {
        //
        // GET: /Admin/Module/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Get()
        {
            List<sd_module> modules = new List<sd_module>();
            var list = Caching.Get("zg_menu");
            if (list != null)
            {
                modules = list as List<sd_module>;
            }
            else
            {
                modules = new Module().FindALLModuleList();
                Caching.Set("zg_menu", modules, 10);
            }
            return Json(modules, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Add(string models)
        {
            JsonResult result = new JsonResult();
            Module bll = new Module();
            List<sd_module> lst = new List<sd_module>();
            lst = JsonConvert.DeserializeObject<List<sd_module>>(models);
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    bll.Add(item);
                }
                result.Data = lst;
            }
            //清除缓存
            Cookie.Remove("zg_menu");
            return result;
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(string models)
        {
            List<sd_module> list = new List<sd_module>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<sd_module>>(models);
                var t = new Module().Update(list);
            }
            //清除缓存
            Cookie.Remove("zg_menu");
            return Json(list);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Delete(string models)
        {
            List<sd_module> list = new List<sd_module>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<sd_module>>(models);
                var t = new Module().Delete(list);
            }
            //清除缓存
            Cookie.Remove("zg_menu");
            return Json(list);
        }
    }
}
