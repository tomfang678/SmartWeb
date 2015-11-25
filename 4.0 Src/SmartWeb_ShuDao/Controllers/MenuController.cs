using Smart.Framework.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Smart.Framework.Utility;

namespace ShuDaoWeb.Controllers
{
    public class MenuController : ApiController
    {
        [HttpGet]
        public String Get()
        {
            var list = new Module().FindAllModule();
            return SerializationHelper.JsonSerialize(list);
        }
    }
}
