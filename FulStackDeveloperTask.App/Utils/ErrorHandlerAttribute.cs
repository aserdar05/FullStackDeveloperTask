using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FulStackDeveloperTask.App.Utils
{
    public class ErrorHandlerAttribute : HandleErrorAttribute
    {
        public ErrorHandlerAttribute()
        {
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)//Exception daha önceden handle edilmişse
            {
                return;
            }

            // İstek AJAX ile gelmişse JSON döndür
            
            // log the error using log4net.
            Log4NetManager.Error(filterContext.Exception.Message, filterContext.Exception);
        }
    }
}