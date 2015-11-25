using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ShuDaoWeb
{
    /// <summary>
    /// mvc站点地图(面包屑)
    /// </summary>
    public class MvcSiteMap
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public string Url { get; set; }
        [XmlAttribute]
        public int ParnetID { get; set; }
        public MvcSiteMap Parent { get; set; }
    }
    public class MvcSiteMapList
    {
        public List<MvcSiteMap> MvcSiteMaps { get; set; }
    }
}
