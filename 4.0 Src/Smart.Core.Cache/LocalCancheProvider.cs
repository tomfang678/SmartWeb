using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Smart.Framework.Utility;
using System.Collections;
using System.Text.RegularExpressions;

namespace Smart.Core.Cache
{
    public class LocalCancheProvider : ICacheProvider
    {
        public virtual object Get(string key)
        {
            return Caching.Get(key);
        }

        public virtual void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove)
        {
            Caching.Set(key, value, minutes, isAbsoluteExpiration, (k, v, reason) =>
            {
                if (onRemove != null)
                    onRemove(k, v, reason.ToString());
            });
        }

        public void Remove(string key)
        {
            Caching.Remove(key);
        }

        public void Clear(string keyRegex)
        {
            List<string> keys = new List<string>();
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var key = enumerator.Key.ToString();
                if (Regex.IsMatch(key, keyRegex, RegexOptions.IgnoreCase))
                {
                    keys.Add(key);
                }
            }
            foreach (var item in keys)
            {
                HttpRuntime.Cache.Remove(item);
            }
        }
    }
}
