using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.Config.Models
{
    [Serializable]
    public class SystemDaoConfig : ConfigFileBase
    {
        public SystemDaoConfig()
        {

        }
        public string Log { get; set; }
        public string DbConnectionString { get; set; }
    }
}
