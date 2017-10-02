
using FullStackDeveloperTask.App.ViewModel;
using FullStackDeveloperTask.UI.Database;
using FullStackDeveloperTask.UI.Infrastructure;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.ViewModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using FullStackDeveloperTask.UI.Infrastructure.Extension;
using System.Web;
using FulStackDeveloperTask.App.Utils;

namespace FullStackDeveloperTask.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            long minYellowPopulation = DatabaseContext.CountryRepository.GetMinYellowPopulation();
            ViewData["MinYellowPopulation"] = minYellowPopulation;
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewData["RegionList"] = DatabaseContext.RegionRepository.GetAll();
            if (id.HasValue) {
                CountryVM model = DatabaseContext.CountryRepository.Get(id.Value);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Exclude = "Flag")]CountryVM model, HttpPostedFileBase flag)
        {
            ModelState.Remove("Country.Id");
            if (model.Country.Id == 0 && flag == null) {
                ModelState.AddModelError("CustomError", "Ülkenin bayrağını seçmelisiniz!");
            }
            if (flag != null)
            {
                model.Flag = flag.InputStream.ToByteArray();
            }
            else {
                model.Flag = DatabaseContext.CountryRepository.Get(model.Country.Id).Flag;
            }
            if (ModelState.IsValid)
            {
                ExecuteResult result = null;
                if (model.Country.Id == 0)
                {
                    result = await DatabaseContext.CountryRepository.Save(model);
                }
                else
                {
                    result = await DatabaseContext.CountryRepository.Update(model);
                }
                if (result.Succeeded)
                {
                    this.AddSuccessMessage(result.ResultMessage);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("CustomError", result.ResultMessage);
                    ViewData["RegionList"] = DatabaseContext.RegionRepository.GetAll();
                    return View(model);
                }
            }
            else
            {
                ViewData["RegionList"] = DatabaseContext.RegionRepository.GetAll();
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            CountryVM model = DatabaseContext.CountryRepository.Get(id);
            return View(model.Country);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Country model)
        {
            ExecuteResult result = await DatabaseContext.CountryRepository.Delete(new CountryVM { Country = model });
            if (result.Succeeded)
            {
                this.AddSuccessMessage(result.ResultMessage);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddErrorMessage(result.ResultMessage);
                return RedirectToAction("Delete", new { id=model.Id });
            }
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