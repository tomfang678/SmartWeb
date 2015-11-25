using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Framework.Contract;
using Smart.Framework.Model;
using Smart.Framework.Utility;

namespace Smart.Framework.BLL
{
    public class Commondata : QueryRepository<ICommondata, sd_commondata>
    {
        public sd_commondata FindByKey(string key)
        {
            sd_commondata model = new sd_commondata();
            if (Caching.Get(key) != null)
            {
                model = Caching.Get(key) as sd_commondata;
                if (model != null)
                {
                    return model;
                }
                else
                {
                    Caching.Remove(key);
                }
            }
            model = dal.FindByKey(key);
            if (model != null)
            {
                Caching.Set(key, model);
            }

            return model;
        }


        public List<sd_commondata> FindByModuleid(int id)
        {
            return dal.FIndByModuleid(id);
        }
    }
}
