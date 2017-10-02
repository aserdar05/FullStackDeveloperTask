using FulStackDeveloperTask.App.Utils;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FulStackDeveloperTask.App
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppConfig.Log4NetPath));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
            log.Info("App Started.. ");

            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
