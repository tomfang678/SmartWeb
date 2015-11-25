using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Smart.Account.Contract.Model
{
    [Serializable]
    [Table("sd_loginInfo")]
    public partial class LoginInfo : ModelBase
    {
        public LoginInfo()
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();
        }

        public LoginInfo(int userId, string loginName)
        {
            UserId = userId;
            LoginName = loginName;
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();
        }

        public virtual int UserId { get; set; }

        public virtual string LoginName { get; set; }

        public virtual Guid LoginToken { get; set; }

        public virtual string ClientIP { get; set; }

        public virtual DateTime LastAccessTime { get; set; }

        public EnumLoginAccountType EnumLoginAccountType { get; set; }

        public string BusinessPermissionString { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                if (string.IsNullOrEmpty(BusinessPermissionString))
                    return new List<EnumBusinessPermission>();
                else
                    return BusinessPermissionString.Split(",".ToCharArray()).Select(p => int.Parse(p)).Cast<EnumBusinessPermission>().ToList();
            }
            set
            {
                BusinessPermissionString = string.Join(",", value.Select(p => (int)p));
            }
        }

    }

    [Flags]
    public enum EnumLoginAccountType
    {
        /// <summary>
        /// 访客
        /// </summary>
        [EnumTitle("[无]", IsDisplay = false)]
        Guest = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        [EnumTitle("管理员")]
        Administrator = 1,

        /// <summary>
        /// 会员
        /// </summary>
        [EnumTitle("会员")]
        Member = 2,
    }
}
