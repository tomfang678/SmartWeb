using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Smart.Framework.Model
{
    public class ModelBase
    {
        public ModelBase()
        {
            this.id = 0;
            this.addtime = DateTime.Now;
            this.updatetime = DateTime.Now;
        }

        [Key]
        [Required]
        public virtual int id { get; set; }

        public virtual DateTime addtime { get; set; }
        public virtual DateTime? updatetime { get; set; }
    }
}
