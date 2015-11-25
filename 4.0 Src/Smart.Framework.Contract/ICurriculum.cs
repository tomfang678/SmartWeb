using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface ICurriculum : IRepository<sd_curriculum>
    {
        Shcedule GetScheDuleList(int top);
        List<sd_curriculum> GetScheduleList(int top);
    }
}
