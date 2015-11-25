namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_resume : ModelBase
    {
        // public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }

        public byte sex { get; set; }

        public int age { get; set; }

        [StringLength(100)]
        public string education { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(20)]
        public string qq { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public string remark { get; set; }

        [StringLength(100)]
        public string files { get; set; }

        [StringLength(100)]
        public string postation { get; set; }

        public int? workyears { get; set; }

        [StringLength(500)]
        public string speciality { get; set; }

        public bool? flg { get; set; }

        public int talentpool { get; set; }

        // public DateTime addtime { get; set; }

        public bool isread { get; set; }
    }
}
