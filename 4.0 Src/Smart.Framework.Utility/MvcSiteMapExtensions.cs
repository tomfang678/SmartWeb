using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.DBUtility
{
    /// <summary>
    /// 站点地图扩展
    /// </summary>
    public static class MvcSiteMapExtensions
    {
        public static MvcHtmlString GeneratorSiteMap(this HtmlHelper html, string url)
        {
            return MvcSiteMapFactory.GeneratorSiteMap(url);
        }
    }
}
