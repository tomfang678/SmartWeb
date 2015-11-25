namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_flash
    {
        public int id { get; set; }

        [StringLength(200)]
        public string URL { get; set; }

        [StringLength(500)]
        public string descript { get; set; }

        [Required]
        [StringLength(200)]
        public string imgurl { get; set; }

        [StringLength(200)]
        public string imgclass { get; set; }

        public bool? isShow { get; set; }

        public DateTime createtime { get; set; }

        public DateTime? updatetime { get; set; }
    }
}
