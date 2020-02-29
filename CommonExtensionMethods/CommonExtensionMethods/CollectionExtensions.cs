﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
 using System.Threading.Tasks;
using System.Xml;

namespace CommonExtensionMethods
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> collection, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new InvalidOperationException($"Page number must be higher than zero");
            if (pageSize <= 0)
                throw new InvalidOperationException("Page size must be higher than zero");

            return collection.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<T> TakePage<T>(this IEnumerable<T> collection, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new InvalidOperationException($"Page number must be higher than zero");
            if (pageSize <= 0)
                throw new InvalidOperationException("Page size must be higher than zero");

            return collection.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        [return: MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            var exists = dictionary.TryGetValue(key, out var result);
            return exists ? result : default;
        }

        [return: MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            var exists = dictionary.TryGetValue(key, out var result);
            return exists ? result : default;
        }

        public static void PushRange<T>(this Stack<T> source, IEnumerable<T> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            collection.ForEach(source.Push);
        }

        public static void EnqueueRange<T>(this Queue<T> source, IEnumerable<T> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            collection.ForEach(source.Enqueue);
        }

        public static List<T> InList<T>(this T item)
        {
            return new List<T>() {item};
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            foreach (var x in enumerable)
            {
                action(x);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            var tasks = new List<Task>();
            foreach (var x in enumerable)
            {
                tasks.Add(action(x));
            }

            await Task.WhenAll(tasks);
        }
    }

}
