
using FullStackDeveloperTask.UI.Database;
using FullStackDeveloperTask.UI.Models;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public ActionResult GetCountries(DataTableModel model) {
            List<Country> countryList = DatabaseContext.CountryRepository.GetCountryList();
            return Json(new
            {
                iTotalRecords = 97,
                iTotalDisplayRecords = 3,
                aaData = countryList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}