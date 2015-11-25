using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 培训信息
    /// </summary>
    public class TrainController : BaseController
    {
        //
        // GET: /Train/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OpenClass()
        {
            return View();
        }
    }
}
