using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class Staff : BaseRepository<sd_staff>, IStaff
    {
        //    public sd_staff Add(sd_staff model)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            return dal.Insert<sd_staff>(model);
        //        }
        //    }

        //    public sd_staff Update(sd_staff a)
        //    {
        //        try
        //        {
        //            using (SqlRepository dal = new SqlRepository())
        //            {
        //                if (a != null)
        //                {
        //                    var mode = (from t in dal.sd_staff
        //                                where t.id == a.id
        //                                select t).FirstOrDefault();
        //                    mode.name = a.name;
        //                    mode.sex = a.sex;
        //                    mode.imgurl = a.imgurl;
        //                    mode.remark = a.remark;
        //                    mode.link = a.link;
        //                    mode.address = a.address;
        //                    mode.phone = a.phone;
        //                    mode.education = a.education;
        //                    mode.professional = a.professional;
        //                    mode.summary = a.summary;
        //                    mode.position = a.position;
        //                    mode.updatetime = DateTime.Now;
        //                    mode.state = a.state;
        //                    mode.isaccess = a.isaccess;
        //                    mode.homeshow = a.homeshow;
        //                    mode.conversiontime = a.conversiontime;
        //                    mode.entrytime = a.entrytime;
        //                    mode.idcard = a.idcard;
        //                    mode.department = a.department;
        //                    mode.orderno = a.orderno;
        //                    mode.managergroup = a.managergroup;
        //                    mode.doctorgroup = a.doctorgroup;
        //                }
        //                dal.SaveChanges();
        //                return a;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    public void Delete(sd_staff model)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            var t = dal.sd_staff.FirstOrDefault(a => a.id == model.id);
        //            if (t != null)
        //            {
        //                dal.sd_staff.Remove(t);
        //            }
        //        }
        //    }
        //    public void Delete(List<sd_staff> list)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            foreach (var item in list)
        //            {
        //                var model = dal.sd_staff.FirstOrDefault(a => a.id == item.id);
        //                if (model != null)
        //                {
        //                    dal.sd_staff.Remove(model);
        //                }
        //            }
        //            dal.SaveChanges();
        //        }
        //    }

        //    //public void Delete(params object[] keyValues)
        //    //{
        //    //    using (SqlRepository dal = new SqlRepository())
        //    //    {
        //    //        foreach (var item in keyValues)
        //    //        {
        //    //            var model = dal.sd_staff.FirstOrDefault(a => a.id == item.);
        //    //            if (model != null)
        //    //            {
        //    //                dal.sd_staff.Remove(model);
        //    //            }
        //    //        }
        //    //        dal.SaveChanges();
        //    //    }
        //    //}

        //    public void Find(string strql)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            dal.Find<sd_staff>(strql);
        //        }
        //    }

        //    public sd_staff Find(params object[] keyValues)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            return dal.Find<sd_staff>(keyValues);
        //        }
        //    }

        //    public List<sd_staff> FindAll()
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            return dal.FindAll<sd_staff>();
        //        }
        //    }

        public List<sd_staff> GetAdvisoryTeam()
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = (from a in dal.sd_staff where a.doctorgroup == true select a).ToList();
                return list;
            }
        }


        //    public sd_staff Find(int id)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            return dal.Find<sd_staff>(id);
        //        }
        //    }


        //    public Framework.DBUtility.PagedList<sd_staff> FindByPager(Expression<Func<sd_staff, bool>> conditions, int pageIndex, int pageSize)
        //    {
        //        using (SqlRepository dal = new SqlRepository())
        //        {
        //            Expression<Func<sd_staff, DateTime>> orderBy = t => t.addtime;
        //            return dal.FindAllByPage<sd_staff, DateTime>(conditions, orderBy, pageSize, pageIndex);
        //        }
        //    }
    }
}
