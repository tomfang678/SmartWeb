using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.Config
{
    public interface IConfigService
    {
        string GetConfig(string fileName);
        void SaveConfig(string fileName, string content);
        string GetFilePath(string fileName);
    }
}
