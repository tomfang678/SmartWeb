using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Framework.Model
{
    public class ModuleInfo
    {
        public ModuleInfo() { }
        public int parentid { get; set; }
        public string parentname { get; set; }
        public string parenturl { get; set; }
        public string adminurl { get; set; }
        public string icon { get; set; }
        public List<sd_module> list { get; set; }
    }
}
