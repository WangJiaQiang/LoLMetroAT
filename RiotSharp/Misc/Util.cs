﻿using System;
using System.Collections.Generic;
using RiotSharp.Match_V3.Enums;

namespace RiotSharp.Misc
{
    static class Util
    {
        public static DateTime ToDateTimeFromMilliSeconds(this long millis)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(millis);
            return dateTime;
        }

        public static long ToLong(this DateTime dateTime)
        {
            var span = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)span.TotalMilliseconds;
        }

        public static string BuildIdsString(List<int> ids)
        {
            string concatenatedIds = string.Empty;
            for (int i = 0; i < ids.Count - 1; i++)
            {
                concatenatedIds += ids[i] + ",";
            }
            return concatenatedIds + ids[ids.Count - 1];
        }
        public static string BuildIdsString(List<long> ids)
        {
            string concatenatedIds = string.Empty;
            for (int i = 0; i < ids.Count - 1; i++)
            {
                concatenatedIds += ids[i] + ",";
            }
            return concatenatedIds + ids[ids.Count - 1];
        }

        public static string BuildNamesString(List<string> names)
        {
            string concatenatedNames = string.Empty;
            for (int i = 0; i < names.Count - 1; i++)
            {
                concatenatedNames += Uri.EscapeDataString(names[i]) + ",";
            }
            return concatenatedNames + Uri.EscapeDataString(names[names.Count - 1]);
        }

        public static string BuildQueuesString(List<string> queues)
        {
            string concatenatedQueues = string.Empty;
            for (int i = 0; i < queues.Count - 1; i++)
            {
                concatenatedQueues += queues[i] + ",";
            }
            return concatenatedQueues + queues[queues.Count - 1];
        }
        public static string BuildSeasonString(List<Season> seasons)
        {
            string concatenatedQueues = string.Empty;
            for (int i = 0; i < seasons.Count - 1; i++)
            {
                concatenatedQueues += seasons[i].ToCustomString() + ",";
            }
            return concatenatedQueues + seasons[seasons.Count - 1].ToCustomString();
        }
    }
}
