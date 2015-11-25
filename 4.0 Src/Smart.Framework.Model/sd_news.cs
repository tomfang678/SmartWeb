namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_news : ModelBase
    {
        // public int id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string keywords { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public int no_order { get; set; }

        public int? img_ok { get; set; }

        [StringLength(255)]
        public string imgurl { get; set; }

        [StringLength(255)]
        public string imgurls { get; set; }

        [StringLength(100)]
        public string issue { get; set; }

        public int? hits { get; set; }

        // public DateTime? updatetime { get; set; }

        //  public DateTime addtime { get; set; }

        public bool? access { get; set; }

        public bool top_ok { get; set; }

        [StringLength(255)]
        public string filename { get; set; }

        public int newstype { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        [StringLength(500)]
        public string videourl { get; set; }
    }
}
