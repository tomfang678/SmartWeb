using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.DAL.SqlServer
{
    public class Module : BaseRepository<sd_module>, IModule
    {
        public PagedList<List<sd_module>> GetModule(int parentid, int PageIndex, int PageSize)
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var t = (from a in entity.sd_module
                         where a.parentid == parentid
                         select new sd_module
                         {
                             id = a.id,
                             name = a.name,
                             parentid = a.parentid,
                             orderno = a.orderno,
                             addtime = a.addtime,
                             url = a.url,
                             adminurl = a.adminurl,
                             summary = a.summary,
                             updatetime = a.updatetime
                         }).OrderByDescending(a => a.addtime).Skip((PageIndex - 1) * PageSize).Take(PageSize);
                //list.AddRange(t);
                //return ToPagedList<List<sd_module>>(t, PageIndex, PageSize);
                //page.Data = list;
                //page.TotalCount = (from ct in entity.sd_module select ct).Count();
                //page.TotalPage = page.TotalCount % PageSize > 1 ? (page.TotalCount / PageSize) + 1 : (page.TotalCount / PageSize);
                //page.PageSize = PageSize;
                //return page;
                return null;
            }
        }

        public List<sd_module> GetModuleList()
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var t = (from a in entity.sd_module
                         where a.parentid == 0
                         orderby a.orderno ascending
                         select new sd_module
                         {
                             id = a.id,
                             name = a.name,
                             url = a.url,
                             adminurl = a.adminurl,
                             updatetime = a.updatetime,
                             addtime = a.addtime,
                             orderno = a.orderno,
                             summary = a.summary,
                             parentid = a.parentid
                         }).ToList();
                return t;
            }
        }
        public List<sd_module> GetAllModuleList()
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var t = (from a in entity.sd_module
                         orderby a.parentid ascending
                         select a).ToList();
                return t;
            }
        }
        public List<ModuleInfo> GetModule()
        {
            List<ModuleInfo> list = new List<ModuleInfo>();
            using (SqlRepository entity = new SqlRepository())
            {
                var t = from a in entity.sd_module where a.parentid == 0 select a;
                foreach (var item in t)
                {
                    var child = GetParentList(item.id);
                    list.Add(new ModuleInfo
                    {
                        parentid = item.id,
                        parentname = item.name,
                        parenturl = item.url,
                        adminurl = item.adminurl,
                        icon = item.icon,
                        list = child
                    });
                }
                return list;
            }
        }
        private List<sd_module> GetParentList(int id)
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var child = (from a in entity.sd_module
                             where a.parentid == id
                             orderby a.orderno ascending
                             select a).ToList();
                return child;
            }
        }
        public sd_commondata GetModuleById(int id)
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var t = (from a in entity.sd_module
                         join b in entity.sd_commondata
                         on a.id equals b.moduleid
                         where a.id == id
                         select new sd_commondata
                         {
                             id = b.id,
                             keys = b.keys,
                             value = b.value,
                             moduleid = a.id,
                             newstime = b.newstime,
                             ischeck = b.ischeck,
                             addtime = b.addtime,
                             updatetime = b.updatetime
                         }).FirstOrDefault();
                return t;
            }
        }
        public List<sd_module> GetModuleByParentId(int parentid)
        {
            using (SqlRepository entity = new SqlRepository())
            {
                var list = (from a in entity.sd_module
                            where a.parentid == parentid
                            select a).OrderBy(a => a.orderno).ToList();
                return list;
            }
        }

    }
}
