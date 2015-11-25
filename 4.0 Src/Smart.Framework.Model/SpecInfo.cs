using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Model
{
    /// <summary>
    /// 规格
    /// </summary>
    public class SystemParamInfo
    {
        /// <summary>
        /// 参数变化
        /// </summary>
        public int ParamId { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { get; set; }

    }
}
