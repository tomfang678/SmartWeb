namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_studentshare : ModelBase
    {
        // public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string company { get; set; }

        [StringLength(50)]
        public string studyclass { get; set; }

        public string says { get; set; }

        public DateTime? newstime { get; set; }

        //  public DateTime addtime { get; set; }

        [StringLength(100)]
        public string imgurl { get; set; }

        public int? orderno { get; set; }

        public bool? valid { get; set; }

        public int? hits { get; set; }

        [StringLength(100)]
        public string vediourl { get; set; }

        [StringLength(200)]
        public string title { get; set; }
    }
}
