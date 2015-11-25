using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Smart.Framework.Utility
{
    public interface IPagedList
    {

        int TotalPage //总页数
        {
            get;
        }

        int TotalCount
        {
            get;
            set;
        }

        int PageIndex
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool IsPreviousPage
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }
    public class PagedList<T> : IPagedList
    {
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            if (index <= 0) { index = 1; }
            if (pageSize <= 0) { pageSize = 20; }
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            var list = source.Skip((index - 1) * pageSize).Take(pageSize);
            this.Data = list != null ? IListOrderBy(list.AsEnumerable(), "addtime") : new List<T>();
        }
        public PagedList(IEnumerable<T> source, int index, int pageSize)
        {
            if (index <= 0) { index = 1; }
            if (pageSize <= 0) { pageSize = 20; }
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            var list = source.Skip((index - 1) * pageSize).Take(pageSize);
            this.Data = list != null ? IListOrderBy(list.AsEnumerable(), "addtime") : new List<T>();
        }
        public IEnumerable<T> Data
        {
            get;
            set;
        }
        public int TotalPage
        {
            get { return (int)System.Math.Ceiling((double)TotalCount / PageSize); }
        }
        public int TotalCount
        {
            get;
            set;
        }
        public int PageIndex
        {
            get;
            set;
        }
        public int PageSize
        {
            get;
            set;
        }
        public bool IsPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool IsNextPage
        {
            get
            {
                return ((PageIndex) * PageSize) < TotalCount;
            }
        }
        public IList<T> IListOrderBy(IEnumerable<T> list, string propertyName)
        {
            try
            {
                if (list == null || list.Count() == 0)
                {
                    return new List<T>();
                }
                Type elementTyple = list.FirstOrDefault().GetType();
                PropertyInfo propertyInfo = elementTyple.GetProperty(propertyName);
                ParameterExpression paramter = Expression.Parameter(elementTyple, "");
                Expression body = Expression.Property(paramter, propertyInfo);
                Expression sourceExpression = list.AsQueryable().Expression;
                Type sourcePropertyType = propertyInfo.PropertyType;
                Expression lambda = Expression.Call(
                    typeof(Queryable), "OrderByDescending",
                    new Type[] { elementTyple, sourcePropertyType },
                    sourceExpression, Expression.Lambda(body, paramter));
                return list.AsQueryable().Provider.CreateQuery<T>(lambda).ToList<T>();
            }
            catch (Exception ex)
            {
                return list.ToList();
            }
        }
    }
    public class PageList<T> : IPagedList
    {

        #region IPagedList 成员
        public T Data
        {
            get;
            set;
        }

        public int TotalPage
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;

            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public bool IsPreviousPage
        {
            get;
            set;
        }

        public bool IsNextPage
        {
            get;
            set;
        }

        #endregion
    }
    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 20);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index)
        {
            return new PagedList<T>(source, index, 20);
        }
    }
}