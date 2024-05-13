using Newtonsoft.Json;

namespace HalfBite.Scripts.Storage.StorageSerializers
{
    public class JsonSerializer : ISerializer
    {
        public string ObjectToString(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public T StringToObject<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}