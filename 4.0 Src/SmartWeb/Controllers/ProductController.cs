using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using Smart.Framework.Contract;
using Smart.Framework.Web;

namespace SmartWeb.Controllers
{
    public class ProductController : BaseApi<Product, sd_product>
    {
        [HttpGet]
        public JsonResult GetList(int PageIndex, int PageSize)
        {
            PagedList<sd_product> list = new Product().FindByPage(PageSize, PageIndex);
            return Json(list);
        }
        [HttpGet]
        public JsonResult Detail(int id)
        {
            var list = new Product().Find(id);
            return Json(list);
        }
    }
}