﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static void PushRange<T>(this Stack<T> source, IEnumerable<T> collection)
        {
            if(source == null) throw new ArgumentNullException(nameof(source));
            collection.ForEach(source.Push);
        }

        public static void EnqueueRange<T>(this Queue<T> source, IEnumerable<T> collection)
        {
            if(source == null) throw new ArgumentNullException(nameof(source));
            collection.ForEach(source.Enqueue);
        }

        public static List<T> InList<T>(this T item)
        {
            return new List<T>(){item};
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if(enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            foreach (var x in enumerable)
            {
                action(x);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if(enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            var tasks = new List<Task>();
            foreach (var x in enumerable)
            {
                tasks.Add(action(x));
            }
            await Task.WhenAll(tasks);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
        
        [return:MaybeNull]
        public static TValue GetOrDefault<TKey,TValue>(this IDictionary<TKey,TValue> source, [NotNull] TKey key)
        {
            var exists = source.TryGetValue(key, out var value);
            return exists ? value : default(TValue)!;
        }
        
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> source, [NotNull]TKey key)
        {
            return source[key];
        }

        public static bool TryGet<TKey, TValue>(this IDictionary<TKey, TValue> source, [NotNull] TKey key, out TValue result)
        {
            return source.TryGetValue(key, out result);
        }
    }
}
