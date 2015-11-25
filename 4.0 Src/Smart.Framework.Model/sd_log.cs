namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_log
    {
        public int id { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        [StringLength(50)]
        public string operation { get; set; }

        public DateTime? addtime { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        [StringLength(500)]
        public string other { get; set; }
    }
}
