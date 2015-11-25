using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Smart.Framework.Utility;

namespace Smart.Core.Config.Models
{
    [Serializable]
    public class UploadConfig : ConfigFileBase
    {
        public UploadConfig() { }

        public List<UploadFolder> UploadFolder { get; set; }

        [XmlAttribute("UploadPath")]
        public string UploadPath { get; set; }

    }

    [Serializable]
    public class UploadFolder
    {
        public List<ThumbnailSize> ThumbnailSizes { get; set; }

        [XmlAttribute("Path")]
        public string Path { get; set; }

        [XmlAttribute("DirType")]
        public string DirType { get; set; }
    }

    [Serializable]
    public class ThumbnailSize
    {
        public ThumbnailSize()
        {
            this.Quality = 88;
            this.Mode = "Cut";
            this.Timming = Timming.Lazy;
            this.WaterMarkerPosition = ImagePosition.Default;
        }

        [XmlAttribute("Width")]
        public int Width { get; set; }
        [XmlAttribute("Height")]
        public int Height { get; set; }
        [XmlAttribute("Quality")]
        public int Quality { get; set; }
        [XmlAttribute("AddWaterMarker")]
        public bool AddWaterMarker { get; set; }
        [XmlAttribute("WaterMarkerPosition")]
        public ImagePosition WaterMarkerPosition { get; set; }
        [XmlAttribute("WaterMarkerPath")]
        public string WaterMarkerPath { get; set; }
        [XmlAttribute("Mode")]
        public string Mode { get; set; }
        [XmlAttribute("Timming")]
        public Timming Timming { get; set; }
        [XmlAttribute("IsReplace")]
        public bool IsReplace { get; set; }
    }

    public enum DirType
    {
        //按天
        Day = 1,
        //按月份
        Month = 2,
        //按扩展名
        Ext = 3
    }

    [Flags]
    public enum Timming
    {
        //延迟用工具生成
        Lazy = 1,
        //上传后即时生成
        Immediate = 2,
        //请求图片时按需生成
        OnDemand = 4
    }

}
