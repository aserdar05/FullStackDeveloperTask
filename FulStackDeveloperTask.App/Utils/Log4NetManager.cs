using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Utils
{
    public class Log4NetManager
    {
        public static ILog GetLogger(string loggerName = "AppLogger")
        {
            ILog _logger = LogManager.Exists(loggerName);
            if (_logger == null)
                _logger = LogManager.GetLogger(loggerName);
            return _logger;
        }

        /// <summary>
        /// Mesajı Info seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        public static void Info(string message)
        {
            GetLogger().Info(message);
        }

        /// <summary>
        /// Mesajı Warn seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        public static void Warn(string message)
        {
            GetLogger().Warn(message);
        }

        /// <summary>
        /// Mesajı Debug seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        public static void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        /// <summary>
        /// Mesajı Error seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        public static void Error(string message)
        {
            GetLogger().Error(message);
        }

        /// <summary>
        /// Mesajı Fatal seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        public static void Fatal(string message)
        {
            GetLogger().Fatal(message);
        }
        
        /// <summary>
        /// Mesajı ve hatanın detayını Debug seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        /// <param name="t">Loglanacak hata</param>
        public static void Debug(string message, Exception t)
        {
            GetLogger().Debug(message, t);
        }

        /// <summary>
        /// Mesajı ve hatanın detayını Info seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        /// <param name="t">Loglanacak hata</param>
        public static void Info(string message, Exception t)
        {
            GetLogger().Info(message, t);
        }

        /// <summary>
        /// Mesajı ve hatanın detayını Warn seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        /// <param name="t">Loglanacak hata</param>
        public static void Warn(string message, Exception t)
        {
            GetLogger().Warn(message, t);
        }

        /// <summary>
        /// Mesajı ve hatanın detayını Error seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        /// <param name="t">Loglanacak hata</param>
        public static void Error(string message, Exception t)
        {
            GetLogger().Error(message, t);
        }

        /// <summary>
        /// Mesajı ve hatanın detayını Fatal seviyesinde loglar
        /// </summary>
        /// <param name="message">Loglanacak mesaj</param>
        /// <param name="t">Loglanacak hata</param>
        public static void Fatal(string message, Exception t)
        {
            GetLogger().Fatal(message, t);
        }
        
        
    }
}