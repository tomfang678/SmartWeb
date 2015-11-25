using Smart.Framework.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.BLL
{
    public interface IQuery<T> where T : class
    {
        bool Add(T model);
        bool Delete(T model);
        bool Delete(int key);
        bool Delete(IEnumerable<T> list);
        bool Update(T model);
        bool Update(IEnumerable<T> list);
        T Find(int key);
        IEnumerable<T> FindALL();
        PagedList<T> FindByPage(int size, int pageindex);
    }
}
