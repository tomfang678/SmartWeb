
using Smart.Framework.Contract;
using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface IModule : IRepository<sd_module>
    {
        PagedList<List<sd_module>> GetModule(int parentid, int PageIndex, int PageSize);
        List<sd_module> GetModuleList();
        List<sd_module> GetAllModuleList();
        List<ModuleInfo> GetModule();
        sd_commondata GetModuleById(int id);
        List<sd_module> GetModuleByParentId(int parentid);

    }
}
