using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示双精度数字表达式。
    /// </summary>
    public class DoubleLiteral : Expression
    {
        #region 私有字段

        private double _Value;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化双精度数字表达式。
        /// </summary>
        /// <param name="line">指定双精度数字表达式所在位置的行数。</param>
        /// <param name="col">指定双精度数字表达式所在位置的列数。</param>
        /// <param name="value">指定双精度数字表达式的值。</param>
        public DoubleLiteral(int line, int col, double value)
            : base(line, col)
        {
            _Value = value;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取双精度数字表达式的值。
        /// </summary>
        public double Value
        {
            get { return _Value; }
        }

        #endregion
    }
}
