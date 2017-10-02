using FullStackDeveloperTask.UI.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.UI.Database
{
    public class DatabaseContext
    {
        public static readonly CountryRepository CountryRepository = new CountryRepository();
        public static readonly RegionRepository RegionRepository = new RegionRepository();
    }
}