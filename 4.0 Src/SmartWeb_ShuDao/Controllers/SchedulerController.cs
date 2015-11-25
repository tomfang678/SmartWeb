using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 课程安排
    /// </summary>
    public class SchedulerController : BaseController
    {
        //
        // GET: /Scheduler/

        public ActionResult Index()
        {
            return View();
        }

    }
}
