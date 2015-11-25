using System;
using System.Data.Linq.Mapping;
using System.Text;

namespace Smart.Framework.Model
{
    [Serializable]
    [Table(Name = "Item")]
    public class ItemInfo
    {
        public ItemInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="name">Item Name</param>
        /// <param name="quantity">Quantity in stock</param>
        /// <param name="price">Price</param>
        /// <param name="productName">Parent product name</param>
        /// <param name="image">Item image</param>
        /// <param name="categoryid">Category id</param>
        /// <param name="productid">Product id</param>
        public ItemInfo(string id, string name, int quantity, decimal price, string productName, string image, string categoryid, string productid)
        {
            this.id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.ProductName = productName;
            this.Image = image;
            this.Categoryid = categoryid;
            this.Productid = productid;
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string ProductName { get; set; }

        public string Categoryid { get; set; }

        // Properties
        public string id { get; set; }
        /// <summary>
        /// 上架id
        /// </summary>
        public string Itemid { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public int Unit { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string Productid { get; set; }
        /// <summary>
        /// 吊牌价
        /// </summary>
        public decimal ListPrice { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitCost { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public int Supplier { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 上架商品名称（中文）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上架商品名称（英文）
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// 上架商品名称（繁体）
        /// </summary>
        public string NameTc { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Descn { get; set; }

        /// <summary>
        /// 商品描述(英文)
        /// </summary>
        public string DescEn { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string DescAttr { get; set; }

        /// <summary>
        /// 商品规格（英文）
        /// </summary>
        public string DescAttrEn { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 评论id
        /// </summary>
        public int Commentid { get; set; }
    }
}
