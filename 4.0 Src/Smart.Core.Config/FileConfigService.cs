using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Smart.Core.Config
{
    public class FileConfigService : IConfigService
    {
        public static readonly string pathConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        public string GetConfig(string fileName)
        {
            if (!Directory.Exists(pathConfig))
            {
                Directory.CreateDirectory(pathConfig);
            }
            var configPath = GetFilePath(fileName);
            if (!File.Exists(configPath))
            {
                return null;
            }
            else { return File.ReadAllText(configPath); }
        }

        public void SaveConfig(string fileName, string content)
        {
            string filePath = GetFilePath(fileName);
            File.WriteAllText(filePath, content);
        }

        public string GetFilePath(string fileName)
        {
            string configFile = string.Format(@"{0}/{1}.xml", pathConfig, fileName);
            return configFile;
        }
    }
}
