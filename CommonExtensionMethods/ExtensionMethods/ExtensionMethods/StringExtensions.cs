﻿using System;
using System.Globalization;
using Newtonsoft.Json;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static T FromJson<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static string CapitalizeFirstLetter(this string input)
        {
            if (input.IsEmpty())
            {
                return input;
            }
            return input;
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsEmpty(this string input)
        {
            if(input == null) throw new ArgumentNullException(nameof(input));
            return string.IsNullOrEmpty(input);
        }

        public static DateTimeOffset ToDateTime(this string input)
        {
            if(input == null) throw new ArgumentNullException(nameof(input));
            return DateTimeOffset.Parse(input, new CultureInfo("cs-CZ"));
        }

        public static DateTimeOffset ToDateTime(this string input, CultureInfo cultureInfo)
        {
            if(input == null) throw new ArgumentNullException(nameof(input));
            return DateTimeOffset.Parse(input, cultureInfo);
        }
        public static bool TryToDateTime(this string input, CultureInfo cultureInfo, out DateTimeOffset result)
        {
            return DateTimeOffset.TryParse(input, cultureInfo, DateTimeStyles.None, out result);
        }

        public static bool TryToDateTime(this string input, out DateTimeOffset result)
        {
            return DateTimeOffset.TryParse(input,new CultureInfo("cs-CZ"), DateTimeStyles.None, out result);
        }

        #region numericOperations
        public static bool IsNumeric(this string input)
        {
            return decimal.TryParse(input, out _);
        }

        public static decimal ToDecimal(this string input)
        {
            return decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static int ToInt(this string input)
        {
            return int.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static long ToLong(this string input)
        {
            return long.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static double ToDouble(this string input)
        {
            return double.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static float ToFloat(this string input)
        {
            return float.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static bool TryToDecimal(this string input, out decimal result)
        {
            return decimal.TryParse(input, out result);
        }

        public static bool TryToInt(this string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public static bool TryToLong(this string input, out long result)
        {
            return long.TryParse(input, out result);
        }

        public static bool TryToDouble(this string input, out double result)
        {
            return double.TryParse(input, out result);
        }

        public static bool TryToFloat(this string input, out float result)
        {
            return float.TryParse(input, out result);
        }
        #endregion
    }
}
