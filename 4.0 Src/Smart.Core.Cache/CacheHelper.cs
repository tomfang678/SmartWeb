using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Smart.Core.Cache
{
    public class CacheHelper
    {
        public static object Get(string key)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);
            return cacheConfig.CacheProvider.Get(key);
        }
        public static void Set(string key, object value)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);

            cacheConfig.CacheProvider.Set(key, value, cacheConfig.CacheConfigItem.Minitus, cacheConfig.CacheConfigItem.IsAbsoluteExpiration, null);
        }

        public static void Remove(string key)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);
            cacheConfig.CacheProvider.Remove(key);
        }

        public static void Clear(string keyRegex = ".*", string moduleRegex = ".*")
        {
            if (!Regex.IsMatch(CacheConfigContext.ModuleName, moduleRegex, RegexOptions.IgnoreCase))
                return;

            foreach (var cacheProviders in CacheConfigContext.CacheProviders.Values)
                cacheProviders.Clear(keyRegex);
        }
        public static T Get<T>(string key, Func<T> realData)
        {
            var getDataFromCache = new Func<T>(() =>
            {
                //返回T的原始类型，值类型0，引用类型false
                T data = default(T);
                var cacheData = Get(key);
                if (cacheData != null)
                {
                    data = (T)cacheData;
                }
                else
                {
                    data = realData();
                    if (data != null)
                    {
                        Set(key, data);
                    }
                }
                return data;
            });
            return GetItem<T>(key, getDataFromCache);
        }


        public static F GetItem<F>(string names, Func<F> getRealData)
        {
            if (HttpContext.Current == null)
            {
                return getRealData();
            }
            var httpContextItem = HttpContext.Current.Items;
            if (httpContextItem.Contains(names))
            {
                return (F)httpContextItem[names];
            }
            else
            {
                var data = getRealData();
                if (data != null)
                    httpContextItem.Add(names, data);
                return data;
            }
        }
        public static F GetItem<F>() where F : new()
        {
            return GetItem<F>(typeof(F).ToString(), () => new F());
        }
        public static F GetItem<F>(Func<F> realData)
        {
            return GetItem<F>(typeof(F).ToString(), realData);
        }
    }
}
