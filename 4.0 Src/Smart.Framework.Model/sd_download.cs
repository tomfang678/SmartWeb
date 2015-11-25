namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_download : ModelBase
    {
        // public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string keywords { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public int? no_order { get; set; }

        [StringLength(255)]
        public string downloadurl { get; set; }

        [StringLength(100)]
        public string filesize { get; set; }

        public int? hits { get; set; }

        //  public DateTime? updatetime { get; set; }

        //  public DateTime addtime { get; set; }

        public int? access { get; set; }

        public int? top_ok { get; set; }

        public int? downloadaccess { get; set; }

        [StringLength(255)]
        public string filename { get; set; }

        [StringLength(50)]
        public string filetype { get; set; }
    }
}
