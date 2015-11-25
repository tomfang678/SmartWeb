using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 标签解析器。
    /// </summary>
    public class TagParser
    {
        #region 私有字段

        private List<Element> _Elements;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化标签解析器。
        /// </summary>
        /// <param name="elements">指定一个元标签库。</param>
        public TagParser(List<Element> elements)
        {
            _Elements = elements;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 收集子标签。
        /// </summary>
        /// <param name="tag">指定一个标签实例。</param>
        /// <param name="index">指定标签索引。</param>
        /// <returns>Tag</returns>
        private Tag CollectForTag(Tag tag, ref int index)
        {
            if (tag.IsClosed) return tag;
            if (string.Compare(tag.Name, "if", true) == 0) tag = new TagIf(tag.Line, tag.Col, tag.AttributeValue("test"));

            Tag collectTag = tag;

            for (index++; index < _Elements.Count; index++)
            {
                Element elem = _Elements[index];

                if (elem is Text)
                    collectTag.InnerElements.Add(elem);
                else if (elem is Expression)
                    collectTag.InnerElements.Add(elem);
                else if (elem is Tag)
                {
                    Tag innerTag = (Tag)elem;
                    if (string.Compare(innerTag.Name, "else", true) == 0)
                    {
                        if (collectTag is TagIf)
                        {
                            ((TagIf)collectTag).FalseBranch = innerTag;
                            collectTag = innerTag;
                        }
                        else
                            throw new ParseException("else 标签必须包含在 if 或 elseif 之内。", innerTag.Line, innerTag.Col);

                    }
                    else if (string.Compare(innerTag.Name, "elseif", true) == 0)
                    {
                        if (collectTag is TagIf)
                        {
                            Tag newTag = new TagIf(innerTag.Line, innerTag.Col, innerTag.AttributeValue("test"));
                            ((TagIf)collectTag).FalseBranch = newTag;
                            collectTag = newTag;
                        }
                        else
                            throw new ParseException("elseif 标签位置不正确。", innerTag.Line, innerTag.Col);
                    }
                    else
                        collectTag.InnerElements.Add(CollectForTag(innerTag, ref index));
                }
                else if (elem is TagClose)
                {
                    TagClose tagClose = (TagClose)elem;
                    if (string.Compare(tag.Name, tagClose.Name, true) == 0)
                        return tag;

                    throw new ParseException("没有为闭合标签 " + tagClose.Name + " 找到合适的开始标签。", elem.Line, elem.Col);
                }
                else
                    throw new ParseException("无效标签： " + elem.GetType().ToString(), elem.Line, elem.Col);
            }

            throw new ParseException("没有为开始标签 " + tag.Name + " 找到合适的闭合标签。", tag.Line, tag.Col);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 创建子标签库。
        /// </summary>
        /// <returns>List&lt;Element&gt;</returns>
        public List<Element> CreateHierarchy()
        {
            List<Element> result = new List<Element>();

            for (int index = 0; index < _Elements.Count; index++)
            {
                Element elem = _Elements[index];

                if (elem is Text)
                    result.Add(elem);
                else if (elem is Expression)
                    result.Add(elem);
                else if (elem is Tag)
                    result.Add(CollectForTag((Tag)elem, ref index));
                else if (elem is TagClose)
                    throw new ParseException("没有为闭合标签 " + ((TagClose)elem).Name + " 找到合适的开始标签。", elem.Line, elem.Col);
                else
                    throw new ParseException("无效标签：" + elem.GetType().ToString(), elem.Line, elem.Col);
            }

            return result;
        }

        #endregion
    }
}
