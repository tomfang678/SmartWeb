using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class Resume : BaseRepository<sd_resume>, IResume
    {
        public sd_resume FindbyWhere(string strname, string phone)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var model = dal.sd_resume.FirstOrDefault(t => t.username == strname && t.phone == phone);
                return model;
            }
        }
    }
}
