using System;
using System.Collections.Generic;

namespace Simplement.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default;
        }
    }
}
