using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Utils
{
    public class AppConfig
    {
        public static string Log4NetPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Log4NetFile");
            }
        }
    }
}