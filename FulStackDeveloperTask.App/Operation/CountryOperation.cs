using FulStackDeveloperTask.App.Database;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FulStackDeveloperTask.App.Utils;
using FullStackDeveloperTask.App.ViewModel;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace FulStackDeveloperTask.App.Operation
{
    public class CountryOperation : BaseOperation<Country>
    {

        public CountryOperation() : base(new CountryDbContext()) {}

        public CountryGridVM GetCountries(DataTableModel table)
        {
            CountryGridVM result = new CountryGridVM();
            using (CountryDbContext context = new CountryDbContext())
            {
                //5. büyük nüfusa sahip ülke alınıyor
                IQueryable<Country> countryQuery = context.CountryList.Include("Region");

                if (!string.IsNullOrEmpty(table.sSearch))
                {
                    string searchText = table.sSearch.ToLower();
                    countryQuery = countryQuery.Where(c => c.CapitalCity.Contains(searchText) || c.Name.Contains(searchText) ||
                        c.FullName.Contains(searchText) || c.Code.Contains(searchText) || c.Region.Name.Contains(searchText));
                }
                result.TotalCount = countryQuery.Count();
                if (!string.IsNullOrEmpty(table.SingleSortingColumn))
                    countryQuery = countryQuery.OrderByField(table.SingleSortingColumn, table.SingleSortDirection);
                else
                    countryQuery = countryQuery.OrderByDescending(m => m.Population);

                countryQuery = countryQuery.Skip(table.iDisplayStart).Take(table.iDisplayLength);

                result.CountryList = countryQuery.ToList();
                if (AppConfig.RenderFlagOnGrid){
                    result.CountryList.ForEach(c => c.Base64FlagData = Convert.ToBase64String(File.ReadAllBytes(AppConfig.FlagPath + string.Format(c.Flag, AppConfig.FlagResolution))));
                }
            }
            return result;
        }

        public long GetMinYellowPopulation()
        {
            using (CountryDbContext context = new CountryDbContext())
            {
                return context.CountryList.OrderByDescending(c => c.Population).Skip(AppConfig.YellowLineCount - 1).Take(1).Select(c => c.Population).FirstOrDefault();
            }
        }

        public string GetFlagName(int id)
        {
            string flagName = null;
            using (CountryDbContext context = new CountryDbContext())
            {
                flagName = context.CountryList.Where(c => c.Id == id).Select(c => c.Flag).FirstOrDefault();
            }
            return flagName;
        }

        //protected override ExecuteResult Update(CountryVM model) {

        //    using (CountryDbContext context = new CountryDbContext())
        //    {
        //        if (model.Country.Id == 0)
        //        {
        //            return new ExecuteResult {
        //                Succeeded = false,
        //                ResultMessage = "Ülke id bilgisi girilmedi"
        //            };
        //        }
        //        Country country = context.CountryList.Find(model.Country.Id);
        //        country = model.Country;
        //        context.Entry(country).State = EntityState.Modified;
        //        context.SaveChangesAsync();
        //    }
        //    return new ExecuteResult
        //    {
        //        Succeeded = true
        //    };
        //}

        //protected override ExecuteResult Delete(CountryVM model)
        //{

        //    using (CountryDbContext context = new CountryDbContext())
        //    {
        //        if (model.Country.Id == 0)
        //        {
        //            return new ExecuteResult
        //            {
        //                Succeeded = false,
        //                ResultMessage = "Ülke id bilgisi girilmedi"
        //            };
        //        }
        //        Country country = context.CountryList.Find(model.Country.Id);
        //        context.CountryList.Remove(country);
        //        context.SaveChangesAsync();
        //    }
        //    return new ExecuteResult
        //    {
        //        Succeeded = true
        //    };
        //}

        //protected override ExecuteResult Create(CountryVM model)
        //{

        //    using (CountryDbContext context = new CountryDbContext())
        //    {
        //        if (model.Country.Id == 0)
        //        {
        //            return new ExecuteResult
        //            {
        //                Succeeded = false,
        //                ResultMessage = "Ülke id bilgisi girilmedi"
        //            };
        //        }
        //        context.CountryList.Add(model.Country);
        //        context.SaveChangesAsync();
        //    }
        //    return new ExecuteResult
        //    {
        //        Succeeded = true
        //    };
        //}

    }
}