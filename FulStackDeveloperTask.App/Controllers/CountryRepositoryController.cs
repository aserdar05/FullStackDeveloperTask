using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.Operation;
using FulStackDeveloperTask.App.Utils;
using FulStackDeveloperTask.App.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace FulStackDeveloperTask.App.Controllers
{
    public class CountryRepositoryController : ApiController
    {
        public CountryGridVM GetCountries([FromUri]DataTableModel model)
        {
            using (CountryOperation operation = new CountryOperation())
            {
                return operation.GetCountries(model);
            }
        }

        public long GetMinYellowPopulation() {
            using (CountryOperation operation = new CountryOperation())
            {
                return operation.GetMinYellowPopulation();
            }
        }

        public CountryVM Get(int id) {
            CountryVM model = null;
            using (CountryOperation operation = new CountryOperation())
            {
                model = new CountryVM
                {
                    Country = operation.Get(id)
                };
            }
            try
            {
                model.Flag = File.ReadAllBytes(AppConfig.FlagPath + string.Format(model.Country.Flag, AppConfig.FlagResolution));
            }
            catch (DirectoryNotFoundException e)
            {
                Log4NetManager.Error("Bayrak klasörü bulunamadı", e);
            }
            catch (FileNotFoundException e)
            {
                Log4NetManager.Error("Bayrak dosyası bulunamadı", e);
            }
            return model;
        }

        [HttpPost]
        public ExecuteResult Execute([FromBody]CountryVM model)
        {
            try
            {
                using (CountryOperation operation = new CountryOperation())
                {
                    switch (model.OperationType)
                    {
                        case OperationType.Save:
                            string flagName = model.Country.Code + "-{0}.png";
                            model.Country.Flag = flagName;
                            operation.Save(model.Country);

                            File.WriteAllBytes(AppConfig.FlagPath + string.Format(flagName, AppConfig.FlagResolution), model.Flag);
                            break;
                        case OperationType.Update:
                            model.Country.Flag = operation.GetFlagName(model.Country.Id);
                            operation.Update(model.Country);
                            File.WriteAllBytes(AppConfig.FlagPath + string.Format(model.Country.Code + "-{0}.png", AppConfig.FlagResolution), model.Flag);
                            break;
                        case OperationType.Delete:
                            operation.Delete(model.Country);
                            break;
                    }
                    return new ExecuteResult
                    {
                        Succeeded = true,
                        ResultMessage = "İşleminiz gerçekleştirilmiştir."
                    };
                }
            }
            catch (System.Exception ex)
            {
                Log4NetManager.Error("İşlem sırasında hata alındı.", ex);
                return new ExecuteResult
                {
                    Succeeded = false,
                    ResultMessage = "Beklenmedik bir hata oluştu."
                };
            }
        }
    }
}