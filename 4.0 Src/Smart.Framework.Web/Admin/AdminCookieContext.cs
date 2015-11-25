using Smart.Core.Cache;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Web.Admin;

namespace Smart.Framework.Web
{
    public class AdminCookieContext : CookieContext
    {
        public static AdminCookieContext Current
        {
            get
            {
                return CacheHelper.GetItem<AdminCookieContext>();
            }
        }

        public override string KeyPrefix
        {
            get
            {
                return Fetch.ServerDomain + "_AdminContext_";
            }
        }
    }
}
