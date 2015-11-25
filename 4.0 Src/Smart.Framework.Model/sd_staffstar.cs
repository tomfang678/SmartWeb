namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_staffstar
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [StringLength(500)]
        public string staffid { get; set; }

        public string story { get; set; }

        public DateTime addtime { get; set; }

        public DateTime? selecttime { get; set; }

        public int? orderno { get; set; }

        public bool? isvalide { get; set; }

        [StringLength(100)]
        public string imgurl { get; set; }

        [StringLength(500)]
        public string shortdesc { get; set; }

        public int? hits { get; set; }

        public int? stafftype { get; set; }
    }
}
