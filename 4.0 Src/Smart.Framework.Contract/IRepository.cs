using Smart.Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface IRepository<T> where T : class
    {
        bool Add(T model);
        bool Add(IEnumerable<T> list);
        bool Delete(T model);
        bool Delete(int key);
        bool Delete(IEnumerable<T> list);
        bool Update(T model);
        bool Update(IEnumerable<T> list);
        T Find(int key);
        IEnumerable<T> FindALL(Expression<Func<T, bool>> conditions = null);
        PagedList<T> FindByPage(int size, int pageindex);
        PagedList<T> FindByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : class;

    }
}
