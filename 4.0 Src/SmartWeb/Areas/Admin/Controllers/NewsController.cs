using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Smart.Framework.BLL;
using Smart.Framework.Model;

namespace SmartWeb.Areas.Admin.Controllers
{
    public class NewsController : AdministratorController
    {
        //
        // GET: /Admin/News/
        public ActionResult Index()
        {
            if (Request["newstype"] != null)
            {
                ViewData["newstype"] = Request["newstype"].ToString();
            }
            return View();
        }
        public ActionResult Edit()
        {
            sd_news news = new sd_news();
            if (!string.IsNullOrEmpty(Request["newsid"]))
            {
                news = new News().Find(int.Parse(Request["newsid"].ToString()));
            }
            ViewData["news"] = news;
            return View();
        }
        public ActionResult AddNews()
        {
            ViewData["type"] = new NewsType().FindALL();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult GetNewsList(int newstype, int page, int pageSize)
        {
            JsonResult result = new JsonResult();
            News bll = new News();
            var t = bll.FindByPage(newstype,page,pageSize);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditNews(string models)
        {
            sd_news news = new sd_news();
            List<sd_news> list = new List<sd_news>();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                news = Newtonsoft.Json.JsonConvert.DeserializeObject<sd_news>(models);
                list.Add(news);
                result.Data = new News().Update(list);
            }
            return result;
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult DeleteNews(string models)
        {
            List<sd_news> list = new List<sd_news>();
            if (models != null)
            {
                List<sd_news> newslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sd_news>>(models);
                foreach (sd_news news in newslist)
                {
                    list.Add(new sd_news { id = news.id });
                }
                bool result = new News().Delete(list);
                return Json(result);
            }
            return Json(false);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete()
        {
            if (Request["newsid"] != null)
            {
                sd_news model = new sd_news
                    {
                        id = int.Parse(Request["newsid"].ToString())
                    };
                bool result = new News().Delete(model);
            }
            return Json(false);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult PublishNews(string models)
        {
            sd_news news = new sd_news();
            JsonResult result = new JsonResult();
            if (models != null)
            {
                news = JsonConvert.DeserializeObject<sd_news>(models);
                news.content = news.content.Replace("?", "").Replace("？", "");
                var data = new News().Add(news);
                result.Data = true;
            }
            else
            {
                result.Data = false;
            }
            return result;
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
                    string imgPath = "/images/news/" + imgName + st;     //通过此对象获取文件名

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
    }
}
