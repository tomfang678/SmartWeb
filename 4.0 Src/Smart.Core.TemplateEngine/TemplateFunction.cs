using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 为内置函数提供支持的委托。
    /// </summary>
    /// <param name="args">内置函数的函数名。</param>
    /// <returns>object</returns>
    public delegate object TemplateFunction(object[] args);
}
