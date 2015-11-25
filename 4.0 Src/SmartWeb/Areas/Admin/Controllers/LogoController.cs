using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class LogoController : AdministratorController
    {
        //
        // GET: /Admin/Logo/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FileSave(IEnumerable<HttpPostedFileBase> files)
        {
            List<string> imagePath = new List<string>();
            if (files != null)
            {
                var FileCollect = from a in files where a != null select a;
                foreach (var file in FileCollect)
                {
                    string imgPath = "~/Content/style/images/" + file.FileName;
                    string AbsolutePath = Server.MapPath(imgPath);
                    file.SaveAs(AbsolutePath);              //将上传的东西保存
                    imagePath.Add(imgPath);
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
                    string imgPath = "~/Content/style/images/" + file.FileName;     //通过此对象获取文件名
                    string AbsolutePath = Server.MapPath(imgPath);
                    System.IO.File.Delete(AbsolutePath);
                }
            }
            return Json("");
        }
    }
}
