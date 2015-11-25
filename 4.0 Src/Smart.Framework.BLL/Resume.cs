using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;
using System.Linq.Expressions;

namespace Smart.Framework.BLL
{
    public class Resume : QueryRepository<IResume, sd_resume>
    {
        public sd_resume FindByWhere(string strname, string phone)
        {
            return dal.FindbyWhere(strname,phone);
        }
    }
}
