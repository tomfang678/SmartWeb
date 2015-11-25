using Smart.Framework.Utility;
using Smart.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Smart.Core.Log;
using Smart.Framework.Contract;
using System.Reflection;

namespace Smart.Framework.Web
{

    /// <summary>
    /// 前端公共接口
    /// </summary>
    /// <typeparam name="T">业务类</typeparam>
    /// <typeparam name="S">实体类</typeparam>
    public class BaseApi<T, S> : Smart.Framework.Web.SmartControllerBase
        where T : class
        where S : class
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            int _id = 0;
            var num = int.TryParse(Request.QueryString["id"].ToString(), out _id);
            Id = _id;
            dynamic instance = (T)Activator.CreateInstance(typeof(T));
            ViewBag.Detail = instance.Find(Id);
            return View();
        }

        public int Id { get; set; }

        #region 统一接口规范

        /// <summary>
        /// 查询前N条
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult GetTop(int top)
        {
            return Json("");
        }

        /// <summary>
        /// 根据ID查询实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Joson</returns>
        [HttpGet]
        public virtual JsonResult Get(int id)
        {
            try
            {
                dynamic instance = (T)Activator.CreateInstance(typeof(T));
                var model = instance.Find(id);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string error = string.Format("{0}执行Get({1})方法时出现异常/n", typeof(T).ToString(), id);
                //记录异常
                Logger.Error(LoggerType.WebException, error, ex);
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 根据分页信息查询列表
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页数据条数</param>
        /// <returns>Joson</returns>
        [HttpGet]
        public virtual JsonResult GetByPage(int PageIndex, int PageSize)
        {
            try
            {
                dynamic instance = (T)Activator.CreateInstance(typeof(T));
                PagedList<S> list = instance.FindByPage(PageSize, PageIndex);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string error = string.Format("{0}执行GetList({1},{2})方法时出现异常/n", typeof(T).ToString(), PageIndex, PageSize);
                //记录异常
                Logger.Error(LoggerType.WebException, error, ex);
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public virtual bool Add(string json)
        {
            return true;
        }

        [HttpPost]
        public virtual bool Delete(string json)
        {
            return true;
        }

        [HttpPost]
        public virtual bool Delete(int id)
        {
            return true;
        }
        #endregion
    }
}