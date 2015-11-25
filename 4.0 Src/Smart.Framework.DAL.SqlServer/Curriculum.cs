using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{
    public class Curriculum : BaseRepository<sd_curriculum>, ICurriculum
    {
        /// <summary>
        ///获取即将 往期  近期课程信息
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public Shcedule GetScheDuleList(int top)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                DateTime dtrenc = DateTime.Now.AddDays(7);
                var rect = (from a in dal.sd_curriculum where a.startdate < dtrenc orderby a.startdate ascending select a).Take(top);
                var soon = (from a in dal.sd_curriculum where a.startdate > dtrenc orderby a.startdate ascending select a).Take(top);
                var end = (from a in dal.sd_curriculum where a.startdate < DateTime.Now orderby a.startdate ascending select a).Take(top);
                Shcedule scd = new Shcedule
                {
                    RecentlList = rect.ToList(),
                    SoonList = soon.ToList(),
                    EndList = end.ToList()
                };
                return scd;
            }
        }
        public List<sd_curriculum> GetScheduleList(int top)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = from a in dal.sd_curriculum orderby a.addtime descending select a;
                if (list != null)
                {
                    return list.Take(top).ToList();
                }
                else
                {
                    return new List<sd_curriculum>();
                }
            }
        }
    }
}
