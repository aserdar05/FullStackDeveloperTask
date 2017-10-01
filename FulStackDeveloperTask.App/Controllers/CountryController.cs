using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Operation;
using System.Collections.Generic;
using System.Web.Http;

namespace FulStackDeveloperTask.App.Controllers
{
    public class CountryController : ApiController
    {
        public List<Country> GetCountries()
        {
            return CountryOperation.GetCountries();
        }
    }
}