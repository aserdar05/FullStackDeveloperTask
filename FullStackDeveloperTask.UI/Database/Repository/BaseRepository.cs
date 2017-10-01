using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FullStackDeveloperTask.UI.Database.Repository
{
    public class BaseRepository
    {
        protected readonly string ApiUrl = "http://localhost/FulStackDeveloperTask.App/Api/";

        protected virtual string GetApiControllerName() {
            return this.GetType().Name;

        }

        public async Task<ExecuteResult> Save(UIModel model) {
            return await Execute(model, ExecuteType.Save);
        }

        public async Task<ExecuteResult> Update(UIModel model)
        {
            return await Execute(model, ExecuteType.Update);
        }

        public async Task<ExecuteResult> Delete(UIModel model)
        {
            return await Execute(model, ExecuteType.Delete);
        }

        private async Task<ExecuteResult> Execute(UIModel model, ExecuteType executeType)
        {
            ExecuteResult result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(model));
                // HTTP POST
                HttpResponseMessage response = await client.PostAsync(this.GetApiControllerName() + "/" + executeType.ToString(), content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ExecuteResult>(data);
                }
            }
            return result;
        }

    }
}