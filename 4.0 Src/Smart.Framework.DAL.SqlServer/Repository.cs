using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.SqlServerDAL
{
    /// <summary>
    /// EF数据结构实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _db;

        public Repository()
        {
            // Logger = NullLogger.Instance;
            // _db = new EEE114Entities();
        }

        //  public ILogger Logger { get; set; }
        #region IRepository<T> 成员
        List<string> _columns;
        public Repository<T> AddColumn(Func<string> func)
        {
            _columns.Add(func());
            return this;
        }
        #region Create,Update,Delete
        public virtual void Create(T entity)
        {
            _db.Entry<T>(entity);
            _db.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            //var ObjectStateEntry = ((IObjectContextAdapter)_db).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            //string[] p = { };
            //Array.ForEach(p, x =>
            //{
            //    ObjectStateEntry.SetModifiedProperty(x.Trim());
            //});
        }

        public virtual void Delete(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Set<T>().Remove(entity);
        }

        public virtual void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string Message = "error:";
                if (ex.InnerException == null)
                    Message += ex.Message + ",";
                else if (ex.InnerException.InnerException == null)
                    Message += ex.InnerException.Message + ",";
                else if (ex.InnerException.InnerException.InnerException == null)
                    Message += ex.InnerException.InnerException.Message + ",";
                throw new Exception(Message);
            }
        }
        #endregion

        #region Get
        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).Count();
        }
        public T Get(params object[] id)
        {
            throw new NotImplementedException();
        }
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).SingleOrDefault();
        }
        public IQueryable<T> Table
        {
            get { return _db.Set<T>(); }
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order)
        {
            var orderable = new Orderable<T>(Fetch(predicate).AsQueryable());
            order(orderable);
            return orderable.Queryable;
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }
        #endregion

        #endregion
    }
}
