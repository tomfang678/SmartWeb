using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System.Linq.Expressions;

namespace Smart.Framework.BLL
{

    public partial class News : QueryRepository<INews, sd_news>
    {
        public PagedList<sd_news> FindByPage(int categoryid, int size, int pageindex)
        {
            if (categoryid == 0)
            {
                return dal.FindByPage(pageindex, size);
            }
            else
            {
                Expression<Func<sd_news, bool>> predicate = t => t.newstype == categoryid;
                return dal.FindByPager(predicate, pageindex, size);
            }
        }
        public List<sd_news> GetTop(int top = 10)
        {
            return dal.GetTop(top);
        }

        public List<sd_news> GetByNewsCategory(int id)
        {
            return dal.GetByNewsCategory(id);
        }

    }
}
