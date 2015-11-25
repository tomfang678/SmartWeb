using Smart.Account.Contract;
using Smart.Account.Contract.Model;
using Smart.Account.DAL;
using Smart.Core.Cache;
using Smart.Core.Config;
using Smart.Core.Log;
using Smart.Framework.BLL;
using Smart.Framework.Contract;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Smart.Account.BLL
{
    public class AccountService : IAccountService
    {
        private readonly int _UserLoginTimeoutMinutes = CachedConfigContext.Current.SystemConfig.UserLoginTimeoutMinutes;
        private readonly string _LoginInfoKeyFormat = "LoginInfo_{0}";
        public LoginInfo GetLoginInfo(Guid Token)
        {
            return CacheHelper.Get<LoginInfo>(string.Format(_LoginInfoKeyFormat, Token), () =>
            {
                using (AccountDBContext db = new AccountDBContext())
                {
                    //超时处理
                    var timeOutList = db.FindAll<LoginInfo>(p => DbFunctions.DiffMinutes(DateTime.Now, p.LastAccessTime) > _UserLoginTimeoutMinutes);
                    if (timeOutList.Count() > 0)
                    {
                        foreach (var item in timeOutList)
                        {
                            db.LoginInfos.Remove(item);
                        }
                        db.SaveChanges();
                    }
                    var loginInfo = db.FindAll<LoginInfo>(s => s.LoginToken == Token).FirstOrDefault();
                    if (loginInfo != null)
                    {
                        loginInfo.LastAccessTime = DateTime.Now;
                        db.Update<LoginInfo>(loginInfo);
                    }
                    return loginInfo;
                }
            });
        }

        public LoginInfo Login(string loginName, string password)
        {
            LoginInfo loginInfo = null;
            try
            {
                loginName = loginName.Trim();
                using (var dbContext = new AccountDBContext())
                {
                    var user = dbContext.Users.Include("Roles").Where(u => u.LoginName == loginName && u.Password == password && u.IsActive).FirstOrDefault();
                    if (user != null)
                    {
                        string ip = Fetch.UserIp;
                        loginInfo = dbContext.FindAll<LoginInfo>(p => p.LoginName == loginName && p.ClientIP == ip).FirstOrDefault();
                        if (loginInfo != null)
                        {
                            loginInfo.LastAccessTime = DateTime.Now;
                        }
                        else
                        {
                            loginInfo = new LoginInfo(user.id, user.LoginName);
                            loginInfo.ClientIP = ip;
                            loginInfo.BusinessPermissionList = user.BusinessPermissionList;
                            dbContext.Insert<LoginInfo>(loginInfo);
                        }
                    }
                }
                return loginInfo;
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return loginInfo;
            }
        }

        public void Logout(Guid token)
        {
            using (var dbContext = new AccountDBContext())
            {
                var loginInfo = dbContext.FindAll<LoginInfo>(l => l.LoginToken == token).FirstOrDefault();
                if (loginInfo != null)
                {
                    dbContext.Delete<LoginInfo>(loginInfo);
                }
            }
            CacheHelper.Remove(string.Format(_LoginInfoKeyFormat, token));
        }

        public void ModifyPwd(Contract.Model.User user)
        {
            using (var dbContext = new AccountDBContext())
            {
                if (dbContext.Users.Any(t => t.id == user.id && t.Password == user.Password))
                {
                    if (!string.IsNullOrEmpty(user.NewPassword))
                    {
                        user.Password = Encrypt.Encode(user.NewPassword);
                        dbContext.Update(user);
                    }
                }
                else
                {
                    throw new BusinessException("输入的原始密码不正确");
                }
            }
        }

        public User GetUser(int id)
        {
            using (var dbContext = new AccountDBContext())
            {
                return dbContext.Users.Include("Role").Where(t => t.id == id).SingleOrDefault();
            }
        }

        public IEnumerable<User> GetUserList(UserRequest request = null)
        {
            request = request ?? new UserRequest();

            using (var dbContext = new AccountDBContext())
            {
                IQueryable<User> users = dbContext.Users.Include("Roles");

                if (!string.IsNullOrEmpty(request.LoginName))
                    users = users.Where(u => u.LoginName.Contains(request.LoginName));

                if (!string.IsNullOrEmpty(request.Mobile))
                    users = users.Where(u => u.Mobile.Contains(request.Mobile));

                return users.OrderByDescending(u => u.id).ToList();
            }
        }

        public void SaveUser(User user)
        {
            using (var dbContext = new AccountDBContext())
            {
                if (user.id > 0)
                {
                    dbContext.Update<User>(user);

                    var roles = dbContext.Roles.Where(r => user.RoleIds.Contains(r.id)).ToList();
                    user.Roles = roles;
                    dbContext.SaveChanges();
                }
                else
                {
                    var existUser = dbContext.FindAll<User>(u => u.LoginName == user.LoginName);
                    if (existUser.Count > 0)
                    {
                        throw new BusinessException("LoginName", "此登录名已存在！");
                    }
                    else
                    {
                        dbContext.Insert<User>(user);

                        var roles = dbContext.Roles.Where(r => user.RoleIds.Contains(r.id)).ToList();
                        user.Roles = roles;
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public void DeleteUser(List<int> ids)
        {
            try
            {
                using (var dbContext = new AccountDBContext())
                {
                    dbContext.Users.Include("Role").Where(u => ids.Contains(u.id)).ToList().ForEach(a => { a.Roles.Clear(); dbContext.Users.Remove(a); });
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role GetRole(int id)
        {
            using (var dbContext = new AccountDBContext())
            {
                return dbContext.Find<Role>(id);
            }
        }

        public IEnumerable<Role> GetRoleList(RoleRequest request = null)
        {
            request = request ?? new RoleRequest();

            using (var dbContext = new AccountDBContext())
            {
                IQueryable<Role> role = dbContext.Roles;

                if (!string.IsNullOrEmpty(request.RoleName))
                    role = role.Where(u => u.Name.Contains(request.RoleName));

                return role.OrderByDescending(u => u.id).ToList();
            }
        }

        public void SaveRole(Role role)
        {
            using (var dbContext = new AccountDBContext())
            {
                if (role.id > 0)
                {
                    dbContext.Update<Role>(role);
                }
                else
                {
                    dbContext.Insert<Role>(role);
                }
            }
        }

        public void DeleteRole(List<int> ids)
        {
            using (var dbContext = new AccountDBContext())
            {
                dbContext.Roles.Include("Users").Where(u => ids.Contains(u.id)).ToList().ForEach(a => { a.Users.Clear(); dbContext.Roles.Remove(a); });
                dbContext.SaveChanges();
            }
        }

        //public Guid SaveVerifyCode(string verifyCodeText)
        //{
        //    //if (string.IsNullOrWhiteSpace(verifyCodeText))
        //    //    throw new BusinessException("verifyCode", "输入的验证码不能为空！");

        //    //using (var dbContext = new AccountDBContext())
        //    //{
        //    //    var verifyCode = new VerifyCode(){VerifyText = verifyCodeText, Guid = Guid.NewGuid()};
        //    //    dbContext.Insert<VerifyCode>(verifyCode);
        //    //    return verifyCode.Guid;
        //    //}
        //    throw NullReferenceException;
        //}

        //public bool CheckVerifyCode(string verifyCodeText, Guid guid)
        //{
        //    //using (var dbContext = new AccountDBContext())
        //    //{
        //    //    var verifyCode = dbContext.FindAll<VerifyCode>(v => v.Guid == guid && v.VerifyText == verifyCodeText).LastOrDefault();
        //    //    if (verifyCode != null)
        //    //    {
        //    //        dbContext.VerifyCodes.Remove(verifyCode);
        //    //        dbContext.SaveChanges();

        //    //        //清除验证码大于2分钟还没请求的
        //    //        var expiredTime = DateTime.Now.AddMinutes(-2);
        //    //        dbContext.VerifyCodes.Where(v => v.CreateTime < expiredTime).Delete();

        //    //        return true;
        //    //    }
        //    //    else
        //    //    {
        //    //        return false;
        //    //    }
        //    //}
        //}
    }
}
