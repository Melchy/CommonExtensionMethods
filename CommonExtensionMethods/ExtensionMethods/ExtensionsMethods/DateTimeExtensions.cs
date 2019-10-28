﻿using System;
 
 namespace ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static bool Between(this DateTimeOffset inputDate, DateTimeOffset rangeStart, DateTimeOffset rangeEnd)
        {
            return inputDate.Ticks >= rangeStart.Ticks && inputDate.Ticks <= rangeEnd.Ticks;
        }

        public static DateTimeOffset Tomorrow(this DateTimeOffset datetime)
        {
            return datetime.AddDays(1);
        }
        public static DateTimeOffset Yesterday(this DateTimeOffset datetime)
        {
            return datetime.AddDays(-1);
        }

        /// <summary>
        /// Returns a DateTime with its value set to Now minus the provided TimeSpan value.
        /// </summary>
        /// <example>
        /// 10.Seconds().AgoUtc()
        /// </example>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset AgoUtc(this TimeSpan value)
        {
            return Clock.UtcNow.Subtract(value);
        }

        /// <summary>
        /// Returns a DateTime with its value set to Now plus the provided TimeSpan value.
        /// </summary>
        /// <example>
        /// 10.Seconds().FromNowUtc()
        /// </example>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset FromNowUtc(this TimeSpan value)
        {
            return Clock.UtcNow.Add(value);
        }
    }
}
