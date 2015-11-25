using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Model
{
    public class Shcedule
    {
        public Shcedule()
        {
            RecentlList = new List<sd_curriculum>();
            SoonList = new List<sd_curriculum>();
            EndList = new List<sd_curriculum>();
        }

        /// <summary>
        /// 近期课程
        /// </summary>
        public List<sd_curriculum> RecentlList { get; set; }
        /// <summary>
        /// 即将开课
        /// </summary>
        public List<sd_curriculum> SoonList { get; set; }
        /// <summary>
        /// 已经结束
        /// </summary>
        public List<sd_curriculum> EndList { get; set; }
    }
}
