using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Smart.Account.Contract.Model
{
    [AuditableAttribute]
    [Table("sd_user")]
    public partial class User : ModelBase
    {
        public User()
        {
            this.Roles = new List<Role>();
            this.IsActive = true;
            this.RoleIds = new List<int>();
        }

        [Required(ErrorMessage = "登录名不能为空")]
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }

        [RegularExpression(@"^[1-9]\d{10}$", ErrorMessage = "手机号码格式不正确")]
        public string Mobile { get; set; }

        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public virtual List<Role> Roles { get; set; }

        [NotMapped]
        public List<int> RoleIds { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                var permissions = new List<EnumBusinessPermission>();

                foreach (var role in Roles)
                {
                    permissions.AddRange(role.BusinessPermissionList);
                }
                return permissions.Distinct().ToList();
            }
        }
    }
}
