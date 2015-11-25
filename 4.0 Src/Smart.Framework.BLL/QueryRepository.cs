using Smart.Core.Log;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Smart.Framework.BLL
{
    public abstract class QueryRepository<I, T> : IRepository<T>
        where T : class
        where I : class
    {
        protected static dynamic dal = Smart.Framework.DALFactory.DataAccess.CreateInstance<I>();
        public virtual bool Add(T model)
        {
            try
            {
                return dal.Add(model);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual bool Add(IEnumerable<T> list)
        {
            try
            {
                return dal.Add(list);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual bool Delete(T model)
        {
            try
            {
                return dal.Delete(model);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual bool Delete(int key)
        {
            try
            {
                return dal.Delete(key);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual bool Delete(IEnumerable<T> list)
        {
            try
            {
                return dal.Delete(list);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual bool Update(T model)
        {
            try
            {
                return dal.Update(model);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public bool Update(IEnumerable<T> list)
        {
            try
            {
                return dal.Update(list);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggerType.ServiceException, ex);
                return false;
            }
        }
        public virtual T Find(int key)
        {
            return dal.Find(key);
        }
        public virtual IEnumerable<T> FindALL(System.Linq.Expressions.Expression<Func<T, bool>> conditions = null)
        {
            return dal.FindALL(conditions);
        }
        public virtual PagedList<T> FindByPage(int size, int pageindex)
        {
            return dal.FindByPage(size, pageindex);
        }
        public virtual PagedList<T> FindByPager(System.Linq.Expressions.Expression<Func<T, bool>> conditions, int pageSize, int pageIndex)
        {
            return dal.FindByPage(conditions, pageSize, pageIndex);
        }
        public virtual PagedList<T> FindByPage<T, S>(System.Linq.Expressions.Expression<Func<T, bool>> conditions, System.Linq.Expressions.Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : class
        {
            return dal.FindByPage(conditions, orderBy, pageSize, pageIndex);
        }

        public virtual void FindByPageWithCache(string table, int pageindex, int size, string sqlWhere)
        {
            var data = Caching.Get(table); //获取缓存 

            // 判断缓存数据为空 
            if (data == null)
            {
                // 获取数据 
                // var data = dal.FindByPage(size, pageindex);

                // 创建缓存依赖 
                // AggregateCacheDependency cd = DependencyFacade.GetModuleDependency();
                //HttpRuntime.Cache.Add(key, data, cd, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

            }
        }
    }
}
