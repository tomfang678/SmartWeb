﻿using Smart.Account.Contract.Model;
using Smart.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Web.Admin
{
    public class UserContext
    {
        protected IAuthCookie authCookie;

        public UserContext(IAuthCookie authCookie)
        {
            this.authCookie = authCookie;
        }

        public LoginInfo LoginInfo
        {
            get
            {
                return CacheHelper.GetItem<LoginInfo>("LoginInfo", () =>
                {
                    if (authCookie.UserToken == Guid.Empty)
                        return null;

                    //var loginInfo = ServiceContext.Current.AccountService.GetLoginInfo(authCookie.UserToken);

                    //if (loginInfo != null && loginInfo.UserID > 0 && loginInfo.UserID != this.authCookie.UserId)
                    throw new Exception("非法操作，试图通过网站修改Cookie取得用户信息！");

                    return null;
                });
            }
        }
    }
}