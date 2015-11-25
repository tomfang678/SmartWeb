using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;

namespace Smart.Framework.BLL
{
    public class AuthenticationBLL
    {
        public AuthenticationBLL() { }
        private static readonly IAuthentication dal = Smart.Framework.DALFactory.DataAccess.CreateInstance<IAuthentication>("AuthenticationDAL");
        public int Login(string name, string pwd)
        {
            return dal.Authentication(name, pwd);
        }
        public bool ChangePwd(string name, string oldpwd, string newpwd)
        {
            return dal.UpdatePwd(name, oldpwd, newpwd);
        }
    }
}
