using Smart.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Contract
{
    public interface INews : IRepository<sd_news>
    {
        List<sd_news> GetTop(int topnum);

        /// <summary>
        /// 根据新闻类型获取新闻列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<sd_news> GetByNewsCategory(int id);
    }
}
