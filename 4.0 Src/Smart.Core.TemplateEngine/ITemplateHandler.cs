using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 为模板提供自定义方法的接口。
    /// </summary>
    public interface ITemplateHandler
    {
        /// <summary>
        /// 在模板处理过程之前运行的方法。
        /// </summary>
        /// <param name="manager">指定一个模板管理器实例。</param>
        void BeforeProcess(TemplateManager manager);

        /// <summary>
        /// 在模板处理过程之后运行的方法。
        /// </summary>
        /// <param name="manager">指定一个模板管理器实例。</param>
        void AfterProcess(TemplateManager manager);
    }
}
