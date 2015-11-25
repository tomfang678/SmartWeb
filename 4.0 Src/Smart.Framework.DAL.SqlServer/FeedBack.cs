using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class FeedBack : BaseRepository<sd_message>, IFeedBack
    {
        public bool Check(string name, string email, string subject, DateTime dt)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var t = (from a in dal.sd_message where a.name == name && a.email == email && a.contact == subject && a.addtime.Year == dt.Year && a.addtime.Month == dt.Month && a.addtime.Day == dt.Day select a).FirstOrDefault();
                return t == null ? false : true;
            }
        }
    }
}
