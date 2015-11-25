using Smart.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.Config
{
    public abstract class ConfigFileBase
    {
        public int id { get; set; }

        public virtual bool ClusteredByIndex
        {
            get
            {
                return false;
            }
        }

        public ConfigFileBase()
        {
        }

        internal virtual void Save()
        {
        }

        internal virtual void UpdateNodeList<T>(List<T> nodeList) where T : ConfigNodeBase
        {
            //重写id(index)
            foreach (var node in nodeList)
            {
                if (node.id > 0)
                    continue;

                node.id = nodeList.Max(n => n.id) + 1;
            }

            //重写排序，如1,4,5变为1,2,3
            //int i = 1;    
            //var sortedNodeList = nodeList.OrderBy(n=>n.Order).ToList();
            //foreach (var node in sortedNodeList)
            //    node.Order = i++;
        }
    }
}

