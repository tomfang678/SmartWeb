using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.DBUtility
{
    /// <summary>
    /// 站点地图工厂
    /// </summary>
    public class MvcSiteMapFactory
    {
        private static List<MvcSiteMap> siteMapList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SiteMapString))
                    throw new ArgumentException("请为在web.config中配置SiteMapString节点,以支持网站地图功能");

                return ConfigCache.ConfigFactory.Instance.GetConfig<MvcSiteMapList>(System.Web.HttpContext.Current.Server.MapPath(SiteMapString)).MvcSiteMaps;
            }
        }

        private static string SiteMapString = System.Configuration.ConfigurationManager.AppSettings["SiteMapString"] ?? string.Empty;

        /// <summary>
        /// 生成站点地图
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MvcHtmlString GeneratorSiteMap(string url)
        {
            StringBuilder str = new StringBuilder();
            List<string> pathList = new List<string>();
            MvcSiteMap current = GetSiteMap(url);
            GetFather(current, pathList);
            pathList.Reverse();
            pathList.ForEach(i =>
            {
                str.AppendFormat("<span style='padding:0 5px;'>{0}</span>>", i);
            });

            string result = str.ToString();
            if (!string.IsNullOrWhiteSpace(result))
                result = result.Remove(str.ToString().Length - 1);

            return MvcHtmlString.Create(result);
        }

        static MvcSiteMap GetSiteMap(string url)
        {
            return siteMapList.FirstOrDefault(i => i.Url == url);
        }
        /// <summary>
        /// 递归找老祖宗
        /// </summary>
        /// <param name="father"></param>
        static void GetFather(MvcSiteMap father, List<string> pathList)
        {


            if (father != null)
            {
                pathList.Add(string.Format("<a href={0}>{1}</a>", father.Url, father.Title));
                father.Parent = siteMapList.FirstOrDefault(i => i.ID == father.ParnetID);
                GetFather(father.Parent, pathList);
            }
        }
    }
}
