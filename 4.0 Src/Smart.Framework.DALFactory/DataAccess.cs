using System.Configuration;
using System.Reflection;
using Smart.Core.Cache;
using Smart.Core.Log;

namespace Smart.Framework.DALFactory
{
    /// <summary>
    /// 搭建数据访问层
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess()
        {
        }

        public static T CreateInstance<T>(string cls = "") where T : class
        {
            try
            {
                var interfaceName = typeof(T).Name;
                if (string.IsNullOrEmpty(cls))
                {
                    //默认DAL类型为接口去掉I
                    cls = interfaceName.TrimStart('I');
                }
                string className = path + "." + cls;
                return (T)Assembly.Load(path).CreateInstance(className);
            }
            catch (System.Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                throw;
            }
        }


        /// <summary>
        /// AutoFac依赖注入
        /// </summary>
        //public static T Get<T>()
        //    where T : class
        //{
        //    object o = typeof(T).Name;
        //    //dynamic dal=T.ToString().;
        //    //直接指定实例类型
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<TDal>().As<T>();
        //    using (var container = builder.Build())
        //    {
        //        var manager = container.Resolve<T>();
        //        return manager;
        //    }
        //}
    }
}
