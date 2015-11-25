using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Smart.Framework.Model;
using Smart.Framework.BLL;

namespace ShuDaoWeb.Areas.Admin.Controllers
{
    public class FileUploadController : AdministratorController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddFile(string models)
        {
            JsonResult result = new JsonResult();
            Download bll = new Download();
            List<sd_download> fileList = new List<sd_download>();
            sd_download info = new sd_download();
            if (models != null)
            {

                fileList = JsonConvert.DeserializeObject<List<sd_download>>(models);
                if (fileList.Count > 0)
                {
                  bll.Add(fileList);
                    result.Data = fileList;
                }
            }
            return result;
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetFileList(int page, int pageSize)
        {
            Download bll = new Download();
            var t = bll.FindByPage(pageSize,page);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public JsonResult DeleteFile(string models)
        {
            JsonResult result = new JsonResult();
            Download bll = new Download();
            List<sd_download> fileList = new List<sd_download>();
            sd_download info = new sd_download();
            if (models != null)
            {
                var t = JsonConvert.DeserializeObject<List<sd_download>>(models);
                if (t.Count > 0)
                {
                    bll.Delete(t);
                    result.Data = fileList;
                }
            }
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public JsonResult UpdateFile(string models)
        {
            JsonResult result = new JsonResult();
            Download bll = new Download();
            List<sd_download> fileList = new List<sd_download>();
            sd_download info = new sd_download();
            if (models != null)
            {
                if (models.StartsWith("["))
                {
                    var jarr = JArray.Parse(models);
                    if (jarr.Count > 0)
                    {
                        foreach (var item in jarr)
                        {
                            info = Newtonsoft.Json.JsonConvert.DeserializeObject<sd_download>(item.ToString());
                            fileList.Add(info);
                        }
                        if (fileList.Count > 0)
                        {
                            bll.Update(fileList);
                            result.Data = fileList;
                        }
                    }
                }
            }
            return result;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UploadFiles(string models)
        {
            JsonResult result = new JsonResult();
            Download bll = new Download();
            if (models != null)
            {
                try
                {
                    sd_download download = JsonConvert.DeserializeObject<sd_download>(models);
                    if (!string.IsNullOrEmpty(download.filesize))
                    {
                        download.filesize = Math.Round(float.Parse(download.filesize) / 1024, 2).ToString();
                    }
                    result.Data = bll.Add(download);
                }
                catch (Exception ex)
                {
                    result.Data = false;
                }
            }
            return result;
        }

        [HttpPost]
        public ActionResult NewsOriginalSave(IEnumerable<HttpPostedFileBase> files)
        {
            List<string> imagePath = new List<string>();
            if (files != null)
            {
                var FileCollect = from a in files where a != null select a;
                foreach (var file in FileCollect)
                {
                    string imgPath = "/" + file.FileName;     //通过此对象获取文件名
                    string AbsolutePath = Server.MapPath(imgPath);
                    file.SaveAs(AbsolutePath);              //将上传的东西保存
                    imagePath.Add(imgPath);
                }
            }
            return Json(imagePath);
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
                    string imgName = DateTime.Now.ToString("yyyyMMddhhmmss");
                    string st = Path.GetExtension(file.FileName);
                    string imgPath = "/upload/" + imgName + st;     //通过此对象获取文件名

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
                    string imgPath = file.FileName;     //通过此对象获取文件名
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

    }
}
