using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullStackDeveloperTask.UI.Infrastructure.Extension
{
    public static class ControllerExtension
    {
        public static void AddSuccessMessage(this Controller controller, string message) {
            controller.TempData["AppSuccess"] = message;
        }
        public static void AddErrorMessage(this Controller controller, string message)
        {
            controller.TempData["AppError"] = message;
        }

    }
}