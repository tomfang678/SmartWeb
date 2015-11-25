using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class TagAttribute
    {

        private string _Name;
        private Expression _Expression;

        /// <summary>
        /// 初始化标签属性。
        /// </summary>
        /// <param name="name">指定标签属性的名称。</param>
        /// <param name="expression">指定标签属性的值。</param>
        public TagAttribute(string name, Expression expression)
        {
            _Name = name;
            _Expression = expression;
        }


        /// <summary>
        /// 获取标签属性的值。
        /// </summary>
        public Expression Expression
        {
            get { return _Expression; }
        }

        /// <summary>
        /// 获取标签属性的名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }
    }
}
