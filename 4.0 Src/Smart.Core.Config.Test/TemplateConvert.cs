using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart.Core.TemplateEngine;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Smart.Core.Config.Test
{
    [TestClass]
    public class TemplateConvert
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> list = new List<string> { "one", "to", "three", "four" };
            Dictionary<string, object> tmp = new Dictionary<string, object>();
            tmp.Add("list", list);
            var name = TemplateEngine.TemplateManager.Publish("", tmp, "", "");
        }
    }
}
