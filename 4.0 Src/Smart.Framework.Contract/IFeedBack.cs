using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface IFeedBack : IRepository<sd_message>
    {
        bool Check(string name, string email, string subject, DateTime dt);
    }
}
