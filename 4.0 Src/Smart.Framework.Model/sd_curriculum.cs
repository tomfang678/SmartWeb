namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_curriculum:ModelBase
    {
      //  public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string course { get; set; }

        [StringLength(100)]
        public string imgurl { get; set; }

        [StringLength(50)]
        public string classtime { get; set; }

        public DateTime? startdate { get; set; }

        public DateTime? enddate { get; set; }

        [StringLength(50)]
        public string teacher { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        public int? studentnum { get; set; }

        [Column(TypeName = "text")]
        public string contents { get; set; }

       // public DateTime addtime { get; set; }

        public int hits { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        public decimal? price { get; set; }

        [StringLength(50)]
        public string daterange { get; set; }

       // public DateTime? updatetime { get; set; }
    }
}
