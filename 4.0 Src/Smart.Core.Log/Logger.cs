using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace Smart.Core.Log
{
    public class Logger
    {
        public static void Error(LoggerType loggerType, object msg, Exception ex)
        {
            ILog log = LogManager.GetLogger(loggerType.ToString());
            log.Error(msg, ex);
        }
        public static void Error(LoggerType loggerType, string info, Exception ex)
        {
            ILog log = LogManager.GetLogger(loggerType.ToString());
            log.Error(info, ex);
        }
        public static void Error(LoggerType loggerType, string msg)
        {
            ILog log = LogManager.GetLogger(loggerType.ToString());
            log.Error(msg);
        }
        public static void Error(LoggerType loggerType, Exception ex)
        {
            ILog log = LogManager.GetLogger(loggerType.ToString());
            log.Error(ex.Message);
        }
    }
    public enum LoggerType
    {
        WebException,
        ServiceException
    }
}
