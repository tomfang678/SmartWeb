using Smart.Core.TemplateEngine.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 为自定义标签功能提供接口。
    /// </summary>
    public interface ITagHandler
    {
        /// <summary>
        /// 在标签处理开始时执行的方法。
        /// </summary>
        /// <param name="manager">指定一个模板管理器实例。</param>
        /// <param name="tag">指定一个自定义标签。</param>
        /// <param name="processInnerElements">是否处理内部代码。默认为 true。</param>
        /// <param name="captureInnerContent">是否将内部代码处理的结果直接附加到模板输出流。默认为 false。</param>
        void TagBeginProcess(TemplateManager manager, Tag tag, ref bool processInnerElements, ref bool captureInnerContent);

        /// <summary>
        /// 在标签处理结束时执行的方法。
        /// </summary>
        /// <param name="manager">指定一个模板管理器实例。</param>
        /// <param name="tag">指定一个自定义标签。</param>
        /// <param name="innerContent">是否处理内部代码。默认为 true。</param>
        void TagEndProcess(TemplateManager manager, Tag tag, string innerContent);
    }
}
