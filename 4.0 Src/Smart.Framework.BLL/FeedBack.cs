using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{

    public class FeedBack : QueryRepository<IFeedBack, sd_message>
    {
        public bool Check(string name, string email, string subject, DateTime dt)
        {
            return dal.Check(name, email, subject, dt);
        }
    }
}
