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
            return CountryOperation.Instance.GetCountries(model);
        }

        public ExecuteResult Execute(UIModel model)
        {
            CountryOperation operation = CountryOperation.Instance;
            CountryVM vm = model as CountryVM;
            switch (model.OperationType)
            {
                case OperationType.Save:
                    return operation.Save<Country>(vm.Country);
                case OperationType.Update:
                    return operation.Update<Country>(vm.Country);
                case OperationType.Delete:
                    return operation.Delete<Country>(vm.Country);
                default:
                    return new ExecuteResult
                    {
                        Succeeded = false,
                        ResultMessage = "İşlem tipi hatalı"
                    };
            }
        }
    }
}