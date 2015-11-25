using Smart.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Account.Contract.Model
{
    public class UserRequest : Request
    {
        public string LoginName { get; set; }
        public string Mobile { get; set; }
    }

    public class RoleRequest : Request
    {
        public string RoleName { get; set; }
    }
}
