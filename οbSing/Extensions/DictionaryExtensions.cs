using System.Collections.Generic;
using System.Linq;

namespace obSing.Extensions
{
    /// <summary>
    /// Dictionary Extensions methods
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Concat two arrays
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> target)
        {
            if (target.IsNullOrEmpty())
                return;

            foreach (var t in target)
            {
                if (source.ContainsKey(t.Key)) continue;

                source.Add(t.Key, t.Value);
            }
        }

        /// <summary>
        /// Check if Dictionary is null or Empty
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) => dictionary is null || !dictionary.Any();
    }
}