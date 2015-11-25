namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_companyevent
    {
        public int id { get; set; }

        public int year { get; set; }

        public DateTime? newstime { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public DateTime? addtime { get; set; }

        public DateTime? updatetime { get; set; }

        public bool isparent { get; set; }
    }
}
