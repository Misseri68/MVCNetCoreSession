using MVCNetCoreSession.Helpers;
using Newtonsoft.Json;
namespace MVCNetCoreSession.Extensions
{
    public static class SessionExtension  
    {
        public static T GetObject<T> (this ISession session, string key)
        {
            string json = session.GetString(key);

            if (json != null)
            {
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            else
            {
                return default(T);
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }


    }


}
