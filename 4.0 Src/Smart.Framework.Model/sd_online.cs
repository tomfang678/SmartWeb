namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_online
    {
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int? no_order { get; set; }

        [Column(TypeName = "text")]
        public string qq { get; set; }

        [StringLength(100)]
        public string msn { get; set; }

        [StringLength(100)]
        public string taobao { get; set; }

        [StringLength(100)]
        public string alibaba { get; set; }

        [StringLength(100)]
        public string skype { get; set; }
    }
}
