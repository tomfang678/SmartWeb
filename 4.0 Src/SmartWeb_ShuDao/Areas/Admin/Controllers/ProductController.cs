using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class ProductController : AdministratorController
    {

        public ActionResult Index()
        {
            if (Request["Category"] != null)
            {
                ViewData["category"] = Request["Category"].ToString();
            }
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var t = Request["id"] == null ? 0 : int.Parse(Request["id"].ToString());
            var model = new Product().Find(t);
            ViewData["product"] = model;
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProduct(string models)
        {
            List<sd_product> list = new List<sd_product>();
            if (models != null)
            {
                sd_product about = JsonConvert.DeserializeObject<sd_product>(models);
                about.updateTime = DateTime.Now;
                list.Add(about);
                var t = new Product().Update(list);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Destroy(string models)
        {
            bool result = false;
            if (models != null)
            {
                List<sd_product> about = JsonConvert.DeserializeObject<List<sd_product>>(models);
                result = new Product().Delete(about);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddPorduct(string models)
        {
            sd_product product = new sd_product();
            JsonResult result = new JsonResult();
            Product bll = new Product();
            if (models != null)
            {
                product = JsonConvert.DeserializeObject<sd_product>(models);
                product.addTime = DateTime.Now;
            }
            result.Data = bll.Add(product);
            return result;
        }

        [HttpPost]
        public ActionResult FileSave(IEnumerable<HttpPostedFileBase> files)
        {
            List<string> imagePath = new List<string>();
            if (files != null)
            {
                try
                {
                    var FileCollect = from a in files where a != null select a;
                    foreach (var file in FileCollect)
                    {
                        string imgName = DateTime.Now.ToString("yyyyMMddhhmmss");
                        string imgPath = "/images/product/" + imgName + file.FileName;
                        //通过此对象获取文件名                        
                        string AbsolutePath = Server.MapPath(imgPath);
                        file.SaveAs(AbsolutePath);              //将上传的东西保存
                        imagePath.Add(imgPath);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return Json(imagePath);
        }

        [HttpPost]
        public ActionResult FileRemove(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var FileCollect = from a in files where a != null select a;
                foreach (var file in FileCollect)
                {
                    string imgPath = "/images/product/" + file.FileName;     //通过此对象获取文件名
                    string AbsolutePath = Server.MapPath(imgPath);
                    System.IO.File.Delete(AbsolutePath);
                }
            }
            return Json("");
        }
        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetProductList(int Category, int pageSize, int page)
        {
            JsonResult result = new JsonResult();
            Product bll = new Product();
            var t = bll.FindByPage(Category, pageSize, page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}
