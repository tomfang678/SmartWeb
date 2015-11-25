using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示字段访问表达式。
    /// </summary>
    public class FieldAccess : Expression
    {
        #region 私有字段

        private Expression _Exp;
        private string _Field;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化字段访问表达式。
        /// </summary>
        /// <param name="line">指定字段访问表达式所在位置的行数。</param>
        /// <param name="col">指定字段访问表达式所在位置的列数。</param>
        /// <param name="exp">指定字段访问表达式的值。</param>
        /// <param name="field">指定字段访问表达式的字段名。</param>
        public FieldAccess(int line, int col, Expression exp, string field)
            : base(line, col)
        {
            _Exp = exp;
            _Field = field;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取字段访问表达式的值。
        /// </summary>
        public Expression Exp
        {
            get { return _Exp; }
        }

        /// <summary>
        /// 获取字段访问表达式的字段名。
        /// </summary>
        public string Field
        {
            get { return _Field; }
        }

        #endregion
    }
}
