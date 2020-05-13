using Newtonsoft.Json;

namespace JogosAPI.Domain.Util
{
    public static class TranslateObject
    {
        public static string ToJsonString(this object data)
        {
            var jsonString = JsonConvert.SerializeObject(data);
            return jsonString;
        }
    }
}
