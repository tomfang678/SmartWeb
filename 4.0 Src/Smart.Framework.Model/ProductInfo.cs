using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Smart.Framework.Model
{
    public class ProductInfo
    {
        private EntityRef<CategoryInfo> _category;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="name">Product Name</param>
        /// <param name="description">Product Description</param>
        /// <param name="image">Product image</param>
        /// <param name="categoryid">Category id</param>
        public ProductInfo(string id, string name, string description, string image, string categoryid)
        {
            this.id = id;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this._category = new EntityRef<CategoryInfo>();
            //  this._category.Entity.Categoryid = id;
        }

        // Properties
        [Column(Name = "Productid", IsPrimaryKey = true, DbType = "varchar(10)")]
        public string id { get; set; }

        [Column(Name = "Name", DbType = "varchar(80)")]
        public string Name { get; set; }

        [Column(Name = "Descn", DbType = "varchar(255)")]
        public string Description { get; set; }

        [Column(Name = "Image", DbType = "varchar(80)")]
        public string Image { get; set; }

        [Column(Name = "Categoryid", DbType = "varchar(10)")]
        public string Categoryid { get; set; }

        [Association(IsForeignKey = true, ThisKey = "Categoryid", Storage = "_category")]
        public CategoryInfo Category
        {
            get
            {
                return this._category.Entity;
            }
            set
            {
                this._category.Entity = value;
                //  value.Products.Add(this);
            }
        }
    }
}
