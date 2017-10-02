using FullStackDeveloperTask.App.ViewModel;
using FullStackDeveloperTask.UI.Infrastructure;
using FulStackDeveloperTask.App.Models;
using FulStackDeveloperTask.App.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDeveloperTask.UI.Database.Repository
{
    public class BaseRepository
    {
        protected string GetApiController() {
            return this.GetType().Name;
        }

        protected T Get<T>(int id)
        {
            WebClient client = new WebClient();
            client.Headers["Accept"] = "application/json";
            string url = string.Format(AppConfig.ApiUrl + this.GetApiController() + "/Get/{0}", id);
            string jsonString = client.DownloadString(new Uri(url));
            T result = JsonConvert.DeserializeObject<T>(jsonString);
            return result;
        }

        protected List<T> GetAll<T>()
        {
            WebClient client = new WebClient();
            client.Headers["Accept"] = "application/json";
            string url = string.Format(AppConfig.ApiUrl + this.GetApiController() + "/GetAll");
            string jsonString = client.DownloadString(new Uri(url));
            List<T> result = JsonConvert.DeserializeObject<List<T>>(jsonString);
            return result;
        }

        public async Task<ExecuteResult> Save(UIModel model) {
            model.OperationType = OperationType.Save;
            return await Execute(model);
        }

        public async Task<ExecuteResult> Update(UIModel model)
        {
            model.OperationType = OperationType.Update;
            return await Execute(model);
        }

        public async Task<ExecuteResult> Delete(UIModel model)
        {
            model.OperationType = OperationType.Delete;
            return await Execute(model);
        }

        private async Task<ExecuteResult> Execute(UIModel model)
        {
            ExecuteResult result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppConfig.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                // HTTP POST
                string url = this.GetApiController() + "/Execute";
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ExecuteResult>(data);
                }
                else {
                    Context.Logger.Error("Execute çağrısı sırasında hata.Status code : " + response.StatusCode);
                    result = new ExecuteResult {
                        Succeeded = false,
                        ResultMessage = "Beklenmedik bir hata oluştu"
                    };
                }
            }
            return result;
        }

    }
}