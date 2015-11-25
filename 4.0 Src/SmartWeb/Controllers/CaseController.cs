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
    public class CaseController : BaseApi<Case, sd_case>
    {

        [HttpGet]
        public JsonResult GetList(int PageIndex, int PageSize)
        {
            PagedList<sd_case> list = new Case().FindByPage(PageSize, PageIndex);
            return Json(list);
        }
        [HttpGet]
        public JsonResult Detail(int id)
        {
            var list = new Case().Find(id);
            return Json(list);
        }
    }
}
