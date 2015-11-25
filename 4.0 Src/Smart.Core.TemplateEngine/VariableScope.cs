using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 提供变量标签视图管理功能。
    /// </summary>
    public sealed class VariableScope
    {
        #region 私有字段

        private VariableScope _Parent;
        private Dictionary<string, object> _Values;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化变量视图。
        /// </summary>
        public VariableScope()
            : this(null)
        {
        }

        /// <summary>
        /// 初始化变量视图，并为其指定父视图。
        /// </summary>
        /// <param name="parent"></param>
        public VariableScope(VariableScope parent)
        {
            _Parent = parent;
            _Values = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 清空视图。
        /// </summary>
        public void Clear()
        {
            _Values.Clear();
        }

        /// <summary>
        /// 判断指定的标签是否已经声明（同时会从父视图中查找）。
        /// </summary>
        public bool IsDefined(string name)
        {
            if (_Values.ContainsKey(name))
                return true;
            else if (_Parent != null)
                return _Parent.IsDefined(name);
            else
                return false;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取指定名称的标签取值。
        /// </summary>
        /// <param name="name">包含视图标签名称的字符串。</param>
        /// <returns>object</returns>
        public object this[string name]
        {
            get
            {
                if (!_Values.ContainsKey(name))
                {
                    if (_Parent != null)
                        return _Parent[name];
                    else
                        return null;
                }
                else
                    return _Values[name];
            }

            set { _Values[name] = value; }
        }

        /// <summary>
        /// 获取视图的父级视图。
        /// </summary>
        public VariableScope Parent
        {
            get { return _Parent; }
        }

        #endregion
    }
}
