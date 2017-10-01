
using FullStackDeveloperTask.App.ViewModel;
using FullStackDeveloperTask.UI.Database;
using FullStackDeveloperTask.UI.Infrastructure;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.ViewModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using FullStackDeveloperTask.UI.Infrastructure.Extension;

namespace FullStackDeveloperTask.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue) {
                CountryVM model = DatabaseContext.CountryRepository.Get(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CountryVM model)
        {
            ExecuteResult result = null;
            if (model.Country.Id == 0)
            {
                await DatabaseContext.CountryRepository.Save(model);
            }
            else
            {
                await DatabaseContext.CountryRepository.Update(model);
            }
            if (result.Succeeded)
            {
                this.AddSuccessMessage(result.ResultMessage);
                return RedirectToAction("Index");
            }
            else {
                this.AddErrorMessage(result.ResultMessage);
                return View(model);
            }

        }

        public ActionResult Delete(int id)
        {
            CountryVM model = DatabaseContext.CountryRepository.Get(id);
            return View(model.Country);
        }

        [HttpPost]
        public ActionResult Delete()
        {
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