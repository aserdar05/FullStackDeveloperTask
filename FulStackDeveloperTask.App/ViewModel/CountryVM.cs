using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackDeveloperTask.App.ViewModel
{
    public class CountryVM : UIModel
    {
        public Country Country { get; set; }
        public byte[] Flag { get; set; }
    }
}