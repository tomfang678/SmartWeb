using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示命名表达式。
    /// </summary>
    public class Name : Expression
    {
        #region 私有字段

        private string _id;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化命名表达式。
        /// </summary>
        /// <param name="line">指定命名表达式所在位置的行数。</param>
        /// <param name="col">指定命名表达式所在位置的列数。</param>
        /// <param name="id">指定命名表达式的标识符。</param>
        public Name(int line, int col, string id)
            : base(line, col)
        {
            _id = id;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取命名表达式的标识符。
        /// </summary>
        public string id
        {
            get { return _id; }
        }

        #endregion
    }
}
