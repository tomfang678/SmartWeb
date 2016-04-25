using Smart.Framework.BLL;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using Smart.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Controllers
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class NewsController : BaseController //BaseApi<News, sd_news>
    {

        [HttpPost]
        public JsonResult GetTopNews()
        {
            var list = new News().GetTop();
            return Json(list);
        }

        [HttpGet]
        public JsonResult GetNewsList(int PageIndex, int PageSize)
        {
            PagedList<sd_news> list = new News().FindByPage(PageSize, PageIndex);
            return Json(list);
        }
        [HttpGet]
        public JsonResult GetNews(int id)
        {
            var list = new News().Find(id);
            return Json(list);
        }
    }
}
