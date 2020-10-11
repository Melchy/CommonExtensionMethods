 using System;
 using System.Diagnostics.CodeAnalysis;
 using System.Globalization;
 using System.Text;

 namespace CommonExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static string RemovePrefixIfExists(this string input, string prefix)
        {
            return input.StartsWith(prefix, StringComparison.InvariantCulture)
                ? input.Substring(prefix.Length, input.Length - prefix.Length)
                : input;
        }
        
        
        public static string RemoveSuffixIfExists(this string input, string suffix)
        {
            return input.EndsWith(suffix, StringComparison.InvariantCulture)
                ? input.Substring(0, input.Length - suffix.Length)
                : input;
        }

        public static string CapitalizeFirstLetter(this string input)
        {
            if (input.IsEmpty())
            {
                return input;
            }

            return char.ToUpperInvariant(input[0]) + input[1..];
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsEmpty(this string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return string.IsNullOrEmpty(input);
        }

        public static byte[] ToUtf8ByteArray(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        public static DateTimeOffset ToDateTime(this string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return DateTimeOffset.Parse(input, CultureInfo.InvariantCulture);
        }

        public static DateTimeOffset ToDateTime(this string input, CultureInfo cultureInfo)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return DateTimeOffset.Parse(input, cultureInfo);
        }

        public static bool TryToDateTime(this string input, CultureInfo cultureInfo, out DateTimeOffset result)
        {
            return DateTimeOffset.TryParse(input, cultureInfo, DateTimeStyles.None, out result);
        }

        public static bool TryToDateTime(this string input, out DateTimeOffset result)
        {
            return DateTimeOffset.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

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
    }
}
