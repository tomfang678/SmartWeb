namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_message
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string contact { get; set; }

        [Column(TypeName = "text")]
        public string info { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        public DateTime addtime { get; set; }

        public bool? readok { get; set; }

        [Column(TypeName = "text")]
        public string useinfo { get; set; }

        [StringLength(50)]
        public string lang { get; set; }

        public int? access { get; set; }

        [StringLength(30)]
        public string customerid { get; set; }
    }
}
