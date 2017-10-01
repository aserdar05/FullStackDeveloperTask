using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Utils
{
    public class DataFeeder
    {
        public void FeedData() {
            string json = File.ReadAllText(@"C:\Users\SERDARAY\Desktop\STM\FullStackDeveloperTask\FulStackDeveloperTask.App\Utils\document_africa.json");
            JToken token = JToken.Parse(json);
            JArray men = (JArray)token.SelectToken("people[0].men");

        }
    }
}