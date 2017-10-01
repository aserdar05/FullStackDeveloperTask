using FulStackDeveloperTask.App.Database;
using FulStackDeveloperTask.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Operation
{
    public class CountryOperation
    {
        public static List<Country> GetCountries()
        {
            using (DatabaseContext context = new DatabaseContext()) {
                return context.Country.ToList();
            }
        }
    }
}