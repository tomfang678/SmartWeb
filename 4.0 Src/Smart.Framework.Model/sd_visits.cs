namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_visits
    {
        public int id { get; set; }

        [StringLength(100)]
        public string module { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        public DateTime? visittime { get; set; }

        [StringLength(100)]
        public string remark { get; set; }
    }
}
