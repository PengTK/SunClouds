using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunClouds.Model
{
    internal class TimeConverter
    {
        public static DateTime UnixToUtc(int unixTime, int timezoneOffset)
        {
            DateTime utcDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
            utcDateTime = utcDateTime.AddSeconds(timezoneOffset);
            return utcDateTime;
        }
    }
}
