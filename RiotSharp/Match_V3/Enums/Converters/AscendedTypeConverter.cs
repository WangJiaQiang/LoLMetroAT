﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace RiotSharp.Match_V3.Enums.Converters
{
    class AscendedTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "CHAMPION_ASCENDED":
                    return AscendedType.ChampionAscended;
                case "CLEAR_ASCENDED":
                    return AscendedType.ClearAscended;
                case "MINION_ASCENDED":
                    return AscendedType.MinionAscended;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((AscendedType)value).ToCustomString());
        }
    }
}
