using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class HomeController : AdministratorController
    {
        //
        // GET: /Admin/Admin/
        // [Authorize]
        public ActionResult Index()
        {
            //Parallel.Invoke(() =>
            //    {
            //        //月访问量
            //        //ViewData["visit"] = GetTodayVist();
            //        //ViewData["appoint"] = TodayAppointmentList();
            //        //ViewData["feedback"] = TodayFeedBackList();
            //        //ViewData["resume"] = TodayResumeList();
            //    });
            return View();
        }
        /// <summary>
        /// 今日留言反馈
        /// </summary>
        /// <returns></returns>
        //public List<MessageInfo> TodayFeedBackList()
        //{
        //    return new FeedBackBLL().GetTodayFeedBackList() as List<MessageInfo>;
        //}

        /// <summary>
        /// 今日预约
        /// </summary>
        /// <returns></returns>
        //public List<AppointInfo> TodayAppointmentList()
        //{
        //    return new AppointmentBLL().GetTodayAppointList() as List<AppointInfo>;
        //}

        /// <summary>
        /// 今日在线简历
        /// </summary>
        /// <returns></returns>
        //public List<ResumeInfo> TodayResumeList()
        //{
        //    return new ResumeBLL().GetTodayResumeList() as List<ResumeInfo>;
        //}
        //public ActionResult VisDetail(string ip)
        //{
        //    return Json(new VisitBLL().GetVistDetail(ip));
        //}
        //public ActionResult DayStack()
        //{
        //    ViewData["dayvist"] = new VisitBLL().GetVisitByEveryDay();
        //    return View();
        //}
        //public ActionResult YearStack(int top, DateTime time)
        //{
        //    ViewData["yearvist"] = new VisitBLL().GetVisitByYear(top, time);
        //    return View();
        //}
        //[HttpPost]
        //public JsonResult ToDayStack()
        //{
        //    List<VisitsInfo> list = new List<VisitsInfo>();
        //    DataTable dt = new VisitBLL().GetVisitByToDay();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(
        //          new VisitsInfo
        //          {
        //              Ip = row["ip"].ToString(),
        //              num = Convert.ToInt32(row["num"].ToString())
        //          }
        //        );
        //    }
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        //public DataTable GetTodayVist()
        //{
        //    VisitBLL bll = new VisitBLL();
        //    return bll.GetVisitByToDay();
        //}
    }
}
