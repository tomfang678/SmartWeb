using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.BLL
{
    public abstract class CommonQuery<TDAL, T> : IQuery<T>
        where TDAL : class
        where T : class
    {
        private static T dal = Smart.DALFactory.DataAccess<T>.CreateInstance("");
        public virtual void CreateInstance(string dalstr)
        {
            dal = Smart.DALFactory.DataAccess<T>.CreateInstance(dalstr);
        }
        public T Add()
        {
            throw new NotImplementedException();
        }

        public T Delete()
        {
            throw new NotImplementedException();
        }

        public List<T> Find(T model)
        {
            throw new NotImplementedException();
        }

        public List<T> FindALL()
        {
           
            throw new NotImplementedException();
        }

        public List<T> FindByPage(T model)
        {
            throw new NotImplementedException();
        }
    }
}
