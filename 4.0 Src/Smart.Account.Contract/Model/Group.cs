using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Smart.Account.Contract.Model
{
    [Auditable]
    [Table("sd_group")]
    public class Group : ModelBase
    {
        public string GroupName { get; set; }
        public string Info { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
