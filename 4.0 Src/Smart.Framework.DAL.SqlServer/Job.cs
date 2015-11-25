using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Model;
using System.Linq.Expressions;
using Smart.Framework.Contract;

namespace Smart.Framework.DAL.SqlServer
{
    public class Job : BaseRepository<sd_job>, IJob
    {
    }
}
