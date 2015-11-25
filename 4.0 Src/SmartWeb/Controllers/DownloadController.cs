using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using Smart.Framework.Contract;
using Smart.Framework.Web;

namespace SmartWeb.Controllers
{
    /// <summary>
    /// 资料下载
    /// </summary>
    public class DownloadController : BaseApi<Download, sd_download>
    {
        //
        // GET: /Download/
        [HttpGet]
        public ActionResult GetDownloadList(int PageIndex, int PageSize)
        {
            IPagedList jsonstr = new Download().FindByPage(PageSize, PageIndex);
            return Json(jsonstr);
        }
    }
}
