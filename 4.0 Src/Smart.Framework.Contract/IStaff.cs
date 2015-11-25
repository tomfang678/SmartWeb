using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface IStaff : IRepository<sd_staff>
    {
        List<sd_staff> GetAdvisoryTeam();

    }
}
