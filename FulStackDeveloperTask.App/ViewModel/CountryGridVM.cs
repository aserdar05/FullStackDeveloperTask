using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.ViewModel
{
    public class GridVM
    {
        public int TotalCount { get; set; }
    }


    public class CountryGridVM : GridVM
    {
        public List<Country> CountryList { get; set; }
    }
}