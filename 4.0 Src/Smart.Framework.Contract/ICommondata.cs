using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface ICommondata : IRepository<sd_commondata>
    {
        sd_commondata FindByKey(string key);
        List<sd_commondata> FIndByModuleId(int id);
    }
}
