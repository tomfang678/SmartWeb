using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{

    public class Staff : QueryRepository<IStaff, sd_staff>
    {
        public List<sd_staff> GetAdvisoryTeam()
        {
            List<sd_staff> list = new List<sd_staff>();
            if (Caching.Get("sd_AdvisoryTeam") != null)
            {
                list = Caching.Get("sd_AdvisoryTeam") as List<sd_staff>;
                if (list == null || list.Count == 0)
                {
                    Caching.Remove("sd_AdvisoryTeam");
                }
            }
            else
            {
                var temp = this.FindALL();
                if (temp != null)
                {
                    list = this.FindALL().ToList();
                }
                else
                {
                    list = null;
                }
                if (list != null && list.Count > 0)
                {
                    Caching.Set("sd_AdvisoryTeam", list);
                }
            }
            return list;
        }
    }
}
