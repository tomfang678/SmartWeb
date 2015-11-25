using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示字符串表达式。
    /// </summary>
    public class StringExpression : Expression
    {
        #region 私有字段

        private List<Expression> _Exps;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化字符串表达式。
        /// </summary>
        /// <param name="line">指定字符串表达式所在位置的行数。</param>
        /// <param name="col">指定字符串表达式所在位置的列数。</param>
        public StringExpression(int line, int col)
            : base(line, col)
        {
            _Exps = new List<Expression>();
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 添加字符串表达式的实例。
        /// </summary>
        /// <param name="exp">指定一个表达式。</param>
        public void Add(Expression exp)
        {
            _Exps.Add(exp);
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取字符串表达式的数量。
        /// </summary>
        public int ExpCount
        {
            get { return _Exps.Count; }
        }

        /// <summary>
        /// 获取指定索引位置的字符串表达式。
        /// </summary>
        /// <param name="index">指定索引数字。</param>
        /// <returns>Expression</returns>
        public Expression this[int index]
        {
            get { return _Exps[index]; }
        }

        /// <summary>
        /// 获取字符串表达式集合。
        /// </summary>
        public IEnumerable<Expression> Expressions
        {
            get
            {
                for (int i = 0; i < _Exps.Count; i++)
                    yield return _Exps[i];
            }
        }

        #endregion
    }
}
