using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示数组访问表达式。
    /// </summary>
    public class ArrayAccess : Expression
    {
        #region 私有字段

        private Expression _Exp;
        private Expression _Index;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化数组访问表达式。
        /// </summary>
        /// <param name="line">指定数组访问表达式所在位置的行数。</param>
        /// <param name="col">指定数组访问表达式所在位置的列数。</param>
        /// <param name="exp">指定数组访问表达式的值。</param>
        /// <param name="index">指定数组访问表达式的索引。</param>
        public ArrayAccess(int line, int col, Expression exp, Expression index)
            : base(line, col)
        {
            _Exp = exp;
            _Index = index;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取数组访问表达式的值。
        /// </summary>
        public Expression Exp
        {
            get { return _Exp; }
        }

        /// <summary>
        /// 获取数组访问表达式的索引。
        /// </summary>
        public Expression Index
        {
            get { return _Index; }
        }

        #endregion
    }
}
