using Smart.Framework.BLL;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    /// <summary>
    /// 预约
    /// </summary>
    public class AppointmentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        ///Appointment/Add
        ///
        [HttpPost]
        public bool Add(string models)
        {
            sd_appointmentClass cls = SerializationHelper.JsonDeserialize<sd_appointmentClass>(models);
            var entity = new Appointment().Add(cls);
            if (entity)
            {
                return true;
            }
            return false;
        }
    }
}
