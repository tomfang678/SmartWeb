using System;

namespace Smart.Framework.Model
{
    /// <summary>
    /// 商品种类
    /// </summary>
    [Serializable]
    public class CategoryInfo
    {
        /// <summary>
        /// 商品种类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 父级类别ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 商品种类
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品种类（英文）
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// 商品描述（中文）
        /// </summary>
        public string Des { get; set; }

        /// <summary>
        /// 商品描述（英文）
        /// </summary>
        public string DescEn { get; set; }
    }
}
