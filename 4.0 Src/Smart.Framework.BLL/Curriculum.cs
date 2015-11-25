using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{

    public class Curriculum : QueryRepository<ICurriculum, sd_curriculum>
    {
        public Shcedule GetScheduleList(int top)
        {
            return dal.GetScheDuleList(top);
        }

        public List<sd_curriculum> GetCurriculum(int top = 10)
        {
            return dal.GetScheduleList(top);
        }
    }
}
