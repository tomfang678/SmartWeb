using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.Config.Models
{
    [Serializable]
    public class SystemConfig : ConfigFileBase
    {
        public SystemConfig()
        {
        }

        #region 序列化属性
        public int UserLoginTimeoutMinutes { get; set; }
        #endregion
    }
}
