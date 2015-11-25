namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_admin
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string admin_type { get; set; }

        [Required]
        [StringLength(15)]
        public string admin_id { get; set; }

        [StringLength(64)]
        public string admin_pass { get; set; }

        [Required]
        [StringLength(30)]
        public string admin_name { get; set; }

        public byte admin_sex { get; set; }

        [StringLength(150)]
        public string admin_email { get; set; }

        public int admin_login { get; set; }

        [StringLength(20)]
        public string admin_modify_ip { get; set; }

        public DateTime? admin_modify_date { get; set; }

        public DateTime? admin_register_date { get; set; }

        public DateTime? admin_approval_date { get; set; }

        public int? admin_group { get; set; }

        public int? usertype { get; set; }

        public int checkid { get; set; }

        [Column(TypeName = "text")]
        public string cookie { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string admin_shortcut { get; set; }
    }
}
