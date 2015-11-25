namespace Smart.Framework.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sd_module : ModelBase
    {
        //  public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        // public DateTime? addtime { get; set; }

        // public DateTime? updatetime { get; set; }

        public int? parentid { get; set; }

        public int orderno { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        [StringLength(200)]
        public string adminurl { get; set; }

        [StringLength(200)]
        public string summary { get; set; }

        [StringLength(50)]
        public string icon { get; set; }

    }
}
