using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class TagIf : Tag
    {
        private Tag _FalseBranch;
        private Expression _Test;

        /// <summary>
        /// 初始化 if 语句标签。
        /// </summary>
        /// <param name="line">指定 if 语句标签所在位置的行数。</param>
        /// <param name="col">指定 if 语句标签所在位置的列数。</param>
        /// <param name="test">指定 if 语句的条件测试表达式。</param>
        public TagIf(int line, int col, Expression test)
            : base(line, col, "if")
        {
            _Test = test;
        }

        /// <summary>
        /// 设置或获取 if 语句的 false 分支。
        /// </summary>
        public Tag FalseBranch
        {
            get { return _FalseBranch; }
            set { _FalseBranch = value; }
        }

        /// <summary>
        /// 获取 if 语句的条件测试表达式。
        /// </summary>
        public Expression Test
        {
            get { return _Test; }
        }
    }
}
