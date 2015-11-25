using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 表示模板标签。
    /// </summary>
    public class Tag : Element
    {
        #region 私有字段

        private string _Name;
        private List<TagAttribute> _Attribs;
        private List<Element> _InnerElements;
        private TagClose _CloseTag;
        private bool _IsClosed;	// set to true if tag ends with />

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化模板标签。
        /// </summary>
        /// <param name="line">指定模板标签所在位置的行数。</param>
        /// <param name="col">指定模板标签所在位置的列数。</param>
        /// <param name="name">指定模板标签的名称。</param>
        public Tag(int line, int col, string name)
            : base(line, col)
        {
            _Name = name;
            _Attribs = new List<TagAttribute>();
            _InnerElements = new List<Element>();
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 获取指定属性的值。
        /// </summary>
        /// <param name="name">包含属性名称的字符串。</param>
        /// <returns>Expression</returns>
        public Expression AttributeValue(string name)
        {
            foreach (TagAttribute attrib in _Attribs)
                if (string.Compare(attrib.Name, name, true) == 0)
                    return attrib.Expression;

            return null;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取模板标签的属性表。
        /// </summary>
        public List<TagAttribute> Attributes
        {
            get { return _Attribs; }
        }

        /// <summary>
        /// 获取模板标签的内部标签库。
        /// </summary>
        public List<Element> InnerElements
        {
            get { return _InnerElements; }
        }

        /// <summary>
        /// 获取模板标签的名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// 设置或获取模板标签的闭合标签。
        /// </summary>
        public TagClose CloseTag
        {
            get { return _CloseTag; }
            set { _CloseTag = value; }
        }

        /// <summary>
        /// 设置或获取模板标签是否是自关闭的。
        /// </summary>
        public bool IsClosed
        {
            get { return _IsClosed; }
            set { _IsClosed = value; }
        }

        #endregion
    }
}