using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示回调函数表达式。
    /// </summary>
    public class FCall : Expression
    {
        #region 私有字段

        private string _Name;
        private Expression[] _Args;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化回调函数表达式。
        /// </summary>
        /// <param name="line">指定回调函数表达式所在位置的行数。</param>
        /// <param name="col">指定回调函数表达式所在位置的列数。</param>
        /// <param name="name">指定回调函数表达式的名称。</param>
        /// <param name="args">指定回调函数表达式的参数列表。</param>
        public FCall(int line, int col, string name, Expression[] args)
            : base(line, col)
        {
            _Name = name;
            _Args = args;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取回调函数表达式的参数列表。
        /// </summary>
        public Expression[] Args
        {
            get { return _Args; }
        }

        /// <summary>
        /// 获取回调函数表达式的名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        #endregion
    }
}
