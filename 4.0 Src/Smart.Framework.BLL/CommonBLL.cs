using Smart.Framework.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.BLL
{
    public abstract class CommonBLL<TInterface, TDAL> : ICommon<TDAL>
        where TInterface : class ,new()
        where TDAL : Object
    {
        //  protected TDAL dal;
        protected static readonly IAbout dal = Smart.DALFactory.DataAccess<IAbout>.CreateInstance(TDAL);

        // private ICommon<TModel> common;

        public CommonBLL()
        {
            //dal = new TDAL();
            // common = (ICommon<TModel>)dal;
        }

        #region ICommon<TModel>
        public TDAL Add(TDAL model)
        {
            return dal.Add(model);
        }
        public TDAL Update(TDAL model)
        {
            return common.Update(model);
        }
        public void Delete(TDAL model)
        {
            common.Delete(model);
        }
        public void Delete(params object[] keyValues)
        {
            common.Delete(keyValues);
        }
        public TDAL Find(params object[] keyValues)
        {
            return common.Find(keyValues);
        }
        public List<TDAL> FindAll()
        {
            return common.FindAll();
        }
        public List<TDAL> FindByPager()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
