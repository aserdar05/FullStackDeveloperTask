using FulStackDeveloperTask.App.Utils;
using System.Web;
using System.Web.Mvc;

namespace FulStackDeveloperTask.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandlerAttribute());
        }
    }
}
