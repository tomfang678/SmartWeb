using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示原义字符串对象。
    /// </summary>
    public class StringLiteral : Expression
    {
        #region 私有字段

        private string _Content;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化原义字符串。
        /// </summary>
        /// <param name="line">指定原义字符串所在位置的行数。</param>
        /// <param name="col">指定原义字符串所在位置的列数。</param>
        /// <param name="content">指定原义字符串的内容。</param>
        public StringLiteral(int line, int col, string content)
            : base(line, col)
        {
            _Content = content;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取原义字符串的内容。
        /// </summary>
        public string Content
        {
            get { return _Content; }
        }

        #endregion
    }
}
