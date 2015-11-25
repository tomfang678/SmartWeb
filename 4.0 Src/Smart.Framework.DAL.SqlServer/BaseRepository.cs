using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Smart.Framework.Model;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public bool Add(T model)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                try
                {
                    dal.Set<T>().Add(model);
                    int result = dal.SaveChanges();
                    return (result == 1 ? true : false);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
        public bool Add(IEnumerable<T> list)
        {
            try
            {
                using (SqlRepository dal = new SqlRepository())
                {

                    foreach (var item in list)
                    {
                        dal.Set<T>().Add(item);
                    }
                    int result = dal.SaveChanges();
                    return (result == 1 ? true : false);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(T model)
        {
            try
            {
                using (SqlRepository dal = new SqlRepository())
                {
                    dal.Entry<T>(model).State = EntityState.Deleted;
                    int result = dal.SaveChanges();
                    return (result == 1 ? true : false);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int key)
        {
            var model = this.Find(key);
            return Delete(model);
        }
        public bool Delete(IEnumerable<T> list)
        {
            try
            {
                bool result = false;
                foreach (var item in list)
                {
                    result = Delete(item);
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(T model)
        {
            try
            {
                using (SqlRepository dal = new SqlRepository())
                {
                    var set = dal.Set<T>();
                    set.Attach(model);
                    dal.Entry<T>(model).State = EntityState.Modified;
                    int result = dal.SaveChanges();
                    return (result == 1 ? true : false);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(IEnumerable<T> list)
        {
            try
            {
                using (SqlRepository dal = new SqlRepository())
                {
                    foreach (var item in list)
                    {
                        var set = dal.Set<T>();
                        set.Attach(item);
                        dal.Entry<T>(item).State = EntityState.Modified;
                    }
                    int result = dal.SaveChanges();
                    return (result == 1 ? true : false);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public T Find(int key)
        {
            try
            {
                using (SqlRepository dal = new SqlRepository())
                {
                    return dal.Set<T>().Find(key);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<T> FindALL(Expression<Func<T, bool>> conditions = null)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                if (conditions == null)
                    return dal.Set<T>().ToList();
                else
                    return dal.Set<T>().Where(conditions).ToList();
            }
        }

        public PagedList<T> FindByPage(int pagesize, int pageindex)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var queryList = dal.Set<T>() as IEnumerable<T>;
                return queryList.ToPagedList(pageindex, pagesize);
            }
        }

        public PagedList<T> FindByPager(Expression<Func<T, bool>> conditions, int pageSize, int pageIndex)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var queryList = conditions == null ? dal.Set<T>() : dal.Set<T>().Where(conditions) as IEnumerable<T>;
                return queryList.ToPagedList(pageIndex, pageSize);
            }
        }

        public PagedList<T> FindByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : class
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var queryList = conditions == null ? dal.Set<T>().OrderByDescending(orderBy) : dal.Set<T>().Where(conditions).OrderByDescending(orderBy) as IEnumerable<T>;
                return queryList.ToPagedList(pageIndex, pageSize);
            }
        }
    }
}
