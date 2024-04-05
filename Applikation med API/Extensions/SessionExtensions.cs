using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;

namespace Applikation_med_API.Extensions
{
    //public static class SessionExtensions
    //{
    //    public static void SetObjectAsJson(this ISession session, string key, object value)
    //    {
    //        session.SetString(key, JsonSerializer.Serialize(value));
    //    }

    //    public static T GetObjectFromJson<T>(this ISession session, string key)
    //    {
    //        var value = session.GetString(key);
    //        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    //    }
    //}
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

}
