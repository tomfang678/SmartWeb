using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class StaffStarController : AdministratorController
    {
        //
        // GET: /Admin/StaffStar/
        public ActionResult Index()
        {
            if (Request["typeid"] != null)
            {
                ViewData["typeid"] = Request["typeid"].ToString();
            }
            return View();
        }
        public ActionResult Add()
        {
            if (Request["id"] != null)
            {
                ViewData["star"] = new StaffStarBLL().GetStaffStarById(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["star"] = null;
            }
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Release(string models)
        {
            StaffStarInfo jobmodel = new StaffStarInfo();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                jobmodel = JsonConvert.DeserializeObject<StaffStarInfo>(models);
                result.Data = new StaffStarBLL().AddStaffStars(jobmodel);
            }
            else
            {
                result.Data = false;
            }
            return result;
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Get(int typeid, int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            StaffStarBLL bll = new StaffStarBLL();
            var t = bll.GetStaffStarList(typeid, page, pageSize);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            StaffStarInfo info = new StaffStarInfo();
            List<StaffStarInfo> list = new List<StaffStarInfo>();
            if (models != null)
            {
                info = JsonConvert.DeserializeObject<StaffStarInfo>(models);
                list.Add(info);
                var t = new StaffStarBLL().UpdateStaffStar(list);
            }
            return Json(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            List<StaffStarInfo> list = new List<StaffStarInfo>();
            if (models != null)
            {
                list = JsonConvert.DeserializeObject<List<StaffStarInfo>>(models);
                var t = new StaffStarBLL().UpdateStaffStar(list);
            }
            return Json(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Delete(string models)
        {
            List<StaffStarInfo> stafflist = new List<StaffStarInfo>();
            List<int> list = new List<int>();

            if (models != null)
            {
                stafflist = JsonConvert.DeserializeObject<List<StaffStarInfo>>(models);
                foreach (var item in stafflist)
                {
                    list.Add(item.id);
                }
                var t = new StaffStarBLL().DeleteStaffStar(list);
            }
            return Json(true);
        }
    }
}
