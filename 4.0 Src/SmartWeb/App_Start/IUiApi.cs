using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SmartWeb
{
    interface IUiApi
    {
        [HttpGet]
        JsonResult Get();

        [HttpGet]
        JsonResult GetByPage(int page, int pageSize);

        [HttpPost]
        JsonResult Add(string model);

        [HttpPost]
        JsonResult Delete();
    }
}
