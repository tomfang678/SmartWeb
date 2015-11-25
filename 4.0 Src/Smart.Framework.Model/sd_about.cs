namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_about
    {
        public Guid id { get; set; }

        [Column(TypeName = "text")]
        public string shortDesc { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        public DateTime addtime { get; set; }

        public DateTime? updatetime { get; set; }

        [Column(TypeName = "text")]
        public string other { get; set; }

        public int? moduleid { get; set; }
    }
}
