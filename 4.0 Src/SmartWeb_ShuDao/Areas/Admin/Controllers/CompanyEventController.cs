using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class CompanyEventController : AdministratorController
    {
        //private CompanyEventBLL bll = new CompanyEventBLL();

        //
        // GET: /Admin/CompanyEvent/

        public ActionResult Index()
        {

            //var t = bll.GetCompanyEventList(1, int.MaxValue).Data;
            //if (t != null)
            //{
            //    ViewData["eventlist"] = t;
            //}
            return View();
        }
        public ActionResult Edit()
        {

            //if (Request["id"] != null)
            //{
            //    ViewData["events"] = bll.GetCompanyEventListById(int.Parse(Request["id"].ToString()));
            //}
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Get()
        {
            JsonResult result = new JsonResult();
            //var t = bll.GetCompanyEventList(1, 500);
           // return Json(t, JsonRequestBehavior.AllowGet);
            return result;
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(string models)
        {
            //CompanyEventInfo model = new CompanyEventInfo();
            //if (models != null)
            //{
            //    model = JsonConvert.DeserializeObject<CompanyEventInfo>(models);
            //    var t = new CompanyEventBLL().UpdateCompanyEvent(model);
            //}
            return Json(true);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Add(string models)
        {
            if (models != null)
            {
                //var companyevent = JsonConvert.DeserializeObject<CompanyEventInfo>(models);
                //companyevent.addtime = DateTime.Now;
                //companyevent.year = companyevent.newstime.Value.Year;
                //new CompanyEventBLL().AddCompanyEvents(companyevent);

            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                //new CompanyEventBLL().DeleteCompanyEvent(id);
                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(false);
            }
        }
    }
}
