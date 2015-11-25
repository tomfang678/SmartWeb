using Smart.Framework.BLL;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.Utility;
using Smart.Framework.Web;

namespace SmartWeb.Controllers
{
    /// <summary>
    /// 招聘信息
    /// </summary>
    public class RecruitmentController : BaseApi<Recruitment, sd_resume>
    {
        public ActionResult Index()
        {
            var list = new Recruitment().FindALL();
            ViewData["job"] = list;
            return View();
        }

        [HttpGet]
        public JsonResult GetJobList(int PageIndex = 1, int PageSize = 20)
        {
            var list = new Recruitment().FindByPage(PageSize, PageIndex);
            return Json(list);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = new Recruitment().Find(id);
            return Json(model);
        }

        [HttpPost]
        public JsonResult SendResume(string model)
        {
            try
            {
                var code = Request.QueryString["code"];
                var sesion = Session["ValidateCode"] != null ? Session["ValidateCode"].ToString().ToLower() : "";
                if (code != sesion)
                {
                    return Json(0);
                }
                if (!string.IsNullOrEmpty(model))
                {
                    var entity = SerializeHelper.JsonDeserialize<sd_resume>(model);
                    entity.addtime = DateTime.Now;
                    var check = new Resume().FindByWhere(entity.username, entity.phone);
                    if (check != null)
                    {
                        new Resume().Delete(check);
                    }
                    var list = new Resume().Add(entity);
                    return Json(list);
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
