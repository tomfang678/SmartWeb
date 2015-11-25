using Smart.Account.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Account.Contract;

namespace Smart.Account.Contract
{
    public interface IAccountService
    {
        LoginInfo GetLoginInfo(Guid Token);

        LoginInfo Login(string loginName, string password);
        void Logout(Guid token);
        void ModifyPwd(User user);
        User GetUser(int id);
        IEnumerable<User> GetUserList(UserRequest request = null);
        void SaveUser(User user);
        void DeleteUser(List<int> ids);

        Role GetRole(int id);
        IEnumerable<Role> GetRoleList(RoleRequest request = null);
        void SaveRole(Role role);
        void DeleteRole(List<int> ids);

        //Guid SaveVerifyCode(string verifyCodeText);
        //bool CheckVerifyCode(string verifyCodeText, Guid guid);
    }
}
