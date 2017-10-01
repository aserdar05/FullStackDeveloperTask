using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Model;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.Operation;
using FulStackDeveloperTask.App.ViewModel;
using System.Collections.Generic;
using System.Web.Http;

namespace FulStackDeveloperTask.App.Controllers
{
    public class CountryController : ApiController
    {
        public CountryGridVM GetCountries([FromUri]DataTableModel model)
        {
            using (CountryOperation operation = new CountryOperation())
            {
                return operation.GetCountries(model);
            }
        }

        public CountryVM Get(int id) {
            using (CountryOperation operation = new CountryOperation())
            {
                CountryVM model = new CountryVM
                {
                    Country = operation.Get(id)
                };
                return model;
            }
        }

        [HttpPost]
        public ExecuteResult Execute([FromBody]CountryVM model)
        {
            using (CountryOperation operation = new CountryOperation())
            {
                switch (model.OperationType)
                {
                    case OperationType.Save:
                        operation.Save(model.Country);
                        break;
                    case OperationType.Update:
                        operation.Update(model.Country);
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
    }
}