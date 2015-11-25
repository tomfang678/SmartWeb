namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_job : ModelBase
    {
        //public int id { get; set; }

        [StringLength(200)]
        public string position { get; set; }

        public int count { get; set; }

        [StringLength(200)]
        public string place { get; set; }

        [StringLength(200)]
        public string deal { get; set; }

        //public DateTime addtime { get; set; }

        public int useful_life { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public int access { get; set; }

        public int? top_ok { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string filename { get; set; }

        public int? no_order { get; set; }

        [Column(TypeName = "text")]
        public string shortdescript { get; set; }
    }
}
