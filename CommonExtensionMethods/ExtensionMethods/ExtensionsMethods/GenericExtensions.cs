﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace ExtensionMethods
{
    public static class GenericExtensions
    {
        [return:NotNullIfNotNull("input")]
        public static string? ToJson<T>(this T input)
        {
            return input != null ? JsonConvert.SerializeObject(input) : null;
        }
    }
}
