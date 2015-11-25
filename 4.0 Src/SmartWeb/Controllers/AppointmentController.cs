using Smart.Framework.BLL;
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
    /// 预约
    /// </summary>
    public class AppointmentController : BaseApi<Appointment, sd_appointmentClass>
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
