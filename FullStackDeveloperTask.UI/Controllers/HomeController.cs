
using FullStackDeveloperTask.App.ViewModel;
using FullStackDeveloperTask.UI.Database;
using FullStackDeveloperTask.UI.Infrastructure;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.ViewModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FullStackDeveloperTask.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CountryVM model)
        {
            ExecuteResult result = await DatabaseContext.CountryRepository.Save(model);
            return View();
        }

        public ActionResult GetCountries(DataTableModel table)
        {
            Util.TableSortByRequest(table, table.iSortCol_0, table.sSortDir_0);
            CountryGridVM response = DatabaseContext.CountryRepository.GetCountryList(table);
            return Json(new
            {
                sEcho = table.sEcho,
                iTotalRecords = table.iDisplayLength,
                iTotalDisplayRecords = response.TotalCount,
                aaData = response.CountryList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}