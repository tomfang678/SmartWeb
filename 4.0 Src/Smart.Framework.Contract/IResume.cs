
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface IResume : IRepository<sd_resume>
    {
        sd_resume FindbyWhere(string strname, string phone);
    }
}
