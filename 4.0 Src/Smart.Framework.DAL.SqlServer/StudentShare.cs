using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class StudentShare : BaseRepository<sd_studentshare>, IStudentShare
    {
        public List<sd_studentshare> GetTop(int topnum)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = (from a in dal.sd_studentshare orderby a.addtime descending select a).Take(topnum).ToList();
                return list;
            }
        }
    }
}
