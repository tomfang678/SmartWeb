
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{

    public class AuthenticationDAL : BaseRepository<sd_admin>, IAuthentication
    {
        public int Authentication(string name, string pwd)
        {
            try
            {
                using (SqlRepository entity = new SqlRepository())
                {
                    sd_admin model = entity.sd_admin.FirstOrDefault(a => a.admin_id == name);
                    string pass = Encrypt.Decode(model.admin_pass.Trim());
                    if (pwd == pass && model.checkid == 1)
                    {
                        //记录日志
                        return 1;
                    }
                    else
                    {
                        //记录日志
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public bool UpdatePwd(string name, string oldpwd, string key)
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var newpwd = Encrypt.Encode(key);
                var oldpass = Encrypt.Encode(oldpwd);
                var t = entity.sd_admin.FirstOrDefault(a => a.admin_name == name && a.admin_pass == oldpass);
                if (t != null)
                {
                    t.admin_pass = newpwd;
                    entity.SaveChanges();
                    //记录日志
                    return true;
                }
                else
                {
                    //记录日志
                    return false;
                }
            }
        }
    }
}
