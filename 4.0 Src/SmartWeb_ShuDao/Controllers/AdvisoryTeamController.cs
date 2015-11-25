﻿using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuDaoWeb.Controllers
{
    public class AdvisoryTeamController : BaseController
    {
        //
        // GET: /AdvisoryTeam/
        public ActionResult Index()
        {

            ViewData["staff"] = new Staff().GetAdvisoryTeam();
            return View();
        }
        public ActionResult Detail()
        {
            var id = Request.QueryString["id"].ToString();
            int sid = 0;
            var num = int.TryParse(id, out sid);
            ViewData["staffDetail"] = new Staff().Find(sid);
            return View();
        }
    }
}
