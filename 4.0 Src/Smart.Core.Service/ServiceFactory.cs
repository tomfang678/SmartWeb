using Smart.Core.Cache;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.Service
{
    public abstract class ServiceFactory
    {
        public abstract T CreateService<T>() where T : class;
    }

    /// <summary>
    /// 直接引用
    /// </summary>
    public class RefServiceFactory : ServiceFactory
    {
        public override T CreateService<T>()
        {
            //第一次通过反射创建服务实例，然后缓存住
            var interfaceName = typeof(T).Name;
            return CacheHelper.Get<T>(string.Format("Service_{0}", interfaceName), () =>
            {
                return AssemblyHelper.FindTypeByInterface<T>();
            });
        }
    }

    /// <summary>
    ///WCF引用 
    /// </summary>
    public class WcfServiceFactory : ServiceFactory
    {
        public override T CreateService<T>()
        {
            var uri = string.Empty;
            var proxy = WcfServiceProxy.CreateServiceProxy<T>(uri);
            return proxy;
        }
    }
}
