using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class NewsType : BaseRepository<sd_newstype>, INewsType
    {
        //public sd_newstype Add(sd_newstype model)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Insert<sd_newstype>(model);
        //    }
        //}

        //public sd_newstype Update(sd_newstype model)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Update<sd_newstype>(model);
        //    }
        //}

        //public void Delete(sd_newstype model)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        dal.Delete<sd_newstype>(model);
        //    }
        //}

        //public bool Delete(List<sd_newstype> list)
        //{
        //    try
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            foreach (var item in list)
        //            {
        //                dal.Delete<sd_newstype>(item);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public void Delete(params object[] keyValues)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {

        //        //dal.Delete<sd_newstype>(keyValues as sd_newstype);
        //    }
        //}

        //public void Find(string strql)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        dal.Find<sd_newstype>(strql);
        //    }
        //}

        //public sd_newstype Find(params object[] keyValues)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Find<sd_newstype>(keyValues);
        //    }
        //}

        //public List<sd_newstype> FindAll()
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.FindAll<sd_newstype>();
        //    }
        //}

        //public PagedList<sd_newstype> FindByPager(Expression<Func<sd_newstype, bool>> conditions, int pageSize, int pageIndex)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.FindAllByPage<sd_newstype, DateTime>(conditions, null, pageSize, pageIndex);
        //    }
        //}

        //public List<sd_newstype> GetTop(int topnum)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        var list = (from a in dal.sd_newstype orderby a.id descending select a).Take(topnum).ToList();
        //        return list;
        //    }
        //}


        //public sd_newstype Find(int id)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        return dal.Find<sd_newstype>(id);
        //    }
        //}

        //public List<sd_newstype> GetByNewsCategory(int id)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        var list = (from a in dal.sd_newstype
        //                    select a).ToList();
        //        return list;
        //    }
        //}

        //public bool Update(List<sd_newstype> list)
        //{
        //    using (SqlRepository dal = new SqlRepository())
        //    {
        //        try
        //        {
        //            foreach (var item in list)
        //            {
        //                dal.Update<sd_newstype>(item);
        //            }
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }

        //    }
        //}

        //public bool DeleteByList(List<sd_newstype> list)
        //{
        //    try
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            foreach (var item in list)
        //            {
        //                dal.Delete<sd_newstype>(item);
        //            }
        //        } return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateByModel(sd_newstype model)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
