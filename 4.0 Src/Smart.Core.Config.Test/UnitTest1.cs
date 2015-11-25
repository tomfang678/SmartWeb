using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart.Core.Log;

namespace Smart.Core.Config.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = CachedConfigContext.Current.SystemConfig;
            var value = t.UserLoginTimeoutMinutes;

            var upload = CachedConfigContext.Current.UploadConfig;
            var up = upload.UploadFolder;
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LogTest()
        {
            Logger.Error(LoggerType.ServiceException, "text", new Exception("test2"));
        }
    }
}
