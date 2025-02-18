using Newtonsoft.Json;

namespace MVCNetCoreSession.Helpers
{
    public class HelperJsonSession
    {
        public static string SerializeObject<T>(T data)
        {
            string objeto = JsonConvert.SerializeObject(data);
            return objeto;
        }

        public static T DeserializeObject<T>(string data)
        {
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}
