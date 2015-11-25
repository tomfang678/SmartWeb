using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using System.Linq.Expressions;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{
    public class Product : QueryRepository<IProduct, sd_product>
    {
        public PagedList<sd_product> FindByPage(int category, int size, int pageindex)
        {
            Expression<Func<sd_product, bool>> predicate = t => t.categoryid == category;
            return dal.FindByPager(predicate, size, pageindex);
        }
    }
}
