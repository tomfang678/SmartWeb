using System.Collections.Generic;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Smart.Framework.DAL.SqlServer
{

    public class Category : BaseRepository<sd_category>, ICategory
    {
        //public sd_category Add(sd_category model)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Insert<sd_category>(model);
        //    }
        //}

        //public void Delete(sd_category model)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        dal.Delete<sd_category>(model);
        //    }
        //}

        //public void Find(string strql)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        dal.Find<sd_category>(strql);
        //    }
        //}

        //public sd_category Find(params object[] keyValues)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Find<sd_category>(keyValues);
        //    }
        //}

        //public List<sd_category> FindAll()
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.FindAll<sd_category>();
        //    }
        //}

        //public sd_category Find(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Framework.DBUtility.PagedList<sd_category> FindByPager(Expression<Func<sd_category, bool>> conditions, int pageSize, int pageIndex)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.FindAllByPage<sd_category, DateTime>(conditions, null, pageSize, pageIndex);
        //    }
        //}

        //public bool Update(List<sd_category> list)
        //{
        //    try
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            foreach (var item in list)
        //            {
        //                var mode = (from a in dal.sd_category
        //                            where a.id == item.id
        //                            select a).FirstOrDefault();
        //                mode.name = item.name;
        //                mode.parent = item.parent;
        //                mode.remark = item.remark;
        //            }
        //            dal.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public bool Delete(List<sd_category> list)
        //{
        //    try
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            foreach (var item in list)
        //            {
        //                var mode = (from a in dal.sd_category
        //                            where a.id == item.id
        //                            select a).FirstOrDefault();

        //                var m = dal.sd_category.Remove(mode);
        //            }
        //            dal.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool Update(sd_category model)
        //{
        //    try
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            var mode = (from a in dal.sd_category
        //                        where a.id == model.id
        //                        select a).FirstOrDefault();
        //            mode.name = model.name;
        //            mode.parent = model.parent;
        //            mode.remark = model.remark;
        //            dal.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
