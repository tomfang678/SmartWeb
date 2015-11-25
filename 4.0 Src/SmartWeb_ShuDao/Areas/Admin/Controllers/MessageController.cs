using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    /// <summary>
    /// 用户反馈信息
    /// </summary>
    public class MessageController : AdministratorController
    {
        //
        // GET: /Admin/Curriculum/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModel()
        {
            if (Request["id"] != null)
            {
              //  ViewData["curriculum"] = new CurriculumBLL().GetCurriculumListById(int.Parse(Request["id"].ToString()));
            }
            else
            {
                ViewData["curriculum"] = null;
            }
            return View();
        }
        public ActionResult Add()
        {
            var t = Request.QueryString["id"];
            if (t != null)
            {
              //  ViewData["curriculum"] = new CurriculumBLL().GetCurriculumListById(int.Parse(t.ToString()));
            }
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddCurriculum(string models)
        {
            //CurriculumInfo curriculum = new CurriculumInfo();
            JsonResult result = new JsonResult();
            //if (models != null)
            //{
            //    curriculum = JsonConvert.DeserializeObject<CurriculumInfo>(models);
            //    TimeSpan? day = curriculum.enddate - curriculum.startdate;
            //    if (string.IsNullOrEmpty(curriculum.daterange))
            //    {
            //        curriculum.daterange = (day.Value.TotalDays + 1).ToString();
            //    }
            //    result.Data = new CurriculumBLL().AddCurriculums(curriculum);
            //    result.Data = true;
            //}
            //else
            //{
            //    result.Data = false;
            //}
            return result;
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Request.QueryString(PageIndex);
            JsonResult result = new JsonResult();
            //CurriculumBLL bll = new CurriculumBLL();
            //var t = bll.GetCurriculumList(1, 20).Data;
            //return Json(t, JsonRequestBehavior.AllowGet);
            return null;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(string models)
        {
            //CurriculumInfo model = new CurriculumInfo();
            //List<CurriculumInfo> list = new List<CurriculumInfo>();
            //if (models != null)
            //{
            //    model = JsonConvert.DeserializeObject<CurriculumInfo>(models);
            //    var t = new CurriculumBLL().UpdateCurriculum(model);
            //}
            //return Json(list);
            return null;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateList(string models)
        {
            //CurriculumInfo model = new CurriculumInfo();
            //List<CurriculumInfo> list = new List<CurriculumInfo>();
            //if (models != null)
            //{
            //    try
            //    {
            //        list = JsonConvert.DeserializeObject<List<CurriculumInfo>>(models);
            //        foreach (CurriculumInfo item in list)
            //        {
            //            var t = new CurriculumBLL().UpdateCurriculum(item);
            //        }
            //        return Json(true);
            //    }
            //    catch (Exception ex)
            //    {
            //        return Json(false);
            //    }
            //}
            //return Json(list);
            return null;
        }
        [HttpPost]
        public JsonResult Delete(string models)
        {
            if (models != null)
            {
                //var list = JsonConvert.DeserializeObject<List<CurriculumInfo>>(models);
                //foreach (var item in list)
                //{
                //    new CurriculumBLL().DeleteCurriculum(item.id);
                //}
            }
            return Json(true);
        }
    }
}
