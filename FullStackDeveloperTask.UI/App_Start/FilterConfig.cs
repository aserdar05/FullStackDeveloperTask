using FullStackDeveloperTask.UI.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace FullStackDeveloperTask.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandlerAttribute());
        }
    }
}
