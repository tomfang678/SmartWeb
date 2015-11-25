using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Smart.Core.TemplateEngine.Parser;

namespace Smart.Core.TemplateEngine
{
    public class Template
    {
        #region 私有字段

        private string _Name;
        private List<Element> _Elements;
        private Template _Parent;
        private string _data;
        private Dictionary<string, Template> _Templates;

        #endregion

        #region 构造函数

        /// <summary>
        /// 从元标签库初始化模板对象。
        /// </summary>
        /// <param name="name">指定模板名称。</param>
        /// <param name="elements">指定一个元标签库。</param>
        public Template(string name, List<Element> elements)
        {
            _Name = name;
            _Elements = elements;
            _Parent = null;

            _InitTemplates();
        }

        /// <summary>
        /// 从元标签库为指定的模板初始化子模板对象。
        /// </summary>
        /// <param name="name">指定模板名称。</param>
        /// <param name="elements">指定一个元标签库。</param>
        /// <param name="parent">指定父模板的实例。</param>
        public Template(string name, List<Element> elements, Template parent)
        {
            _Name = name;
            _Elements = elements;
            _Parent = parent;

            _InitTemplates();
        }

        #endregion

        #region 私有方法

        private void _InitTemplates()
        {
            _Templates = new Dictionary<string, Template>(StringComparer.InvariantCultureIgnoreCase);

            foreach (Element elem in _Elements)
            {
                if (elem is Tag)
                {
                    Tag tag = (Tag)elem;
                    if (string.Compare(tag.Name, "template", true) == 0)
                    {
                        Expression ename = tag.AttributeValue("name");
                        string tname;
                        if (ename is StringLiteral)
                            tname = ((StringLiteral)ename).Content;
                        else
                            tname = "?";

                        Template template = new Template(tname, tag.InnerElements, this);
                        _Templates[tname] = template;
                    }
                }
            }
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 从模板文件初始化模板对象。
        /// </summary>
        /// <param name="name">指定模板名称。</param>
        /// <param name="filename">包含模板文件完整路径的字符串。</param>
        /// <returns>Template</returns>
        public static Template FromFile(string name, string filename)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(filename))
            {
                string data = reader.ReadToEnd();
                return Template.FromString(name, data);
            }
        }

        /// <summary>
        /// 从模板代码初始化模板对象。
        /// </summary>
        /// <param name="name">指定模板名称。</param>
        /// <param name="data">包含模板代码的字符串。</param>
        /// <returns>Template</returns>
        public static Template FromString(string name, string data)
        {
            TemplateLexer lexer = new TemplateLexer(data);
            TemplateParser parser = new TemplateParser(lexer);
            List<Element> elems = parser.Parse();
            TagParser tagParser = new TagParser(elems);
            elems = tagParser.CreateHierarchy();
            return new Template(name, elems);
        }


        /// <summary>
        /// 查找指定的模板实例。
        /// </summary>
        /// <param name="name">指定一个模板实例名称。</param>
        /// <returns>Template</returns>
        public virtual Template FindTemplate(string name)
        {
            if (_Templates.ContainsKey(name))
                return _Templates[name];
            else if (_Parent != null)
                return _Parent.FindTemplate(name);
            else
                return null;
        }

        #endregion

        #region 公有属性
        public string Data
        {
            get { return _data; }
            set { this._data = value; }
        }

        /// <summary>
        /// 获取模板的标签库。
        /// </summary>
        public List<Element> Elements
        {
            get { return _Elements; }
        }

        /// <summary>
        /// 获取模板名称。
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// 获取一个 Boolea 值，确认模板是否拥有父模板。
        /// </summary>
        public bool HasParent
        {
            get { return _Parent != null; }
        }

        /// <summary>
        /// 获取模板的父模板实例。
        /// </summary>
        public Template Parent
        {
            get { return _Parent; }
        }

        /// <summary>
        /// 获取模板对象包含的所有模板的集合。
        /// </summary>
        public Dictionary<string, Template> Templates
        {
            get { return _Templates; }
        }

        #endregion
    }
}
