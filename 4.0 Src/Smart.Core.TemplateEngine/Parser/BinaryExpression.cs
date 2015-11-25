using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示预定义运算符表达式。
    /// </summary>
    public class BinaryExpression : Expression
    {
        #region 私有字段

        private Expression _Lhs;
        private Expression _Rhs;
        private TokenKind _op;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化预定义运算符表达式。
        /// </summary>
        /// <param name="line">指定预定义运算符表达式所在位置的行数。</param>
        /// <param name="col">指定预定义运算符表达式所在位置的列数。</param>
        /// <param name="lhs">指定预定义运算符表达式的左侧值。</param>
        /// <param name="op">指定预定义运算符表达式的运算符。</param>
        /// <param name="rhs">指定预定义运算符表达式的右侧值。</param>
        public BinaryExpression(int line, int col, Expression lhs, TokenKind op, Expression rhs)
            : base(line, col)
        {
            _Lhs = lhs;
            _Rhs = rhs;
            _op = op;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取预定义运算符表达式的左侧值。
        /// </summary>
        public Expression Lhs
        {
            get { return _Lhs; }
        }

        /// <summary>
        /// 获取预定义运算符表达式的右侧值。
        /// </summary>
        public Expression Rhs
        {
            get { return _Rhs; }
        }

        /// <summary>
        /// 获取预定义运算符表达式的运算符。
        /// </summary>
        public TokenKind Operator
        {
            get { return _op; }
        }

        #endregion
    }
}
