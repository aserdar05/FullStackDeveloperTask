using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Utils
{
    public class JsonConverterUtil
    {
        JsonSerializerSettings serializerSettings;

        public JsonConverterUtil()
        {
            serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
            serializerSettings.NullValueHandling = NullValueHandling.Include;
            serializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            serializerSettings.TypeNameHandling = TypeNameHandling.All;
            serializerSettings.Formatting = Formatting.None;
            //serializerSettings.Binder = EsbSerializationBinder.Instance;
            serializerSettings.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
        }

        /// <summary>
        /// Gönderilen nesneyi JSON formatında stringe serialize eder
        /// </summary>
        /// <param name="obj">orjinal nesne</param>
        /// <returns>JSON formatında string</returns>
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }

        /// <summary>
        /// Gönderilen JSON metnini orjinal nesneye çevirir
        /// </summary>
        /// <typeparam name="T">Çevrilecek tür</typeparam>
        /// <param name="json">JSON formatında string</param>
        /// <returns>orjinal nesne</returns>
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, serializerSettings);
        }

        /// <summary>
        /// Gönderilen JSON metnini dynamic türünde nesneye çevirir
        /// </summary>
        /// <param name="json">JSON formatında string</param>
        /// <returns>dynamic türünde nesne</returns>
        public dynamic DeserializeToDynamic(string json)
        {
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        /// <summary>
        /// Gönderilen JSON metnini object türünde nesneye çevirir
        /// </summary>
        /// <param name="json">JSON formatında string</param>
        /// <returns>object türünde nesne</returns>
        public object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject(json, serializerSettings);
        }

        /// <summary>
        /// Gönderilen JSON metnini belirtilen türde nesneye çevirir
        /// </summary>
        /// <param name="json">JSON formatında string</param>
        /// <param name="type">Çevrilecek tür</param>
        /// <returns>Type türünde nesne</returns>
        public object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, serializerSettings);
        }
    }
}