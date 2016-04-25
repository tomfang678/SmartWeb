namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_staff : ModelBase
    {

        // public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public byte sex { get; set; }

        [StringLength(200)]
        public string imgurl { get; set; }

        [Column(TypeName = "text")]
        public string remark { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string education { get; set; }

        [StringLength(100)]
        public string professional { get; set; }

        [StringLength(500)]
        public string summary { get; set; }

        [StringLength(50)]
        public string position { get; set; }

        // public DateTime addtime { get; set; }

        // public DateTime? updatetime { get; set; }

        //[StringLength(20)]
        //public string state { get; set; }

        public int? isaccess { get; set; }

        public bool? homeshow { get; set; }

        //public DateTime? entrytime { get; set; }

        //public DateTime? conversiontime { get; set; }

        [StringLength(50)]
        public string idcard { get; set; }

        [StringLength(50)]
        public string department { get; set; }

        public int? orderno { get; set; }

        public bool? doctorgroup { get; set; }

        public bool? managergroup { get; set; }
    }
}
