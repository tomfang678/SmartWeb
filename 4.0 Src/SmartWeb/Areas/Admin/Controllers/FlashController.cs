using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SmartWeb.Areas.Admin.Controllers
{
    public class FlashController : AdministratorController
    {
        //
        // GET: /Admin/Flash/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFlashList()
        {
            //FlashBLL bll = new FlashBLL();
            //List<FlashInfo> List = bll.GetAllFlashList();
           // return Json(List, JsonRequestBehavior.AllowGet);
            return null;
        }
        [HttpPost]
        public ActionResult AddFlash(string model)
        {
            JsonResult returndata = new JsonResult();
            //if (model != string.Empty || model != null)
            //{
            //    var flash = JsonConvert.DeserializeObject<FlashInfo>(model);
            //    FlashBLL bll = new FlashBLL();
            //    var result = bll.AddFlash(flash);
            //    returndata.Data = result;
            //}
            return returndata;
        }
        public ActionResult Edit()
        {
            //ViewData["flash"] = new FlashInfo();
            //if (Request["flashid"] != null)
            //{
            //    ViewData["flash"] = new FlashBLL().GetFlashByid(int.Parse(Request["flashid"].ToString()));
            //}
            return View();
        }
        public void Delete()
        {
            //ViewData["flash"] = new FlashInfo();
            //if (Request["flashid"] != null)
            //{
            //    var result = new FlashBLL().DeleteFlash(int.Parse(Request["flashid"].ToString()));
            //}
            Response.Redirect("/Admin/Flash?s=" + new Random(1000).Next());
        }

        [HttpPost]
        public ActionResult UpdateFlash(string model)
        {
            //FlashInfo flash = JsonConvert.DeserializeObject<FlashInfo>(model);
            //flash.updatetime = DateTime.Now;
            //bool result = new FlashBLL().UpdateFlash(flash);
            JsonResult returndata = new JsonResult();
            //returndata.Data = result;
            return returndata;
        }
        public ActionResult AddFlash()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileSave(IEnumerable<HttpPostedFileBase> files)
        {
            List<string> imagePath = new List<string>();
            if (files != null)
            {
                //var FileCollect = from a in files where a != null select a;
                //foreach (var file in FileCollect)
                //{
                //    string imgPath = new FilePathHelper().FlashImagPath + "/" + file.FileName;
                //    string AbsolutePath = Server.MapPath(imgPath);
                //    file.SaveAs(AbsolutePath);              //将上传的东西保存
                //    imagePath.Add(imgPath);
                //}
            }
            return Json(imagePath);
        }

        [HttpPost]
        public ActionResult FileRemove(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                //var FileCollect = from a in files where a != null select a;
                //foreach (var file in FileCollect)
                //{
                //    string imgPath = new FilePathHelper().FlashImagPath + "/" + file.FileName;     //通过此对象获取文件名
                //    string AbsolutePath = Server.MapPath(imgPath);
                //    System.IO.File.Delete(AbsolutePath);
                //}
            }
            return Json("");
        }
    }
}
