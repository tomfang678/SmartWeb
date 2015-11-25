using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 资料下载
    /// </summary>
    public class DownloadController : BaseController
    {
        //
        // GET: /Download/
        public ActionResult Index()
        {
            ViewData["downloadlist"] = new Download().FindALL();
            return View();
        }
    }
}
