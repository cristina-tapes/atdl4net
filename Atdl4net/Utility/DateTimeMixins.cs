
using System;

namespace Atdl4net.Utility
{
    public static class DateTimeMixins
    {
        public static DateTime SetCurrentTime(this DateTime dateTime)
        {
            dateTime =
                dateTime.Subtract(new TimeSpan(0, dateTime.Hour, dateTime.Minute,
                    dateTime.Second));

            dateTime =
                dateTime.Add(new TimeSpan(0, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));

            return dateTime;
        }
    }
}
