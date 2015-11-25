using Smart.Core.Config.Models;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace Smart.Core.Config
{
    public class CachedConfigContext : ConfigContext
    {
        public override T Get<T>(string index = null)
        {
            var fileName = this.GetConfigFileName<T>(index);
            var key = "ConfigFile" + fileName;
            var content = Caching.Get(key);
            if (content != null)
            {
                return (T)content;
            }
            var value = base.Get<T>(index);
            Caching.Set(key, value, new CacheDependency(ConfigService.GetFilePath(fileName)));
            return value;
        }

        public static CachedConfigContext Current = new CachedConfigContext();

        public SystemConfig SystemConfig
        {
            get { return this.Get<SystemConfig>(); }
        }
        public UploadConfig UploadConfig
        {
            get { return this.Get<UploadConfig>(); }
        }
        public CacheConfig CacheConfig
        {
            get { return this.Get<CacheConfig>(); }
        }
        public SystemDaoConfig DaoConfig
        {
            get { return this.Get<SystemDaoConfig>(); }
        }
    }
}
