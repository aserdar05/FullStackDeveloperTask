using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace FullStackDeveloperTask.UI.Database.Repository
{
    public class CountryRepository : BaseRepository
    {
        public CountryGridVM GetCountryList(DataTableModel model) {
            WebClient client = new WebClient();
            client.Headers["Accept"] = "application/json";
            string url = string.Format(base.ApiUrl + "Country/GetCountries?iColumns={0}&iDisplayLength={1}&iDisplayStart={2}&iSortingCols={3}&sColumns={4}" +
                "&sEcho={5}&SingleSortDirection={6}&SingleSortingColumn={7}&,sSearch={8}", model.iColumns, model.iDisplayLength, model.iDisplayStart,
                 model.iSortingCols, model.sColumns, model.sEcho, model.SingleSortDirection, model.SingleSortingColumn, model.sSearch);
            string returnedString = client.DownloadString(new Uri(url));
            CountryGridVM vm = JsonConvert.DeserializeObject<CountryGridVM>(returnedString);
            return vm;
        }
    }
}