namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_case : ModelBase
    {
        //public int id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string ctitle { get; set; }

        [StringLength(200)]
        public string keywords { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public int? no_order { get; set; }

        [StringLength(255)]
        public string imgurl { get; set; }

        [Column(TypeName = "text")]
        public string displayimg { get; set; }

        public int? hits { get; set; }

        //  public DateTime? updatetime { get; set; }

        //  public DateTime addtime { get; set; }

        public bool? access { get; set; }

        public bool? top_ok { get; set; }
    }
}
