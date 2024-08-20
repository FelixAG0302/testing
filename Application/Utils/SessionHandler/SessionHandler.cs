using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace testing.Application.Utils.SessionHandler
{
    public static class SessionHandler
    {
        public static void Set<Value>(this ISession session, Value value, string Key)
        {
            string ValueToBeSave = JsonConvert.SerializeObject(value);
            session.SetString(Key, ValueToBeSave);
        }
        public static Value Get<Value>(this ISession session, string key)
        {
            string value = session.GetString(key);
            Value returnValue = value is null ? default : JsonConvert.DeserializeObject<Value>(value);
            return returnValue;
        }
    }
}
