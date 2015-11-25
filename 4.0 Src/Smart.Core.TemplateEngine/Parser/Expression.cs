using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示模板表达式。
    /// </summary>
    public abstract class Expression : Element
    {
        /// <summary>
        /// 初始化模板表达式。
        /// </summary>
        /// <param name="line">指定模板表达式所在位置的行数。</param>
        /// <param name="col">指定模板表达式所在位置的列数。</param>
        public Expression(int line, int col)
            : base(line, col)
        {

        }
    }
}
