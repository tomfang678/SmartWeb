using Smart.Framework.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.SqlServerDAL
{
    public abstract class BaseCommon<T> : ICommon<T> where T : class
    {
        DbContextBase db;
        public BaseCommon(DbContextBase context)
        {
            this.db = context;
        }
        public BaseCommon() { }
        public DbContextBase Context
        {
            get
            {
                return db;
            }
        }

        #region ICommon<T>
        public T Add(T model)
        {
            return db.Insert<T>(model);
        }
        public T Update(T model)
        {
            return db.Update<T>(model);
        }
        public void Delete(T model)
        {
            db.Delete<T>(model);
        }
        public void Delete(params object[] keyValues)
        {
            T model = Find(keyValues);
            if (model != null)
            {
                db.Delete(model);
            }
        }
        public T Find(params object[] keyValues)
        {
            return db.Find<T>(keyValues);
        }
        public List<T> FindAll()
        {
            return db.FindAll<T>().ToList();
        }

        public List<T> FindByPager()
        {
            return new List<T>(); // db.FindAllByPage<T>();
        }

        #endregion
    }
}
