using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{
    public class News : BaseRepository<sd_news>, INews
    {
        public List<sd_news> GetTop(int topnum)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = (from a in dal.sd_news orderby a.addtime descending select a).Take(topnum).ToList();
                return list;
            }
        }

        public List<sd_news> GetByNewsCategory(int id)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = (from a in dal.sd_news
                            join b in dal.sd_newstype on a.newstype equals b.id
                            where a.newstype == id
                            orderby a.addtime descending
                            select a).ToList();
                return list;
            }
        }
    }
}
