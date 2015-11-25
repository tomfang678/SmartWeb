using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{
    public class Commondata : BaseRepository<sd_commondata>, ICommondata
    {
        public List<sd_commondata> FIndByModuleId(int id)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var list = (from a in dal.sd_commondata where a.moduleid == id orderby id select a).ToList();
                return list;
            }
        }

        public sd_commondata FindByKey(string key)
        {
            using (SqlRepository dal = new SqlRepository())
            {
                var model = (from t in dal.sd_commondata where t.keys == key select t).FirstOrDefault();
                return model;
            }
        }
    }
}
