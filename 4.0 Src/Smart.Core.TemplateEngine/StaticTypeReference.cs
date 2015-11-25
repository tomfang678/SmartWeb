using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 为引用静态类型提供支持。
    /// </summary>
    public sealed class StaticTypeReference
    {
        #region 私有字段

        private readonly Type type;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化静态引擎实例。
        /// </summary>
        /// <param name="type">包含要引用的方法、属性等对象的 System.Type。</param>
        public StaticTypeReference(Type type)
        {
            this.type = type;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取要引用的方法、属性等对象的 System.Type。
        /// </summary>
        public Type Type
        {
            get { return type; }
        }

        #endregion
    }
}
