using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.BLL
{
    /// <summary>
    /// 网站异常业务
    /// </summary>
    public class Web_ExceptionLogManager : IWeb_ExceptionLogManager
    {
        IRepository<Web_ExceptionLog> _web_ExceptionLogRepository;
        public Web_ExceptionLogManager(IRepository<Web_ExceptionLog> web_ExceptionLogRepository)
        {
            _web_ExceptionLogRepository = web_ExceptionLogRepository;
        }
        #region IWeb_ExceptionLogManager 成员

        public List<Web_ExceptionLog> GetWeb_ExceptionLog()
        {
            return _web_ExceptionLogRepository.Fetch(i => i.FullInfo != null, i => i.Asc(j => j.OccurTime)).ToList();

        }

        #endregion
    }
}
