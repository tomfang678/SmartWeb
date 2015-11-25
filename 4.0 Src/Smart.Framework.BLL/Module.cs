using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{

    public partial class Module : QueryRepository<IModule, sd_module>
    {
        public List<sd_module> FindALLModuleList()
        {
            return dal.GetAllModuleList();
        }
        public List<ModuleInfo> FindAllModule()
        {
            try
            {
                return dal.GetModule();
            }
            catch (Exception ex)
            {
                return dal.GetModule();
            }
        }
        public List<sd_module> GetModuleByParentid()
        {
            return dal.GetModuleByParentid(0);
        }
    }
}
