﻿using System;
using System.Reflection;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Misc.Converters
{
    class DateTimeConverterFromLong : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if(token.Value<long?>() != null)
            {
                return new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(token.Value<long>()).ToLocalTime();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((DateTime)value).ToLong());
        }
    }
}
