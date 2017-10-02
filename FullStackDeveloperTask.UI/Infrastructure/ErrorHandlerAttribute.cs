using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullStackDeveloperTask.UI.Infrastructure
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

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // İstek AJAX ile gelmişse JSON döndür
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                int httpCode = new HttpException(null, filterContext.Exception).GetHttpCode();

                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ExecuteResult
                    {
                        Succeeded = false,
                        ResultMessage = filterContext.Exception.Message
                    }
                };
            }
            // log the error using log4net.
            Context.Logger.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //İstek ajax değilse view döndür
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                int httpCode = new HttpException(null, filterContext.Exception).GetHttpCode();
                switch (httpCode)
                {
                    case 401:
                        filterContext.Controller.TempData["AppError"] = "Sayfaya erişim yetkiniz yoktur";
                        filterContext.HttpContext.Response.Redirect("~/Error/AuthorizationError");
                        break;
                    default:
                        filterContext.Controller.TempData["AppError"] = "Şu anda işleminiz gerçekleştirilememektedir.Lütfen daha sonra tekrar deneyin.";
                        filterContext.HttpContext.Response.Redirect("~/Error/Index");
                        break;
                }
            }
        }
    }
}