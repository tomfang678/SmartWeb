using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class TagClose : Element
    {
        private string _Name;

        /// <summary>
        /// 初始化闭合标签。
        /// </summary>
        /// <param name="line">指定闭合标签所在位置的行数。</param>
        /// <param name="col">指定闭合标签所在位置的列数。</param>
        /// <param name="name">指定闭合标签的名称。</param>
        public TagClose(int line, int col, string name)
            : base(line, col)
        {
            _Name = name;
        }

        /// <summary>
        /// 获取闭合标签的名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }
    }
}
