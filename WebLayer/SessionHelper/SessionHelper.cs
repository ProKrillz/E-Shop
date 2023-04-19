﻿using System.Text;
using Newtonsoft.Json;

namespace WebLayer.SessionHelper
{
    public static class SessionHelper
    {
        public static void SetSessionString(this ISession session, string value, string key)
        => session.Set(key, Encoding.UTF8.GetBytes(value));
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
