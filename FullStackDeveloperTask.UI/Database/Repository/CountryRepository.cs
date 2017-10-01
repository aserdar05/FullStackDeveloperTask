using FulStackDeveloperTask.App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace FullStackDeveloperTask.UI.Database.Repository
{
    public class CountryRepository : BaseRepository
    {
        public List<Country> GetCountryList() {
            WebClient client = new WebClient();
            client.Headers["Accept"] = "application/json";
            string returnedString = client.DownloadString(new Uri(base.ApiUrl + "Country/GetCountries"));
            List<Country> countryList = JsonConvert.DeserializeObject<List<Country>>(returnedString);
            return countryList;
        }
    }
}