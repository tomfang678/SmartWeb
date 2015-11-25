using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Account.Contract.Model
{
    public enum EnumBusinessPermission
    {
        [EnumTitle("[无]", IsDisplay = false)]
        None = 0,
        /// <summary>
        /// 管理用户
        /// </summary>
        [EnumTitle("管理用户")]
        AccountManage_User = 101,

        /// <summary>
        /// 管理角色
        /// </summary>
        [EnumTitle("管理角色")]
        AccountManage_Role = 102,

    }
}
