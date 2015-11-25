using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    /// <summary>
    /// 对redis数据源操作
    /// </summary>
    public class RedisRepository
    {
        #region IRepository 成员

        public void Get()
        {
            Console.WriteLine("Redis数据源");
        }

        #endregion
    }
}
