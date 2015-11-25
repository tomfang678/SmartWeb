namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_commondata : ModelBase
    {
       // public int id { get; set; }

        [Required]
        [StringLength(4000)]
        public string keys { get; set; }

        public string value { get; set; }

        public int moduleid { get; set; }

        //  public DateTime addtime { get; set; }

        //  public DateTime? updatetime { get; set; }

        public DateTime? newstime { get; set; }

        public bool ischeck { get; set; }
    }
}
