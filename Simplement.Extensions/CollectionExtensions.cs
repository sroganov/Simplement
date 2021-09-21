using System;
using System.Collections.Generic;

namespace Simplement.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Iterates enumerable and performs action on each element.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Returns value by key or default.
        /// </summary>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default;
        }

        /// <summary>
        /// Splits enumerable into batches of given size.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
        {
            using var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
                yield return YieldBatchElements(enumerator, batchSize - 1);
        }
        private static IEnumerable<T> YieldBatchElements<T>(IEnumerator<T> source, int batchSize)
        {
            yield return source.Current;

            for (var i = 0; i < batchSize && source.MoveNext(); i++)
                yield return source.Current;
        }
    }
}
