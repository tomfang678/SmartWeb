using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class Text : Element
    {
        private string _Data;

        /// <summary>
        /// 初始化文本内容元标签。
        /// </summary>
        /// <param name="line">指定文本内容元标签所在位置的行数。</param>
        /// <param name="col">指定文本内容元标签所在位置的列数。</param>
        /// <param name="data">指定文本内容元标签所包含的内容。</param>
        public Text(int line, int col, string data)
            : base(line, col)
        {
            _Data = data;
        }

        /// <summary>
        /// 获取文本内容。
        /// </summary>
        public string Data
        {
            get { return _Data; }
        }
    }
}
