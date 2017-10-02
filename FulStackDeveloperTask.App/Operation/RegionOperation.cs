using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FulStackDeveloperTask.App.Database;

namespace FulStackDeveloperTask.App.Operation
{
    public class RegionOperation : BaseOperation<Region>
    {
        public RegionOperation() : base(new CountryDbContext()) { }
    }
}